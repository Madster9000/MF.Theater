using System;
using System.Collections.Generic;
using System.Linq;
using MF.Theater.Context.Factories;
using MF.Theater.DataModel;
using MF.Theater.DTO;

namespace MF.Theater.Services.Commands
{
    public class PerfomanceCommands: IPerfomanceCommands
    {
        private readonly IDbContextFactory mDbContextFactory;

        public PerfomanceCommands(IDbContextFactory dbContextFactory)
        {
            mDbContextFactory = dbContextFactory;
        }

        public void Create(PerfomanceDto request)
        {
            using (var context = mDbContextFactory.CreateContext())
            {
                var perfomance = new Perfomance
                {
                    Id=Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description
                };

                if (request.PlayPeriods != null && request.PlayPeriods.Any())
                {
                    foreach (var playPeriodDto in request.PlayPeriods)
                    {
                        var playPeriod = new PlayPeriod
                        {
                            Id = Guid.NewGuid(),
                            StartDate = playPeriodDto.StartDate,
                            EndDate = playPeriodDto.EndDate,
                            TicketsCapacity = playPeriodDto.TicketsCapacity
                        };

                        perfomance.PlayPeriods.Add(playPeriod);
                    }
                }
                

                context.Set<Perfomance>().Add(perfomance);
                context.SaveChanges();
            }
        }

        public void Update(PerfomanceDto request)
        {
            using (var context = mDbContextFactory.CreateContext())
            {
                var currentPerfomance =
                    context.Set<Perfomance>().Include("PlayPeriods").FirstOrDefault(x => x.Id == request.Id);

                if (currentPerfomance == null)
                {
                    throw new ApplicationException("Постановка не найдена");
                }

                currentPerfomance.Name = request.Name;
                currentPerfomance.Description = request.Description;

                foreach (var playPeriodDto in request.PlayPeriods)
                {
                    var currentPlayPeriod = currentPerfomance.PlayPeriods.FirstOrDefault(x => x.Id == playPeriodDto.Id);
                    if (currentPlayPeriod == null)
                    {
                        var playPeriod = new PlayPeriod
                        {
                            Id = Guid.NewGuid(),
                            StartDate = playPeriodDto.StartDate,
                            EndDate = playPeriodDto.EndDate,
                            TicketsCapacity = playPeriodDto.TicketsCapacity
                        };

                        currentPerfomance.PlayPeriods.Add(playPeriod);
                        continue;
                    }

                    currentPlayPeriod.StartDate = playPeriodDto.StartDate;
                    currentPlayPeriod.EndDate = playPeriodDto.EndDate;
                    currentPlayPeriod.TicketsCapacity = playPeriodDto.TicketsCapacity;
                }

                context.SaveChanges();
            }
        }
    }
}