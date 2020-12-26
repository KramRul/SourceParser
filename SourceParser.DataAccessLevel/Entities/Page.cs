namespace SourceParser.DataAccessLevel.Entities
{
    public class Page : BaseEntity
    {
        public string CountOfPages { get; set; }
        public string PageFirst { get; set; }
        public string PageLast { get; set; }
    }
}