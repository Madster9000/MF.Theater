using System;
using System.Collections.Generic;
using System.Data.Entity;
using MF.Theater.Context.Properties;
using MF.Theater.DataModel;

namespace MF.Theater.Context
{
    public class TheaterContextInitializer : 
        //CreateDatabaseIfNotExists<TheaterContext>
        DropCreateDatabaseAlways<TheaterContext>
    {
        protected override void Seed(TheaterContext context)
        {
            var perfomances = new List<Perfomance>
            {
                new Perfomance{Id = Guid.NewGuid(), Name = "Test1", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test2", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test3", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test4", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test5", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test6", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test7", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test8", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test9", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test10", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test11", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test12", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test13", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test14", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test15", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test16", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test17", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test18", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
            };

            context.Perfomances.AddRange(perfomances);
            context.SaveChanges();

            var initialSqlScript = Resources.Initial;

            context.Database.ExecuteSqlCommand(initialSqlScript);

            base.Seed(context);
        }
    }
}