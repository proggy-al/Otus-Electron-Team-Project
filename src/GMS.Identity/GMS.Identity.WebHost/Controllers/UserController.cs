using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using GMS.Identity.Core.Abstractions.Repositories;
using GMS.Identity.WebHost.Infrastructure;
using GMS.Identity.Client;
using GMS.Identity.Client.Models;
using JWTAuthManager;
using FluentValidation;
using FluentValidation.Results;
using JWTAuthManager.Options;

namespace GMS.Identity.WebHost.Controllers;

[EnableCors("_myAllowSpecificOrigins")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserRepository _userRepository;
    private readonly AuthOptions _authOptions;
    private readonly IValidator _validator;

    public UserController(IUserRepository userRepository, AuthOptions authOptions, IValidator<UserCreateApiModel> validator)
    {
        _userRepository = userRepository;
        _authOptions = authOptions; 
        _validator = validator;
    }

    /// <summary>
    /// Get user by ID, should be authorize as Admin or System
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [RequirePrivelege(Priviliges.Administrator, Priviliges.System)]
    [HttpGet(IdentityRouting.GetUser)]
    public async Task<UserApiModel?> GetUser([FromRoute] Guid id)
    {
        return await _userRepository.GetUser(id);
    }

    /// <summary>
    /// Get all users , should be authorize as Admin or System
    /// </summary>
    /// <returns></returns>
    [RequirePrivelege(Priviliges.Administrator, Priviliges.System)]
    [HttpGet(IdentityRouting.GetAllUsers)]
    public async Task<List<UserApiModel>> GetAllUsers()
    {
        //так мы получаем ID авторизованного юзера
            var id= User.Claims.FirstOrDefault(a => a.Type == "ID").Value;

        var res= await _userRepository.GetUsers();
        Response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");
        Response.Headers.Add("X-Total-Count", res.Count.ToString());
        return res;
    }

    /// <summary>
    /// Create user, should be authorize as Admin or System
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [RequirePrivelege(Priviliges.Administrator, Priviliges.System)]
    [HttpPost(IdentityRouting.CreateUser)]
    public async Task<ActionResult<UserApiModel>>CreateUser([FromBody] UserCreateApiModel user)
    {
        var validationContext = new ValidationContext<UserCreateApiModel>(user);
        ValidationResult validationResult = await _validator.ValidateAsync(validationContext);

        if (!validationResult.IsValid) { return BadRequest(validationResult.Errors.Aggregate("Validation error: ", (a, b) => $"{a} {b};")); }

        try
        {
            var res = await _userRepository.CreateAsync(user);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }

    /// <summary>
    /// Update user, should be authorize as Admin or System
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    [RequirePrivelege(Priviliges.Administrator, Priviliges.System)]
    [HttpPut(IdentityRouting.PatchUser)]
    public async Task<ActionResult<bool>> PatchUser([FromRoute] Guid id, [FromBody] UserPatchApiModel user)
    {
        
        try
        {
            var task = await _userRepository.PatchAsync(id, user);
            return Ok(task);
        }
        catch (ArgumentException exx)
        {
            return NotFound(exx.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Delete user, should be authorize as Admin or System
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [RequirePrivelege(Priviliges.Administrator, Priviliges.System)]
    [HttpDelete(IdentityRouting.DeleteUser)]
    public async Task<ActionResult<bool>> DeleteUser([FromRoute] Guid id)
    {
        try
        {
            var res = await _userRepository.DeleteAsync(id);
            return Ok(true);
        }
        catch (ArgumentException exx)
        {
            return NotFound(exx.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Athorize user, without any restriction
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost(IdentityRouting.GetToken)]
    public async Task<ActionResult<string>> Token([FromBody] UserAuthorizeApiModel user)
    {
        var identity =await GetIdentity(user);
        if (identity == null)
        {
            return BadRequest(new { errorText = "Invalid username or password." });
        }

        var encodedJwt = TokenProducer.GetJWTToken(identity.Claims, _authOptions);

        var response = new
        {
            token = encodedJwt,
            username = identity.Name
        };

        return Ok(response);
    }

    private async Task<ClaimsIdentity> GetIdentity(UserAuthorizeApiModel user)
    {
        var person = await _userRepository.AuthorizeUser(user);
        if (person != null)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role),
                    new Claim("ID", person.Id.ToString()),
                    new Claim("NameTelegram", person.TelegramUserName.ToString()),                  
                    new Claim("Role", person.Role),
                    new Claim("EMail",person.Email)
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        // если пользователя не найдено
        return null;
    }

}
