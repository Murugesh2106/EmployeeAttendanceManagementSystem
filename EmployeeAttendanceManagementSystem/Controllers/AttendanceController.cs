using EmployeeAttendanceManagementSystem.Data;
using EmployeeAttendanceManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendanceManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Attendances = _context.Attendances;
            return View(Attendances);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Attendance model)
        {
            _context.Attendances.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                NotFound();
            }
            
            var attendance = _context.Attendances.Find(id);
            return View(attendance);
        }

        [HttpPost]
        public IActionResult Edit(Attendance model)
        {
            ModelState.Remove("Employees");
            if (ModelState.IsValid)
            {
                _context.Attendances.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                NotFound();
            }
  
            var attendance = _context.Attendances.Find(id);
            return View(attendance);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Attendance model)
        {
            _context.Attendances.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
