namespace PeerislandsTest.Contracts
{
    public class IQueryGenerator
    {
        public string Select { get; set; }
        public string FromTable { get; set; }
        public string Where { get; set; }
        public string GroupBy { get; set; }
        public string OrderBy { get; set; }
        public string Having { get; set; }
        public string Join { get; set; }
        public string On { get; set; }
        public string LessThen { get; set; }
        public string GreaterThen { get; set; }
        public string EqualsTo { get; set; }
        public string NotEqualsTo { get; set; }
        public string In { get; set; }
        public string Between { get; set; }
        public string And { get; set; }
        public string Or { get; set; }
    }
}
