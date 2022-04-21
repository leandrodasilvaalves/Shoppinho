using Bogus;
using Bogus.Extensions.Brazil;
using Shoppinho.Sdk.Core.ObjValores;
using Xunit;

namespace tests.ObjValores
{
    public class CpfTestes
    {        
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
        public void DeveraSerFalsoQuandoTamanhoDiferenteDeOnze(string cpfInvalido)
        {
            Cpf cpf = new (cpfInvalido);
            var resultado = cpf.Validar();
            Assert.False(resultado);
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

        public void DeveraSerFalsoQuandoTodosNumerosForemIguais(string cpfInvalido)
        {
            Cpf cpf = new (cpfInvalido);
            var resultado = cpf.Validar();
            Assert.False(resultado);
        }

        [InlineData("12345678909")]
        [InlineData("123.456.789-09")]
        public void DeveraSerFalsoQuandoInformarSequencialInvalido(string cpfInvalido)
        {
            Cpf cpf = new (cpfInvalido);
            var resultado = cpf.Validar();
            Assert.False(resultado);
        }

        [Fact]
        public void DeverSerValidoQuandoInformarCpfValido()
        {
            var faker = new Faker("pt_BR");        
            Cpf cpf = new(faker.Person.Cpf());                        
            var resultado = cpf.Validar();
            Assert.True(resultado);
        }

        //CPF Inválidos
        //http://www.upenet.com.br/concursos/18_prevupe/Publicacao/090618_alunos%20com%20CPF%20invalidos.pdf
        [Theory]
        [InlineData("17734532493")]        
        [InlineData("00135829304")]        
        [InlineData("12070275460")]        
        [InlineData("00138625504")]        
        [InlineData("00127436714")]        
        [InlineData("00136123694")]        
        [InlineData("13090940977")]        
        [InlineData("01303816444")]        
        [InlineData("05531808499")]                
        public void DeveraSerFalsoQuandoInformarCpfInvalido(string cpfInvalido)
        {
            Cpf cpf = new(cpfInvalido);
            var resultado = cpf.Validar();
            Assert.False(resultado);
        }
    }
}