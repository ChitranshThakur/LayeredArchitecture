using ServicesLayer.CustomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDoctorRepository DoctorRepository { get; }

        void Save();
    }
}
