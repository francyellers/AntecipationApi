using AntecipationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntecipationApi.Services
{
    public interface ISolicitationService
    {
        IEnumerable<Solicitation> GetByPeriod(string dates);
    }
}
