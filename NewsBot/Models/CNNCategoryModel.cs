using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBot.Models
{
    /*
    public class Rootobject
    {
        [JsonProperty("rss")]
        public Rss rss { get; set; }
    }

    public class Rss
    {
        [JsonProperty("@xmlns:dc")]
        public string xmlnsdc { get; set; }
        [JsonProperty("@xmlns:content")]
        public string xmlnscontent { get; set; }
        [JsonProperty("@xmlns:atom")]
        public string xmlnsatom { get; set; }
        [JsonProperty("@xmlns:media")]
        public string xmlnsmedia { get; set; }
        [JsonProperty("@xmlns:feedburner")]
        public string xmlnsfeedburner { get; set; }
        [JsonProperty("version")]
        public string version { get; set; }
        [JsonProperty("channel")]
        public Channel channel { get; set; }
    }


    public class Channel
    {
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("link")]
        public string link { get; set; }
        [JsonProperty("image")]
        public Image image { get; set; }
        [JsonProperty("generator")]
        public string generator { get; set; }
        [JsonProperty("lastBuildDate")]
        public string lastBuildDate { get; set; }
        [JsonProperty("pubDate")]
        public string pubDate { get; set; }
        [JsonProperty("copyright")]
        public string copyright { get; set; }
        [JsonProperty("language")]
        public string language { get; set; }
        [JsonProperty("ttl")]
        public string ttl { get; set; }
        [JsonProperty("atom10link")]
        public Atom10Link[] atom10link { get; set; }
        [JsonProperty("feeburnerinfo")]
        public FeedburnerInfo feedburnerinfo { get; set; }
        [JsonProperty("thespringboxskin")]
        public ThespringboxSkin thespringboxskin { get; set; }
        [JsonProperty("item")]
        public List<Item> item { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public string title { get; set; }
        public string link { get; set; }
    }

    public class FeedburnerInfo
    {
        public string uri { get; set; }
    }

    public class ThespringboxSkin
    {
        public string xmlnsthespringbox { get; set; }
        public string text { get; set; }
    }

    public class Atom10Link
    {
        public string xmlnsatom10 { get; set; }
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Item
    {
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("link")]
        public string link { get; set; }
        [JsonProperty("guid")]
        public Guid guid { get; set; }
        [JsonProperty("pubDate")]
        public string pubDate { get; set; }
        [JsonProperty("mediagroup")]
        public MediaGroup mediagroup { get; set; }
        [JsonProperty("feedburnerorgLink")]
        public string feedburnerorigLink { get; set; }
    }

    public class Guid
    {
        public string isPermaLink { get; set; }
        public string text { get; set; }
    }

    public class MediaGroup
    {
        public MediaContent[] mediacontent { get; set; }
    }

    public class MediaContent
    {
        public string medium { get; set; }
        public string url { get; set; }
        public string height { get; set; }
        public string width { get; set; }
    }
    */
}