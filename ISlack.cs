using Services.Slack.SlackModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.Slack
{
    public interface ISlack
    {
        ISlack Attachments(List<Attachment> list);
        ISlack Username(string username);
        ISlack Channel(string channel);
        ISlack IconUrl(string iconUrl);
        ISlack IconEmoji(string iconEmoji);
        ISlack MrkDwn(bool mrkdwn);
        ISlack Webhook(string webhook);
        ISlack Proxy(IWebProxy proxy);
        Task<HttpResponseMessage> SendAlert(string text);
    }
}
