using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatientApp.Models
{
    public class Appointments
    {

        [Key]
        public int AppointmentID { get; set; }

        //[DataType(DataType.DateTime )]
        [Required]
        [Display(Name = "Date & Time")]
        public DateTime DateTime { get; set; }

        [Required]
        public int BP { get; set; }
        public int Weight { get; set; }
        public int Temperature { get; set; }

        [Required]
        [Display(Name = "Doctor")]
        public string DoctorName { get; set; }

        [Required]
        [Display(Name = "Patient ID")]
        public int PatientID { get; set; }

        [ForeignKey("PatientID")]
        public virtual Patients Patients { get; set; }

    }
}