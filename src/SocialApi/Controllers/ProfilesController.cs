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
  public class ProfilesController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET: api/Profiles
    public IQueryable<Profile> GetProfiles()
    {
      return db.Profiles;
    }

    // GET: api/Profiles/5
    [ResponseType(typeof (Profile))]
    public async Task<IHttpActionResult> GetProfile(int id)
    {
      var profile = await db.Profiles.FindAsync(id);
      if (profile == null)
      {
        return NotFound();
      }

      return Ok(profile);
    }

    // PUT: api/Profiles/5
    [ResponseType(typeof (void))]
    public async Task<IHttpActionResult> PutProfile(int id, Profile profile)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != profile.ProfileId)
      {
        return BadRequest();
      }

      db.Entry(profile).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ProfileExists(id))
        {
          return NotFound();
        }
        throw;
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // POST: api/Profiles
    [ResponseType(typeof (Profile))]
    public async Task<IHttpActionResult> PostProfile(Profile profile)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      db.Profiles.Add(profile);
      await db.SaveChangesAsync();

      return CreatedAtRoute("DefaultApi", new {id = profile.ProfileId}, profile);
    }

    // DELETE: api/Profiles/5
    [ResponseType(typeof (Profile))]
    public async Task<IHttpActionResult> DeleteProfile(int id)
    {
      var profile = await db.Profiles.FindAsync(id);
      if (profile == null)
      {
        return NotFound();
      }

      db.Profiles.Remove(profile);
      await db.SaveChangesAsync();

      return Ok(profile);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool ProfileExists(int id)
    {
      return db.Profiles.Count(e => e.ProfileId == id) > 0;
    }
  }
}