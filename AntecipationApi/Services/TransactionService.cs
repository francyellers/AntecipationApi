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
            List<Transaction> listTrans = new List<Transaction>();


            var availableTrans = _context.Transactions.Where(t => t.SolicitationId == null && t.AcquirerConfirmation == true);

            Parallel.ForEach(availableTrans, x =>
            {
                Transaction t = new Transaction();
                t.TransctionDate = x.TransctionDate;
                t.DateTransfer = x.DateTransfer;
                t.AcquirerConfirmation = x.AcquirerConfirmation;
                t.TransactionValue = x.TransactionValue;
                if (x.ParcelNumber > 1)
                    t.ValueTransfer = (x.TransactionValue - 0.90M) - (x.ParcelNumber * 3.8M);
                t.ParcelNumber = x.ParcelNumber;
                t.SolicitationId = x.SolicitationId;

                listTrans.Add(t);

            });

            return listTrans;

        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        /*public void Update(long[] ids)
        {
            //List<Transaction> listTrans = new List<Transaction>();

            Console.WriteLine(" METODO - " + ids.Length.ToString());

            Parallel.For(0, ids.Length, i =>
            {
                var solicitation = _context.Solicitations.Where(s => s.Result == null).First();
                _context.Transactions.Where(t => ids[i] == (t.SolicitationId)).ToList()
                .ForEach(t => t.SolicitationId = solicitation.SolicitationId);
                Console.WriteLine(" Id - " + ids[i]);
                _context.SaveChanges();
                Transaction t = new Transaction();
                t.TransctionDate =
            });
            /*
            string x = "";
            for (int i = 0; i < id.Length; i++)
            {
                x = x + " - " + id[i];
            }
            
        }*/

        public void Update(long id)
        {
            var solicitation = _context.Solicitations.Where(s => s.Result == null).First();
            _context.Transactions.Where(t => t.TransactionId == id).ToList()
            .ForEach(t => t.SolicitationId = solicitation.SolicitationId);

            _context.SaveChanges();
        }
    }
}
