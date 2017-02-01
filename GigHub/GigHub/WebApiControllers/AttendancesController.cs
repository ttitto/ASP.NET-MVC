using System.Linq;
using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.WebApiControllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext context;

        public AttendancesController()
        {
            this.context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (this.context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {
                return BadRequest("The attendance already exists.");
            }

            var attendance = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = User.Identity.GetUserId()
            };
            this.context.Attendances.Add(attendance);
            this.context.SaveChanges();

            return this.Ok();
        }
    }
}
