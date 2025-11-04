using System.Configuration;

namespace abchotel.DAL
{
    public class DatabaseHelperBase
    {
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["abchotel.Properties.Settings.Setting"].ConnectionString;
    }
}