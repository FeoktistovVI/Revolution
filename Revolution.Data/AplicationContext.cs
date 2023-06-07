using Microsoft.EntityFrameworkCore;

namespace Revolution.Data;


    public class AplicationContext: DbContext
    {
        public AplicationContext()
        {
        
        }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;" +
                                       "Port=5432;" +
                                       "Database=revolution;" +
                                       "Username=postgres;" +
                                       "Password=1");
        public DbSet<Area> Areas { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventsResult> EventsResults { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        //dotnet tool install --global dotnet-ef
        //dotnet ef migrations add 'begin'
        //dotnet ef database update

        
        
    
        /*protected override void OnModelCreating(ModelBuilder model)
        {
           
      /*      new UserMap(model.Entity<User>());
            new PersonMap(model.Entity<Person>());
            new CardMap(model.Entity<Card>());
            new MailTokenMap(model.Entity<MailToken>());
            new DiscountMap(model.Entity<Discount>()); #1#
           /* base.OnModelCreating(model);#1#
        }*/
    }
