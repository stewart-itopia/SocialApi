namespace SocialApi.Models
{
  public class Connection
  {
    public int Id { get; set; }
    public int ConnectionCount { get; set; }
    public int GroupCount { get; set; }
    public string FavouritesCount { get; set; }
    public int UserProfileId { get; set; }
  }
}