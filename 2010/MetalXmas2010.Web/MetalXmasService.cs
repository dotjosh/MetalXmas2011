
using MetalXmas2010.Web.Model;

namespace MetalXmas2010.Web
{
	using System.Linq;
	using System.ServiceModel.DomainServices.Hosting;
	using System.ServiceModel.DomainServices.Server;

	[EnableClientAccess()]
	public class MetalXmasService : DomainService
	{
		private readonly MetalXmasDbContext _dbContext;

		public MetalXmasService()
		{
			_dbContext = new MetalXmasDbContext();
		}

		public IQueryable<Comment> GetComments()
		{
			return _dbContext.Comments;
		}

		public void InsertComment(Comment comment)
		{
			_dbContext.Comments.Add(comment);
		}

		public override bool Submit(ChangeSet changeSet)
		{
			var submitResult = false;

			try
			{
				submitResult = base.Submit(changeSet);
				_dbContext.SaveChanges();
			}
			catch
			{
			}

			return false;
		}
	}
}


