using System;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Xml;

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
					Console.WriteLine (link.Uri.ToString());
				}
				Console.WriteLine ();
			}
		}
	}
}
