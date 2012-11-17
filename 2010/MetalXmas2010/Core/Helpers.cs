using System;
using System.Windows.Browser;

namespace MetalXmas2010.Core
{
	public class Helpers
	{
		public static Uri GetSongUrl(string relativeUrl)
		{
			var documentUri = HtmlPage.Document.DocumentUri;
			return new Uri("http://" + documentUri.Host + ":" + documentUri.Port + documentUri.LocalPath + relativeUrl);
		}
	}
}