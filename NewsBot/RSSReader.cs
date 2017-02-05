using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;
using System.Data;
using System.Linq;
using System.Xml.Xsl;

namespace NewsBot { 

    public class RssNews
    {
        public string Title;
        public string PublicationDate;
        public string Description;
    }

    public class RssReader
    {
        public string convertRss(string url)
        {
            var s = RssReader.Read(url);
            StringBuilder sb = new StringBuilder();
            foreach (RssNews rs in s)
            {
                sb.AppendLine(rs.Title);
                sb.AppendLine(rs.PublicationDate);
                sb.AppendLine(rs.Description);
            }

            return sb.ToString();
        }

        public static List<RssNews> Read(string url)
        {
            string Password = "ABC";
            string UserAccount = "123";
            string DomainName = "XYZ";

            if (url != "")
            {
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);

                if (UserAccount != "")
                {

                    wr.Credentials = new NetworkCredential(UserAccount, Password, DomainName);

                    var webClient = new WebClient();
                    string result = webClient.DownloadString(url);
                    XDocument document = XDocument.Parse(result);

                    return (from descendant in document.Descendants("item")
                            select new RssNews()
                            {
                                Description = descendant.Element("description").Value,
                                Title = descendant.Element("title").Value,
                                PublicationDate = descendant.Element("pubDate").Value
                            }).ToList();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }

}