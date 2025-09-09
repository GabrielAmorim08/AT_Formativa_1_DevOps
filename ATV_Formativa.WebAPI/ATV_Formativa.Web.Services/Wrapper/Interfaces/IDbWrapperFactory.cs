using ATV_Formativa.WebAPI.Utils;

namespace ATV_Formativa.WebAPI.Wrapper.Interfaces
{
    public interface IDbWrapperFactory : IDisposable
    {
        IDbWrapper CreateWrapper(Common.DataBase dataBase);
    }
}
