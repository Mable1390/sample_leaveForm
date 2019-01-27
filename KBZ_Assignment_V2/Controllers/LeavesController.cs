using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using KBZ_Assignment_V2.Models;

namespace KBZ_Assignment_V2.Controllers
{
    public class LeavesController : ApiController
    {
        private KBZ_Assignment_V2Context db = new KBZ_Assignment_V2Context();

        // GET: api/Leaves
        /*
        public IQueryable<Leave> GetLeaves()
        {
            return db.Leaves.Include(b => b.Employee);
        }
        */
        public IQueryable<LeaveDTO> GetLeaves()
        {
            var leaves = from l in db.Leaves
                         select new LeaveDTO()
                         {
                             Id = l.Id,
                             EmployeeName = l.Employee.Name,
                             Date = l.Date
                         };
            return leaves;
        }

        // GET: api/Leaves/5

        /*
        [ResponseType(typeof(Leave))]
        public async Task<IHttpActionResult> GetLeave(int id)
        {
            Leave leave = await db.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            return Ok(leave);
        }
        */
        [ResponseType(typeof(LeaveDetailDTO))]
        public async Task<IHttpActionResult> GetLeave(int id)
        {
            var leave = await db.Leaves.Include(l => l.Employee).Select(l =>

            new LeaveDetailDTO()
            {
                Id = l.Id,
                Title = l.Title,
                Date = l.Date,
                Reason = l.Reason,
                EmployeeName = l.Employee.Name
            }).SingleOrDefaultAsync(l => l.Id == id);
            if (leave == null)
            {
                return NotFound();
            }
            return Ok(leave);
        }

        // PUT: api/Leaves/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLeave(int id, Leave leave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leave.Id)
            {
                return BadRequest();
            }

            db.Entry(leave).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Leaves
        /*
        [ResponseType(typeof(Leave))]
        public async Task<IHttpActionResult> PostLeave(Leave leave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Leaves.Add(leave);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = leave.Id }, leave);
        }
        */
        [ResponseType(typeof(LeaveDTO))]
        public async Task<IHttpActionResult> PostLeave (Leave leave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Leaves.Add(leave);
            await db.SaveChangesAsync();
            db.Entry(leave).Reference(x => x.Employee).Load();
            var dto = new LeaveDTO()
            {
                Id = leave.Id,
                Date = leave.Date,
                EmployeeName = leave.Employee.Name
            };
            return CreatedAtRoute("DefaultAPI", new { id = leave.Id }, dto);
        }
        // DELETE: api/Leaves/5
        [ResponseType(typeof(Leave))]
        public async Task<IHttpActionResult> DeleteLeave(int id)
        {
            Leave leave = await db.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            db.Leaves.Remove(leave);
            await db.SaveChangesAsync();

            return Ok(leave);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaveExists(int id)
        {
            return db.Leaves.Count(e => e.Id == id) > 0;
        }
    }
}