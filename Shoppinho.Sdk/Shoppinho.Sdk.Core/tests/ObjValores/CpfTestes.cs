using Bogus;
using Bogus.Extensions.Brazil;
using Shoppinho.Sdk.Core.ObjValores;
using Xunit;

namespace Shoppinho.Sdk.Core.Testes.ObjValores
{
    public sealed class CpfTestes
    {
        private readonly Faker _faker = new Faker("pt_BR");

        [Fact]
        public void DeverSerSucessoQuandoInformarCpfValido()
        {
            Cpf cpf = new(_faker.Person.Cpf());
            Assert.True(cpf.Validar());
        }

        [Theory]
        [InlineData("458.598.630-80", "45859863080")]
        [InlineData("071.596.950-11", "07159695011")]
        [InlineData("906.485.600-15", "90648560015")]
        [InlineData("390.761.120-96", "39076112096")]
        public void DeveraExtrairSomenteNumeros(string numeroCpf, string valorEsperado)
        {
            Cpf cpf = new(numeroCpf);
            Assert.Equal(valorEsperado, cpf.SomenteNumeros);
        }

        [Theory]
        [InlineData("000.111.666-777")]
        [InlineData("000.111.666-777888")]
        [InlineData("000111666777888")]
        [InlineData("0")]
        [InlineData("000.000.000-0")]
        public void DeveraFalharQuandoTamanhoDiferenteDeOnze(string cpfInvalido)
        {
            Cpf cpf = new (cpfInvalido);
            Assert.False(cpf.Validar());
        }

        [Theory]
        [InlineData("000.000.000-00")]
        [InlineData("111.111.111-11")]
        [InlineData("222.222.222-22")]
        [InlineData("333.333.333-33")]
        [InlineData("444.444.444-44")]
        [InlineData("555.555.5555.55")]
        [InlineData("666.666.666-66")]
        [InlineData("777.777.777.-77")]
        [InlineData("888.888.888-88")]
        [InlineData("999.999.999-99")]

        public void DeveraFalharQuandoTodosNumerosForemIguais(string cpfInvalido)
        {
            Cpf cpf = new (cpfInvalido);
            Assert.False(cpf.Validar());
        }

        [Theory]
        [InlineData("12345678909")]
        [InlineData("123.456.789-09")]
        public void DeveraFalharQuandoInformarSequencialInvalido(string cpfInvalido)
        {
            Cpf cpf = new (cpfInvalido);
            Assert.False(cpf.Validar());
        }

       [Fact]               
        public void DeveraFalharQuandoInformarCpfInvalido()
        {
            var numero = _faker.Person.Cpf(false); 
            int criarDigitoFake(int index) => int.Parse(numero[index].ToString()) + 1;
            numero = $"{numero.Substring(0, 8)}{criarDigitoFake(9)}{criarDigitoFake(10)}";

            Cpf cpf = new(numero);            
            Assert.False(cpf.Validar());
        }
    }
}