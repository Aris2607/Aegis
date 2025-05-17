namespace AegisTest.Helpers.Database
{
    public class DBLoader
    {
        public static string GetConnstring()
        {
            string Server = Environment.GetEnvironmentVariable("SERVER");
            string Db = Environment.GetEnvironmentVariable("NAME");
            string Connstring = $@"Server={Server};Database={Db};Trusted_Connection=True;TrustServerCertificate=True";
            Console.WriteLine("Connstring" + Connstring);
            return Connstring;

        }
    }
}