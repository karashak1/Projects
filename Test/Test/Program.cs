using System;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.Web;

namespace Test
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			string url = "http://news.google.com/?q=Disney&output=rss";
			XmlReader reader = XmlReader.Create (url);
			SyndicationFeed feed = SyndicationFeed.Load (reader);
			foreach (SyndicationItem item in feed.Items) {
				string subject = item.Title.Text;
				string summery = item.Summary.Text;
				Console.WriteLine (subject);
				foreach (SyndicationLink link in item.Links) {
					var output = link.Uri.ToString ().Split ('&');
					foreach (var part in output)
						if (part.Contains ("url=http"))
							Console.WriteLine (part.Split('=')[1]);
				}
				Console.WriteLine ();
			}

			var request = (HttpWebRequest)WebRequest.Create ("http://cs.newpaltz.edu/~plotkinm/2012Grad/Final/api/Cities.php?term");
			using (var response = (HttpWebResponse)request.GetResponse ()) {
				var output = new StreamReader(response.GetResponseStream (), Encoding.UTF8);
				Console.WriteLine (output.ReadToEnd ());


			}
		}
	}
}
