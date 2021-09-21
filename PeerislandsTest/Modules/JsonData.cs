using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PeerislandsTest.Modules
{
    public class JsonData
    {
        [JsonPropertyName("columns")]
        public List<Column> Columns { get; set; }
    }
    public class Column
    {
        [JsonPropertyName("operator")]
        public string Operator { get; set; }

        [JsonPropertyName("fieldName")]
        public string FieldName { get; set; }

        [JsonPropertyName("fieldValue")]
        public string FieldValue { get; set; }
    }
}
