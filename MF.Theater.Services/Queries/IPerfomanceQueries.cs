using System.Collections.Generic;
using MF.Theater.DataModel;

namespace MF.Theater.Services.Queries
{
    public interface IPerfomanceQueries
    {
        ICollection<Perfomance> SelectAll();
    }
}