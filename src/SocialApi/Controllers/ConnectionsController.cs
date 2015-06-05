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
  public class ConnectionsController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET: api/Connections
    public IQueryable<Connection> GetConnections()
    {
      return db.Connections;
    }

    // GET: api/Connections/5
    [ResponseType(typeof (Connection))]
    public async Task<IHttpActionResult> GetConnection(int id)
    {
      var connection = await db.Connections.FindAsync(id);
      if (connection == null)
      {
        return NotFound();
      }

      return Ok(connection);
    }

    // PUT: api/Connections/5
    [ResponseType(typeof (void))]
    public async Task<IHttpActionResult> PutConnection(int id, Connection connection)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != connection.ConnectionId)
      {
        return BadRequest();
      }

      db.Entry(connection).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ConnectionExists(id))
        {
          return NotFound();
        }
        throw;
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // POST: api/Connections
    [ResponseType(typeof (Connection))]
    public async Task<IHttpActionResult> PostConnection(Connection connection)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      db.Connections.Add(connection);
      await db.SaveChangesAsync();

      return CreatedAtRoute("DefaultApi", new {id = connection.ConnectionId}, connection);
    }

    // DELETE: api/Connections/5
    [ResponseType(typeof (Connection))]
    public async Task<IHttpActionResult> DeleteConnection(int id)
    {
      var connection = await db.Connections.FindAsync(id);
      if (connection == null)
      {
        return NotFound();
      }

      db.Connections.Remove(connection);
      await db.SaveChangesAsync();

      return Ok(connection);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool ConnectionExists(int id)
    {
      return db.Connections.Count(e => e.ConnectionId == id) > 0;
    }
  }
}