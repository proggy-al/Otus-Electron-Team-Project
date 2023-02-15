using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;
using System.ComponentModel;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class FitnessClubConfiguration : IEntityTypeConfiguration<FitnessClub>
    {
        public void Configure(EntityTypeBuilder<FitnessClub> builder)
        {
            builder.HasMany(f => f.Products)
                   .WithOne(p => p.FitnessClub)
                   .IsRequired();
            builder.HasMany(f => f.Areas)
                   .WithOne(p => p.FitnessClub)
                   .IsRequired();
            builder.HasMany(f => f.Contracts)
                   .WithOne(p => p.FitnessClub)
                   .IsRequired();
            builder.HasMany(f => f.TimeSlots)
                   .WithOne(p => p.FitnessClub)
                   .IsRequired();

            builder.Property(p => p.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")
                   .IsRequired();
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasColumnType("character varying(64)")
                   .IsUnicode(false);
            builder.Property(p => p.Description)
                   .IsRequired(false)
                   .HasColumnType("character varying(4096)")
                   .IsUnicode(false);
            builder.Property(p => p.Address)
                   .IsRequired(false)
                   .HasColumnType("character varying(256)")
                   .IsUnicode(false);
            builder.Property(p => p.OwnerId)
                   .IsRequired();

            builder.HasIndex(p => p.Name)
                   .IsUnique();


            var goldsGym = new FitnessClub()
            {
                Id = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                Name = "Gold's Gym Venice",
                Description = "Gold’s Gym Venice gives you access to everything you need reach your fitness goals:" +
                " all outdoor workout spaces, weight and strength training areas, a wide selection of free weights, " +
                "cardio equipment, resistance machines – plus a team of certified Personal Trainers ready to support " +
                "and motivate you to become the strongest version of yourself. From our beginning as a small " +
                "bodybuilding gym in 1965 to today, Gold’s Gym delivers a dynamic fitness experience focused on " +
                "strength and performance. View our local gym membership options and join Gold’s Gym Venice now.",
                Address = "360 Hampton Dr, Venice, CA 90291, USA",
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001")    //Joe Gold 
            };

            var almaz = new FitnessClub()
            {
                Id = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                Name = "Атлетический клуб Алмаз",
                Description = "Атлетический клуб «Алмаз» является одним из самых известных клубов Санкт-Петербурга " +
                "и России, развивающих фитнес и бодибилдинг. За более чем 25 летнею историю развития, клуб накопил " +
                "богатейший опыт в сфере фитнеса и бодибилдинга. Об этом свидетельствуют многочисленные победы " +
                "воспитанников клуба на международных, Российских и городских соревнованиях по фитнесу и бодибилдингу." +
                "Клуб оборудован удобными раздевалками, душевыми, современными системами вентиляции зала." +
                "Тренера клуба помогут клиентам составить индивидуальные программы тренировок, скорректируют диету, " +
                "помогут распланировать распорядок дня, для желающих проведут персональные тренировки.",
                Address = "Россия, Санкт-Петербург, ул. Воскова, д. 16",
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000002")    //Андрей Прокофьев
            };

            builder.HasData(goldsGym, almaz);
        }
    }
}
