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
    public class HolidaysController : ApiController
    {
        private KBZ_Assignment_V2Context db = new KBZ_Assignment_V2Context();

        // GET: api/Holidays
        public IQueryable<Holiday> GetHolidays()
        {
            return db.Holidays;
        }

        // GET: api/Holidays/5
        [ResponseType(typeof(Holiday))]
        public async Task<IHttpActionResult> GetHoliday(int id)
        {
            Holiday holiday = await db.Holidays.FindAsync(id);
            if (holiday == null)
            {
                return NotFound();
            }

            return Ok(holiday);
        }

        // PUT: api/Holidays/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHoliday(int id, Holiday holiday)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != holiday.Id)
            {
                return BadRequest();
            }

            db.Entry(holiday).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidayExists(id))
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

        // POST: api/Holidays
        [ResponseType(typeof(Holiday))]
        public async Task<IHttpActionResult> PostHoliday(Holiday holiday)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Holidays.Add(holiday);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = holiday.Id }, holiday);
        }

        // DELETE: api/Holidays/5
        [ResponseType(typeof(Holiday))]
        public async Task<IHttpActionResult> DeleteHoliday(int id)
        {
            Holiday holiday = await db.Holidays.FindAsync(id);
            if (holiday == null)
            {
                return NotFound();
            }

            db.Holidays.Remove(holiday);
            await db.SaveChangesAsync();

            return Ok(holiday);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HolidayExists(int id)
        {
            return db.Holidays.Count(e => e.Id == id) > 0;
        }
    }
}