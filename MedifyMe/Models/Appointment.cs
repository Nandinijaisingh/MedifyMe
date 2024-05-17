using System;
using System.Collections.Generic;

namespace MedifyMe.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int? DrId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}
