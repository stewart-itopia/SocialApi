using System;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialApi.Controllers;
using SocialApi.Models;

namespace SocialApi.Tests.Controllers
{
  [TestClass]
  public class AccountControllerTest
  {

    [TestMethod]
    public void GetUserProfilesTest()
    {
      //Given I have users in the database
      AccountController controller = new AccountController();

      //When I get users 
      var users = controller.GetUserProfiles();

      //Then at leaset one user must be returned
      Assert.IsTrue(users.Any(), "No user was returned");
    }


    [TestMethod]
    public void GetUserProfileTest()
    {
      //Given
      AccountController controller = new AccountController();
      //UserProfile newUser = new UserProfile()
      //{
      //  FirstName = "Test",
      //  Surname = "Test",
      //  Avatar = "img/mcfly.jpg",
      //  CellNumber = "0722846658",
      //  EmailAddress = "stewart@itopia.co.za",
      //  JobTitle = "Developer",
      //  ShortBio = "Developer out of Cape Town",
      //  Title = "Mr"
      //};

    //var response  =  controller.PostUserProfile(newUser);
      //When

      //Then

      UserProfile profile = new UserProfile();

      Assert.IsTrue(profile.Id != 0, "No user was returned");
    }

    [TestMethod]
    public void PutUserProfileTest()
    {
      //Given
      AccountController controller = new AccountController();
      //When

      //Then
    }

    [TestMethod]
    public void PostUserProfileTest()
    {
      //Given
      AccountController controller = new AccountController();
      //UserProfile newUser = new UserProfile()
      //{
      //  FirstName = "Test",
      //  Surname = "Test",
      //  AvatarPath = "img/mcfly.jpg",
      //  CellNumber = "0722846658",
      //  EmailAddress = "stewart@itopia.co.za",
      //  JobTitle = "Developer",
      //  ShortBio = "Developer out of Cape Town",
      //  Title = "Mr"
      //};
      //When
      //var response = controller.PostUserProfile(newUser);

      //Then
      //Assert.AreEqual(response.StatusCode ,HttpStatusCode.Created, "User was not added");
    }

    [TestMethod]
    public void DeleteUserProfileTest()
    {
      //Given
      AccountController controller = new AccountController();
      //When

      //Then
    }
  }
}
