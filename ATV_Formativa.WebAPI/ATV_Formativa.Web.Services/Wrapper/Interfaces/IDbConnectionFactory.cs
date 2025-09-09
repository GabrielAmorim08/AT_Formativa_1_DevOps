using ATV_Formativa.WebAPI.Utils;
using System.Data;

namespace ATV_Formativa.WebAPI.Wrapper.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection(Common.DataBase dataBase);
    }

    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection(Common.DataBase dataBase)
        {
            return Common.GetConnection(dataBase);
        }
    }
}
