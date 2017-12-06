using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Services.Slack.SlackModels
{
    [DataContract(Name = "message")]
    public class SlackMessage
    {
        /// <summary>
        /// message text to display
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// more options in message, see Attachment Class for properties
        /// </summary>
        [DataMember(Name = "attachments", IsRequired = false)]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// You can override a custom integration's configured name with the username field in your JSON payload.
        /// </summary>
        [DataMember(Name = "username", IsRequired = false, EmitDefaultValue = false)]
        public string Username { get; set; }

        /// <summary>
        /// ou can override a custom integration's configured channel by specifying the channel field in your JSON payload.
        /// A public channel can be specified with "channel": "#other-channel", and a Direct Message with "channel": "@username".
        /// </summary>
        [DataMember(Name = "channel", IsRequired = false, EmitDefaultValue = false)]
        public string Channel { get; set; }

        /// <summary>
        /// icon url
        /// </summary>
        [DataMember(Name = "icon_url", IsRequired = false, EmitDefaultValue = false)]
        public string IconUrl { get; set; }

        /// <summary>
        /// You can also override the bot icon either with icon_emoji
        /// use one emoji from the emoji class
        /// </summary>
        [DataMember(Name = "icon_emoji", IsRequired = false, EmitDefaultValue = false)]
        public string Emoji { get; set; }

        /// <summary>
        /// If you just want to turn Slack's markdown-like processing off so that all those characters (`*_```~) do nothing,
        /// include the mrkdwn attribute with a false value:
        /// {
        /// "mrkdwn": false,
        /// "text": "*This will not be bold.* It will be surrounded gloriously with stars."
        /// }
        /// (Message Builder Example)
        /// If you want to reinforce the default behavior explicitly, add a mrkdwn field to your message JSON and set it to true.
        /// The attribute mrkdwn is missing vowels because our markup language is not quite markdown but something quite like it.
        /// </summary>
        [DataMember(Name = "mrkdwn", IsRequired = false, EmitDefaultValue = false)]
        public bool UseMarkdown { get; set; }
    }
}