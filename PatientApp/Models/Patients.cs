using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientApp.Models
{
    public class Patients
    {
        public Patients()
        {
           
            this.Appointments = new List<Appointments>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PatientID { get; set; }

        [Required]
        [RegularExpression(@"^(([A-Za-z]+[\s]{1}[A-Za-z]+)|([A-Za-z]+[\s]{1}[A-Za-z]+[\s]{1}[A-Za-z]+)|([A-Za-z]+))$", ErrorMessage="Please enter upper and lower case alphabets only")]
        [Display(Name = "Patient Name")]
        [StringLength(255)]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        public int Age { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [StringLength(50)]
        [RegularExpression(@"^[\+][9][1][\-\s]?[1-9]\d{9}$|^[0][1-9]\d{9}$|^[1-9]\d{9}$", ErrorMessage= "Enter mobile no. in one of these formats: +91-7876765456|+91 7876765456| 07876765456| 7876765456")]
        public string MobileNumber { get; set; }

        [Required]
        [StringLength(1000)]
        public string Address { get; set; }
        
        public virtual ICollection<Appointments> Appointments { get; set; }

    }
}