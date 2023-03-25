using GMS.Communication.Core;
using GMS.Communication.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace GMS.Communication.DataAccess.Context
{
    public class GmsMessagesDb : DbContext
    {
        DbSet<GmsMessage>  Messages {get;set;}

        public GmsMessagesDb(DbContextOptions<GmsMessagesDb> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GmsMessage>()
                .Property(s => s.SenderId)
                .IsRequired();
            modelBuilder.Entity<GmsMessage>()
                .Property(s => s.RecipientId)
                .IsRequired();
            modelBuilder.Entity<GmsMessage>()
                .Property(s => s.Subject)
                .HasMaxLength(200)
                .IsRequired();
            modelBuilder.Entity<GmsMessage>()
                .Property(s => s.Body)
                .HasMaxLength(800)
                .IsRequired();
            modelBuilder.Entity<GmsMessage>()
                .Property(s => s.Subject)
                .IsRequired();
            modelBuilder.Entity<GmsMessage>()
                .Property(s => s.Type)
                .HasDefaultValue(MessageType.Text)
                .IsRequired();
            modelBuilder.Entity<GmsMessage>()
                .Property(s => s.Status)
                .HasDefaultValue(MessageStatus.none)
                .IsRequired();
        }
    }
}