using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MdoDb.Organization.Model;


namespace MdoTestKrv.Models.Empl
{
    public class EmplSearch
    {
        public EmplFilter Filter { get; set; }
        public IEnumerable<EmplItem> Empls { get; set; }       
    }

    public struct EmplFilter
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public class EmplItem
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string Name { get; set; }

        [DisplayName("Год рождения")]
        public int BirthYear { get; set; }

        [DisplayName("Должность")]
        public string Title { get; set; }        
    }

}