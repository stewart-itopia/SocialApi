namespace SocialApi.Models
{
  public class Connection
  {
    public int Id { get; set; }
    public int ConnectionCount { get; set; }
    public int GroupCount { get; set; }
    public int FavouritesCount { get; set; }
    public int UserProfileId { get; set; }
    public int GroupInvites { get; internal set; }
    public int ConnectRequests { get; internal set; }
  }
}