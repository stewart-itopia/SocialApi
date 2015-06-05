using System.Data.Entity;

namespace SocialApi.Models
{
  public class SocializeContext : DbContext
  {
    //public SchoolDBContext(): base("SchoolDBConnectionString") 
    //    {
    //  Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());

    //  //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
    //  //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
    //  //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
    //}
    //public DbSet<Student> Students { get; set; }
    //public DbSet<Standard> Standards { get; set; }


    public SocializeContext() :
      base("DefaultConnection"){   }



    public DbSet<Article> Articles { get; set; }
    public DbSet<Connection> Connections { get; set; }
    public DbSet<Invite> Invites { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //base.OnModelCreating(modelBuilder);
      //modelBuilder.Entity<Student>()
      //           .HasRequired<Standard>(s => s.Standard)
      //           .WithMany(s => s.Students)
      //           .HasForeignKey(s => s.StdId);

      //one-to-many
      //modelBuilder.Entity<Standard>()
      //            .HasMany<Student>(s => s.Students)
      //            .WithRequired(s => s.Standard)
      //            .HasForeignKey(s => s.StdId);

      //one-to-many 
      //modelBuilder.Entity<Student>()
      //            .HasOptional<Standard>(s => s.Standard)
      //            .WithMany(s => s.Students)
      //            .HasForeignKey(s => s.StdId);


      //modelBuilder.Entity<Student>()
      //            .HasMany<Course>(s => s.Courses)
      //            .WithMany(c => c.Students)
      //            .Map(cs =>
      //            {
      //              cs.MapLeftKey("StudentRefId");
      //              cs.MapRightKey("CourseRefId");
      //              cs.ToTable("StudentCourse");
      //            });

      //modelBuilder.Configurations.Add(new StudentEntityConfiguration());

    }
  }

  //public class StudentEntityConfiguration : EntityTypeConfiguration<Student>
  //{
  //  public StudentEntityConfiguration()
  //  {

  //    this.ToTable("StudentInfo");

  //    this.HasKey<int>(s => s.StudentKey);


  //    this.Property(p => p.DateOfBirth)
  //            .HasColumnName("DoB")
  //            .HasColumnOrder(3)
  //            .HasColumnType("datetime2");

  //    this.Property(p => p.StudentName)
  //            .HasMaxLength(50);

  //    this.Property(p => p.StudentName)
  //            .IsConcurrencyToken();

  //    this.HasMany<Course>(s => s.Courses)
  //       .WithMany(c => c.Students)
  //       .Map(cs =>
  //       {
  //         cs.MapLeftKey("StudentId");
  //         cs.MapRightKey("CourseId");
  //         cs.ToTable("StudentCourse");
  //       });
  //  }
  //}
}