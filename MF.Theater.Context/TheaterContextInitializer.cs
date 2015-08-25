using System;
using System.Collections.Generic;
using System.Data.Entity;
using MF.Theater.DataModel;

namespace MF.Theater.Context
{
    public class TheaterContextInitializer : DropCreateDatabaseAlways<TheaterContext>
    {
        protected override void Seed(TheaterContext context)
        {
            var perfomances = new List<Perfomance>
            {
                new Perfomance{Id = Guid.NewGuid(), Name = "Test"},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test"},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test"}
            };

            context.Perfomances.AddRange(perfomances);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}