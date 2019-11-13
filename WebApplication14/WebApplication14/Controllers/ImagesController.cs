﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication14.DataAccess;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class ImagesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Images
        public IQueryable<Image> GetImages()
        {
            return db.Images;
        }

        // GET: api/Images/5
        [ResponseType(typeof(Image))]
        public async Task<IHttpActionResult> GetImage(string id)
        {
            Image image = await db.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        // PUT: api/Images/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutImage(string id, Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.Id)
            {
                return BadRequest();
            }

            db.Entry(image).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Images
        [ResponseType(typeof(Image))]
        public async Task<IHttpActionResult> PostImage(Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Images.Add(image);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ImageExists(image.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = image.Id }, image);
        }

        // DELETE: api/Images/5
        [ResponseType(typeof(Image))]
        public async Task<IHttpActionResult> DeleteImage(string id)
        {
            Image image = await db.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            db.Images.Remove(image);
            await db.SaveChangesAsync();

            return Ok(image);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageExists(string id)
        {
            return db.Images.Count(e => e.Id == id) > 0;
        }
    }
}