using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SocialApi.Models;

namespace SocialApi.Controllers
{
  public class RatesController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET: api/Rates
    public IQueryable<Rate> GetRates()
    {
      return db.Rates;
    }

    // GET: api/Rates/5
    [ResponseType(typeof (Rate))]
    public async Task<IHttpActionResult> GetRate(int id)
    {
      var rate = await db.Rates.FindAsync(id);
      if (rate == null)
      {
        return NotFound();
      }

      return Ok(rate);
    }

    // PUT: api/Rates/5
    [ResponseType(typeof (void))]
    public async Task<IHttpActionResult> PutRate(int id, Rate rate)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != rate.RateId)
      {
        return BadRequest();
      }

      db.Entry(rate).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RateExists(id))
        {
          return NotFound();
        }
        throw;
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // POST: api/Rates
    [ResponseType(typeof (Rate))]
    public async Task<IHttpActionResult> PostRate(Rate rate)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      db.Rates.Add(rate);
      await db.SaveChangesAsync();

      return CreatedAtRoute("DefaultApi", new {id = rate.RateId}, rate);
    }

    // DELETE: api/Rates/5
    [ResponseType(typeof (Rate))]
    public async Task<IHttpActionResult> DeleteRate(int id)
    {
      var rate = await db.Rates.FindAsync(id);
      if (rate == null)
      {
        return NotFound();
      }

      db.Rates.Remove(rate);
      await db.SaveChangesAsync();

      return Ok(rate);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool RateExists(int id)
    {
      return db.Rates.Count(e => e.RateId == id) > 0;
    }
  }
}