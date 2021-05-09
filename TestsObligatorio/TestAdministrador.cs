﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace TestsObligatorio
{

    [TestClass]
    public class TestAdministrador
    {

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaAlPrincipio()
        {
            AdminContras administrador = new AdminContras();
            Assert.AreEqual(true, administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Assert.AreEqual(false, administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorAgregarUsuarioSinNombre()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario();
            Assert.ThrowsException<ObjetoIncompletoException>(() => administrador.AgregarUsuario(usuario));
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConDosUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Assert.AreEqual(false, administrador.EsListaUsuariosVacia());
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.AgregarUsuario(usuario2);
            Assert.AreEqual(false, administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorPedirNombreUsuarioCorrecto()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);

            Usuario aBuscar = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual(usuario, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioPrimeroConDosAgregados()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.AgregarUsuario(usuario2);

            Usuario aBuscar = new Usuario
            {
                Nombre = "Roberto"
            };

            Assert.AreEqual(usuario, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioSegundoConDosAgregados()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.AgregarUsuario(usuario2);

            Usuario aBuscar = new Usuario
            {
                Nombre = "Pedro"
            };
            Assert.AreEqual(usuario2, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioInexistente()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.AgregarUsuario(usuario2);

            Usuario inexistente = new Usuario
            {
                Nombre = "Ernesto"
            };
            Assert.ThrowsException<ObjetoInexistenteException>(() => administrador.GetUsuario(inexistente));
        }

        [TestMethod]
        public void AdministradorVacioYaExisteUsuario()
        {
            AdminContras administrador = new AdminContras();
            Usuario buscador = new Usuario
            {
                Nombre = "Roberto"
            };

            Assert.IsFalse(administrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorYaExisteUsuarioExistente()
        {
            AdminContras administrador = new AdminContras();

            Usuario agregar = new Usuario()
            {
                Nombre = "Roberto"
            };
            
            Usuario buscador = new Usuario
            {
                Nombre = "Roberto"
            };

            administrador.AgregarUsuario(agregar);

            Assert.IsTrue(administrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorNoVacioYaExisteUsuarioNoExistente()
        {
            AdminContras administrador = new AdminContras();

            Usuario agregar = new Usuario()
            {
                Nombre = "Agregar"
            };

            Usuario buscador = new Usuario
            {
                Nombre = "Buscador"
            };

            administrador.AgregarUsuario(agregar);

            Assert.IsFalse(administrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosVacia()
        {
            AdminContras administrador = new AdminContras();

            Assert.IsNull(administrador.GetListaUsuarios());
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosNoVacia()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };
            administrador.AgregarUsuario(usuario);

            Assert.IsNotNull(administrador.GetListaUsuarios());
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosEsIgual()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };

            administrador.AgregarUsuario(usuario1);
            administrador.AgregarUsuario(usuario2);

            List<Usuario> usuariosComparar = new List<Usuario>
            {
                usuario1,
                usuario2
            };
            Assert.AreEqual(true, usuariosComparar.SequenceEqual(administrador.GetListaUsuarios())); ;
        }
    }

}
