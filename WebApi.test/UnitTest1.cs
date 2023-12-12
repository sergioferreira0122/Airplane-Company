using webAPI.Application.Services;
using webAPI.Models;


namespace WebApi.test
{
    public class UnitTest1
    {

        Calculos calculos = new Calculos();

        [Fact]
        public void CalcularDuracaoViagemTest()
        {
            DateTime dataPartida = new DateTime(2023, 6, 15);
            DateTime dataChegada = new DateTime(2023, 6, 20);
            int expectavel = 5;

            int dias = calculos.CalcularDuracaoViagem(dataPartida, dataChegada);


            Assert.Equal(expectavel, dias);

        }

        [Fact]
        public void CalcularDescontoCompraTest()
        {
            var travel = new Travel
            {
                Client = Enumerable.Repeat(new Client(), 20).ToList(), //Nesta linha de c�digo estamos a criar uma lista que contem 20 inst�ncias de 'Client'
                Destination = new Destination { Price = 100 }
            };
            double expectedRes = 85;

            var result = calculos.CalcularDescontoCompra(travel);

            Assert.Equal(expectedRes, result);
        }

        [Fact]
        public void CalcularPrecoTotalViagemTest()
        {
            var travel = new Travel
            {
                Client = Enumerable.Repeat(new Client(), 20).ToList(), //Nesta linha de c�digo estamos a criar uma lista que contem 20 inst�ncias de 'Client'
                Destination = new Destination { Price = 100 }
            };
            double precoExpectavel = 2000;

            var preco = calculos.CalcularPrecoTotalViagem(travel);

            Assert.Equal(precoExpectavel, preco);
        }
    }
}