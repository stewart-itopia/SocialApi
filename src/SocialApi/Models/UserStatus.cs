using System.Collections.Generic;

namespace SocialApi.Models
{
  public class UserStatus
  {
    public int Id { get; set; }
    public string Message { get; set; }
    public byte[] Image { get; set; }
    public int UserProfileId { get; set; }
    public string Title { get; internal set; }

    //public virtual ICollection<Comment> Comments { get; set; }
  }
}