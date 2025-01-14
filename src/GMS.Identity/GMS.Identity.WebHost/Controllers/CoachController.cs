﻿using GMS.Identity.Client.Models;
using GMS.Identity.Client;
using GMS.Identity.Core.Abstractions.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Authorization;
using GMS.Identity.DataAccess.Repositories;

namespace GMS.Identity.WebHost.Controllers;

[EnableCors("_myAllowSpecificOrigins")]
[ApiController]
public class CoachController: ControllerBase
{
    private readonly ICoachRepository _userRepository;

    public CoachController(ICoachRepository userRepository)
    {
        _userRepository = userRepository ;
    }

    /// <summary>
    /// Get user by ID, should be authorize
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet(IdentityRouting.GetCoach)]
    public async Task<ActionResult<UserApiModel?>> GetCoach([FromRoute] Guid id)
    {
        var res = await _userRepository.GetCoach(id);
        return  res==null||res.UserName==null?NotFound(): Ok(res);
    }

    /// <summary>
    /// Get all users , should be authorize 
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpGet(IdentityRouting.GetAllCoaches)]
    public async Task<List<UserApiModel>> GetAllCoaches()
    {
        var res = await _userRepository.GetCoaches();
        Response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");
        Response.Headers.Add("X-Total-Count", res.Count.ToString());
        return res;
    }

    /// <summary>
    /// Get list coaches
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet(IdentityRouting.GetListCoaches)]
    public async Task<List<UserApiShortModel>> GetCoaches([FromQuery] List<Guid> ids)
    {
        return await _userRepository.GetListCoaches(ids);
    }
}
