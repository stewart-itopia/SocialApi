namespace SocialApi.Models
{
  public class Invite
  {
    public int Id { get; set; }
    public int GroupCount { get; set; }
    public int ConnectionCount { get; set; }
    public int UserProfileId { get; set; }
  }
}