namespace ConsoleRepo
{
 
    using ConsoleRepo.DomainObjecs;
	using Microsoft.EntityFrameworkCore;

	public partial class SchoolContext : DbContext
    {
        public SchoolContext()
            : base()
        {
        }

        public virtual DbSet<Student> Student { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=school;Trusted_Connection=True;ConnectRetryCount=0");
		}
	}
}
