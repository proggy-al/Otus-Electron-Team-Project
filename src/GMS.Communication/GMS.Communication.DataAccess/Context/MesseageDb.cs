using GMS.Communication.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace GMS.Communication.DataAccess.Context
{
    public class MesseageDb
    {
        DbSet<ChatMessage>  GmsMesseage {get;set;}

        public MesseageDb()
        {
            
        }
    }
}