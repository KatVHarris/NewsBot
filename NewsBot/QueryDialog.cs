using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Collections;
using NewsBot.Models;

namespace NewsBot
{
    [Serializable]
    public class QueryDialog : IDialog<object>
    {
        public List<string> CategoryList = new List<string>();

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            string headline ="";
            string unformated = "";
            switch (message.Text)
            {
                case "read headlines":
                    break;
                case "top stories":
                    //List<NytTopModel.Item> headlines = JSONConvert.localConvertXML("http://rss.cnn.com/rss/cnn_topstories.rss");
                    //headline = GetFirst10Items(headlines);
                    //unformated = GetUnformattedFirst10Items(headlines);
                    //TalkToUser(context,unformated);
                    break;
                case "world":
                    //getRSSFeed("world");
                    List<NytWorldModel.Item> headlines = JSONConvert.localConvertXML("http://rss.cnn.com/rss/cnn_topstories.rss");
                    headline = GetFirst10Items(headlines);
                    unformated = GetUnformattedFirst10Items(headlines);
                    TalkToUser(context, unformated);

                    break;
                case "business":
                    //getRSSFeed("business");

                    break;
                case "health":
                    //getRSSFeed("health");

                    break;
                default:
                    break;
            }

            //RssReader reader = new RssReader();
            //string x = reader.convertRss(message.Text);
            await context.PostAsync(headline);
            context.Wait(MessageReceivedAsync);
           
        }

        private string GetUnformattedFirst10Items(List<NytWorldModel.Item> allheadlines)
        {
            string unformattedHeadlines = "";
            foreach (NytWorldModel.Item i in allheadlines)
            {
                unformattedHeadlines = unformattedHeadlines + i.title + ", ";
            }
            return unformattedHeadlines;
        }

        public void TalkToUser(IDialogContext context, string headline)
        {
            //Speak aloud the results
            var bingClientTTS = new TTSSample.Program();
            bingClientTTS.PlayVoice(headline);


        }

        public string GetFirst10Items(List<NytWorldModel.Item> allheadlines)
        {
            string formatedString = "";
            foreach (NytWorldModel.Item i in allheadlines)
            {
                formatedString = formatedString + "* "+ i.title + " \n ";
            }
            return formatedString;
        }
    }


}