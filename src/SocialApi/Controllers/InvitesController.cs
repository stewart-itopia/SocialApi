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
  public class InvitesController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET: api/Invites
    public IQueryable<Invite> GetInvites()
    {
      return db.Invites;
    }

    // GET: api/Invites/5
    [ResponseType(typeof (Invite))]
    public async Task<IHttpActionResult> GetInvite(int id)
    {
      var invite = await db.Invites.FindAsync(id);
      if (invite == null)
      {
        return NotFound();
      }

      return Ok(invite);
    }

    // PUT: api/Invites/5
    [ResponseType(typeof (void))]
    public async Task<IHttpActionResult> PutInvite(int id, Invite invite)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != invite.InviteId)
      {
        return BadRequest();
      }

      db.Entry(invite).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!InviteExists(id))
        {
          return NotFound();
        }
        throw;
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // POST: api/Invites
    [ResponseType(typeof (Invite))]
    public async Task<IHttpActionResult> PostInvite(Invite invite)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      db.Invites.Add(invite);
      await db.SaveChangesAsync();

      return CreatedAtRoute("DefaultApi", new {id = invite.InviteId}, invite);
    }

    // DELETE: api/Invites/5
    [ResponseType(typeof (Invite))]
    public async Task<IHttpActionResult> DeleteInvite(int id)
    {
      var invite = await db.Invites.FindAsync(id);
      if (invite == null)
      {
        return NotFound();
      }

      db.Invites.Remove(invite);
      await db.SaveChangesAsync();

      return Ok(invite);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool InviteExists(int id)
    {
      return db.Invites.Count(e => e.InviteId == id) > 0;
    }
  }
}