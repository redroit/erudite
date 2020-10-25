using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using erudite.Models;
using erudite.ViewModel;

namespace erudite.Controllers.Teachers
{
    public class TeacherApplicationController : Controller
    {
        // GET: TeacherApplication
        public ActionResult TeachingCategory()
        {
            return View();
        }
        
        public ActionResult InstituteAreas()
        {
            List<AreaInstitute> areas = new List<AreaInstitute>();
            AreaInstitute particulararea = new AreaInstitute();
            using (InstituteDataEntities db = new InstituteDataEntities())
            {
                for (int i = 1; i <=db.Areas.Count() ; i++)
                {
                    
                   particulararea.area = db.Areas.Where(m => m.areasId == i).FirstOrDefault();
                   particulararea.noofInstitute = db.Institutes.Where(m => m.areasId == i).Count();
                    areas.Add(particulararea);
                }
                
            }
            
            
            return View(areas);
        }
        public ActionResult InstituteList(string id)
        {
            InstitutesofParticularArea institutes = new InstitutesofParticularArea();
            using (InstituteDataEntities db = new InstituteDataEntities())
            {
                var areaId = db.Areas.Where(m => m.Area1 == id).FirstOrDefault().areasId;
                institutes.institute =  db.Institutes.Where(m => m.areasId == areaId).ToList();

            }
            institutes.area = id;
            return View(institutes);
        }

        public ActionResult InstituteDetail(string id)
        {
            Institute institute = new Institute();
            List<Slot> Slots = new List<Slot>();
            using (InstituteDataEntities db = new InstituteDataEntities())
            {
                institute = db.Institutes.Where(m => m.fullName == id).FirstOrDefault();
                Slots = db.Slots.Where(m => m.Institutes.Select(c => c.fullName).Contains(id)).ToList();
            }
            ViewBag.Slot = Slots;
            return View(institute);
        }
        
    }
}