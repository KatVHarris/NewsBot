using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBot.Models
{
    public class RSSCNNModel
    {
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("pubDate")]
        public string pubDate { get; set; }
        [JsonProperty("link")]
        public string link { get; set; }
        [JsonProperty("guid")]
        public string guid { get; set; }
        [JsonProperty("author")]
        public string author { get; set; }
        [JsonProperty("thumnail")]
        public string thumbnail { get; set; }
        [JsonProperty("description")]
        public string desription { get; set; }


        //        "items": [
        //{
        //"title": "Breaking: Homeland Security suspends travel ban"
        //"pubDate": "2017-02-04 18:01:15"
        //"link": "http://rss.cnn.com/~r/rss/cnn_topstories/~3/qo6sG4Fse2A/index.html"
        //"guid": "http://www.cnn.com/2017/02/03/politics/federal-judge-temporarily-halts-trump-travel-ban-nationwide-ag-says/index.html"
        //"author": ""
        //"thumbnail": ""
        //"description": "A federal judge in Washington State granted a temporary restraining order Friday night that the state's attorney general said immediately halted President Donald Trump's immigration executive order effective nationwide.<div class="feedflare"> <a href="http://rss.cnn.com/~ff/rss/cnn_topstories?a=qo6sG4Fse2A:5pp2Rz3nRm0:yIl2AUoC8zA"><img src="http://feeds.feedburner.com/~ff/rss/cnn_topstories?d=yIl2AUoC8zA" border="0"></a> <a href="http://rss.cnn.com/~ff/rss/cnn_topstories?a=qo6sG4Fse2A:5pp2Rz3nRm0:7Q72WNTAKBA"><img src="http://feeds.feedburner.com/~ff/rss/cnn_topstories?d=7Q72WNTAKBA" border="0"></a> <a href="http://rss.cnn.com/~ff/rss/cnn_topstories?a=qo6sG4Fse2A:5pp2Rz3nRm0:V_sGLiPBpWU"><img src="http://feeds.feedburner.com/~ff/rss/cnn_topstories?i=qo6sG4Fse2A:5pp2Rz3nRm0:V_sGLiPBpWU" border="0"></a> <a href="http://rss.cnn.com/~ff/rss/cnn_topstories?a=qo6sG4Fse2A:5pp2Rz3nRm0:qj6IDK7rITs"><img src="http://feeds.feedburner.com/~ff/rss/cnn_topstories?d=qj6IDK7rITs" border="0"></a> <a href="http://rss.cnn.com/~ff/rss/cnn_topstories?a=qo6sG4Fse2A:5pp2Rz3nRm0:gIN9vFwOqvQ"><img src="http://feeds.feedburner.com/~ff/rss/cnn_topstories?i=qo6sG4Fse2A:5pp2Rz3nRm0:gIN9vFwOqvQ" border="0"></a> </div> <img src="http://feeds.feedburner.com/~r/rss/cnn_topstories/~4/qo6sG4Fse2A" height="1" width="1" alt=""> "
        //"content": "A federal judge in Washington State granted a temporary restraining order Friday night that the state's attorney general said immediately halted President Donald Trump's immigration executive order effective nationwide.<div class="feedflare"> <a href="http://rss.cnn.com/~ff/rss/cnn_topstories?a=qo6sG4Fse2A:5pp2Rz3nRm0:yIl2AUoC8zA"><img src="http://feeds.feedburner.com/~ff/rss/cnn_topstories?d=yIl2AUoC8zA" border="0"></a> <a href="http://rss.cnn.com/~ff/rss/cnn_topstories?a=qo6sG4Fse2A:5pp2Rz3nRm0:7Q72WNTAKBA"><img src="http://feeds.feedburner.com/~ff/rss/cnn_topstories?d=7Q72WNTAKBA" border="0"></a> <a href="http://rss.cnn.com/~ff/rss/cnn_topstories?a=qo6sG4Fse2A:5pp2Rz3nRm0:V_sGLiPBpWU"><img src="http://feeds.feedburner.com/~ff/rss/cnn_topstories?i=qo6sG4Fse2A:5pp2Rz3nRm0:V_sGLiPBpWU" border="0"></a> <a href="http://rss.cnn.com/~ff/rss/cnn_topstories?a=qo6sG4Fse2A:5pp2Rz3nRm0:qj6IDK7rITs"><img src="http://feeds.feedburner.com/~ff/rss/cnn_topstories?d=qj6IDK7rITs" border="0"></a> <a href="http://rss.cnn.com/~ff/rss/cnn_topstories?a=qo6sG4Fse2A:5pp2Rz3nRm0:gIN9vFwOqvQ"><img src="http://feeds.feedburner.com/~ff/rss/cnn_topstories?i=qo6sG4Fse2A:5pp2Rz3nRm0:gIN9vFwOqvQ" border="0"></a> </div> <img src="http://feeds.feedburner.com/~r/rss/cnn_topstories/~4/qo6sG4Fse2A" height="1" width="1" alt=""> "
        //"enclosure": {
        //"link": "http://i2.cdn.turner.com/cnnnext/dam/assets/170204111249-03-airport-protest-dca-0201-super-169.jpg"
        //}

    }

    public class RSSCNNModelList
    {
        [JsonProperty("item")]
        public string id { get; set; }

    }


}