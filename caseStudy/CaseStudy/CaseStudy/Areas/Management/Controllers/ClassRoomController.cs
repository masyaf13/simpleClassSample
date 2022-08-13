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
    public class ClassRoomController : Controller
    {
       

        IClassRoomRepository _repoClassRoom;
        public ClassRoomController(IClassRoomRepository repoClassRoom)
        {
            
            _repoClassRoom = repoClassRoom;
        }

        public IActionResult ClassRoomList()
        {
            List<ClassRoom> classRooms = _repoClassRoom.GetAll();
            return View(classRooms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClassRoom classRoom)
        {


            if (!ModelState.IsValid)
            {
                return View(classRoom);
            }
            try
            {
                _repoClassRoom.Add(classRoom);
                return RedirectToAction("ClassRoomList", "ClassRoom", new { area = "Management" });
            }
            catch (DbUpdateException)
            {
                ViewBag.Message = "Bu isimle bir sinif mevcuttur.";
                return View(classRoom);

            }

            
        }

              public IActionResult HardDelete(string id)
        {
            _repoClassRoom.SpecialDelete(id);
            return RedirectToAction("ClassRoomList", "ClassRoom", new { area = "Management" });
        }

     
    }
}
