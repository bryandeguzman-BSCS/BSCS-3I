using Microsoft.AspNetCore.Mvc;
using System_student_record.Models;

namespace System_student_record.Controllers
{
    public class CoursesController : Controller
    {
        static List<Course> courses =
        new List<Course>()
        {
            new Course
            {
                Id = 1,
                CourseCode = "BSIT",
                CourseName = "Bachelor of Science in Information Technology"
            }
        };

        // INDEX

        public IActionResult Index()
        {
            return View(courses);
        }

        // CREATE PAGE

        public IActionResult Create()
        {
            return View();
        }

        // SAVE COURSE

        [HttpPost]
        public IActionResult Create(Course course)
        {
            course.Id = courses.Count + 1;

            courses.Add(course);

            return RedirectToAction("Index");
        }

        // EDIT PAGE

        public IActionResult Edit(int id)
        {
            var course =
            courses.FirstOrDefault(x => x.Id == id);

            return View(course);
        }

        // UPDATE COURSE

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            var existing =
            courses.FirstOrDefault(x => x.Id == course.Id);

            if (existing != null)
            {
                existing.CourseCode = course.CourseCode;
                existing.CourseName = course.CourseName;
            }

            return RedirectToAction("Index");
        }

        // DELETE COURSE

        public IActionResult Delete(int id)
        {
            var course =
            courses.FirstOrDefault(x => x.Id == id);

            if (course != null)
            {
                courses.Remove(course);
            }

            return RedirectToAction("Index");
        }
    }
}