using System;
using System.Collections.Generic;

namespace SocialApi.Models
{
  public class Article
  {
    public Article()
    {
      Comments = new HashSet<Comment>();
    }

    public int ArticleId { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public int ProfileId { get; set; }
    public int Likes { get; set; }
    public byte[] Avatar { get; set; }
    public int CommentsCount { get; set; }
    public byte[] ArticleImage { get; set; }
    public string ArticleTitle { get; set; }
    public string ShortBio { get; set; }
    public DateTime DatePosted { get; set; }
    public string FullName { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
    public virtual Profile Profile { get; set; }
  }
}