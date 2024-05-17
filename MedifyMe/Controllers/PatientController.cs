using MedifyMe.Models;
using MedifyMe.RequestResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MedifyMe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly MedifydbContext context;

        public PatientController(MedifydbContext context)
        {
            this.context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAllPreviousAppointments(int? AppointmentId)
        {
            if(AppointmentId == null || context.Appointments == null)
            {
                return NotFound();
            }

            var Result = await context.Appointments.FindAsync(AppointmentId);
            return Ok(Result);
        }
        [HttpPost]
        public async Task<ActionResult> BookAppointmentAsync(AppointmentRequest apt)
        {
            var obj = new Appointment()
            {
                DrId=apt.DrId,
                PatientId=apt.PatientId,
                AppointmentDate = apt.AppointmentDate,
                
            };
            context.Appointments.AddAsync(obj);
            await context.SaveChangesAsync();
            return Ok(HttpStatusCode.Created);

        }

    }
}
 