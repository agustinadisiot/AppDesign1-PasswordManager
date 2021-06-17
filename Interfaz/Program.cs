using System;
using System.Windows.Forms;

namespace Interfaz
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            /*ControladoraAdministrador controladoraAdministrador = new ControladoraAdministrador();
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            ControladoraEncriptador controladoraEncriptador = new ControladoraEncriptador();
            controladoraAdministrador.BorrarTodo();

            List<string> nombresUsuarios = new List<String>()
            {
                "Joaquin",
                "Agustina",
                "Santiago",
                "Pedro",
                "Roberto"
            };

            Usuario Joaquin = new Usuario()
            {
                Nombre = "Joaquin",
                ClaveMaestra = "JM12345"
            };

            Usuario Agustina = new Usuario()
            {
                Nombre = "Agustina",
                ClaveMaestra = "A#45PastelPink"
            };

            Usuario Santiago = new Usuario()
            {
                Nombre = "Santiago",
                ClaveMaestra = "12345SD"
            };

            Usuario Pedro = new Usuario()
            {
                Nombre = "Pedro",
                ClaveMaestra = "ClaveMaestra"
            };

            Usuario Roberto = new Usuario()
            {
                Nombre = "Roberto",
                ClaveMaestra = "12345ABCD"
            };

            List<Usuario> usuarios = new List<Usuario>()
            {
                Joaquin,
                Agustina,
                Santiago,
                Pedro,
                Roberto
            };

            List<string> sitios = new List<String>()
            {
                "ort.edu.uy",
                "gestion.ort.edu.uy",
                "youtube.com",
                "twitter.com",
                "hulu.com",
                "facebook",
                "netflix.com",
                "snapchat",
                "Google.com",
                "Disney Plus",
                "Apple",
                "github.com",
                "Microsoft Teams",
                "Mercado Libre"
            };


            List<string> nombresCategorias = new List<string>()
            {
                "Personal",
                "Facultad",
                "Trabajo",
                "Importantes",
                "Entretenimiento",
                "Familia",
                "Compras Online",
                "Otros"
            };

            GeneradoraClaves generadoraClavesRoja = new GeneradoraClaves()
            {
                IncluirMayusculas = false,
                IncluirMinusculas = true,
                IncluirNumeros = false,
                IncluirSimbolos = false,
            };

            GeneradoraClaves generadoraClavesNaranja = new GeneradoraClaves()
            {
                IncluirMayusculas = false,
                IncluirMinusculas = true,
                IncluirNumeros = false,
                IncluirSimbolos = false,
            };

            GeneradoraClaves generadoraClavesAmarilla = new GeneradoraClaves()
            {
                IncluirMayusculas = false,
                IncluirMinusculas = true,
                IncluirNumeros = false,
                IncluirSimbolos = false,
            };

            GeneradoraClaves generadoraClavesVerdeClaro = new GeneradoraClaves()
            {
                IncluirMayusculas = true,
                IncluirMinusculas = true,
                IncluirNumeros = true,
                IncluirSimbolos = false,
            };

            GeneradoraClaves generadoraClavesVerdeOscuro = new GeneradoraClaves()
            {
                IncluirMayusculas = true,
                IncluirMinusculas = true,
                IncluirNumeros = true,
                IncluirSimbolos = true,
            };

            List<GeneradoraClaves> listaGeneradoras = new List<GeneradoraClaves>() {
                generadoraClavesRoja,
                generadoraClavesNaranja,
                generadoraClavesAmarilla,
                generadoraClavesVerdeClaro,
                generadoraClavesVerdeOscuro
            };


            List<int> largosMinimosClaves = new List<int>()
            {
                5,
                8,
                15,
                15,
                15
            };
            List<int> largosMaximosClaves = new List<int>()
            {
                7,
                13,
                25,
                25,
                25
            };


            Random random = new Random();

            GeneradoraClaves generadoraTarjetas = new GeneradoraClaves()
            {
                IncluirMayusculas = false,
                IncluirMinusculas = false,
                IncluirSimbolos = false,
                IncluirNumeros = true
            };

            List<string> tiposTarjeta = new List<string>() {
                "Visa",
                "American Expres",
                "Discover",
                "MasterCard"
            };
            int agregadas = 0;
            string categoriaActual;
            foreach (Usuario usuarioActual in usuarios)
            {
                controladoraAdministrador.AgregarUsuario(usuarioActual);
                List<string> copiaCategorias = new List<String>(nombresCategorias);
                for (int i = 0; i < 5; i++)
                {
                    int pos = random.Next(copiaCategorias.Count);
                    categoriaActual = copiaCategorias.ElementAt(pos);
                    copiaCategorias.Remove(categoriaActual);

                    Categoria nuevaCategoria = new Categoria()
                    {
                        Nombre = categoriaActual
                    };

                    controladoraUsuario.AgregarCategoria(nuevaCategoria, usuarioActual);
                    List<string> copiaSitios = new List<string>(sitios);
                    List<string> usuarioSitios = new List<string>();
                    usuarioSitios.Add(usuarioActual.Nombre);
                    generadoraClavesVerdeOscuro.Largo = random.Next(5, 25);
                    for (int k = 0; k < 5; k++)
                    {
                        generadoraClavesVerdeOscuro.Largo = random.Next(5, 25);
                        usuarioSitios.Add(generadoraClavesVerdeOscuro.Generar());
                    };

                    generadoraClavesVerdeOscuro.Largo = random.Next(5, 25);

                    if (i < 4)
                    {
                        bool agrego = false;
                        while (!agrego)
                        {
                            try
                            {
                                agregadas = agregadas % 10;
                                generadoraTarjetas.Largo = 16;
                                string tipo = tiposTarjeta.ElementAt(random.Next(0, tiposTarjeta.Count));



                                Tarjeta aAgregar = new Tarjeta()
                                {
                                    Numero = generadoraTarjetas.Generar(),
                                    Nombre = generadoraClavesVerdeOscuro.Generar(),
                                    Tipo = tipo,
                                    Vencimiento = DateTime.Now
                                };
                                aAgregar.Nota = generadoraClavesVerdeOscuro.Generar();

                                int cantCodigo = random.Next(0, 2);

                                if (cantCodigo == 0)
                                {
                                    aAgregar.Codigo = "" + random.Next(100, 999);
                                }
                                else
                                {
                                    aAgregar.Codigo = "" + random.Next(1000, 9999);
                                }


                                controladoraUsuario.AgregarTarjeta(aAgregar, nuevaCategoria, usuarioActual);
                                agrego = true;

                            }
                            catch (Exception) { };

                        }
                    }


                    string sitioActual;
                    string usuarioSitio;
                    for (int j = 0; j < 5; j++)
                    {
                        bool paso = false;
                        while (!paso)
                        {
                            try
                            {
                                int posSitio = random.Next(copiaSitios.Count);
                                sitioActual = copiaSitios.ElementAt(posSitio);


                                int posUsuario = random.Next(usuarioSitios.Count);
                                usuarioSitio = usuarioSitios.ElementAt(posUsuario);

                                int min = largosMinimosClaves.ElementAt(j);
                                int max = largosMaximosClaves.ElementAt(j);

                                int largoCodigo = random.Next(min, max + 1);
                                GeneradoraClaves generadoraActual = listaGeneradoras.ElementAt(j);
                                generadoraActual.Largo = largoCodigo;
                                string codigo = generadoraActual.Generar();

                                Clave aAgregar = new Clave()
                                {
                                    Sitio = sitioActual,
                                    Codigo = codigo,
                                    FechaModificacion = DateTime.Now,
                                    UsuarioClave = usuarioSitio,
                                    Nota = generadoraActual.Generar()
                                };

                                aAgregar =controladoraEncriptador.Encriptar(aAgregar);

                                controladoraUsuario.AgregarClave(aAgregar, nuevaCategoria, usuarioActual);
                                usuarioSitios.Remove(usuarioSitio);
                                copiaSitios.Remove(sitioActual);
                                paso = true;
                            }
                            catch (Exception)
                            {
                                string hola = "hola";
                            }
                        }

                    }


                }
            }*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VentanaPrincipal());

        }
    }
}
