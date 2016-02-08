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
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class WebApiController : ApiController
    {
        private CategoryModel db = new CategoryModel();

        // GET: api/Api
        public IQueryable<BOOKS> GetBOOKS()
        {
            return db.BOOKS;
        }

        // GET: api/Api/5
        [ResponseType(typeof(BOOKS))]
        public IHttpActionResult GetBOOKS(int id)
        {
            BOOKS bOOKS = db.BOOKS.Find(id);
            if (bOOKS == null)
            {
                return NotFound();
            }

            return Ok(bOOKS);
        }

        // PUT: api/Api/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBOOKS(int id, BOOKS bOOKS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bOOKS.BOOKID)
            {
                return BadRequest();
            }

            db.Entry(bOOKS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BOOKSExists(id))
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

        // POST: api/Api
        [ResponseType(typeof(BOOKS))]
        public IHttpActionResult PostBOOKS(BOOKS bOOKS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BOOKS.Add(bOOKS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bOOKS.BOOKID }, bOOKS);
        }

        // DELETE: api/Api/5
        [ResponseType(typeof(BOOKS))]
        public IHttpActionResult DeleteBOOKS(int id)
        {
            BOOKS bOOKS = db.BOOKS.Find(id);
            if (bOOKS == null)
            {
                return NotFound();
            }

            db.BOOKS.Remove(bOOKS);
            db.SaveChanges();

            return Ok(bOOKS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BOOKSExists(int id)
        {
            return db.BOOKS.Count(e => e.BOOKID == id) > 0;
        }
    }
}