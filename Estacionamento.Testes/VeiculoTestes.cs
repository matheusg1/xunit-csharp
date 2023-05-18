using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper mensagemConsole;
        public VeiculoTestes(ITestOutputHelper _mensagemConsole)
        {
            mensagemConsole = _mensagemConsole;
            mensagemConsole.WriteLine("construtor invocado");
            veiculo = new Veiculo();            
        }


        [Theory(DisplayName = "Aceleração")]
        [ClassData(typeof(Veiculo))]        
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //arrange
            //var veiculo = new Veiculo();            

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
            //var veiculo = new Veiculo();
            //act
            veiculo.Acelerar(10);
            //assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //arrange
            //var veiculo = new Veiculo();
            //act
            veiculo.Frear(10);
            //assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Tipo de veículo")]
        public void TestaTipoVeiculo()
        {
            //arrange
            //var veiculo = new Veiculo();
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
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //act
            string dados = veiculo.ToString();

            //assert
            Assert.Contains("Ficha do Veículo:", dados);

        }

        [Fact]
        public void TestaNomeProprietarioComMenosDeTresCaracteres()
        {
            //arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => veiculo.Proprietario = nomeProprietario
                );

        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //arrange
            string placa = "ASDF8888";
            
            //Act & Assert
            var mensagem = Assert.Throws<FormatException>(
                () => veiculo.Placa = placa
            );
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            mensagemConsole.WriteLine("dispose invocado");            
        }
    }
}
