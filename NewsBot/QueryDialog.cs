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
            switch (message.Text)
            {
                case "read headlines":
                    break;
                case "top stories":
                    List<Item> headlines = JSONConvert.localConvertXML("http://rss.cnn.com/rss/cnn_topstories.rss");
                    headline = GetFirst10Items(headlines);
                    break;
                case "world":
                    //getRSSFeed("world");

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

        public string GetFirst10Items(List<Item> allheadlines)
        {
            string formatedString = "";
            foreach (Item i in allheadlines)
            {
                formatedString = formatedString + "* "+ i.title + " \n\n ";
            }
            return formatedString;
        }
    }


}