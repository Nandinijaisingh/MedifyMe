namespace MedifyMe.RequestResponseModels
{
    public class RegisterRequest
    {
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int IsDoctor { get; set; }
        public string? Password { get; set; }
    }
}
