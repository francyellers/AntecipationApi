﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntecipationApi.Models
{
    public class Transaction
    {
        public long TransactionId { get; set; }
        public DateTime TransctionDate { get; set; }
        public DateTime? DateTransfer { get; set; }
        public bool? AcquirerConfirmation { get; set; }
        public decimal? TransactionValue { get; set; }
        public decimal? ValueTransfer { get; set; }
        public int? ParcelNumber { get; set; }

        public long? SolicitationId { get; set; }
        public Solicitation Solicitation { get; set; }
    }
}