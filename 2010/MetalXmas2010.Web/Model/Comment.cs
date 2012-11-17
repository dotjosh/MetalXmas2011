using System.ComponentModel.DataAnnotations;

namespace MetalXmas2010.Web.Model
{
	public class Comment
	{
		[Key]
		public int CommentID { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Location { get; set; }
		[Required]
		public string Comments { get; set; }
	}
}