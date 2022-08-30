using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.CustomRepository;
using ServicesLayer.Repository.IRepository;

namespace ArchitectureMVCApi.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("get")]
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _unitOfWork.DoctorRepository.GetAll();
        }

        [HttpGet("getone")]
        public ActionResult GetDoctorById(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var doctorFromDb = _unitOfWork.DoctorRepository.GetFirstOrDefault(x => x.ID == id);
            return Ok(doctorFromDb);
        }

        [HttpPost("create")]
        public IActionResult CreateDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DoctorRepository.Add(doctor);
                _unitOfWork.DoctorRepository.Save();
                return Json(new { success = true, message = "Created Successfully" });
            }
            return Json(new { success = false, message = "Failed" });
        }

        [HttpPut("update")]
        public IActionResult UpdateDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                return NotFound();
            }
            _unitOfWork.DoctorRepository.Update(doctor);
            _unitOfWork.DoctorRepository.Save();
            return Json(new { success = true, message = "Updated successfully" });
        }

        [HttpPost("delete")]
        public IActionResult DeleteDoctor(int id)
        {
            if (id == null)
            { 
               return BadRequest();
            }
            var doctorDb = _unitOfWork.DoctorRepository.GetFirstOrDefault(x => x.ID == id);
            _unitOfWork.DoctorRepository.Remove(doctorDb);
            return Json(new { success = true, message = "Deleted successfully" });
        }

    }
}
