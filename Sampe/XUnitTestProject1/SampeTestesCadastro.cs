using System;
using Xunit;
using Sampe.Controllers;
using Sampe.Models;
using Sampe;
using dn32.infraestrutura.Fabrica;

namespace SampeTeste
{
    public class SampeTestesCadastro
    {


        [Fact(DisplayName = nameof(CadastroDadosValidos))]
        public void CadastroDadosValidos()
        {


            var cargo = new Cargo();
            cargo.NomeCargo = "Administrador";
            cargo.CargoId = 1;
            cargo.DescricaoCargo = "Uhum";
            Assert.Equal("Administrador", cargo.NomeCargo);
            Assert.Equal("Uhum", cargo.DescricaoCargo);
            Assert.Equal(1, cargo.CargoId);

            var usuario = new Usuario();
            usuario.Login = "Sileisa";
            usuario.NomeUsuario = "Sileisa";
            usuario.SobrenomeUsuario = "Alexandrino";
            usuario.Senha = "123456";
            usuario.Hierarquia = "Acesso Total";
            usuario.UsuarioId = 1;
            usuario.Cargo = cargo;
            Assert.Equal("Sileisa", usuario.NomeUsuario);
            Assert.Equal("Alexandrino", usuario.SobrenomeUsuario);
            Assert.Equal("Sileisa", usuario.Login);
            Assert.Equal("123456", usuario.Senha);
            Assert.Equal("Acesso Total", usuario.Hierarquia);
            Assert.Equal(usuario.Cargo, cargo);

            var maquina = new Maquina();
            maquina.MaquinaId = 1;
            maquina.NomeMaquina = "Injetora 1";
            Assert.Equal(1, maquina.MaquinaId);
            Assert.Equal("Injetora 1", maquina.NomeMaquina);

            var molde = new Molde();
            molde.MoldeId = 1;
            molde.NomeMolde = "Anel";
            molde.Cavidade = 10;
            Assert.Equal(1, molde.MoldeId);
            Assert.Equal("Anel", molde.NomeMolde);

            // Id inválido
            /*var molde = new Molde();
           molde.MoldeId = "Sil";
           molde.NomeMolde = "Anel";
           molde.Cavidade = 10;
           Assert.Equal(1,molde.MoldeId);
           Assert.Equal("Anel",molde.NomeMolde);*/
            // Atributos vazios
            /*var molde = new Molde();            
           molde.NomeMolde = "";          
            Assert.Equal(1,molde.MoldeId);
            Assert.Equal("Anel",molde.NomeMolde);*/

            var atividadeOS = new AtividadeOS();
            atividadeOS.AtividadeOSId = 1;
            atividadeOS.NomeAtvOs = "remover pino extrator";
            Assert.Equal(1, atividadeOS.AtividadeOSId);
            Assert.Equal("remover pino extrator", atividadeOS.NomeAtvOs);

            var atividadeTM = new AtividadeTM();
            atividadeTM.AtividadeTMId = 1;
            atividadeTM.NomeAtvTm = "kgngkjdg";
            Assert.Equal(1, atividadeTM.AtividadeTMId);
            Assert.Equal("kgngkjdg", atividadeTM.NomeAtvTm);
        }

        [Fact(DisplayName = nameof(CadastroNomeESobrenomeVazio))]
        public void CadastroNomeESobrenomeVazio()
        {
            var usuario = new Usuario();
            var cargo = new Cargo();
            cargo.NomeCargo = "Administrador";
            cargo.CargoId = 1;
            cargo.DescricaoCargo = "Uhum";
            usuario.Login = "Sileisa";
            usuario.Senha = "123456";
            usuario.Hierarquia = "Acesso Total";
            usuario.UsuarioId = 1;
            usuario.Cargo = cargo;
            Assert.Equal("Sileisa", usuario.NomeUsuario);
            Assert.Equal("Alexandrino", usuario.SobrenomeUsuario);
            Assert.Equal("Sileisa", usuario.Login);
            Assert.Equal("123456", usuario.Senha);
            Assert.Equal("Acesso Total", usuario.Hierarquia);
            Assert.Equal(usuario.Cargo, cargo);

        }
        [Fact(DisplayName = nameof(HierarquiaVazio))]
        public void HierarquiaVazio()
        {
            var cargo = new Cargo();
            cargo.NomeCargo = "Administrador";
            cargo.CargoId = 1;
            cargo.DescricaoCargo = "Uhum";
            var usuario = new Usuario();
            usuario.Login = "Sileisa";
            usuario.NomeUsuario = "Sileisa";
            usuario.SobrenomeUsuario = "Alexandrino";
            usuario.Senha = "123456";
            usuario.Hierarquia = "";
            usuario.UsuarioId = 1;
            usuario.Cargo = cargo;
            Assert.Equal("Sileisa", usuario.NomeUsuario);
            Assert.Equal("Alexandrino", usuario.SobrenomeUsuario);
            Assert.Equal("Sileisa", usuario.Login);
            Assert.Equal("123456", usuario.Senha);
            Assert.Equal("Acesso Total", usuario.Hierarquia);
            Assert.Equal(usuario.Cargo, cargo);
        }
        [Fact(DisplayName = nameof(CadastroCargoVazio))]
        public void CadastroCargoVazio()
        {
            var cargo = new Cargo();
            cargo.NomeCargo = "Administrador";
            cargo.CargoId = 1;
            cargo.DescricaoCargo = "Uhum";
            var usuario = new Usuario();
            usuario.Login = "Sileisa";
            usuario.NomeUsuario = "Sileisa";
            usuario.SobrenomeUsuario = "Alexandrino";
            usuario.Senha = "123456";
            usuario.Hierarquia = "";
            usuario.UsuarioId = 1;          
            Assert.Equal("Sileisa", usuario.NomeUsuario);
            Assert.Equal("Alexandrino", usuario.SobrenomeUsuario);
            Assert.Equal("Sileisa", usuario.Login);
            Assert.Equal("123456", usuario.Senha);
            Assert.Equal("Acesso Total", usuario.Hierarquia);
            Assert.Equal(usuario.Cargo, cargo);
        }
      /*  [Fact(DisplayName = nameof(CadastroNomeESobrenomeDuplicado))]
        public void CadastroNomeESobrenomeDuplicado()
        {

        }*/
     }
}
