using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsObligatorio
{
    [TestClass]
    public class TestCategoria
    {

        [TestMethod]
        public void CategoriaGetNombreCorrecto()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual("Trabajo", categoria.Nombre);
        }

        [TestMethod]
        public void CategoriaGetNombreCambiado()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual("Trabajo", categoria.Nombre);
            categoria.Nombre = "Facultad";
            Assert.AreEqual("Facultad", categoria.Nombre);
        }

        [TestMethod]
        public void CategoriaLargoNombreMenorA3()
        {
            Categoria categoria = new Categoria();
            Assert.ThrowsException<LargoIncorrectoException>(() => categoria.Nombre = "A");
        }

        [TestMethod]
        public void CategoriaLargoNombreMayorA15()
        {
            Categoria categoria = new Categoria();
            Assert.ThrowsException<LargoIncorrectoException>(() => categoria.Nombre = "1234567890123456");
        }
    }

    [TestClass]
    public class TestCategoriaClaves
    {
        [TestMethod]
        public void CategoriaEsListaClavesVaciaSinClaves()
        {
            Categoria categoria = new Categoria();
            Assert.AreEqual(true, categoria.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaEsListaClavesConClaves()
        {
            Categoria categoria = new Categoria();
            Clave clave = new Clave()
            {
                Sitio = "youtube.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria.AgregarClave(clave);
            Assert.AreEqual(false, categoria.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaConDosClaves()
        {
            Categoria categoria = new Categoria();
            Clave clave1 = new Clave()
            {
                Sitio = "youtube.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Juan Perez"

            };
            categoria.AgregarClave(clave1);
            Assert.AreEqual(false, categoria.EsListaClavesVacia());
            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria.AgregarClave(clave2);
            Assert.AreEqual(false, categoria.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaAgregarClaveSinSitioOAplicacion()
        {
            Categoria categoria = new Categoria();
            Clave clave1 = new Clave()
            {
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarClave(clave1));
        }

        [TestMethod]
        public void CategoriaAgregarClaveSinClave()
        {
            Categoria categoria = new Categoria();
            Clave clave1 = new Clave()
            {
                Sitio = "youtube.com",
                UsuarioClave = "Roberto"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarClave(clave1));
        }

        [TestMethod]
        public void CategoriaAgregarClaveSinUsuario()
        {
            Categoria categoria = new Categoria();
            Clave clave1 = new Clave()
            {
                Sitio = "youtube.com",
                Codigo = "EstaEsUnaClave1"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarClave(clave1));
        }

        [TestMethod]
        public void CategoriaAgregarClaveYaExistente()
        {
            Categoria categoria = new Categoria();
            Clave clave1 = new Clave()
            {
                Sitio = "youtube.com",
                UsuarioClave = "Roberto",
                Codigo = "EstaEsUnaClave1"
            };
            categoria.AgregarClave(clave1);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.AgregarClave(clave1));
        }

        [TestMethod]
        public void CategoriaGetClaveCorrecta()
        {
            Categoria categoria1 = new Categoria();
            Clave claveAGuardar = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(claveAGuardar);

            Clave claveBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Roberto"
            };

            Assert.AreEqual(claveAGuardar, categoria1.GetClave(claveBuscadora));
        }

        [TestMethod]
        public void CategoriaGetClavePrimeraConDos()
        {
            Categoria categoria1 = new Categoria();
            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);

            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            Clave claveBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Roberto"
            };

            Assert.AreEqual(clave1, categoria1.GetClave(claveBuscadora)); ;
        }

        [TestMethod]
        public void CategoriaGetClaveSegundaConDos()
        {
            Categoria categoria1 = new Categoria();
            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);

            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            Clave claveBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Luis88"
            };


            Assert.AreEqual(clave2, categoria1.GetClave(claveBuscadora)); ;
        }

        [TestMethod]
        public void CategoriaGetListaClaves()
        {
            Categoria categoria1 = new Categoria();
            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);
            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            List<Clave> claves = new List<Clave>
            {
                clave1,
                clave2
            };

            Assert.AreEqual(true, claves.SequenceEqual(categoria1.GetListaClaves())); ;
        }

        [TestMethod]
        public void CategoriaEqualsMismoNombre()
        {
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Assert.AreEqual(categoria1, categoria2);
        }

        [TestMethod]
        public void CategoriaEqualsDiferenteNombre()
        {
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreNotEqual(categoria1, categoria2);
        }

        [TestMethod]
        public void CategoriaEqualsMismoNombreConMayYMin()
        {
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria categoria2 = new Categoria()
            {
                Nombre = "personal"
            };
            Assert.AreEqual(categoria1, categoria2);
        }

        [TestMethod]
        public void CategoriaEqualsConNull()
        {
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria categoria2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria1.Equals(categoria2));
        }

        [TestMethod]
        public void CategoriaEqualsConString()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            String falsaCategoria = "Personal";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => categoria.Equals(falsaCategoria));
        }

        [TestMethod]
        public void CategoriaYaExisteClaveSiExistente()
        {
            Categoria categoria = new Categoria();
            Clave clave = new Clave() {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(clave);
            Clave claveIgual = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            Assert.AreEqual(true, categoria.YaExisteClave(claveIgual));
        }

        [TestMethod]
        public void CategoriaYaExisteClaveMismoUsuarioDiferenteSitio()
        {
            Categoria categoria = new Categoria();
            Clave clave = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(clave);
            Clave claveDiferenteSitio = new Clave()
            {
                Sitio = "www.youtube.com",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            Assert.AreEqual(false, categoria.YaExisteClave(claveDiferenteSitio));
        }

        [TestMethod]
        public void CategoriaYaExisteClaveMismoSitioDiferenteUsuario()
        {
            Categoria categoria = new Categoria();
            Clave clave = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(clave);
            Clave claveDiferenteUsuario = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "222222",
                Codigo = "12345678"
            };
            Assert.AreEqual(false, categoria.YaExisteClave(claveDiferenteUsuario));
        }

        [TestMethod]
        public void CategoriaYaExisteClaveDiferentesClaves()
        {
            Categoria categoria = new Categoria();
            Clave clave = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(clave);
            Clave claveDiferenteClave = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "87654321"
            };
            Assert.AreEqual(true, categoria.YaExisteClave(claveDiferenteClave));
        }

        [TestMethod]
        public void CategoriaBorrarClaveCategoriaVacia()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioClave = "222222";
            String paginaClave = "www.ort.edu.uy";

            Clave aBorrar = new Clave()
            {
                Sitio = paginaClave,
                UsuarioClave = usuarioClave

            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.BorrarClave(aBorrar));
        }

        [TestMethod]
        public void CategoriaBorrarClaveExistenteCategoria()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioClave = "222222";
            String paginaClave = "www.ort.edu.uy";
            Clave clave = new Clave()
            {
                UsuarioClave = usuarioClave,
                Sitio = paginaClave,
                Codigo = "1234AbC$"
            };

            categoria.AgregarClave(clave);
            Assert.IsTrue(categoria.YaExisteClave(clave));

            categoria.BorrarClave(clave);
            Assert.IsFalse(categoria.YaExisteClave(clave));
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaDespuesDeBorrar()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioClave = "222222";
            String paginaClave = "www.ort.edu.uy";
            Clave clave = new Clave()
            {
                UsuarioClave = usuarioClave,
                Sitio = paginaClave,
                Codigo = "1234AbC$"
            };

            categoria.AgregarClave(clave);
            categoria.BorrarClave(clave);
            Assert.IsTrue(categoria.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaDespuesDeBorrarAgregar()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioClave = "222222";
            String paginaClave = "www.ort.edu.uy";
            Clave clave = new Clave()
            {
                UsuarioClave = usuarioClave,
                Sitio = paginaClave,
                Codigo = "1234AbC$"
            };

            categoria.AgregarClave(clave);
            categoria.BorrarClave(clave);
            categoria.AgregarClave(clave);
            Assert.IsFalse(categoria.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaGetClaveBorrada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioClaveBorrar = "222222";
            String paginaClaveBorrar = "www.ort.edu.uy";

            Clave claveBorrar = new Clave()
            {
                UsuarioClave = usuarioClaveBorrar,
                Sitio = paginaClaveBorrar,
                Codigo = "1234AbC$"
            };

            Clave claveBuscadora = new Clave()
            {
                UsuarioClave = usuarioClaveBorrar,
                Sitio = paginaClaveBorrar
            };

            categoria.AgregarClave(claveBorrar);
            categoria.BorrarClave(claveBorrar);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.GetClave(claveBuscadora));
        }

        [TestMethod]
        public void CategoriaDosClavesGetClaveBorrada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioClaveBorrar = "222222";
            String paginaClaveBorrar = "www.ort.edu.uy";

            Clave claveBorrar = new Clave()
            {
                UsuarioClave = usuarioClaveBorrar,
                Sitio = paginaClaveBorrar,
                Codigo = "1234AbC$"
            };

            Clave claveOtra = new Clave()
            {
                UsuarioClave = "OtraClave",
                Sitio = "otroSitio.com",
                Codigo = "1234AbC$"
            };


            categoria.AgregarClave(claveBorrar);
            categoria.AgregarClave(claveOtra);
            categoria.BorrarClave(claveBorrar);


            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.GetClave(claveBorrar));
        }

        [TestMethod]
        public void CategoriaBorrarClaveNoExistenteNoVacio()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioClaveBorrar = "222222";
            String paginaClaveBorrar = "www.ort.edu.uy";

            Clave claveBorrar = new Clave()
            {
                UsuarioClave = usuarioClaveBorrar,
                Sitio = paginaClaveBorrar
            };

            Clave claveOtra = new Clave()
            {
                UsuarioClave = "OtraClave",
                Sitio = "otroSitio.com",
                Codigo = "1234AbC$"
            };

            categoria.AgregarClave(claveOtra);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.BorrarClave(claveBorrar));
        }

        [TestMethod]
        public void CategoriaModificarClaveNoExistente()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioClaveModificar = "Usuario23";
            string paginaClaveModificar = "www.ort.edu.uy";
            string claveClaveModificar = "1234AbC$";

            Clave nuevaClave = new Clave()
            {
                UsuarioClave = usuarioClaveModificar,
                Sitio = paginaClaveModificar, 
                Codigo = claveClaveModificar
            };

            string usuarioClaveInexistente = "12345@";
            string paginaClaveInexistente = "www.ort.edu.uy";

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioClaveInexistente,
                Sitio = paginaClaveInexistente
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.ModificarClave(buscadora, nuevaClave));
        }

        [TestMethod]
        public void CategoriaAlModificarClaveAgregadaLaClaveViejaDejaDeExistir()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioClaveModificar = "Usuario23";
            string paginaClaveModificar = "www.ort.edu.uy";
            string claveClaveModificar = "1234AbC$";

            Clave claveVieja = new Clave()
            {
                UsuarioClave = usuarioClaveModificar,
                Sitio = paginaClaveModificar,
                Codigo = claveClaveModificar,
                Nota = ""
            };
            categoria.AgregarClave(claveVieja);

            string usuarioClaveNueva = "user543";
            string paginaClaveNueva = "aulas.edu.uy";
            string claveClaveNueva = "1234A@C$";

            Clave claveNueva = new Clave()
            {
                UsuarioClave = usuarioClaveNueva,
                Sitio = paginaClaveNueva,
                Codigo = claveClaveNueva,
                Nota = ""
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioClaveModificar,
                Sitio = paginaClaveModificar
            };

            categoria.ModificarClave(claveVieja, claveNueva);
            Assert.IsFalse(categoria.YaExisteClave(buscadora));
        }

        [TestMethod]
        public void CategoriaModificarClaveYaExistente()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioClave1 = "Usuario23";
            string paginaClave1 = "www.ort.edu.uy";
            string claveClave1 = "1234AbC$";

            Clave clave1 = new Clave()
            {
                UsuarioClave = usuarioClave1,
                Sitio = paginaClave1,
                Codigo = claveClave1
            };

            categoria.AgregarClave(clave1);

            string usuarioClave2 = "user23";
            string paginaClave2 = "aulas.edu.uy";
            string claveClave2 = "1234AbC$";

            Clave clave2 = new Clave()
            {
                UsuarioClave = usuarioClave2,
                Sitio = paginaClave2,
                Codigo = claveClave2
            };

            categoria.AgregarClave(clave2);

            Clave duplicada = new Clave()
            {
                UsuarioClave = usuarioClave2,
                Sitio = paginaClave2,
                Codigo = claveClave2
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.ModificarClave(clave1, duplicada));
        }

        [TestMethod]
        public void CategoriaModificarClaveAgregada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioClaveVieja = "Usuario23";
            string paginaClaveVieja = "www.ort.edu.uy";
            string claveClaveVieja = "1234AbC$";

            Clave claveVieja = new Clave()
            {
                UsuarioClave = usuarioClaveVieja,
                Sitio = paginaClaveVieja,
                Codigo = claveClaveVieja,
                Nota = ""
            };

            categoria.AgregarClave(claveVieja);

            string usuarioClaveNueva = "user23";
            string paginaClaveNueva = "aulas.edu.uy";
            string claveClaveNueva = "1234AbC$";

            Clave claveNueva = new Clave()
            {
                UsuarioClave = usuarioClaveNueva,
                Sitio = paginaClaveNueva,
                Codigo = claveClaveNueva,
                Nota = ""
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioClaveNueva,
                Sitio = paginaClaveNueva
            };

            categoria.ModificarClave(claveVieja, claveNueva);
            Assert.AreEqual(claveNueva, buscadora);
        }

        [TestMethod]
        public void CategoriaModificarClaveCambiarNotaYClave()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioClaveVieja = "Usuario23";
            string paginaClaveVieja = "www.ort.edu.uy";
            string claveClaveVieja = "1234AbC$";

            Clave claveVieja = new Clave()
            {
                UsuarioClave = usuarioClaveVieja,
                Sitio = paginaClaveVieja,
                Codigo = claveClaveVieja,
                Nota = "Vieja"
            };

            categoria.AgregarClave(claveVieja);

            string claveClaveNueva = "Nueva";

            Clave claveNueva = new Clave()
            {
                UsuarioClave = usuarioClaveVieja,
                Sitio = paginaClaveVieja,
                Codigo = claveClaveNueva,
                Nota = "Nueva"
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioClaveVieja,
                Sitio = paginaClaveVieja
            };

            categoria.ModificarClave(buscadora, claveNueva);

            bool igualSitioYUsuario = claveVieja.Equals(claveNueva);
            bool igualNota = claveVieja.Nota == claveNueva.Nota;
            bool igualClave = claveVieja.Codigo == claveNueva.Codigo;  

            Assert.IsTrue(igualSitioYUsuario && igualNota && igualClave);
        }

        [TestMethod]
        public void CategoriaModificarClaveCambiaFechaModificacion()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioClaveVieja = "Usuario23";
            string paginaClaveVieja = "www.ort.edu.uy";
            string claveClaveVieja = "1234AbC$";

            Clave claveVieja = new Clave()
            {
                UsuarioClave = usuarioClaveVieja,
                Sitio = paginaClaveVieja,
                Codigo = claveClaveVieja,
                Nota = "Vieja"
            };

            claveVieja.FechaModificacion = new DateTime(2000, 1, 1);

            categoria.AgregarClave(claveVieja);

            string claveClaveNueva = "Cambiada";

            Clave claveNueva = new Clave()
            {
                UsuarioClave = usuarioClaveVieja,
                Sitio = paginaClaveVieja,
                Codigo = claveClaveNueva,
                Nota = "Nueva"
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioClaveVieja,
                Sitio = paginaClaveVieja
            };

            categoria.ModificarClave(buscadora, claveNueva);

            bool igualSitioYUsuario = claveVieja.Equals(claveNueva);
            bool igualNota = claveVieja.Nota == claveNueva.Nota;
            bool igualClave = claveVieja.Codigo == claveNueva.Codigo;
            bool distintaFecha = claveVieja.FechaModificacion == System.DateTime.Now.Date;
            Assert.IsTrue(igualSitioYUsuario && igualNota && igualClave && distintaFecha);
        }

        [TestMethod]
        public void CategoriaGetClavesColorEsVacia()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            int cantidadRojas = 0;
            const string rojo = "rojo";
            Assert.AreEqual(cantidadRojas, categoria.GetListaClavesColor(rojo).Count);
        }

        [TestMethod]
        public void CategoriaGetListaClavesColorNoVacia()
        {
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave12@",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);

            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "clave",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            List<Clave> clavesVerdes = new List<Clave>
            {
                clave1
            };

            const string verdeOscuro = "verde oscuro";
            List<Clave> getListaClavesVerdes = categoria1.GetListaClavesColor(verdeOscuro);

            bool getListaClavesContieneLasClavesVerdes = getListaClavesVerdes.All(clavesVerdes.Contains);
            bool clavesVerdesContieneListaClavesVerdes = clavesVerdes.All(getListaClavesVerdes.Contains);

            Assert.IsTrue(getListaClavesContieneLasClavesVerdes && clavesVerdesContieneListaClavesVerdes);
        }
    }

    [TestClass]
    public class TestCategoriaTarjeta
    {
        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaSinTarjetas()
        {
            Categoria categoria = new Categoria();
            Assert.AreEqual(true, categoria.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaConTarjetas()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Codigo = "567",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta1);
            Assert.AreEqual(false, categoria.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaConDosTarjetas()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Codigo = "567",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta1);
            Assert.AreEqual(false, categoria.EsListaTarjetasVacia());
            Tarjeta tarjeta2= new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta2);
            Assert.AreEqual(false, categoria.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinNombre()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinTipo()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Numero = "3456567890876543",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinNumero()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinCodigo()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinVencimiento()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Codigo = "567",
                Nota = ""
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaGetTarjetaCorrecta()
        {
            Categoria categoria1 = new Categoria();
            string numeroTarjeta = "3456567890876543";

            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjeta,
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta1);

            Tarjeta buscadora = new Tarjeta() 
            { 
                Numero = numeroTarjeta
            };

            Assert.AreEqual(tarjeta1, categoria1.GetTarjeta(buscadora)); 
        }

        [TestMethod]
        public void CategoriaGetTarjetaPrimeraConDos()
        {
            Categoria categoria1 = new Categoria();

            string numeroTarjetaPrimera = "3456567890876543";
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjetaPrimera,
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta2);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaPrimera
            };

            Assert.AreEqual(tarjeta1, categoria1.GetTarjeta(buscadora)); 
        }

        [TestMethod]
        public void CategoriaGetTarjetaSegundaConDos()
        {
            Categoria categoria1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta1);

            string numeroSegundaTarjeta = "1234567890876553";

            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroSegundaTarjeta,
                Codigo = "789",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta2);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroSegundaTarjeta
            };

            Assert.AreEqual(tarjeta2, categoria1.GetTarjeta(buscadora));
        }

        [TestMethod]
        public void CategoriaGetListaTarjetas()
        {
            Categoria categoria1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta2);

            List<Tarjeta> tarjetas = new List<Tarjeta>
            {
                tarjeta1,
                tarjeta2
            };

            Assert.AreEqual(true, tarjetas.SequenceEqual(categoria1.GetListaTarjetas()));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaSiExistente()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
        };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.YaExisteTarjeta(tarjetaIgual));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteNumero()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "1234567812345678",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(false, categoria.YaExisteTarjeta(tarjetaDistintoNumero));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteNombre()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.YaExisteTarjeta(tarjetaDistintoNombre));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteTipo()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard Gold",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteCodigo()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaYaExistente()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Codigo = "345",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.AgregarTarjeta(tarjeta));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaCategoriaVacia()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            string numeroTarjeta = "1234567890876543";

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.BorrarTarjeta(aBorrar));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaCategoriaConUnaTarjeta()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            string numeroTarjeta = "1234567890876543";
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjeta,
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Assert.IsTrue(categoria.YaExisteTarjeta(tarjeta));

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            categoria.BorrarTarjeta(aBorrar);
            Assert.IsFalse(categoria.YaExisteTarjeta(tarjeta));
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaDespuesDeBorrar()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            string numeroTarjeta = "1234567890876543";
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjeta,
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Assert.IsTrue(categoria.YaExisteTarjeta(tarjeta));

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            categoria.BorrarTarjeta(aBorrar);
            Assert.IsTrue(categoria.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaGetTarjetaBorrada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjeta = "1234567890876543";

            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjeta,
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            categoria.AgregarTarjeta(tarjeta);
            categoria.BorrarTarjeta(aBorrar);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.GetTarjeta(buscadora));
        }

        [TestMethod]
        public void CategoriaDosTarjetasGetTarjetaBorrada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjeta = "1234567890876543";

            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjeta,
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "4254567490876549",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            categoria.AgregarTarjeta(tarjeta1);
            categoria.AgregarTarjeta(tarjeta2);
            categoria.BorrarTarjeta(aBorrar);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.GetTarjeta(buscadora));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaQueNoExiste()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "4254567490876549",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            string numeroTarjeta = "1234567890876543";

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.BorrarTarjeta(aBorrar));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteVencimiento()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123",
                Vencimiento = new DateTime(2026, 9, 2)
            };
            Assert.AreEqual(true, categoria.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void CategoriaAlModificarTarjetaAgregadaLaTarjetaViejaDejaDeExistir()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjetaVieja = "4254567490876549";
            Tarjeta tarjetaVieja = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjetaVieja,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjetaVieja);

            string numeroTarjetaNueva = "1234567890876543";
            Tarjeta tarjetaNueva = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjetaNueva,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaVieja
            };
            categoria.ModificarTarjeta(tarjetaVieja, tarjetaNueva);
            Assert.IsFalse(categoria.YaExisteTarjeta(buscadora));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaNoExistente()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjeta = "4254567490876549";
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjeta,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);

            string numeroTarjetaInexistente = "1234567890876543";

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaInexistente
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.ModificarTarjeta(categoria.GetTarjeta(buscadora), tarjeta));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaYaExistente()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjeta = "4254567490876549";
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjeta,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta1);

            string numeroTarjeta2 = "1234567890876543";
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Master",
                Tipo = "Mastercard",
                Numero = numeroTarjeta2,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 4, 1)
            };
            categoria.AgregarTarjeta(tarjeta2);

            Tarjeta duplicada = new Tarjeta()
            {
                Nombre = "Master",
                Tipo = "Mastercard",
                Numero = numeroTarjeta2,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 4, 1)
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.ModificarTarjeta(tarjeta1, duplicada));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaAgregada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjetaVieja = "4254567490876549";
            Tarjeta tarjetaVieja = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjetaVieja,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjetaVieja);

            string numeroTarjetaNueva = "1234567890876543";
            Tarjeta tarjetaNueva = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjetaNueva,
                Nota = "",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaNueva
            };

            categoria.ModificarTarjeta(tarjetaVieja, tarjetaNueva);
            Assert.AreEqual(tarjetaNueva, buscadora);
        }

        [TestMethod]
        public void CategoriaModificarTarjetaCambiarTodoMenosNumero()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjetaVieja = "1111111111111111";
            Tarjeta tarjetaVieja = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjetaVieja,
                Codigo = "111",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjetaVieja);

            Tarjeta tarjetaNueva = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjetaVieja,
                Nota = "Nota Agregada",
                Codigo = "222",
                Vencimiento = new DateTime(2099, 8, 8)
            };

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaVieja
            };

            categoria.ModificarTarjeta(tarjetaVieja, tarjetaNueva);

            bool igualNumero = tarjetaVieja.Numero == tarjetaNueva.Numero;
            bool igualNombre = tarjetaVieja.Nombre == tarjetaNueva.Nombre;
            bool igualTipo = tarjetaVieja.Tipo == tarjetaNueva.Tipo;
            bool igualNota = tarjetaVieja.Nota == tarjetaNueva.Nota;
            bool igualCodigo = tarjetaVieja.Codigo == tarjetaNueva.Codigo;
            bool igualVencimiento = tarjetaVieja.Vencimiento == tarjetaNueva.Vencimiento;

            bool modificoCorrecto = igualNumero && igualNombre && igualTipo && igualNota && igualCodigo && igualVencimiento;

            Assert.IsTrue(modificoCorrecto);
        }
    }
}
