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
  public class StatusController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET api/Status
    public IEnumerable<UserStatus> GetUserStatus()
    {
      return db.UserStatuses.AsEnumerable();
    }

    // GET api/Status/5
    public UserStatus GetUserStatus(int id)
    {
      var userstatus = db.UserStatuses.Find(id);
      if (userstatus == null)
      {
        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
      }

      return userstatus;
    }

    // PUT api/Status/5
    public HttpResponseMessage PutUserStatus(int id, UserStatus userstatus)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      if (id != userstatus.Id)
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      db.Entry(userstatus).State = EntityState.Modified;

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

    // POST api/Status
    public HttpResponseMessage PostUserStatus(UserStatus userstatus)
    {
      if (ModelState.IsValid)
      {
        db.UserStatuses.Add(userstatus);
        db.SaveChanges();

        var response = Request.CreateResponse(HttpStatusCode.Created, userstatus);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = userstatus.Id}));
        return response;
      }
      return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
    }

    // DELETE api/Status/5
    public HttpResponseMessage DeleteUserStatus(int id)
    {
      var userstatus = db.UserStatuses.Find(id);
      if (userstatus == null)
      {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }

      db.UserStatuses.Remove(userstatus);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK, userstatus);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}