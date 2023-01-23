using AutoMapper;
using GMS.Identity.Client.Models;
using GMS.Identity.Core.Abstractions.Repositories;
using GMS.Identity.Core.Domain.Administration;
using GMS.Identity.DataAccess.Context;
using GMS.Identity.DataAccess.Utils;
using Microsoft.EntityFrameworkCore;

namespace GMS.Identity.DataAccess.Repositories

{
    public class UserRepository:IUserRepository
    {
        private readonly IdentityContext _context;    
        private readonly IMapper _mapper;
    
        public UserRepository(IdentityContext context, IMapper mapper)    
        {       
            _context = context;
            _mapper = mapper;
        }
            
        public async Task<UserApiModel?> GetUser(Guid id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u=>u.Id==id);
            if (entity != null)
            {
               return _mapper.Map<UserApiModel>(entity);
            } 
            return null;
        }

        public async Task<List<UserApiModel>> GetUsers()
        {
            var entities = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserApiModel>>(entities);
        }

        public async Task<UserApiModel> CreateAsync(UserCreateApiModel createApiModel)
        {
            User user = _mapper.Map<User>(createApiModel);
            var userSaltAndPassword=UserHelper.GetSaltAndPassword(createApiModel.Password);
            user.Salt = userSaltAndPassword.salt;
            user.PasswordHash = userSaltAndPassword.pass;
            user.Role = "User";
            user.IsActive= true;
            await _context.Users.AddAsync(user);
            await this._context.SaveChangesAsync();

            return _mapper.Map<UserApiModel>(user);
        }
               

        public async Task<bool> PatchAsync(Guid id, UserPatchApiModel user)
        {
            User currentUser = await _context.Users.FindAsync(id);
            
            if (currentUser == null)
            {
                return false;
            }
            else
            {
                currentUser.UserName = user.UserName;
                currentUser.TelegramUserName = user.TelegramUserName;
                currentUser.Email= user.Email;
                currentUser.IsActive= user.IsActive;
                var userSaltAndPassword = UserHelper.GetSaltAndPassword(user.Password);
                currentUser.Salt = userSaltAndPassword.salt;
                currentUser.PasswordHash = userSaltAndPassword.pass;
                await this._context.SaveChangesAsync();
                return true;    
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await this._context.Users.FindAsync(id);
            if (user == null)
                return false;
            else
            {
                //_context.Users.Remove(user);
                user.IsActive = false;
                await this._context.SaveChangesAsync();
                return true;
            }
        }


        public async Task<UserJwtTokenModel?> AuthorizeUser(UserAuthorizeApiModel user)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(a => a.UserName == user.UserName);

            if (entity != null && (UserHelper.GetHashedPassword(entity.Salt, user.Password) == entity.PasswordHash))
            {
                return _mapper.Map<UserJwtTokenModel>(entity);
            }
            return null;
        }

    }
}
