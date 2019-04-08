using MdoDb.Organization.Model;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MdoTestKrv.Models.Empl
{
    public class EmplDetails
    {
        const string RequeredError = "Обязательное поле";

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequeredError)]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = RequeredError)]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = RequeredError)]
        [DisplayName("Отчество")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = RequeredError)]
        [Range(1900, 2000, ErrorMessage = "Недопустимый год")]
        [DisplayName("Год рождения")]
        public int BirthYear { get; set; }

        [DisplayName("Должность")]
        public string Title { get; set; }

        public EmplDetails()
        {
        }

        public EmplDetails(Employee empl)
        {            
            Id = empl.Id;
            FirstName = empl.FirstName;
            MiddleName = empl.MiddleName;
            LastName = empl.LastName;
            BirthYear = empl.BirthYear;
            Title = empl.Title;
        }

        public Employee ToEmployee()
        {
            return new Employee()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                BirthYear = this.BirthYear,
                Title = this.Title
            };
        }

    }
}