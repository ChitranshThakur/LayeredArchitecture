using RepositoryLayer.Data;
using ServicesLayer.CustomRepository;
using ServicesLayer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            DoctorRepository = new DoctorRepository(_db);
        }

        public IDoctorRepository DoctorRepository { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
