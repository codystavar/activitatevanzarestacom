using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public static class stringconnection
    {
        // Path static
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\WinXP\\source\\repos\\Licenta\\WindowsFormsApp1\\Stacom.accdb;Persist Security Info=False;";
        //public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Stacom.accdb;Persist Security Info=False;";
        public static OleDbConnection connection = new OleDbConnection(connectionString);

        //username login
        public static string username;

    }



}
