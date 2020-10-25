using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using erudite.Models;
namespace erudite.ViewModel
{
    public class Form
    {
        public Form()
        {
            this.selectedRequirement = new Requirement();
       
        }
       public TeacherBioData biodata { get; set; }
       public Day day { get; set; }
       public Requirement selectedRequirement { get; set; }
       public HttpPostedFileBase ImageFile { get; set; }

    }
}