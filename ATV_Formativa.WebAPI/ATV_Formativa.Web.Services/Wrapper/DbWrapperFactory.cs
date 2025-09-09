using ATV_Formativa.WebAPI.Utils;
using ATV_Formativa.WebAPI.Wrapper.Interfaces;
using Microsoft.AspNetCore.Connections;
using static ATV_Formativa.WebAPI.Wrapper.DbWrapper;

namespace ATV_Formativa.WebAPI.Wrapper
{
    public class DbWrapperFactory : IDbWrapperFactory
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private IDbWrapper _dapperWrapper;

        public DbWrapperFactory(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public IDbWrapper CreateWrapper(Common.DataBase dataBase)
        {
            _dapperWrapper = new DbWrapper(_dbConnectionFactory, dataBase);

            return _dapperWrapper;
        }

        public void Dispose()
        {
            if (_dapperWrapper != null)
            {
                _dapperWrapper.Dispose();
            }
        }
    }
}
