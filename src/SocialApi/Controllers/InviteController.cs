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
  public class InviteController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET api/Invite
    public IEnumerable<Invite> GetInvites()
    {
      return db.Invites.AsEnumerable();
    }

    // GET api/Invite/5
    public Invite GetInvite(int id)
    {
      var invite = db.Invites.Find(id);
      if (invite == null)
      {
        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
      }

      return invite;
    }

    // PUT api/Invite/5
    public HttpResponseMessage PutInvite(int id, Invite invite)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      if (id != invite.Id)
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      db.Entry(invite).State = EntityState.Modified;

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

    // POST api/Invite
    public HttpResponseMessage PostInvite(Invite invite)
    {
      if (ModelState.IsValid)
      {
        db.Invites.Add(invite);
        db.SaveChanges();

        var response = Request.CreateResponse(HttpStatusCode.Created, invite);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = invite.Id}));
        return response;
      }
      return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
    }

    // DELETE api/Invite/5
    public HttpResponseMessage DeleteInvite(int id)
    {
      var invite = db.Invites.Find(id);
      if (invite == null)
      {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }

      db.Invites.Remove(invite);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK, invite);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}