using System.Data.SqlClient;

namespace ATV_Formativa.WebAPI.Utils
{
    public class Common
    {
        public static string? ConnDB = "";

        public enum DataBase
        {
            ConnDB = 1,
            ConnDB_IFS = 2,
            ConnDB_Tableau = 3
        }
        public static SqlConnection GetConnection(DataBase db)
        {
            SqlConnection? retorno = null;
            retorno = new SqlConnection(Common.ConnDB);
            retorno.Open();
            return retorno;
        }
    }
}
