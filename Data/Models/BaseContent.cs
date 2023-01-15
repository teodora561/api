using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations.Schema;

namespace KbstAPI.Data.Models
{
    public class BaseContent
    {
        public int ID {get; set;}
        [JsonConverter(typeof(StringEnumConverter))]
        public ContentType Type { get; set; }

        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }

        [ForeignKey("LayoutSectionId")]
        public int? LayoutSectionId { get; set; }

    }

    /// <summary>
    /// Acts as a container around other groups and properties
    /// </summary>

    public class Group : BaseContent
    {
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Decides how the contents are rendered. In a row or in a column.
        /// </summary>
        public string Direction { get; set; } = String.Empty;

        /// <summary>
        /// Depending on the render direction, it will set a gap in that axis
        /// </summary>
        public int Gap { get; set; }

        /// <summary>
        /// Recursive list of other content
        /// </summary>
        public ICollection<BaseContent> Content { get; set; }

        public Label? Label { get; set; }

        public int LabelId { get; set; }

    }

    /// <summary>
    /// Acts as a reference to some property. This decides which property is rendered here.
    /// </summary>

    public class PropertyRef : BaseContent
    {

        /// <summary>
        /// The property key of the property being referenced here. It must actually exist in the properties dict
        /// </summary>
        public string Ref { get; set; } = String.Empty;

        /// <summary>
        /// Additional options for rendering the label.
        /// Unlike the group, the text for the label is taken from the property, and here we just have
        /// some additional info.
        /// </summary>
        public LabelOptions? LabelOptions { get; set; }

        public int LabelOptionsId { get; set; }
    }

    public enum ContentType
    {
        Group,
        Property
    }
}
