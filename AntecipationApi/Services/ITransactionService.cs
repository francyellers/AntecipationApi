using AntecipationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntecipationApi.Services
{
    public interface ITransactionService
    {
        void Add(Transaction trans);

        IEnumerable<Transaction> GetAll();

        Transaction Find(long id);

        void Remove(long id);

        void Update(long[] ids);

        void Update(long id);
    }
}
