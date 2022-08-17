namespace People_Task.Common
{
    public class ConnectionStrings
    {
        public string PostgresqlConnection { get; set; }
    }

    public class Images
    {
        public string Connection { get; set; }
        public string Extensions { get; set; }
        public int MaxContentLength { get; set; }
    }

    public class Upload
    {
        public Images Images { get; set; }
    }

    public class PeopleTaskConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Upload Upload { get; set; }
    }
}