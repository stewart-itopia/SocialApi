using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SocialApi.Models;

namespace SocialApi.Controllers
{
  public class ConnectionController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET api/Connection
    public IEnumerable<Connection> GetConnections()
    {
      return db.Connections.AsEnumerable();
    }

    // GET api/Connection/5
    public Connection GetConnection(int id)
    {
      var connection = db.Connections.Find(id);
      if (connection == null)
      {
        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
      }

      return connection;
    }

    // PUT api/Connection/5
    public HttpResponseMessage PutConnection(int id, Connection connection)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      if (id != connection.Id)
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      db.Entry(connection).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK);
    }

    // POST api/Connection
    public HttpResponseMessage PostConnection(Connection connection)
    {
      if (ModelState.IsValid)
      {
        db.Connections.Add(connection);
        db.SaveChanges();

        var response = Request.CreateResponse(HttpStatusCode.Created, connection);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = connection.Id}));
        return response;
      }
      return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
    }

    // DELETE api/Connection/5
    public HttpResponseMessage DeleteConnection(int id)
    {
      var connection = db.Connections.Find(id);
      if (connection == null)
      {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }

      db.Connections.Remove(connection);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK, connection);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}