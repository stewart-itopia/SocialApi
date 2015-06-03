using System;

namespace SocialApi.Models
{
  public class Comment
  {
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int ArticleId { get; set; }
    public string Message { get; set; }

    public DateTime DatePosted { get; set; }
    //public virtual Article Article { get; set; }
  }
}