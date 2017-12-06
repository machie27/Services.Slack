using System.Runtime.Serialization;

namespace Services.Slack.SlackModels
{
    [DataContract]
    public class Field
    {
        /// <summary>
        /// Shown as a bold heading above the value text. It cannot contain markup and will be escaped for you.
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false, IsRequired = false)]
        public string Title { get; set; }

        /// <summary>
        /// he text value of the field. It may contain standard message markup and must be escaped as normal. May be multi-line.
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false, IsRequired = false)]
        public string Value { get; set; }

        /// <summary>
        /// An optional flag indicating whether the value is short enough to be displayed side-by-side with other values.
        /// </summary>
        [DataMember(Name = "short", EmitDefaultValue = false, IsRequired = false)]
        public bool Short { get; set; }
    }
}
