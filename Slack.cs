using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Services.Slack.SlackModels;

using Newtonsoft.Json;

namespace Services.Slack
{
    public class Slack : ISlack
    {
        private readonly List<Attachment> attachments = new List<Attachment>();
        private string channel;
        private string iconEmoji;
        private string iconUrl;
        private bool mrkdwn = true;
        private IWebProxy proxy;
        private string username;
        private string webHook;

        public ISlack Attachments(List<Attachment> list)
        {
            foreach (var attachment in list)
            {
                this.attachments.Add(attachment);
            }
            return this;
        }

        public ISlack Username(string username)
        {
            this.username = username;
            return this;
        }

        public ISlack Channel(string channel)
        {
            this.channel = channel;
            return this;
        }

        public ISlack IconUrl(string iconUrl)
        {
            this.iconUrl = iconUrl;
            return this;
        }

        public ISlack IconEmoji(string iconEmoji)
        {
            this.iconEmoji = iconEmoji;
            return this;
        }

        public ISlack MrkDwn(bool mrkdwn)
        {
            this.mrkdwn = mrkdwn;
            return this;
        }

        public ISlack Webhook(string webhook)
        {
            this.webHook = webhook;
            return this;
        }

        public ISlack Proxy(IWebProxy proxy)
        {
            this.proxy = proxy;
            return this;
        }

        public async Task<HttpResponseMessage> SendAlert(string text)
        {
            var slackmessage = new SlackMessage
            {
                Text = text,
                Attachments = this.attachments,
                Channel = this.channel,
                Emoji = this.iconEmoji,
                IconUrl = this.iconUrl,
                UseMarkdown = this.mrkdwn,
                Username = this.username
            };

            var message = JsonConvert.SerializeObject(slackmessage, Formatting.Indented);

            using (var client = new HttpClient(new HttpClientHandler { Proxy = this.proxy }))
            {
                return await client.PostAsync(this.webHook, new StringContent(message, Encoding.UTF8, "application/json"));
            }
        }
    }
}