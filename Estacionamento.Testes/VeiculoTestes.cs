using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //arrange
            var veiculo = new Veiculo();
            //act
            veiculo.Acelerar(10);
            //assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            //arrange
            var veiculo = new Veiculo();
            //act
            veiculo.Frear(10);
            //assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //arrange
            var veiculo = new Veiculo();
            //act
            veiculo.Tipo = (TipoVeiculo) 1;
            //assert
            Assert.Equal("Automovel", veiculo.Tipo.ToString());
        }
    }
}
