using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntecipationApi.Models
{
    public class Solicitation
    {
        public long SolicitationId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? StartDateAnalysis { get; set; }
        public DateTime? EndDateAnalysis { get; set; }
        public bool? Result { get; set; }
        public decimal? TotalValueTransactions { get; set; }
        public decimal? TotalValueTransfer { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}