namespace SocialApi.Models
{
  public class Invite
  {
    public int InviteId { get; set; }
    public int GroupCount { get; set; }
    public int ConnectionCount { get; set; }
    public int ProfileId { get; set; }
  }
}