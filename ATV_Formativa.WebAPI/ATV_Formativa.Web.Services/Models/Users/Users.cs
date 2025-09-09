using ATV_Formativa.Web.API.Models.Interfaces;

namespace ATV_Formativa.Web.API.Models.Users
{
    public class Users
    {
        public class Filter : IFilter
        {
            public Guid Id { get; set; }
            public string CodUser { get; set; }
        }
        public class Delete : IDelete
        {
            public Guid Id { get; set; }
            public string CodUser { get; set; }
        }
    }
}
