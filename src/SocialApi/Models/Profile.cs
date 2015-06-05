using System;
using System.Collections.Generic;

namespace SocialApi.Models
{
  public class Profile
  {
    public Profile()
    {
      Comments = new List<Comment>();
      Articles = new List<Article>();
      Statuses = new List<Status>();
      Connections = new List<Connection>();
    }

    public int ProfileId { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string EmailAddress { get; set; }
    public string CellNumber { get; set; }
    public string JobTitle { get; set; }
    public string ShortBio { get; set; }
    public byte[] Avatar { get; set; }
    public DateTime DateCreated { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Article> Articles { get; set; }
    public virtual ICollection<Status> Statuses { get; set; }
    public virtual ICollection<Connection> Connections { get; set; }
  }
}