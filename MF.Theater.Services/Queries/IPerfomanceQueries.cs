﻿using System;
using System.Collections.Generic;
using MF.Theater.DataModel;
using MF.Theater.DTO;

namespace MF.Theater.Services.Queries
{
    public interface IPerfomanceQueries
    {
        ICollection<PerfomanceDto> SelectPagedPerfomances(int pageNumber, int recordsOnPage, DateTime startDate, DateTime endDate, string name);
        int PerfomancesCount(DateTime startDate, DateTime endDate, string name);
    }
}