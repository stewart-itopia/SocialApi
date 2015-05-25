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
  public class RateController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET api/Rate
    public IEnumerable<RateCode> GetRateCodes()
    {
      return db.RateCodes.AsEnumerable();
    }

    // GET api/Rate/5
    public RateCode GetRateCode(int id)
    {
      var ratecode = db.RateCodes.Find(id);
      if (ratecode == null)
      {
        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
      }

      return ratecode;
    }

    // PUT api/Rate/5
    public HttpResponseMessage PutRateCode(int id, RateCode ratecode)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      if (id != ratecode.Id)
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      db.Entry(ratecode).State = EntityState.Modified;

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

    // POST api/Rate
    public HttpResponseMessage PostRateCode(RateCode ratecode)
    {
      if (ModelState.IsValid)
      {
        db.RateCodes.Add(ratecode);
        db.SaveChanges();

        var response = Request.CreateResponse(HttpStatusCode.Created, ratecode);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = ratecode.Id}));
        return response;
      }
      return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
    }

    // DELETE api/Rate/5
    public HttpResponseMessage DeleteRateCode(int id)
    {
      var ratecode = db.RateCodes.Find(id);
      if (ratecode == null)
      {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }

      db.RateCodes.Remove(ratecode);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK, ratecode);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}