using Microsoft.AspNetCore.Authorization;

namespace JWTAuthManager;

/// <summary>
///  Привилегии доступные для назначения пользователю, если нужно добавить - добавляем сюда
///  В базу данных пишем в поле Role соответствующую роль в текстовом формате
/// </summary>
[Flags]
public enum Priviliges
{
    System=0,
    Administrator=1,
    User,
    Spectrator,
    GYMOwner,
    Coach,
    Manager,
    Member,
    GymDoctor,
    ChiefCoach
}

/// <summary>
/// Атрибут позволяющий разграничить доступ по нескольким ролям, агрегатор атрибута Authorize
/// </summary>
[AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true)]
public class RequirePrivelegeAttribute: AuthorizeAttribute
{
    public RequirePrivelegeAttribute(params Priviliges[] priviliges) 
    {
        Roles = String.Join(",",priviliges);
    }

}
