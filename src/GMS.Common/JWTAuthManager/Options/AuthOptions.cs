using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthManager.Options;

public class AuthOptions
{
    public const string Position = "Authorization:AditionalOptions";
    /// <summary>
    /// Издатель токена
    /// </summary>
    public string Issuer { get; set; }
    /// <summary>
    /// Потребитель токена
    /// </summary>
    public string Audience { get; set; }
    /// <summary>
    /// Ключ для шифрации
    /// </summary>
    public string Key { get; set; }
    /// <summary>
    /// время жизни токена в минутах
    /// </summary>
    public int LifeTime { get; set; }

    /// <summary>
    /// Инициализировать новый экземпляр класса SymmetricSecurityKey.
    /// </summary>
    /// <returns>SymmetricSecurityKey</returns>
    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}

