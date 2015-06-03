using SocialApi.Models;

namespace SocialApi.Migrations
{
  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.IO;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<SocializeContext>
    {
    private byte[] articleImage;
    private byte[] avatar;
    private byte[] statusImage;

    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
      AutomaticMigrationDataLossAllowed = true;
      avatar = File.ReadAllBytes(@"D:\Work\Git\socialize-app\src\SocializeApp\www\img\mcfly.jpg");
      articleImage = File.ReadAllBytes(@"D:\Work\Git\socialize-app\src\SocializeApp\www\img\delorean.jpg");
      statusImage = File.ReadAllBytes(@"D:\Work\Git\socialize-app\src\SocializeApp\www\img\dookie.jpg");
    }

        protected override void Seed(SocializeContext context)
        {
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data. E.g.
      //
      //    context.People.AddOrUpdate(
      //      p => p.FullName,
      //      new Person { FullName = "Andrew Peters" },
      //      new Person { FullName = "Brice Lambson" },
      //      new Person { FullName = "Rowan Miller" }
      //    );
      //
      var statuses = new List<UserStatus>()
      {
        new UserStatus()
        {
          Message = "Nine Inch Nails",
          Image = statusImage,
          Title = "Pretty Hate Machine"
        },
         new UserStatus()
        {
          Message = "Nine Inch Nails",
          Image = statusImage,
          Title = "Pretty Hate Machine"
        }
         ,
         new UserStatus()
        {
          Message = "Nine Inch Nails",
          Image = statusImage,
          Title = "Pretty Hate Machine"
        }
         ,
         new UserStatus()
        {
          Message = "Nine Inch Nails",
          Image = statusImage,
          Title = "Pretty Hate Machine"
        }
         ,
         new UserStatus()
        {
          Message = "Nine Inch Nails",
          Image = statusImage,
          Title = "Pretty Hate Machine"
        }
         ,
         new UserStatus()
        {
          Message = "Nine Inch Nails",
          Image = statusImage,
          Title = "Pretty Hate Machine"
        }
         ,
         new UserStatus()
        {
          Message = "Nine Inch Nails",
          Image = statusImage,
          Title = "Pretty Hate Machine"
        }
         ,
         new UserStatus()
        {
          Message = "Nine Inch Nails",
          Image = statusImage,
          Title = "Pretty Hate Machine"
        }
         ,
         new UserStatus()
        {
          Message = "Nine Inch Nails",
          Image = statusImage,
          Title = "Pretty Hate Machine"
        }
      };

      var rates = new RateCode()
      {
        SharePrice = "43.55",
        MaxIncomeCode = "S5S3TZZYJYJYJJJYJJJHJHH3L993JJHHXFF",
        FairburnCapitalCode = "VVXB7 UZ3MS TJWHC CCMMM",
        MoneyMarketRate = "6.08",
        DateUpdated = DateTime.Now
      };

      var connections = new Connection()
      {
        ConnectionCount = 0,
        GroupCount = 0,
        FavouritesCount = 0,
        GroupInvites = 0,
        ConnectRequests = 0
      };

      var user = new UserProfile()
      {
        Title = "Mr",
        FirstName = "Stewart",
        Surname = "Mbofana",
        EmailAddress = "stewart@itopia.co.za",
        CellNumber = "0605279774",
        JobTitle = "Developer",
        ShortBio = "Short Bio",
        Avatar = avatar,
        DateCreated = DateTime.Now
      };

      var articles = new List<Article>()
      {
        new Article()
        {
          Avatar = avatar,
          FullName = "Stewart",
          DatePosted = DateTime.Now,
          ShortBio = "Nine Inch Nails",
          ArticleTitle = "Pretty Hate Machine",
          ArticleImage = articleImage,
          Summary = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text.",
          Body = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text. The footer consists of tabs, icons aligned left, within the card-footer.",
          Likes = 1,
          CommentsCount = 0
        },
         new Article()
        {
          Avatar = avatar,
          FullName = "Stewart",
          DatePosted = DateTime.Now,
          ShortBio = "Nine Inch Nails",
          ArticleTitle = "Pretty Hate Machine",
          ArticleImage = articleImage,
          Summary = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text.",
          Body = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text. The footer consists of tabs, icons aligned left, within the card-footer.",
          Likes = 1,
          CommentsCount = 0
        }
         ,
          new Article()
        {
          Avatar = avatar,
          FullName = "Stewart",
          DatePosted = DateTime.Now,
          ShortBio = "Nine Inch Nails",
          ArticleTitle = "Pretty Hate Machine",
          ArticleImage = articleImage,
          Summary = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text.",
          Body = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text. The footer consists of tabs, icons aligned left, within the card-footer.",
          Likes = 1,
          CommentsCount = 0
        },

           new Article()
        {
          Avatar = avatar,
          FullName = "Stewart",
          DatePosted = DateTime.Now,
          ShortBio = "Nine Inch Nails",
          ArticleTitle = "Pretty Hate Machine",
          ArticleImage = articleImage,
          Summary = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text.",
          Body = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text. The footer consists of tabs, icons aligned left, within the card-footer.",
          Likes = 1,
          CommentsCount = 0
        },
            new Article()
        {
          Avatar = avatar,
          FullName = "Stewart",
          DatePosted = DateTime.Now,
          ShortBio = "Nine Inch Nails",
          ArticleTitle = "Pretty Hate Machine",
          ArticleImage = articleImage,
          Summary = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text.",
          Body = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text. The footer consists of tabs, icons aligned left, within the card-footer.",
          Likes = 1,
          CommentsCount = 0
        },
             new Article()
        {
          Avatar = avatar,
          FullName = "Stewart",
          DatePosted = DateTime.Now,
          ShortBio = "Nine Inch Nails",
          ArticleTitle = "Pretty Hate Machine",
          ArticleImage = articleImage,
          Summary = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text.",
          Body = @"This is a Facebook styled Card. The header is created from a Thumbnail List item, the content is from a card-body consisting of an image and paragraph text. The footer consists of tabs, icons aligned left, within the card-footer.",
          Likes = 1,
          CommentsCount = 0
        }

      };

      articles.ForEach(a => context.Articles.AddOrUpdate(a));
      statuses.ForEach(s => context.UserStatuses.AddOrUpdate(s));
      context.RateCodes.AddOrUpdate(rates);
      context.Profiles.AddOrUpdate(user);
      context.Connections.AddOrUpdate(connections);
      context.SaveChanges(); 
        }
    }
}
