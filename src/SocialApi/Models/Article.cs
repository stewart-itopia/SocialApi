using System;
using System.Collections.Generic;

namespace SocialApi.Models
{
  public class Article
  {
    public int Id { get; set; }
    //public string Title { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public int UserProfileId { get; set; }
    //public string ImagePath { get; set; }
    public int Likes { get; set; }
    //public virtual ICollection<Comment> Comments { get; set; }
    public byte[] Avatar { get;  set; }
    public int CommentsCount { get;  set; }
    public byte[] ArticleImage { get;  set; }
    public string ArticleTitle { get;  set; }
    public string ShortBio { get;  set; }
    public DateTime DatePosted { get;  set; }
    public string FullName { get;  set; }
  }
}