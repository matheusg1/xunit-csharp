using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {
        private Patio estacionamento;
        private Veiculo veiculo;
        public ITestOutputHelper mensagemConsole;

        public PatioTestes(ITestOutputHelper _mensagemConsole)
        {
            estacionamento = new Patio();
            veiculo = new Veiculo();
            mensagemConsole = _mensagemConsole;
            mensagemConsole.WriteLine("construtor invocado");
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Junior";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Andre", "ASD-1498", "Preto", "Gol")]
        [InlineData("Jose", "POL-9242", "Cinza", "Fusca")]
        [InlineData("Maria", "GDR-6524", "Azul", "Opala")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);

        }

        [Theory(DisplayName ="Localiza veiculo")]
        [InlineData("Andre", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoPatioPeloIdDoTicket(string proprietario, string placa, string cor, string modelo)
        {
            //arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //assert
            Assert.Contains("### Ticket Estacionamento Alura", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Jose";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";
            veiculo.Placa = "ZXC-8524";

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Jose";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Opala";
            veiculoAlterado.Placa = "ZXC-8524";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //act
            Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            mensagemConsole.WriteLine("dispose invocado");
        }
    }
}
