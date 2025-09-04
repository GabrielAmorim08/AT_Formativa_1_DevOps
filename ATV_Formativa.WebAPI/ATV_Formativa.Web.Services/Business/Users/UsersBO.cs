using ATV_Formativa.Web.API.Interfaces.NovaPasta;
using ATV_Formativa.Web.API.Models;
using ATV_Formativa.Web.API.Models.Interfaces;

namespace ATV_Formativa.Web.API.Business.Users
{
    public class UsersBO : IUsersService
    {
        public Task<Response> Create(Models.Users.Users record)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Delete(IDelete filtro)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Models.Users.Users>>> Get(IFilter filtro)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Models.Users.Users record)
        {
            throw new NotImplementedException();
        }
    }
}
