using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    class Program
    {
        static void Main(string[] args)
        {

            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Contra clave1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            Contra clave2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave2",
                UsuarioContra = "Hernesto"
            };

            usuario1.AgregarContra(clave1, categoria1);
            usuario1.AgregarContra(clave2, categoria1);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida claveCompartir2 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave2
            };

            usuario1.CompartirClave(claveACompartir1);

            usuario1.CompartirClave(claveCompartir2);

            ClaveCompartida claveCompartidaAUsuario2_1 = new ClaveCompartida()
            {
                Usuario = usuario1,
                Clave = clave1
            };

            ClaveCompartida claveCompartidaAUsuario2_2 = new ClaveCompartida()
            {
                Usuario = usuario1,
                Clave = clave2
            };

            Console.WriteLine(claveCompartidaAUsuario2_1);
            Console.WriteLine(claveCompartidaAUsuario2_2);
            Console.WriteLine(usuario2.Conmigo);
            Console.ReadLine();

            //Assert.IsTrue(usuario2.Conmigo.Contains(claveCompartidaConmigo1) && usuario2.Conmigo.Contains(claveCompartidaConmigo2));

        }

    }
}

