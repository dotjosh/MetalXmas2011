using System;
using System.Windows;
using System.Windows.Browser;
using MetalXmas2010.Web;

namespace MetalXmas2010.Core
{
	public class ServiceFactory
	{
		public static MetalXmasContext Create()
		{
			var documentUri = HtmlPage.Document.DocumentUri;
			string url = documentUri.OriginalString;
			if(!url.EndsWith("/"))
				url += "/";
			var serviceUri = new Uri(url + "MetalXmas2010-Web-MetalXmasService.svc");
			return new MetalXmasContext(serviceUri);
		}
	}
}