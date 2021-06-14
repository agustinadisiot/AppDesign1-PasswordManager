using LogicaDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsObligatorio
{
    [TestClass]
    public class TestUsuarioClave
    {
        private ControladoraUsuario controladoraUsuario;
        private ControladoraCategoria controladoraCategoria;
        private ControladoraAdministrador controladoraAdministrador;

        private Usuario usuario;
        private Usuario usuario2;
        private Usuario usuario3;
        private Categoria categoria1;
        private Categoria categoria2;
        private Clave clave1;
        private Clave clave2;
        private Clave clave3;
        private Clave clave4;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            controladoraUsuario = new ControladoraUsuario();
            controladoraCategoria = new ControladoraCategoria();
            controladoraAdministrador = new ControladoraAdministrador();
            controladoraAdministrador.BorrarTodo();

            usuario = new Usuario()
            {
                Nombre = "Usuario1",
                ClaveMaestra = "Hola12345"
            };

            usuario2 = new Usuario()
            {
                Nombre = "Usuario2",
                ClaveMaestra = "Chau12345"
            };

            usuario3 = new Usuario()
            {
                Nombre = "Usuario3"
            };

            categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };

            clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto",
                Nota = ""
            };

            clave2 = new Clave()
            {
                Sitio = "Netflix.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88",
                Nota = "Nota de una clave"
            };

            clave3 = new Clave()
            {
                Sitio = "youtube.com",
                Codigo = "codrojo",
                UsuarioClave = "Hernesto",
                Nota = ""
            };

            clave4 = new Clave()
            {
                Sitio = "www.hbo.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo",
                Nota = ""
            };

            controladoraAdministrador.AgregarUsuario(usuario);

        }

        [TestMethod]
        public void UsuarioYaExisteClaveUnaCategoriaSiExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1,usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            Clave claveIgual = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave,
                Codigo = clave1.Codigo
            };
            Assert.AreEqual(true, controladoraUsuario.YaExisteClave(claveIgual,usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveMismoUsuarioDiferenteSitio()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            Clave claveDiferenteSitio = new Clave()
            {
                Sitio = "www.youtube.com",
                UsuarioClave = clave1.UsuarioClave,
                Codigo = clave1.Codigo
            };
            Assert.AreEqual(false, controladoraUsuario.YaExisteClave(claveDiferenteSitio, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveMismoSitioDiferenteUsuario()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            Clave claveDiferenteUsuario = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = "222222",
                Codigo = clave1.Codigo
            };
            Assert.AreEqual(false, controladoraUsuario.YaExisteClave(claveDiferenteUsuario, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveDiferentesCodigos()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            Clave claveDiferenteCodigo = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave,
                Codigo = "12345678"
            };
            Assert.AreEqual(true, controladoraUsuario.YaExisteClave(claveDiferenteCodigo, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveDosCategoriasSiExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria2, usuario);

            Clave claveIgual = new Clave()
            {
                Sitio = clave2.Sitio,
                UsuarioClave = clave2.UsuarioClave,
                Codigo = clave2.Codigo,
                Nota = ""
            };
            Assert.AreEqual(true, controladoraUsuario.YaExisteClave(claveIgual, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarClave()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            Assert.AreEqual(true, controladoraUsuario.YaExisteClave(clave1, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarClaveSinCategoria()
        {
            Assert.ThrowsException<CategoriaInexistenteException>(() => controladoraUsuario.AgregarClave(clave1, categoria1, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarClaveSinSitioOAplicacion()
        {
            Clave claveSinSitio = new Clave()
            {
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraUsuario.AgregarClave(claveSinSitio, buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarClaveSinCodigo()
        {
            Clave claveSinCodigo = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111"
            };

            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraUsuario.AgregarClave(claveSinCodigo, buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarClaveSinUsuario()
        {
            Clave claveSinUsuario = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                Codigo = "12345678"
            };
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraUsuario.AgregarClave(claveSinUsuario, buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarClaveRepetida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            controladoraUsuario.AgregarClave(clave1, buscadora, usuario);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraUsuario.AgregarClave(clave1, buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarClaveCategoriaConClave()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            controladoraUsuario.AgregarClave(clave1, buscadora, usuario);

            Categoria resultado = controladoraUsuario.GetCategoria(buscadora, usuario);

            Assert.AreEqual(true, controladoraCategoria.YaExisteClave(clave1,resultado));
        }

        [TestMethod]
        public void UsuarioBorrarClaveSinCategorias()
        {
            Assert.ThrowsException<CategoriaInexistenteException>(() => controladoraUsuario.BorrarClave(clave1, usuario));
        }

        [TestMethod]
        public void UsuarioBorrarClaveSinClaves()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraUsuario.BorrarClave(clave1, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveBorrada()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            Clave aBorrar = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio
            };

            controladoraUsuario.BorrarClave(clave1, usuario);
            Assert.IsFalse(controladoraUsuario.YaExisteClave(clave1,usuario));
        }

        [TestMethod]
        public void UsuarioBorrarClaveYYaExisteClaveRestante()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            Clave aBorrar = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio
            };

            controladoraUsuario.BorrarClave(clave1, usuario);
            Assert.IsTrue(controladoraUsuario.YaExisteClave(clave2, usuario));
        }

        [TestMethod]
        public void UsuarioGetClaveCorrecta()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(clave1, controladoraUsuario.GetClave(claveBuscadora, usuario));
        }

        [TestMethod]
        public void UsuarioaGetClavePrimeraConDosClaves()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(clave1, controladoraUsuario.GetClave(claveBuscadora, usuario)); ;
        }

        [TestMethod]
        public void UsuarioaGetClaveSegundaConDosClaves()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave2.Sitio,
                UsuarioClave = clave2.UsuarioClave
            };

            Assert.AreEqual(clave2, controladoraUsuario.GetClave(claveBuscadora, usuario));
        }

        [TestMethod]
        public void UsuarioaGetClaveATravesDeClaveSinCodigo()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(clave1.Codigo, controladoraUsuario.GetClave(claveBuscadora, usuario).Codigo);
        }

        [TestMethod]
        public void UsuarioaGetClaveInexistente()
        {
            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraUsuario.GetClave(clave1, usuario));
        }

        [TestMethod]
        public void UsuarioModificarClaveNoExistente()
        {
            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = clave1,
                ClaveNueva = clave1,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria1
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraUsuario.ModificarClave(parametros,usuario));
        }

        [TestMethod]
        public void UsuarioAlModificarClaveAgregadaLaClaveViejaDejaDeExistir()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            Clave buscadora = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio
            };


            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = buscadora,
                ClaveNueva = clave2,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria1
            };

            controladoraUsuario.ModificarClave(parametros, usuario);
            Assert.IsFalse(controladoraUsuario.YaExisteClave(buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioModificarClaveYaExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            Clave duplicada = new Clave()
            {
                UsuarioClave = clave2.UsuarioClave,
                Sitio = clave2.Sitio,
                Codigo = "33333333",
                Nota = "Otra Nota"
            };

            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = clave1,
                ClaveNueva = duplicada,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria1
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraUsuario.ModificarClave(parametros, usuario));
        }

        [TestMethod]
        public void UsuarioModificarClaveMoverACategoriaNoExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = clave1,
                ClaveNueva = clave1,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria2
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => controladoraUsuario.ModificarClave(parametros, usuario));
        }

        [TestMethod]
        public void UsuarioModificarClaveMoverACategoriaExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = clave1,
                ClaveNueva = clave2,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria2
            };

            controladoraUsuario.ModificarClave(parametros, usuario);
            Clave buscadora = new Clave()
            {
                UsuarioClave = clave2.UsuarioClave,
                Sitio = clave2.Sitio
            };

            Clave resultado = controladoraUsuario.GetClave(buscadora,usuario);

            Categoria categoriaFinal = controladoraUsuario.GetCategoriaClave(buscadora,usuario);

            bool igualSitio = resultado.Sitio == clave2.Sitio;
            bool igualUsuario = resultado.UsuarioClave == clave2.UsuarioClave;
            bool igualNota = resultado.Nota == clave2.Nota;
            bool igualClave = resultado.Codigo == clave2.Codigo;

            bool igualesDatos = igualSitio && igualUsuario && igualNota && igualClave;
            bool igualCategoria = categoria2 == categoriaFinal;

            Assert.IsTrue(igualesDatos && igualCategoria);
        }

        [TestMethod]
        public void UsuarioGetListaClavesUnaCategoria()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            List<Clave> claves = new List<Clave>
            {
                clave1,
                clave2
            };

            List<Clave> getListaClaves = controladoraUsuario.GetListaClaves(usuario);

            bool getListaClavesContieneLasClaves = getListaClaves.All(claves.Contains);
            bool lasClavesContieneGetListaClaves = claves.All(getListaClaves.Contains);

            Assert.IsTrue(getListaClavesContieneLasClaves && lasClavesContieneGetListaClaves);
        }

        [TestMethod]
        public void UsuarioGetListaClavesDosCategorias()
        {
            controladoraUsuario.AgregarCategoria(categoria1,usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave3, categoria2, usuario);
            controladoraUsuario.AgregarClave(clave4, categoria2, usuario);

            List<Clave> claves = new List<Clave>
            {
                clave1,
                clave2,
                clave3,
                clave4
            };

            List<Clave> getListaClaves = controladoraUsuario.GetListaClaves(usuario);

            bool getListaClavesContieneLasClaves = getListaClaves.All(claves.Contains);
            bool lasClavesContieneGetListaClaves = claves.All(getListaClaves.Contains);

            Assert.IsTrue(getListaClavesContieneLasClaves && lasClavesContieneGetListaClaves);
        }

        [TestMethod]
        public void UsuarioGetCantidadColorRojo()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave3, categoria1, usuario);

            List<Clave> getListaClaves = controladoraUsuario.GetListaClaves(usuario);
            int cantidadRojas = 0;
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();
            foreach (Clave clave in getListaClaves)
            {
                if (nivelSeguridad.GetNivelSeguridad(clave.Codigo).Equals(color.Rojo)) cantidadRojas++;
            }

            Assert.AreEqual(cantidadRojas, controladoraUsuario.GetCantidadColor(color.Rojo, usuario));
        }

        [TestMethod]
        public void UsuarioGetCantidadColor()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);


            List<Clave> getListaClaves = controladoraUsuario.GetListaClaves(usuario);
            ColorNivelSeguridad colores = new ColorNivelSeguridad();
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            string color = colores.VerdeClaro;
            int cantidadColor = 0;
            foreach (Clave clave in getListaClaves)
            {
                if (nivelSeguridad.GetNivelSeguridad(clave.Codigo) == color) cantidadColor++;
            }

            Assert.AreEqual(cantidadColor, controladoraUsuario.GetCantidadColor(color, usuario));
        }

        [TestMethod]
        public void UsuarioGetListaClavesColorEsVacia()
        {
            int cantidadRojas = 0;
            ColorNivelSeguridad color = new ColorNivelSeguridad();
            Assert.AreEqual(cantidadRojas, controladoraUsuario.GetListaClavesColor(color.Rojo, usuario).Count);
        }

        [TestMethod]
        public void UsuarioGetListaClavesColorNoVaciaUnaCategoria()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            clave1.Codigo = "EstaEsUnaClave12@";
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            List<Clave> clavesVerdes = new List<Clave>
            {
                clave1
            };

            ColorNivelSeguridad color = new ColorNivelSeguridad();
            List<Clave> getListaClavesVerdes = controladoraUsuario.GetListaClavesColor(color.VerdeOscuro, usuario);

            bool getListaClavesContieneLasClavesVerdes = getListaClavesVerdes.All(clavesVerdes.Contains);
            bool clavesVerdesContieneListaClavesVerdes = clavesVerdes.All(getListaClavesVerdes.Contains);

            Assert.IsTrue(getListaClavesContieneLasClavesVerdes && clavesVerdesContieneListaClavesVerdes);
        }

        [TestMethod]
        public void UsuarioGetListaClavesColorNoVaciaDosCategoria()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);

            clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "estaesunaclave",
                UsuarioClave = "Roberto",
                Nota = ""
            };
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "ESTAESUNACLAVE",
                UsuarioClave = "Luis88",
                Nota = ""
            };
            controladoraUsuario.AgregarClave(clave2, categoria2, usuario);

            List<Clave> clavesAmarillas = new List<Clave>
            {
                clave1,
                clave2
            };

            ColorNivelSeguridad color = new ColorNivelSeguridad();
            List<Clave> getListaClavesAmarillas = controladoraUsuario.GetListaClavesColor(color.Amarillo, usuario);

            bool getListaClavesContieneLasClavesVerdes = getListaClavesAmarillas.All(clavesAmarillas.Contains);
            bool clavesVerdesContieneListaClavesVerdes = clavesAmarillas.All(getListaClavesAmarillas.Contains);

            Assert.IsTrue(getListaClavesContieneLasClavesVerdes && clavesVerdesContieneListaClavesVerdes);
        }

        [TestMethod]
        public void UsuarioGetCategoriaClaveSinClaves()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraUsuario.GetCategoriaClave(clave1, usuario));
        }

        [TestMethod]
        public void UsuarioGetCategoriaClaveDosCategorias()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria2, usuario);

            Clave buscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                Codigo = clave1.Codigo,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(categoria2, controladoraUsuario.GetCategoriaClave(buscadora, usuario));
        }
    }
}
