using ATV_Formativa.Web.API.Interfaces.Calculadora;
using ATV_Formativa.Web.API.Interfaces.NovaPasta;
using ATV_Formativa.Web.API.Models;
using ATV_Formativa.Web.API.Models.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATV_Formativa.Web.API.Business.Calculadora
{
    public class CalculadoraBO : ICalculadoraService
    {
        public async Task<Response> Dividir(int a, int b)
        {
            Response response = new Response();

            try
            {
                if (b == 0) throw new DivideByZeroException();
                response.Retorno = a / b;
                return response;
            }
            catch (Exception ex)
            {
                response.Sucess = false;
                response.MsgException = ex.Message;
                response.Msg = "Exception";
                response.Code = 500;
                return response;
            }
        }

        public async Task<Response> EhParOuImpar(int numero)
        {
            Response response = new Response();

            try
            {
                response.Retorno = numero % 2 == 0 ? "Par" : "Impar";
                return response;
            }
            catch (Exception ex)
            {
                response.Sucess = false;
                response.MsgException = ex.Message;
                response.Msg = "Exception";
                response.Code = 500;
                return response;
            }
        }

        public async Task<Response> Multiplicar(int a, int b)
        {
            Response response = new Response();

            try
            {
                response.Retorno = a * b;
                return response;
            }
            catch (Exception ex)
            {
                response.Sucess = false;
                response.MsgException = ex.Message;
                response.Msg = "Exception";
                response.Code = 500;
                return response;
            }
        }

        public async Task<Response> Somar(int a, int b)
        {
                Response response = new Response(); 
            try
            {
                response.Retorno = a + b;
                return response;
            }
            catch (Exception ex)
            {
                response.Sucess = false;
                response.MsgException = ex.Message;
                response.Msg = "Exception";
                response.Code = 500;
                return response;
            }
        }

        public async Task<Response> Subtrair(int a, int b)
        {
            Response response = new Response();

            try
            {
                response.Retorno = a - b;
                return response;
            }
            catch (Exception ex)
            {
                response.Sucess = false;
                response.MsgException = ex.Message;
                response.Msg = "Exception";
                response.Code = 500;
                return response;
            }
        }
    }
}
