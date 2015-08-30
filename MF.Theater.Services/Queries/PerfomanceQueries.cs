using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using MF.Theater.Context.Factories;
using MF.Theater.DataModel;
using MF.Theater.DTO;

namespace MF.Theater.Services.Queries
{
    public class PerfomanceQueries: IPerfomanceQueries
    {
        private readonly IDbContextFactory mDbContextFactory;

        public PerfomanceQueries(IDbContextFactory dbContextFactory)
        {
            mDbContextFactory = dbContextFactory;
        }



        public int PerfomancesCount()
        {
            using (var context = mDbContextFactory.CreateContext())
            {
                return context.Set<Perfomance>().Count();
            }
        }

        public ICollection<PerfomanceDto> SelectPagedPerfomances(int pageNumber, int recordsOnPage, DateTime startDate, DateTime endDate, string name)
        {
            using (var context = mDbContextFactory.CreateContext())
            {
                var offset = (pageNumber - 1) * recordsOnPage;

                var result =
                    context.Database.SqlQuery<PerfomanceDto>
                        (
                            "dbo.SelectPerfomancesPage @offset, @fetch, @startDate, @endDate, @name",
                            new SqlParameter("offset", offset),
                            new SqlParameter("fetch", recordsOnPage),
                            new SqlParameter("startDate", startDate),
                            new SqlParameter("endDate", endDate),
                            new SqlParameter("name", name)
                        )
                        .ToList();

                foreach (var perfomance in result)
                {
                    perfomance.PlayPeriods =
                        context.Set<PlayPeriod>().AsNoTracking()
                            .Where(x => x.PerfomanceId == perfomance.Id)
                            .Select
                            (
                                y => new PlayPeriodDto
                                {
                                    Id = y.Id,
                                    EndDate = y.EndDate,
                                    StartDate = y.StartDate,
                                    PerfomanceId = y.PerfomanceId,
                                    TicketsCapacity = y.TicketsCapacity
                                }
                            )
                            .ToList();
                }


                //На мой взгляд, лучше сделать так. Либо писать хитровымудренный скрипт для подтягивания связанных сущностей в одном запросе.
                //context.Database.Log = msg => Debug.WriteLine(msg);

                //var result =
                //    context.Set<Perfomance>()
                //    .OrderBy(x => x.Name)
                //    .Skip(offset)
                //    .Take(recordsOnPage)
                //    .Select
                //    (
                //        x => new PerfomanceDto
                //        {
                //            Id = x.Id,
                //            Description = x.Description,
                //            Name = x.Name,
                //            PlayPeriods =
                //                x.PlayPeriods
                //                .Select
                //                (
                //                    y => new PlayPeriodDto
                //                    {
                //                        Id = y.Id,
                //                        EndDate = y.EndDate,
                //                        StartDate = y.StartDate,
                //                        PerfomanceId = y.PerfomanceId,
                //                        TicketsCapacity = y.TicketsCapacity
                //                    }
                //                )

                //        }
                //    )
                //    .ToList();

                return result;
            }
        }
    }
}