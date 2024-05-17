using System;
using System.Collections.Generic;

namespace MedifyMe.Models
{
    public partial class User
    {
        public int NewUserId { get; set; }
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? IsDoctor { get; set; }
        public string? Password { get; set; }
    }
}
