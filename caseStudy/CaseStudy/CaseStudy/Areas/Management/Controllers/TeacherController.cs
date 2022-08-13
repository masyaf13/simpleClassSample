using CaseStudy.Context;
using CaseStudy.Models;
using CaseStudy.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Web;

namespace CaseStudy.Areas.Management.Controllers
{
    [Area("Management")]

    public class TeacherController : Controller
    {
        ITeacherRepository _repoTeacher;
        IClassRoomRepository _repoClassRoom;
       
        public TeacherController( IClassRoomRepository repoClassRoom, ITeacherRepository repoTeacher)
        {
           
            _repoTeacher = repoTeacher;
            _repoClassRoom = repoClassRoom;

        }


        public IActionResult TeacherList()
        {

            List<Teacher> teachers = _repoTeacher.GetTeachers();
            return View(teachers);
        }



        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {

                return View(teacher);

            }

            teacher.FirstName = teacher.FirstName.ToUpper();
            teacher.LastName = teacher.LastName.ToUpper();
            _repoTeacher.Add(teacher);
            return RedirectToAction("TeacherList", "Teacher", new { area = "Management" });
        }

        public IActionResult Edit(int id)
        {
           List<ClassRoom> classRooms = _repoClassRoom.SelectClassRoom();
            Teacher teacher = _repoTeacher.GetById(id);
            var tuple = new Tuple<Teacher, List<ClassRoom>>(teacher, classRooms);

            return View(tuple);
        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "Item1")] Teacher teacher)
        {

            if (!ModelState.IsValid)
            {
                List<ClassRoom> classRooms = _repoClassRoom.SelectClassRoom();

                var tuple = new Tuple<Teacher, List<ClassRoom>>(teacher, classRooms);
                return View((tuple));

            }
            teacher.FirstName = teacher.FirstName.ToUpper();
            teacher.LastName = teacher.LastName.ToUpper();
            try
            {
                 _repoTeacher.Update(teacher);
                return RedirectToAction("TeacherList", "Teacher", new { area = "Management" });
            }
            catch (DbUpdateException)
            {
                ViewBag.Message = "Sectiginiz sinif baska bir ogretmene atanmistir. Lutfen farkli bir sinif seciniz.";
                List<ClassRoom> classRooms = _repoClassRoom.SelectClassRoom();

                var tuple = new Tuple<Teacher, List<ClassRoom>>(teacher, classRooms);
                return View((tuple));

            }


        }




        public IActionResult Delete(int id)
        {
           
            _repoTeacher.SpecialDelete(id);
            return RedirectToAction("TeacherList", "Teacher", new { area = "Management" });
        }
    }
}
