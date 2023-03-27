using GMS.Core.Core.Domain;

namespace GMS.Core.DataAccess.Data
{
    public static class SeedData
    {
        public static IEnumerable<FitnessClub> FitnessClubs => new List<FitnessClub>()
        {
            new FitnessClub
            {
                Id = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                Name = "Gold's Gym Venice",
                Description = "The Original Home of Serious Training",
                Address = "360 Hampton Dr, Venice, CA 90291, USA",
                OwnerId = Guid.Parse("00000000-0000-0000-0004-000000000001"),    //Joe Gold 
                IsDeleted = false
            },
            new FitnessClub
            {
                Id = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                Name = "Атлетический клуб Алмаз",
                Description = "Персональные тренировки по фитнесу и бодибилдингу",
                Address = "Россия, Санкт-Петербург, ул. Воскова, д. 16",
                OwnerId = Guid.Parse("00000000-0000-0000-0004-000000000002"),    //Андрей Прокофьев
                IsDeleted = false
            },
            new FitnessClub
            {
                Id = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                Name = "Фитнес клуб 3",
                Description = "Персональные тренировки ФК 3",
                Address = "Адрес ФК 3",
                OwnerId = Guid.Parse("00000000-0000-0000-0004-000000000003"),  // Пользователь 3   
                IsDeleted = false
            },
            new FitnessClub
            {
                Id = Guid.Parse("f0000000-0000-0000-0000-000000000004"),
                Name = "Фитнес клуб 4",
                Description = "Персональные тренировки ФК 4",
                Address = "Адрес ФК 4",
                OwnerId = Guid.Parse("00000000-0000-0000-0004-000000000003"),
                IsDeleted = false
            },
            new FitnessClub
            {
                Id = Guid.Parse("f0000000-0000-0000-0000-000000000005"),
                Name = "Фитнес клуб 5",
                Description = "Персональные тренировки ФК 5",
                Address = "Адрес ФК 5",
                OwnerId = Guid.Parse("00000000-0000-0000-0004-000000000003"),
                IsDeleted = false
            },
            new FitnessClub
            {
                Id = Guid.Parse("f0000000-0000-0000-0000-000000000006"),
                Name = "Фитнес клуб 6",
                Description = "Персональные тренировки ФК 6",
                Address = "Адрес ФК 6",
                OwnerId = Guid.Parse("00000000-0000-0000-0004-000000000003"),
                IsDeleted = false
            },
        };

        public static IEnumerable<Area> Areas => new List<Area>()
        {
            // Gold's Gym Venice
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-000000000001"),
                Name = "Outdoor workout area",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-000000000002"),
                Name = "Free weights area",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-000000000003"),
                Name = "Functional training area",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-000000000004"),
                Name = "Resistance Machines area",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-000000000005"),
                Name = "Cardio Equipment area",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                IsDeleted = false
            },

            // Алмаз
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-000000000006"),
                Name = "Тренажерный зал",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-000000000007"),
                Name = "Зона кардиотренажеров",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                IsDeleted = false
            },

