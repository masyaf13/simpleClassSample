using CaseStudy.Context;

using CaseStudy.Models;
using CaseStudy.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy.Areas.Management.Controllers
{
    [Area("Management")]
    public class StudentController : Controller
    {
        
        IStudentRepository _repoStudent;
        IClassRoomRepository _repoClassRoom;

        public StudentController(IStudentRepository repoStudent, IClassRoomRepository repoClassRoom)
        {
           
            _repoStudent= repoStudent;
            _repoClassRoom = repoClassRoom;
        }

        public IActionResult StudentList()
        {
            List<Student> students = _repoStudent.GetStudents();
            return View(students);
        }

        public IActionResult Create()
        {
            List<ClassRoom> classRooms = _repoClassRoom.SelectClassRoom();

            var tuple = new Tuple<Student, List<ClassRoom>>(new Student(), classRooms);
            return View((tuple));
        }

        [HttpPost]
        public IActionResult Create([Bind(Prefix = "Item1")] Student student)
        {
            if (!ModelState.IsValid)
            {
                List<ClassRoom> classRooms= _repoClassRoom.SelectClassRoom();

                var tuple = new Tuple<Student, List<ClassRoom>>(new Student(), classRooms);
                return View((tuple));

            }

            student.FirstName = student.FirstName.ToUpper();
            student.LastName = student.LastName.ToUpper();
            _repoStudent.Add(student);
            return RedirectToAction("StudentList", "Student", new { area = "Management" });
        }

        public IActionResult Edit(int id)
        {

            Student student = _repoStudent.GetById(id);
            List<ClassRoom> classRooms = _repoClassRoom.GetActives();

            var tuple = new Tuple<Student, List<ClassRoom>>(student, classRooms);
            return View(tuple);
        }

        [HttpPost]
        public IActionResult Edit(Student item1)
        {

            if (!ModelState.IsValid)
            {
                List<ClassRoom> classRooms = _repoClassRoom.SelectClassRoom();

                var tuple = new Tuple<Student, List<ClassRoom>>(item1, classRooms);
                return View((tuple));

            }

            item1.FirstName = item1.FirstName.ToUpper();
            item1.LastName = item1.LastName.ToUpper();

            _repoStudent.Update(item1);
            return RedirectToAction("StudentList", "Student", new { area = "Management" });
        }

        public IActionResult Delete(int id)
        {
               
                _repoStudent.Delete(id);
            return RedirectToAction("StudentList","Student",new {area="Management"});
        }
    }
}
