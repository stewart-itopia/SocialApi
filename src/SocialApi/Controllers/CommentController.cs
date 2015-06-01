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
  public class CommentController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET api/Comment
    public IEnumerable<Comment> GetComments()
    {
      return db.Comments.AsEnumerable();
    }

    // GET api/Comment/5
    public Comment GetComment(int id)
    {
      var comment = db.Comments.Find(id);
      if (comment == null)
      {
        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
      }

      return comment;
    }

    // PUT api/Comment/5
    public HttpResponseMessage PutComment(int id, Comment comment)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      if (id != comment.Id)
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      db.Entry(comment).State = EntityState.Modified;

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

    // POST api/Comment
    public HttpResponseMessage PostComment(Comment comment)
    {
      if (ModelState.IsValid)
      {
        db.Comments.Add(comment);
        db.SaveChanges();

        var response = Request.CreateResponse(HttpStatusCode.Created, comment);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = comment.Id}));
        return response;
      }
      return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
    }

    // DELETE api/Comment/5
    public HttpResponseMessage DeleteComment(int id)
    {
      var comment = db.Comments.Find(id);
      if (comment == null)
      {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }

      db.Comments.Remove(comment);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK, comment);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}