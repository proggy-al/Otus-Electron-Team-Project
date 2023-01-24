using GMS.Communication.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Communication.DataAccess.Context
{
    public class MesseageDb
    {
        DbSet<GmsMessage>  GmsMesseage {get;set;}
    }
}