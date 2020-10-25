using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using erudite.Models;
using erudite.ViewModel;
namespace erudite.Controllers.Teachers
{
    public class TeachersApplicationFormController : Controller
    {
        // GET: TeachersApplicationForm
        public ActionResult ApplicationForm(string id)
        {
            int Id = Int32.Parse(id);
            InstituteDataEntities db = new InstituteDataEntities();
            Form form = new Form();

            var Slot = db.Slots.Where(m => m.Institutes.Select(c => c.Id).Contains(Id)).ToList();

            int durationValue = 0;
            List<Given_Slots> givenSlots = new List<Given_Slots>();
            foreach (var value in Slot)
            {
                Given_Slots SlotValue = new Given_Slots();

                SlotValue.duration = value.slotstartTime.ToString() + " - " + value.slotendTime.ToString();
                SlotValue.value = value.slotId;
                givenSlots.Add(SlotValue);
            }
            var Subject = db.Subjects.ToList();
            var schoolSection = db.Sections.ToList();

            ViewBag.Slots = new SelectList(givenSlots, "value", "duration");
            ViewBag.Subject = new SelectList(Subject, "Subjects","Subjects");
            ViewBag.Section = new SelectList(schoolSection, "section1", "section1");
            form.selectedRequirement.selectedSchool = Id;
            return View(form);
        }

        [HttpPost]
        public ActionResult Thanks(Form form)
        {
            string fileName = Path.GetFileNameWithoutExtension(form.ImageFile.FileName);
            string extension = Path.GetExtension(form.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            form.biodata.image = "~/Image/teacher Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/teacher Images/"), fileName);
            form.ImageFile.SaveAs(fileName);
            using(StaffAndStudentsDataEntities db = new StaffAndStudentsDataEntities())
            {
                db.TeacherBioDatas.Add(form.biodata);
                db.SaveChanges();
                form.selectedRequirement.Id = db.TeacherBioDatas.Where(m => m.name == form.biodata.name).FirstOrDefault().Id;
                db.Requirements.Add(form.selectedRequirement);
                db.SaveChanges();
            }
            return View(form.biodata);

        }
       
    }
}