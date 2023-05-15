using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Theory(DisplayName = "Aceleração")]
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

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //arrange
            var veiculo = new Veiculo();
            //act
            veiculo.Acelerar(10);
            //assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
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

        [Fact(DisplayName ="Valida nome proprietário", Skip ="Teste ainda não implementado")]
        public void ValidaNomeProprietarioDoVeiculo()
        {
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //arrange
            var carro = new Veiculo();
            carro.Proprietario = "Carlos Silva";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "ZAP-7419";
            carro.Cor = "Verde";
            carro.Modelo = "Variante";

            //act
            string dados = carro.ToString();

            //assert
            Assert.Contains("Ficha do Veículo:", dados);

        }
    }
}
