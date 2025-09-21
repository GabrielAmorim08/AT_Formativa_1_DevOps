using ATV_Formativa.Web.API.Models;
using ATV_Formativa.Web.API.Models.Users;

namespace ATV_Formativa.Web.API.Interfaces.Calculadora
{
    public interface ICalculadoraService
    {
        public Task<Response> Somar(int a, int b);
        public Task<Response> Dividir(int a, int b);
        public Task<Response> Subtrair(int a, int b);
        public Task<Response> Multiplicar(int a, int b);
        public Task<Response> EhParOuImpar(int numero);
    }
}
