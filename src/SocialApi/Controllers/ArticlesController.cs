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
  public class ArticlesController : ApiController
  {
    private readonly SocializeContext db = new SocializeContext();
    // GET: api/Articles
    public IQueryable<Article> GetArticles()
    {
      return db.Articles;
    }

    // GET: api/Articles/5
    [ResponseType(typeof (Article))]
    public async Task<IHttpActionResult> GetArticle(int id)
    {
      var article = await db.Articles.FindAsync(id);
      if (article == null)
      {
        return NotFound();
      }

      return Ok(article);
    }

    // PUT: api/Articles/5
    [ResponseType(typeof (void))]
    public async Task<IHttpActionResult> PutArticle(int id, Article article)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != article.ArticleId)
      {
        return BadRequest();
      }

      db.Entry(article).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ArticleExists(id))
        {
          return NotFound();
        }
        throw;
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // POST: api/Articles
    [ResponseType(typeof (Article))]
    public async Task<IHttpActionResult> PostArticle(Article article)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      db.Articles.Add(article);
      await db.SaveChangesAsync();

      return CreatedAtRoute("DefaultApi", new {id = article.ArticleId}, article);
    }

    // DELETE: api/Articles/5
    [ResponseType(typeof (Article))]
    public async Task<IHttpActionResult> DeleteArticle(int id)
    {
      var article = await db.Articles.FindAsync(id);
      if (article == null)
      {
        return NotFound();
      }

      db.Articles.Remove(article);
      await db.SaveChangesAsync();

      return Ok(article);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool ArticleExists(int id)
    {
      return db.Articles.Count(e => e.ArticleId == id) > 0;
    }
  }
}