using System;
using System.Collections.Generic;

namespace MedifyMe.Models
{
    public partial class Diagnosis
    {
        public int DiagnosisId { get; set; }
        public int? PatientId { get; set; }
        public string? Diagnosis1 { get; set; }
        public int? AppointmentId { get; set; }
    }
}
