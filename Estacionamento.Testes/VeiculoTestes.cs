using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName = "Aceleração")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //arrange
            var veiculo = new Veiculo();
            //act
            veiculo.Acelerar(10);
            //assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Freios")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //arrange
            var veiculo = new Veiculo();
            //act
            veiculo.Frear(10);
            //assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Tipo de veículo")]
        public void TestaTipoVeiculo()
        {
            //arrange
            var veiculo = new Veiculo();
            //act
            veiculo.Tipo = (TipoVeiculo) 0;
            //assert
            Assert.Equal("Automovel", veiculo.Tipo.ToString());
        }

        [Fact(DisplayName ="Valida nome proprietário",Skip ="Teste ainda não implementado")]
        public void ValidaNomeProprietario()
        {

        }
    }
}
