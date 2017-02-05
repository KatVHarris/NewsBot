using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBot.Models
{

    public class Rootobject
    {
        public string version { get; set; }
        public Channel channel { get; set; }
    }

    public class Channel
    {
        public string title { get; set; }
        public object[] link { get; set; }
        public object[] description { get; set; }
        public string language { get; set; }
        public string copyright { get; set; }
        public string lastBuildDate { get; set; }
        public Image image { get; set; }
        public List<Item> item { get; set; }
    }

    public class Image
    {
        public string title { get; set; }
        public string url { get; set; }
        public string link { get; set; }
    }

    public class Item
    {
        public string title { get; set; }
        public object[] link { get; set; }
        public Guid guid { get; set; }
        public Content content { get; set; }
        public string[] description { get; set; }
        public string credit { get; set; }
        public string creator { get; set; }
        public string pubDate { get; set; }
        public object category { get; set; }
    }

    public class Guid
    {
        public string isPermaLink { get; set; }
        public string text { get; set; }
    }

    public class Content
    {
        public string url { get; set; }
        public string medium { get; set; }
        public string height { get; set; }
        public string width { get; set; }
    }

}