using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntecipationApi.Models;

namespace AntecipationApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApiDbContext _context;

        public TransactionService(ApiDbContext context)
        {
            _context = context;
        }

        public void Add(Transaction trans)
        {
            throw new NotImplementedException();
        }

        public Transaction Find(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(long id)
        {
            throw new NotImplementedException();
        }
    }
}