            // Фитнес клуб 3
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-000000000008"),
                Name = "Зона 8 ФК3",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-000000000009"),
                Name = "Зона 9 ФК3",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-00000000000a"),
                Name = "Зона 10 ФК3",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-00000000000b"),
                Name = "Зона 11 ФК3",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = true
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-00000000000c"),
                Name = "Зона 12 ФК3",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-00000000000d"),
                Name = "Зона 13 ФК3",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-00000000000e"),
                Name = "Зона 14 ФК3",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-00000000000f"),
                Name = "Зона 15 ФК3",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Area
            {
                Id = Guid.Parse("a0000000-0000-0000-0000-000000000010"),
                Name = "Зона 16 ФК3",
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            }
        };

        public static IEnumerable<Product> Products => new List<Product>()
        {
            // Gold's Gym Venice
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000001"),
                Name = "1 personal Training",
                Description = "Cardio training",
                Quantity = 1,
                Price = 100,  
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000002"),
                Name = "8 personal Training",
                Description = "Cardio training",
                Quantity = 8,
                Price = 600,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000003"),
                Name = "1 personal Training",
                Description = "Functional training",
                Quantity = 1,
                Price = 100,  
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000004"),
                Name = "8 personal Training",
                Description = "Functional training",
                Quantity = 8,
                Price = 600,   
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                IsDeleted = false
            },

            // Алмаз
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000005"),
                Name = "1 персональная тренировка",
                Description = "Бодибилдинг",
                Quantity = 1,
                Price = 80,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000006"),
                Name = "8 персональных тренировок",
                Description = "Бодибилдинг",
                Quantity = 8,
                Price = 480,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000007"),
                Name = "1 персональная тренировка",
                Description = "Кардио",
                Quantity = 1,
                Price = 80,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000008"),
                Name = "8 персональных тренировок",
                Description = "Кардио",
                Quantity = 8,
                Price = 480,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                IsDeleted = false
            },

            // Фитнес клуб 3
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000009"),
                Name = "Продукт 9 ФК3",
                Description = "1 персональня тренировка ФК3",
                Quantity = 1,
                Price = 10,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-00000000000a"),
                Name = "Продукт 10 ФК3",
                Description = "2 персональные тренировки ФК3",
                Quantity = 2,
                Price = 20,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-00000000000b"),
                Name = "Продукт 11 ФК3",
                Description = "3 персональные тренировки ФК3",
                Quantity = 3,
                Price = 30,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-00000000000c"),
                Name = "Продукт 12 ФК3",
                Description = "4 персональные тренировки ФК3",
                Quantity = 4,
                Price = 40,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-00000000000d"),
                Name = "Продукт 13 ФК3",
                Description = "5 персональных тренировок ФК3",
                Quantity = 5,
                Price = 50,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-00000000000e"),
                Name = "Продукт 14 ФК3",
                Description = "6 персональных тренировок ФК3",
                Quantity = 6,
                Price = 60,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-00000000000f"),
                Name = "Продукт 15 ФК3",
                Description = "7 персональных тренировок ФК3",
                Quantity = 7,
                Price = 70,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000010"),
                Name = "Продукт 16 ФК3",
                Description = "8 персональных тренировок ФК3",
                Quantity = 8,
                Price = 80,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000011"),
                Name = "Продукт 17 ФК3",
                Description = "9 персональных тренировок ФК3",
                Quantity = 9,
                Price = 90,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            },
            new Product
            {
                Id = Guid.Parse("b0000000-0000-0000-0000-000000000012"),
                Name = "Продукт 18 ФК3",
                Description = "10 персональных тренировок ФК3",
                Quantity = 10,
                Price = 100,
                FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                IsDeleted = false
            }
        };

        public static IEnumerable<Contract> Contracts => new List<Contract>()
        {
            // Gold's Gym Venice
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-000000000001"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000002"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000001"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-000000000002"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000003"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000001"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },

            // Алмаз
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-000000000003"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000006"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000002"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-000000000004"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000008"), 
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000002"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },

            // Фитнес клуб 3
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-000000000005"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000009"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000003"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-000000000006"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-00000000000a"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000003"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-000000000007"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-00000000000b"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000003"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-000000000008"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-00000000000c"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000003"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-000000000009"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-00000000000d"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000003"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-00000000000a"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-00000000000e"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000003"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-00000000000b"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-00000000000f"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000003"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-00000000000c"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000010"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000003"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-00000000000d"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000009"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000003"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            },
            new Contract
            {
                Id = Guid.Parse("c0000000-0000-0000-0000-00000000000e"),
                ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000009"),
                ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000003"),
                UserId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365),
                IsApproved = true,
                IsDeleted = false
            }
        };
    }
}
