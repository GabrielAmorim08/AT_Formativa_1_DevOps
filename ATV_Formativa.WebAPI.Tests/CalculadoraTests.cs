using System;
using ATV_Formativa.Web.API.Business.Calculadora;
using Xunit;

namespace ATV_Formativa.WebAPI.Tests
{
    public class CalculadoraTests
    {
        #region Testes de Sucesso

        [Fact]
        public async Task Somar_DeveRetornarSomaCorreta_NoObjetoResponse()
        {
            var calc = new CalculadoraBO();

            var response = await calc.Somar(10, 5);

            Assert.True(response.Sucess);
            Assert.Equal(200, response.Code);
            Assert.Equal(15, response.Retorno);
        }

        [Fact]
        public async Task Subtrair_DeveRetornarSubtracaoCorreta_NoObjetoResponse()
        {
            var calc = new CalculadoraBO();

            var response = await calc.Subtrair(10, 5);

            Assert.True(response.Sucess);
            Assert.Equal(10 - 5, response.Retorno);
        }

        [Fact]
        public async Task Multiplicar_DeveRetornarMultiplicacaoCorreta_NoObjetoResponse()
        {
            var calc = new CalculadoraBO();

            var response = await calc.Multiplicar(10, 5);

            Assert.True(response.Sucess);
            Assert.Equal(10 * 5, response.Retorno);
        }

        [Fact]
        public async Task Dividir_ComDivisorValido_DeveRetornarDivisaoCorreta()
        {
            var calc = new CalculadoraBO();

            var response = await calc.Dividir(10, 2);

            Assert.True(response.Sucess);
            Assert.Equal(200, response.Code);
            Assert.Equal(5, response.Retorno);
        }

        [Theory]
        [InlineData(10, "Par")]
        [InlineData(7, "Impar")]
        public async Task EhParOuImpar_DeveRetornarStringCorreta_NoObjetoResponse(int numero, string esperado)
        {
            var calc = new CalculadoraBO();

            var response = await calc.EhParOuImpar(numero);

            Assert.True(response.Sucess);
            Assert.Equal(esperado, response.Retorno);
        }

        #endregion

        #region Teste de Falha

        [Fact]
        public async Task Dividir_PorZero_DeveRetornarResponseDeErro()
        {
            var calc = new CalculadoraBO();

            var response = await calc.Dividir(10, 0);

            Assert.False(response.Sucess);

            Assert.Equal(500, response.Code);

            Assert.False(string.IsNullOrEmpty(response.MsgException));

            Assert.Equal("Attempted to divide by zero.",response.MsgException);
        }

        #endregion
    }
}