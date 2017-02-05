﻿using System;
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
                string headline = "";
                string unformated = "";
                List<NEWModel.Item> headlines;
                switch (message)
                {
                    case "read headlines":
                        break;
                    case "top stories":
                        headlines = JSONConvert.localConvertXML("http://rss.nytimes.com/services/xml/rss/nyt/HomePage.xml");
                        headline = GetFirst10Items(headlines);
                        unformated = GetUnformattedFirst10Items(headlines);
                        break;
                    case "world":
                        headlines = JSONConvert.localConvertXML("http://rss.nytimes.com/services/xml/rss/nyt/World.xml");
                        headline = GetFirst10Items(headlines);
                        unformated = GetUnformattedFirst10Items(headlines);

                        break;
                    case "business":
                        headlines = JSONConvert.localConvertXML("http://rss.nytimes.com/services/xml/rss/nyt/World.xml");
                        headline = GetFirst10Items(headlines);
                        unformated = GetUnformattedFirst10Items(headlines);

                        break;
                    case "health":
                        headlines = JSONConvert.localConvertXML("http://rss.nytimes.com/services/xml/rss/nyt/World.xml");
                        headline = GetFirst10Items(headlines);
                        unformated = GetUnformattedFirst10Items(headlines);

                        break;
                    default:
                        break;
                }

                Activity reply = activity.CreateReply(headline);
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


        public string GetFirst10Items(List<NEWModel.Item> allheadlines)
        {
            string formatedString = "";
            int count = 0;
            foreach (NEWModel.Item i in allheadlines)
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
        private string GetUnformattedFirst10Items(List<NEWModel.Item> allheadlines)
        {
            string unformattedHeadlines = "";
            int count = 0;
            foreach (NEWModel.Item i in allheadlines)
            {
                if (count <= 10) { 
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