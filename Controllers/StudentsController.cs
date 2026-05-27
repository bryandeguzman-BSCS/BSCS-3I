using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System_student_record.Models;

namespace System_student_record.Controllers
{
    public class StudentsController : Controller
    {
        private static readonly List<Student> students =
        new List<Student>()
        {
            new Student
            {
                Id = 1,
                StudentId = "2025-0001",
                Name = "Juan Dela Cruz",
                Age = 19,
                Grade = 90
            },

            new Student
            {
                Id = 2,
                StudentId = "2025-0002",
                Name = "Maria Santos",
                Age = 18,
                Grade = 85
            }
        };

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.TotalStudents = students.Count;

            return View();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.Id = students.Count + 1;

            students.Add(student);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student =
            students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var existing =
            students.FirstOrDefault(x => x.Id == student.Id);

            if (existing != null)
            {
                existing.StudentId = student.StudentId;
                existing.Name = student.Name;
                existing.Age = student.Age;
                existing.Grade = student.Grade;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student =
            students.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                students.Remove(student);
            }

            return RedirectToAction("Index");
        }
    }
}