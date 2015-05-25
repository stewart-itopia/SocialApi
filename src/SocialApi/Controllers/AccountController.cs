using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SocialApi.Models;

namespace SocialApi.Controllers
{
  public class AccountController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET api/Account
    public IEnumerable<UserProfile> GetUserProfiles()
    {
      return db.Profiles.AsEnumerable();
    }

    // GET api/Account/5
    public UserProfile GetUserProfile(int id)
    {
      var userprofile = db.Profiles.Find(id);
      if (userprofile == null)
      {
        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
      }

      return userprofile;
    }

    // PUT api/Account/5
    public HttpResponseMessage PutUserProfile(int id, UserProfile userprofile)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      if (id != userprofile.Id)
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      db.Entry(userprofile).State = EntityState.Modified;

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

    // POST api/Account
    public HttpResponseMessage PostUserProfile(UserProfile userprofile)
    {
      if (ModelState.IsValid)
      {
        db.Profiles.Add(userprofile);
        db.SaveChanges();

        var response = Request.CreateResponse(HttpStatusCode.Created, userprofile);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = userprofile.Id}));
        return response;
      }
      return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
    }

    // DELETE api/Account/5
    public HttpResponseMessage DeleteUserProfile(int id)
    {
      var userprofile = db.Profiles.Find(id);
      if (userprofile == null)
      {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }

      db.Profiles.Remove(userprofile);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK, userprofile);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}