using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntecipationApi.Models;

namespace AntecipationApi.Services
{
    public class SolicitationService : ISolicitationService
    {
        private readonly ApiDbContext _context;

        public SolicitationService(ApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Solicitation> GetByPeriod(string dates)
        {
            List<Solicitation> listSolic = new List<Solicitation>();
            Console.WriteLine(dates);
            var initialDate = dates.Substring(0, 10).Replace("-", "/");
            var finalDate = dates.Substring(11,10).Replace("-", "/");

            Console.WriteLine("d1 " + initialDate + " d2: " + finalDate);

            var solic = _context.Solicitations.Where(s => s.RequestDate >= DateTime.Parse(initialDate) 
                                                    && s.EndDateAnalysis <= DateTime.Parse(finalDate));

            Parallel.ForEach(solic, x =>
            {
                Solicitation s = new Solicitation();
                s.SolicitationId = x.SolicitationId;
                s.RequestDate = x.RequestDate;
                s.StartDateAnalysis = x.StartDateAnalysis;
                s.EndDateAnalysis = x.EndDateAnalysis;
                s.Result = x.Result;
                s.TotalValueTransactions = x.TotalValueTransactions;
                s.TotalValueTransfer = x.TotalValueTransfer;

                listSolic.Add(x);
            });


            return listSolic;
        }
    }
}
