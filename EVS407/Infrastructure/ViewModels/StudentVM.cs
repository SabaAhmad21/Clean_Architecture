using DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = null!;

        public string Department { get; set; } = null!;

        public string RoleNumber { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Gender { get; set; } = null!;

    }
    public class StudentCreateVM
    {
        public StudentCreateVM()
        {
            Genders = new List<GenderVM>();
        }
        [Required(ErrorMessage ="Student Name is required!")]
        public string StudentName { get; set; } = null!;
        [Required(ErrorMessage = "Student department is required!")]
        public string Department { get; set; } = null!;
        [Required(ErrorMessage = "Student RoleNumber is required!")]
        public string RoleNumber { get; set; } = null!;
        [Required(ErrorMessage = "Student Phone Number is required!")]
        public string PhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = "Please Select Gender!")]
        [Range(1,5)]
        public int GenderId { get; set; }
        public IEnumerable<GenderVM> Genders { get; set; }
    }
    public class StudentUpdateVM
    {
        public StudentUpdateVM()
        {
            Genders = new List<GenderVM>();
        }
        [Range(1, double.MaxValue)]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Student Name is required!")]
        public string StudentName { get; set; } = null!;
        [Required(ErrorMessage = "Student department is required!")]
        public string Department { get; set; } = null!;
        [Required(ErrorMessage = "Student RoleNumber is required!")]
        public string RoleNumber { get; set; } = null!;
        [Required(ErrorMessage = "Student Phone Number is required!")]
        public string PhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = "Please Select Gender!")]
        [Range(1, 5)]
        public int GenderId { get; set; }
        public IEnumerable<GenderVM> Genders { get; set; }
    }
}
