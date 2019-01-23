using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Application.Data;

namespace Application.WebApi.Controllers
{
    public class testInformationsController : ApiController
    {
        private InformationDbEntities db = new InformationDbEntities();

        // GET: api/testInformations
        public IQueryable<testInformation> GettestInformation()
        {
            return db.testInformation;
        }

        // GET: api/testInformations/5
        [ResponseType(typeof(testInformation))]
        public IHttpActionResult GettestInformation(int id)
        {
            testInformation testInformation = db.testInformation.Find(id);
            if (testInformation == null)
            {
                return NotFound();
            }

            return Ok(testInformation);
        }

        // PUT: api/testInformations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttestInformation(int id, testInformation testInformation)
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
                db.SaveChanges();
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

        // POST: api/testInformations
        [ResponseType(typeof(testInformation))]
        public IHttpActionResult PosttestInformation(testInformation testInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.testInformation.Add(testInformation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = testInformation.id }, testInformation);
        }

        // DELETE: api/testInformations/5
        [ResponseType(typeof(testInformation))]
        public IHttpActionResult DeletetestInformation(int id)
        {
            testInformation testInformation = db.testInformation.Find(id);
            if (testInformation == null)
            {
                return NotFound();
            }

            db.testInformation.Remove(testInformation);
            db.SaveChanges();

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