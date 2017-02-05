﻿using NewsBot.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace NewsBot.Models
{
    public static class JSONConvert
    {
        public static List<NEWModel.Item> currentHeadLineList;
        //public static List<Item> currentHeadLineList;

        public static void BuildHeadlineListFromXML(string RSSfeed)
        {
            //currentHeadLineList = new List<Item>();
            //currentHeadLineList = localConvertXML(RSSfeed);

        }
        //public static List<Item> headlinesList = new List<Item>();
        public static List<NEWModel.Item> localConvertXML(string RSSfeed)
        {

            //string jsonText = Resources.JSONTest2;
            // To convert an XML node contained in string xml into a JSON string   
            // var xmlString = GetXmlLiteralString(); // for testing

            var xmlString = GetXmlStringFromUrl(RSSfeed);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            string jsonText = JsonConvert.SerializeXmlNode(xmlDoc);
            NEWModel.Rootobject myRoot = JsonConvert.DeserializeObject<NEWModel.Rootobject>(jsonText);
            //Rootobject root = JsonConvert.DeserializeObject<Rootobject>(jsonText);
            currentHeadLineList = new List<NEWModel.Item>();
            currentHeadLineList = myRoot.rss.channel.item;
            return currentHeadLineList;

            // To convert JSON text contained in string json into an XML node
            //XmlDocument xmlDocWithJson = JsonConvert.DeserializeXmlNode(jsonString);
        }


        static string GetXmlStringFromUrl(string RSSURL)
        {
            // sample URLs
            //http://news.google.com/?output=rss
            //http://freenewsfeed.newsfactor.com/rss
            //http://feeds.feedburner.com/techulator/articles
            //http://www.feedforall.com/sample.xml
            //http://rss.cnn.com/rss/cnn_topstories.rss

            var xmlString = "";
            String UrlString = RSSURL;
            StringBuilder sb = new StringBuilder();
            XmlTextReader reader = new XmlTextReader(UrlString);

            while (reader.Read())
                sb.AppendLine(reader.ReadOuterXml());

            xmlString = sb.ToString();
            return xmlString;
        }
        static string GetXmlLiteralString()
        {
            // for testing
            var xmlString = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><rss version=\"2.0\"><channel>  <title>W3Schools Home Page</title>  <link>http://www.w3schools.com</link>  <description>Free web building tutorials</description>  <item>    <title>RSS Tutorial</title>    <link>http://www.w3schools.com/xml/xml_rss.asp</link>    <description>New RSS tutorial on W3Schools</description>  </item>  <item>    <title>XML Tutorial</title>    <link>http://www.w3schools.com/xml</link>    <description>New XML tutorial on W3Schools</description>  </item></channel></rss>";
            return xmlString;

        }
    }
}
