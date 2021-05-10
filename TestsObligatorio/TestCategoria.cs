using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class TestCategoriaContras
    {
        [TestMethod]
        public void CategoriaEsListaContrasVaciaSinContras()
        {
            Categoria categoria = new Categoria();
            Assert.AreEqual(true, categoria.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaEsListaContrasConContras()
        {
            Categoria categoria = new Categoria();
            Clave contra = new Clave()
            {
                Sitio = "youtube.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria.AgregarClave(contra);
            Assert.AreEqual(false, categoria.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaEsListaContrasVaciaConDosContras()
        {
            Categoria categoria = new Categoria();
            Clave contra1 = new Clave()
            {
                Sitio = "youtube.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Juan Perez"

            };
            categoria.AgregarClave(contra1);
            Assert.AreEqual(false, categoria.EsListaClavesVacia());
            Clave contra2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria.AgregarClave(contra2);
            Assert.AreEqual(false, categoria.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaAgregarContraSinSitioOAplicacion()
        {
            Categoria categoria = new Categoria();
            Clave contra1 = new Clave()
            {
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarClave(contra1));
        }

        [TestMethod]
        public void CategoriaAgregarContraSinClave()
        {
            Categoria categoria = new Categoria();
            Clave contra1 = new Clave()
            {
                Sitio = "youtube.com",
                UsuarioClave = "Roberto"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarClave(contra1));
        }

        [TestMethod]
        public void CategoriaAgregarContraSinUsuario()
        {
            Categoria categoria = new Categoria();
            Clave contra1 = new Clave()
            {
                Sitio = "youtube.com",
                Codigo = "EstaEsUnaClave1"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarClave(contra1));
        }

        [TestMethod]
        public void CategoriaAgregarContraYaExistente()
        {
            Categoria categoria = new Categoria();
            Clave contra1 = new Clave()
            {
                Sitio = "youtube.com",
                UsuarioClave = "Roberto",
                Codigo = "EstaEsUnaClave1"
            };
            categoria.AgregarClave(contra1);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.AgregarClave(contra1));
        }

        [TestMethod]
        public void CategoriaGetContraCorrecta()
        {
            Categoria categoria1 = new Categoria();
            Clave contraAGuardar = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(contraAGuardar);

            Clave contraBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Roberto"
            };

            Assert.AreEqual(contraAGuardar, categoria1.GetClave(contraBuscadora));
        }

        [TestMethod]
        public void CategoriaGetContraPrimeraConDos()
        {
            Categoria categoria1 = new Categoria();
            Clave contra1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(contra1);

            Clave contra2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(contra2);

            Clave contraBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Roberto"
            };

            Assert.AreEqual(contra1, categoria1.GetClave(contraBuscadora)); ;
        }

        [TestMethod]
        public void CategoriaGetContraSegundaConDos()
        {
            Categoria categoria1 = new Categoria();
            Clave contra1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(contra1);

            Clave contra2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(contra2);

            Clave contraBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Luis88"
            };


            Assert.AreEqual(contra2, categoria1.GetClave(contraBuscadora)); ;
        }

        [TestMethod]
        public void CategoriaGetListaContras()
        {
            Categoria categoria1 = new Categoria();
            Clave contra1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(contra1);
            Clave contra2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(contra2);

            List<Clave> contras = new List<Clave>
            {
                contra1,
                contra2
            };

            Assert.AreEqual(true, contras.SequenceEqual(categoria1.GetListaClaves())); ;
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
        public void CategoriaYaExisteContraSiExistente()
        {
            Categoria categoria = new Categoria();
            Clave contra = new Clave() {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(contra);
            Clave contraIgual = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            Assert.AreEqual(true, categoria.YaExisteClave(contraIgual));
        }

        [TestMethod]
        public void CategoriaYaExisteContraMismoUsuarioDiferenteSitio()
        {
            Categoria categoria = new Categoria();
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(contra);
            Clave contraDiferenteSitio = new Clave()
            {
                Sitio = "www.youtube.com",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            Assert.AreEqual(false, categoria.YaExisteClave(contraDiferenteSitio));
        }

        [TestMethod]
        public void CategoriaYaExisteContraMismoSitioDiferenteUsuario()
        {
            Categoria categoria = new Categoria();
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(contra);
            Clave contraDiferenteUsuario = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "222222",
                Codigo = "12345678"
            };
            Assert.AreEqual(false, categoria.YaExisteClave(contraDiferenteUsuario));
        }

        [TestMethod]
        public void CategoriaYaExisteContraDiferentesClaves()
        {
            Categoria categoria = new Categoria();
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(contra);
            Clave contraDiferenteClave = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "87654321"
            };
            Assert.AreEqual(true, categoria.YaExisteClave(contraDiferenteClave));
        }

        [TestMethod]
        public void CategoriaBorrarContraCategoriaVacia()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";

            Clave aBorrar = new Clave()
            {
                Sitio = paginaContra,
                UsuarioClave = usuarioContra

            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.BorrarClave(aBorrar));
        }

        [TestMethod]
        public void CategoriaBorrarContraExistenteCategoria()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";
            Clave contra = new Clave()
            {
                UsuarioClave = usuarioContra,
                Sitio = paginaContra,
                Codigo = "1234AbC$"
            };

            categoria.AgregarClave(contra);
            Assert.IsTrue(categoria.YaExisteClave(contra));

            categoria.BorrarClave(contra);
            Assert.IsFalse(categoria.YaExisteClave(contra));
        }

        [TestMethod]
        public void CategoriaEsListaContrasVaciaDespuesDeBorrar()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";
            Clave contra = new Clave()
            {
                UsuarioClave = usuarioContra,
                Sitio = paginaContra,
                Codigo = "1234AbC$"
            };

            categoria.AgregarClave(contra);
            categoria.BorrarClave(contra);
            Assert.IsTrue(categoria.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaEsListaContrasVaciaDespuesDeBorrarAgregar()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";
            Clave contra = new Clave()
            {
                UsuarioClave = usuarioContra,
                Sitio = paginaContra,
                Codigo = "1234AbC$"
            };

            categoria.AgregarClave(contra);
            categoria.BorrarClave(contra);
            categoria.AgregarClave(contra);
            Assert.IsFalse(categoria.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaGetContraBorrada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContraBorrar = "222222";
            String paginaContraBorrar = "www.ort.edu.uy";

            Clave contraBorrar = new Clave()
            {
                UsuarioClave = usuarioContraBorrar,
                Sitio = paginaContraBorrar,
                Codigo = "1234AbC$"
            };

            Clave contraBuscadora = new Clave()
            {
                UsuarioClave = usuarioContraBorrar,
                Sitio = paginaContraBorrar
            };

            categoria.AgregarClave(contraBorrar);
            categoria.BorrarClave(contraBorrar);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.GetClave(contraBuscadora));
        }

        [TestMethod]
        public void CategoriaDosContrasGetContraBorrada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContraBorrar = "222222";
            String paginaContraBorrar = "www.ort.edu.uy";

            Clave contraBorrar = new Clave()
            {
                UsuarioClave = usuarioContraBorrar,
                Sitio = paginaContraBorrar,
                Codigo = "1234AbC$"
            };

            Clave contraOtra = new Clave()
            {
                UsuarioClave = "OtraContra",
                Sitio = "otroSitio.com",
                Codigo = "1234AbC$"
            };


            categoria.AgregarClave(contraBorrar);
            categoria.AgregarClave(contraOtra);
            categoria.BorrarClave(contraBorrar);


            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.GetClave(contraBorrar));
        }

        [TestMethod]
        public void CategoriaBorrarContraNoExistenteNoVacio()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContraBorrar = "222222";
            String paginaContraBorrar = "www.ort.edu.uy";

            Clave contraBorrar = new Clave()
            {
                UsuarioClave = usuarioContraBorrar,
                Sitio = paginaContraBorrar
            };

            Clave contraOtra = new Clave()
            {
                UsuarioClave = "OtraContra",
                Sitio = "otroSitio.com",
                Codigo = "1234AbC$"
            };

            categoria.AgregarClave(contraOtra);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.BorrarClave(contraBorrar));
        }

        [TestMethod]
        public void CategoriaModificarContraNoExistente()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioContraModificar = "Usuario23";
            string paginaContraModificar = "www.ort.edu.uy";
            string claveContraModificar = "1234AbC$";

            Clave nuevaContra = new Clave()
            {
                UsuarioClave = usuarioContraModificar,
                Sitio = paginaContraModificar, 
                Codigo = claveContraModificar
            };

            string usuarioContraInexistente = "12345@";
            string paginaContraInexistente = "www.ort.edu.uy";

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioContraInexistente,
                Sitio = paginaContraInexistente
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.ModificarClave(buscadora, nuevaContra));
        }

        [TestMethod]
        public void CategoriaAlModificarContraAgregadaLaContraViejaDejaDeExistir()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioContraModificar = "Usuario23";
            string paginaContraModificar = "www.ort.edu.uy";
            string claveContraModificar = "1234AbC$";

            Clave contraVieja = new Clave()
            {
                UsuarioClave = usuarioContraModificar,
                Sitio = paginaContraModificar,
                Codigo = claveContraModificar,
                Nota = ""
            };
            categoria.AgregarClave(contraVieja);

            string usuarioContraNueva = "user543";
            string paginaContraNueva = "aulas.edu.uy";
            string claveContraNueva = "1234A@C$";

            Clave contraNueva = new Clave()
            {
                UsuarioClave = usuarioContraNueva,
                Sitio = paginaContraNueva,
                Codigo = claveContraNueva,
                Nota = ""
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioContraModificar,
                Sitio = paginaContraModificar
            };

            categoria.ModificarClave(contraVieja, contraNueva);
            Assert.IsFalse(categoria.YaExisteClave(buscadora));
        }

        [TestMethod]
        public void CategoriaModificarContraYaExistente()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioContra1 = "Usuario23";
            string paginaContra1 = "www.ort.edu.uy";
            string claveContra1 = "1234AbC$";

            Clave contra1 = new Clave()
            {
                UsuarioClave = usuarioContra1,
                Sitio = paginaContra1,
                Codigo = claveContra1
            };

            categoria.AgregarClave(contra1);

            string usuarioContra2 = "user23";
            string paginaContra2 = "aulas.edu.uy";
            string claveContra2 = "1234AbC$";

            Clave contra2 = new Clave()
            {
                UsuarioClave = usuarioContra2,
                Sitio = paginaContra2,
                Codigo = claveContra2
            };

            categoria.AgregarClave(contra2);

            Clave duplicada = new Clave()
            {
                UsuarioClave = usuarioContra2,
                Sitio = paginaContra2,
                Codigo = claveContra2
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.ModificarClave(contra1, duplicada));
        }

        [TestMethod]
        public void CategoriaModificarContraAgregada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioContraVieja = "Usuario23";
            string paginaContraVieja = "www.ort.edu.uy";
            string claveContraVieja = "1234AbC$";

            Clave contraVieja = new Clave()
            {
                UsuarioClave = usuarioContraVieja,
                Sitio = paginaContraVieja,
                Codigo = claveContraVieja,
                Nota = ""
            };

            categoria.AgregarClave(contraVieja);

            string usuarioContraNueva = "user23";
            string paginaContraNueva = "aulas.edu.uy";
            string claveContraNueva = "1234AbC$";

            Clave contraNueva = new Clave()
            {
                UsuarioClave = usuarioContraNueva,
                Sitio = paginaContraNueva,
                Codigo = claveContraNueva,
                Nota = ""
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioContraNueva,
                Sitio = paginaContraNueva
            };

            categoria.ModificarClave(contraVieja, contraNueva);
            Assert.AreEqual(contraNueva, buscadora);
        }

        [TestMethod]
        public void CategoriaModificarContraCambiarNotaYClave()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioContraVieja = "Usuario23";
            string paginaContraVieja = "www.ort.edu.uy";
            string claveContraVieja = "1234AbC$";

            Clave contraVieja = new Clave()
            {
                UsuarioClave = usuarioContraVieja,
                Sitio = paginaContraVieja,
                Codigo = claveContraVieja,
                Nota = "Vieja"
            };

            categoria.AgregarClave(contraVieja);

            string claveContraNueva = "Nueva";

            Clave contraNueva = new Clave()
            {
                UsuarioClave = usuarioContraVieja,
                Sitio = paginaContraVieja,
                Codigo = claveContraNueva,
                Nota = "Nueva"
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioContraVieja,
                Sitio = paginaContraVieja
            };

            categoria.ModificarClave(buscadora, contraNueva);

            bool igualSitioYUsuario = contraVieja.Equals(contraNueva);
            bool igualNota = contraVieja.Nota == contraNueva.Nota;
            bool igualClave = contraVieja.Codigo == contraNueva.Codigo;  

            Assert.IsTrue(igualSitioYUsuario && igualNota && igualClave);
        }

        [TestMethod]
        public void CategoriaModificarContraCambiaFechaModificacion()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioContraVieja = "Usuario23";
            string paginaContraVieja = "www.ort.edu.uy";
            string claveContraVieja = "1234AbC$";

            Clave contraVieja = new Clave()
            {
                UsuarioClave = usuarioContraVieja,
                Sitio = paginaContraVieja,
                Codigo = claveContraVieja,
                Nota = "Vieja"
            };

            contraVieja.FechaModificacion = new DateTime(2000, 1, 1);

            categoria.AgregarClave(contraVieja);

            string claveContraNueva = "Cambiada";

            Clave contraNueva = new Clave()
            {
                UsuarioClave = usuarioContraVieja,
                Sitio = paginaContraVieja,
                Codigo = claveContraNueva,
                Nota = "Nueva"
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioContraVieja,
                Sitio = paginaContraVieja
            };

            categoria.ModificarClave(buscadora, contraNueva);

            bool igualSitioYUsuario = contraVieja.Equals(contraNueva);
            bool igualNota = contraVieja.Nota == contraNueva.Nota;
            bool igualClave = contraVieja.Codigo == contraNueva.Codigo;
            bool distintaFecha = contraVieja.FechaModificacion == System.DateTime.Now.Date;
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
