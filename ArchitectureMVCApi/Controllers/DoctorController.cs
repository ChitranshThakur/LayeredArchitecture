using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.CustomRepository;

namespace ArchitectureMVCApi.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _dc;

        public DoctorController(IDoctorRepository dc)
        {
            _dc = dc;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("get")]
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _dc.GetAll();
        }

        [HttpPost("create")]
        public IActionResult CreateDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _dc.Add(doctor);
                _dc.Save();
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
            _dc.Update(doctor);
            _dc.Save();
            return Json(new { success = true, message = "Updated successfully" });
        }

        [HttpPost("delete")]
        public IActionResult DeleteDoctor(int id)
        {
            if (id == null)
            { 
               return BadRequest();
            }
            var doctorDb = _dc.GetFirstOrDefault(x => x.ID == id);
            _dc.Remove(doctorDb);
            return Json(new { success = true, message = "Deleted successfully" });
        }

    }
}
