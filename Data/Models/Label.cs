using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KbstAPI.Data.Models
{
    /// <summary>
    /// Contains the text and the options for this label. Used in groups
    /// </summary>
    public class Label
    {
        [JsonIgnore]
        //[ForeignKey("Group")]
        public int ID { get; set; }
        /// <summary>
        /// HTML or raw text that is to be shown for the label
        /// </summary>
        /// <example>"<h1>Example</h1>"</example>
        public string Text { get; set; } = String.Empty;

        
        public LabelOptions? Options { get; set; }

        [JsonIgnore]
        public int LabelOptionsId { get; set; }

        //public virtual Group Group { get; set; }
    }

    /// <summary>
    /// Advanced label rendering options
    /// </summary>
    public class LabelOptions
    {
        [JsonIgnore]
        public int ID { get; set; }

        /// <summary>
        /// Where, relative to the input, will the label be placed. Possible values: top, bottom, right, left
        /// </summary>
        public string Position { get; set; } = String.Empty;

        /// <summary>
        /// How to align the text inside the label container. Possible values: left, center, right
        /// </summary>
        public string Alignment { get; set;} = String.Empty;

        //[JsonIgnore]
        //public virtual PropertyRef PropertyRef { get; set; }
    }
}
