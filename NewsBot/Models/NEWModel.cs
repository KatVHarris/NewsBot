using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBot.Models
{
    public class NEWModel
    {

        public class Rootobject
        {
            public Rss rss { get; set; }
        }

        public class Rss
        {
            public string xmlnsdc { get; set; }
            public string xmlnsmedia { get; set; }
            public string xmlnsatom { get; set; }
            public string xmlnsnyt { get; set; }
            public string version { get; set; }
            public Channel channel { get; set; }
        }

        public class Channel
        {
            public string title { get; set; }
            public string link { get; set; }
            public AtomLink atomlink { get; set; }
            public object description { get; set; }
            public string language { get; set; }
            public string copyright { get; set; }
            public string lastBuildDate { get; set; }
            public Image image { get; set; }
            public List<Item> item { get; set; }
        }

        public class AtomLink
        {
            public string rel { get; set; }
            public string type { get; set; }
            public string href { get; set; }
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
            public string link { get; set; }
            public Guid guid { get; set; }
            public AtomLink1 atomlink { get; set; }
            public MediaContent mediacontent { get; set; }
            public string mediadescription { get; set; }
            public string mediacredit { get; set; }
            public string description { get; set; }
            public string dccreator { get; set; }
            public string pubDate { get; set; }
            public Category[] category { get; set; }
        }

        public class Guid
        {
            public string isPermaLink { get; set; }
            public string text { get; set; }
        }

        public class AtomLink1
        {
            public string rel { get; set; }
            public string href { get; set; }
        }

        public class MediaContent
        {
            public string url { get; set; }
            public string medium { get; set; }
            public string height { get; set; }
            public string width { get; set; }
        }

        public class Category
        {
            public string domain { get; set; }
            public string text { get; set; }
        }

    }
}