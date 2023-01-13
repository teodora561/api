using KbstAPI.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KbstAPI.Core.Props
{
    public class Property
    {
        public int ID { get; set; }
        public string? Label { get; set; }

        public object? Value { get; set; } 

        public bool Visible { get; set; }

        public bool Editable { get; set; }

        public PropertyType PropertyType { get; set; }  
        


    }

    //public class PropertyConverter : JsonConverter<Property>
    //{
    //    public override Property? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void Write(Utf8JsonWriter writer, Property value, JsonSerializerOptions options)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
