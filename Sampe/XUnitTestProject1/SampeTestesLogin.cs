using Sampe;
using Xunit;


namespace SampeTeste
{
    public class SampeTestesLogin
    {
        [Fact(DisplayName = nameof(LoginDadosValidos))]
        public void LoginDadosValidos()
        {
            var login = new Login();
            login.Senha = "123456";
            login.User = "Wesley";
            login.LoginId = 1;
            Assert.Equal("123456", login.Senha);
            Assert.Equal("Wesley", login.User);
            Assert.Equal(1, login.LoginId);




        }
        [Fact(DisplayName = nameof(LoginSenhaVazio))]
        public void LoginSenhaVazio()
        {
            var login = new Login();
            // login.Senha = "123456";
            login.User = "Wesley";
            login.LoginId = 1;
            Assert.Equal("123456", login.Senha);
            Assert.Equal("Wesley", login.User);
            Assert.Equal(1, login.LoginId);
        }
        [Fact(DisplayName = nameof(LoginSenhaErrado))]
        public void LoginSenhaErrado()
        {
            var login = new Login();
            login.Senha = "123456";
            login.User = "Wesley";
            login.LoginId = 1;
            //Assert.Equal("123456", login.Senha);
            Assert.Equal("169845", login.Senha);
            Assert.Equal("Wesley", login.User);
            Assert.Equal(1, login.LoginId);
        }
        [Fact(DisplayName = nameof(LoginNaoCadastrado))]
        public void LoginNaoCadastrado()
        {
            var login = new Login();
            login.Senha = "123456";
            login.User = "Wesley";
            login.LoginId = 1;
            Assert.Equal("123456", login.Senha);
            Assert.Equal("Ana", login.User);
            //Assert.Equal("Wesley", login.User);
            Assert.Equal(1, login.LoginId);

        }
        [Fact(DisplayName = nameof(LoginUserVazio))]
        public void LoginUserVazio()
        {
            var login = new Login();
            login.Senha = "123456";
            //login.User = "Wesley";
            login.LoginId = 1;
            Assert.Equal("123456", login.Senha);
            Assert.Equal("Wesley", login.User);
            Assert.Equal(1, login.LoginId);
        }

    }
}