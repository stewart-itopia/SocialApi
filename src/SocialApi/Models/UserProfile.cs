namespace SocialApi.Models
{
  public class UserProfile
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string EmailAddress { get; set; }
    public string CellNumber { get; set; }
    public string JobTitle { get; set; }
    public string ShortBio { get; set; }
    public string AvatarPath { get; set; }
  }
}