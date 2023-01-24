using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GMS.Identity.WebHost.Infrastructure;

public interface IAuthOptions
{
    string Issuer { get; set; } 
    string Audience { get; set; }   
    string Key { get; set; }
    int LifeTime { get; set; }  
    SymmetricSecurityKey GetSymmetricSecurityKey();
    
}
