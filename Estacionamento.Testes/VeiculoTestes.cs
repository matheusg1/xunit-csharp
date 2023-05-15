using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Theory(DisplayName = "Acelera��o")]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //arrange
            var veiculo = new Veiculo();            

            //act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Acelera��o 2")]
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

        [Fact(DisplayName = "Tipo de ve�culo")]
        public void TestaTipoVeiculo()
        {
            //arrange
            var veiculo = new Veiculo();
            //act
            veiculo.Tipo = (TipoVeiculo) 0;
            //assert
            Assert.Equal("Automovel", veiculo.Tipo.ToString());
        }

        [Fact(DisplayName ="Valida nome propriet�rio",Skip ="Teste ainda n�o implementado")]
        public void ValidaNomeProprietario()
        {            
        }
    }
}
