using System.Data.Entity;

namespace MetalXmas2010.Web.Model
{
	public class MetalXmasDbContext : DbContext
	{
		public DbSet<Comment> Comments { get; set; }
	}
}