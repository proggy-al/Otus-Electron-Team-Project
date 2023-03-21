using AutoMapper;
using GMS.Identity.Client.Models;
using GMS.Identity.DataAccess.Context;
using JWTAuthManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.DataAccess.Repositories
{
    public class CoachRepository : UserRepository
    {
        public CoachRepository(IdentityContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<UserApiModel?> GetCoach(Guid id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && (u.Role == Priviliges.Coach.ToString() || u.Role == Priviliges.ChiefCoach.ToString())); 
            if (entity != null)
            {
                return _mapper.Map<UserApiModel>(entity);
            }
            return null;
        }

        public async Task<List<UserApiModel>> GetCoaches()
        {
            var entities = await _context.Users.Where(u=> u.Role == Priviliges.Coach.ToString() || u.Role == Priviliges.ChiefCoach.ToString()).ToListAsync();
            return _mapper.Map<List<UserApiModel>>(entities);
        }
    }
}
