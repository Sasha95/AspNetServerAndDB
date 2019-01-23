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
using Application.Data;

namespace Application.WebApi.Controllers
{
    public class testInformationsAsyncController : ApiController
    {
        private InformationDbEntities db = new InformationDbEntities();

        // GET: api/testInformationsAsync
        public IQueryable<testInformation> GettestInformation()
        {
            return db.testInformation;
        }

        // GET: api/testInformationsAsync/5
        [ResponseType(typeof(testInformation))]
        public async Task<IHttpActionResult> GettestInformation(int id)
        {
            testInformation testInformation = await db.testInformation.FindAsync(id);
            if (testInformation == null)
            {
                return NotFound();
            }

            return Ok(testInformation);
        }

        // PUT: api/testInformationsAsync/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttestInformation(int id, testInformation testInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testInformation.id)
            {
                return BadRequest();
            }

            db.Entry(testInformation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testInformationExists(id))
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

        // POST: api/testInformationsAsync
        [ResponseType(typeof(testInformation))]
        public async Task<IHttpActionResult> PosttestInformation(testInformation testInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.testInformation.Add(testInformation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = testInformation.id }, testInformation);
        }

        // DELETE: api/testInformationsAsync/5
        [ResponseType(typeof(testInformation))]
        public async Task<IHttpActionResult> DeletetestInformation(int id)
        {
            testInformation testInformation = await db.testInformation.FindAsync(id);
            if (testInformation == null)
            {
                return NotFound();
            }

            db.testInformation.Remove(testInformation);
            await db.SaveChangesAsync();

            return Ok(testInformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool testInformationExists(int id)
        {
            return db.testInformation.Count(e => e.id == id) > 0;
        }
    }
}