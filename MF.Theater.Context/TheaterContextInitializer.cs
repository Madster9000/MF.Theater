using System;
using System.Collections.Generic;
using System.Data.Entity;
using MF.Theater.Context.Properties;
using MF.Theater.DataModel;

namespace MF.Theater.Context
{
    public class TheaterContextInitializer : 
        CreateDatabaseIfNotExists<TheaterContext>
        //DropCreateDatabaseAlways<TheaterContext>
    {
        protected override void Seed(TheaterContext context)
        {
            var perfomances = new List<Perfomance>
            {
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()},new PlayPeriod{Id = Guid.NewGuid()}}},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest", PlayPeriods = new List<PlayPeriod>{new PlayPeriod{Id = Guid.NewGuid()}}},
            };

            context.Perfomances.AddRange(perfomances);
            context.SaveChanges();

            var initialSqlScript = Resources.Initial;

            context.Database.ExecuteSqlCommand(initialSqlScript);

            base.Seed(context);
        }
    }
}