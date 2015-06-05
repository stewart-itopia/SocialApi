using System.Collections.Generic;

namespace SocialApi.Models
{
  public class Status
  {
    public Status()
    {
      Comments = new HashSet<Comment>();
    }

    public int StatusId { get; set; }
    public string Message { get; set; }
    public byte[] Image { get; set; }
    public int ProfileId { get; set; }
    public string Title { get; internal set; }

    public virtual ICollection<Comment> Comments { get; set; }
  }
}