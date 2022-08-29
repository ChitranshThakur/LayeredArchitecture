
using DomainLayer.Models;
using ServicesLayer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.CustomRepository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        void Update(Doctor doctor);

        void Save();
    }
}
