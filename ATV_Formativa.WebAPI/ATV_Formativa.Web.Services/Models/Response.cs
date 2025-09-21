namespace ATV_Formativa.Web.API.Models
{
    public class Response
    {
        public bool Sucess { get; set; } = true;
        public string Msg { get; set; } = "Request completed successfully";
        public int Code { get; set; } = 200;
        public string MsgException { get; set; } = string.Empty;
        public object Retorno { get; set; }
        public Response() { }
    }
}
