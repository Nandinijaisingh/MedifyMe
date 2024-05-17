namespace MedifyMe.RequestResponseModels
{
    public class AppointmentRequest
    {
        public int DrId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
