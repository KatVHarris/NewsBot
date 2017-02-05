using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using System.Collections.Generic;
using NewsBot.Models;

namespace NewsBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                //// calculate something for us to return
                //int length = (activity.Text ?? string.Empty).Length;


                //// return our reply to the user

                //await Conversation.SendAsync(activity, () => new QueryDialog());

                var message = activity.Text;
                string unformated = "";

                List<NytTopModel.Item> topHeadlines;
                List<NytWorldModel.Item> worldHeadlines;
                string topHeadline = "";
                string worldHeadline = "";

                Activity reply = null;

                switch (message)
                {
                    case "read headlines":
                        break;
                    case "top stories":
                        topHeadlines = JSONConvert.ConvertTopXml("http://rss.nytimes.com/services/xml/rss/nyt/HomePage.xml");
                        topHeadline = GetFirst10TopItems(topHeadlines);
                        unformated = GetUnformattedFirst10TopItems(topHeadlines);
                        reply = activity.CreateReply(topHeadline);
                        break;
                    case "world":
                        worldHeadlines = JSONConvert.ConvertWorldXml("http://rss.nytimes.com/services/xml/rss/nyt/World.xml");
                        worldHeadline = GetFirst10WorldItems(worldHeadlines);
                        unformated = GetUnformattedFirst10WorldItems(worldHeadlines);
                        reply = activity.CreateReply(worldHeadline);
                        break;
                    case "business":
                        //headlines = JSONConvert.localConvertXML("http://rss.nytimes.com/services/xml/rss/nyt/World.xml");
                        //headline = GetFirst10Items(headlines);
                        //unformated = GetUnformattedFirst10Items(headlines);

                        break;
                    case "health":
                        //headlines = JSONConvert.localConvertXML("http://rss.nytimes.com/services/xml/rss/nyt/World.xml");
                        //headline = GetFirst10Items(headlines);
                        //unformated = GetUnformattedFirst10Items(headlines);

                        break;
                    default:
                        break;
                }

                if (reply != null)
                    await connector.Conversations.ReplyToActivityAsync(reply);

                var bingClientTTS = new TTSSample.Program();
                bingClientTTS.PlayVoice(unformated);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }


        public string GetFirst10TopItems(List<NytTopModel.Item> allheadlines)
        {
            string formatedString = "";
            int count = 0;
            foreach (NytTopModel.Item i in allheadlines)
            {
                if (count < 10)
                {
                    formatedString = formatedString + "* " + i.title + " \n ";
                    count++;
                }
                else
                    break;
            }
            return formatedString;
        }
        public string GetFirst10WorldItems(List<NytWorldModel.Item> allheadlines)
        {
            string formatedString = "";
            int count = 0;
            foreach (NytWorldModel.Item i in allheadlines)
            {
                if (count < 10)
                {
                    formatedString = formatedString + "* " + i.title + " \n ";
                    count++;
                }
                else
                    break;
            }
            return formatedString;
        }

        public void TalkToUser(string headline)
        {
            //Speak aloud the results
            var bingClientTTS = new TTSSample.Program();
            bingClientTTS.PlayVoice(headline);


        }
        private string GetUnformattedFirst10TopItems(List<NytTopModel.Item> allheadlines)
        {
            string unformattedHeadlines = "";
            int count = 0;
            foreach (NytTopModel.Item i in allheadlines)
            {
                if (count <= 10)
                {
                    unformattedHeadlines = unformattedHeadlines + i.title + ", ";
                    count++;
                }
                else
                    break;
            }
            return unformattedHeadlines;
        }
        private string GetUnformattedFirst10WorldItems(List<NytWorldModel.Item> allheadlines)
        {
            string unformattedHeadlines = "";
            int count = 0;
            foreach (NytWorldModel.Item i in allheadlines)
            {
                if (count <= 10)
                {
                    unformattedHeadlines = unformattedHeadlines + i.title + ", ";
                    count++;
                }
                else
                    break;
            }
            return unformattedHeadlines;
        }
    }
}