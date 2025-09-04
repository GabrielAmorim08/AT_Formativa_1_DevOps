using ATV_Formativa.Web.API.Models;
using ATV_Formativa.Web.API.Models.Interfaces;

namespace ATV_Formativa.Web.API.Interfaces
{
    public interface IBaseService<T>
    {
        public Task<Response<List<T>>> Get(IFilter filtro);
        public Task<Response> Delete(IDelete filtro);
        public Task<Response> Create(T record);
        public Task<Response> Update(T record);
    }
}
