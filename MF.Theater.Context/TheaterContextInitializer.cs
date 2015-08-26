using System;
using System.Collections.Generic;
using System.Data.Entity;
using MF.Theater.DataModel;

namespace MF.Theater.Context
{
    public class TheaterContextInitializer : CreateDatabaseIfNotExists<TheaterContext>
        //DropCreateDatabaseAlways<TheaterContext>
    {
        protected override void Seed(TheaterContext context)
        {
            var perfomances = new List<Perfomance>
            {
                new Perfomance{Id = Guid.NewGuid(), Name = "Test", Description = "Megatest"},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test2", Description = "Megatest2"},
                new Perfomance{Id = Guid.NewGuid(), Name = "Test3", Description = "Megatest3"}
            };

            context.Perfomances.AddRange(perfomances);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}