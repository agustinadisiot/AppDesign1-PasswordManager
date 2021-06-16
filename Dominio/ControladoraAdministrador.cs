using Negocio;
using Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeNegocio
{
    public class ControladoraAdministrador
    {
        public void BorrarTodo() {
            DataAccessClaveCompartida accesoClaveCompartida = new DataAccessClaveCompartida();
            List<ClaveCompartida> claveCompartidasABorrar = (List<ClaveCompartida>)accesoClaveCompartida.GetTodos();
            foreach (ClaveCompartida aBorrar in claveCompartidasABorrar)
            {
                accesoClaveCompartida.Borrar(aBorrar);
            }

            DataAccessTarjeta daTarjeta = new DataAccessTarjeta();
            List<Tarjeta> tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
            foreach (Tarjeta tarjeta in tarjetas)
            {
                daTarjeta.Borrar(tarjeta);
            }

            DataAccessClave daClave = new DataAccessClave();
            List<Clave> claves = (List<Clave>)daClave.GetTodos();
            foreach (Clave clave in claves)
            {
                daClave.Borrar(clave);
            }

            DataAccessFiltrada daFiltrada = new DataAccessFiltrada();
            List<Filtrada> borrarFiltradas = (List<Filtrada>)daFiltrada.GetTodos();
            foreach (Filtrada filtrada in borrarFiltradas)
            {
                daFiltrada.Borrar(filtrada);
            }

            DataAccessDataBreach daDataBreach = new DataAccessDataBreach();
            List<DataBreach> dataBreaches = (List<DataBreach>)daDataBreach.GetTodos();
            foreach (DataBreach db in dataBreaches)
            {
                daDataBreach.Borrar(db);
            }

            DataAccessCategoria accesoCategoria = new DataAccessCategoria();
            List<Categoria> categoriasABorrar = (List<Categoria>)accesoCategoria.GetTodos();
            foreach (Categoria aBorrar in categoriasABorrar)
            {
                accesoCategoria.Borrar(aBorrar);
            }

            DataAccessUsuario accesoUsuario = new DataAccessUsuario();
            List<Usuario> usuariosABorrar = (List<Usuario>)accesoUsuario.GetTodos();
            foreach (Usuario aBorrar in usuariosABorrar) {
                accesoUsuario.Borrar(aBorrar);
            }
        }

        public bool EsListaUsuariosVacia()
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            List<Usuario> usuarios = (List<Usuario>)acceso.GetTodos();
            return usuarios.Count() == 0;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            controladoraUsuario.Verificar(usuario);

            if (this.YaExisteUsuario(usuario)) throw new ObjetoYaExistenteException();
            DataAccessUsuario acceso = new DataAccessUsuario();
            acceso.Agregar(usuario);
        }

        public Usuario GetUsuario(Usuario aBuscar)
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            List<Usuario> usuarios = (List<Usuario>)acceso.GetTodos();
            Usuario retorno = usuarios.FirstOrDefault(aBuscar.Equals);
            if (retorno != null)
            {
                return acceso.Get(retorno.Id);
            }
            else {
                throw new ObjetoInexistenteException();
            }
        }

        public bool YaExisteUsuario(Usuario buscador)
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            List<Usuario> usuarios = (List<Usuario>)acceso.GetTodos();
            return usuarios.Contains(buscador);
        }

        public List<Usuario> GetListaUsuarios()
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            List<Usuario> usuarios = (List<Usuario>)acceso.GetTodos();
            return usuarios;
        }

        public void CompartirClave(ClaveCompartida aCompartir)
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();

            Usuario usuarioOriginal = aCompartir.Original;
            Usuario usuarioDestino = aCompartir.Destino;
            Clave claveACompartir = controladoraUsuario.GetClave(aCompartir.Clave, usuarioOriginal);


            if (claveACompartir == null) {
                throw new ObjetoInexistenteException();
            }

            if (usuarioOriginal.CompartidasPorMi.Contains(aCompartir)) throw new ObjetoYaExistenteException();


            claveACompartir.EsCompartida = true;
            ControladoraClave controladoraClave = new ControladoraClave();
            controladoraClave.Modificar(claveACompartir);

            ClaveCompartida guardar = new ClaveCompartida()
            {
                Original = usuarioOriginal,
                Destino = usuarioDestino,
                Clave = claveACompartir
            };

            DataAccessClaveCompartida accesoCompartidas = new DataAccessClaveCompartida();
            accesoCompartidas.Agregar(guardar);

            usuarioOriginal.CompartidasPorMi.Add(guardar);
            acceso.Modificar(usuarioOriginal);

            usuarioOriginal = this.GetUsuario(usuarioOriginal);

            guardar = controladoraUsuario.GetClaveCompartidaPorMi(guardar, usuarioOriginal);

            usuarioDestino.CompartidasConmigo.Add(guardar);
            acceso.Modificar(usuarioDestino);
        }

        public void DejarDeCompartir(ClaveCompartida aDejarCompartir)
        {
            List<Usuario> usuarios = this.GetListaUsuarios();
            DataAccessUsuario acceso = new DataAccessUsuario();
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            ControladoraClave controladoraClave = new ControladoraClave();

            Usuario usuarioOriginal = aDejarCompartir.Original;
            Usuario usuarioDestino = aDejarCompartir.Destino;
            Clave claveADejarDeCompartir = aDejarCompartir.Clave;

            if (!claveADejarDeCompartir.EsCompartida) throw new ObjetoInexistenteException();

            ClaveCompartida aEliminar = controladoraUsuario.GetClaveCompartidaPorMi(aDejarCompartir, usuarioOriginal);

            if (!usuarioDestino.CompartidasConmigo.Contains(aEliminar)) throw new ObjetoInexistenteException();

            DataAccessClaveCompartida accesoCompartidas = new DataAccessClaveCompartida();
            accesoCompartidas.Borrar(aEliminar);

            usuarioOriginal.CompartidasPorMi.Remove(aEliminar);
            usuarioDestino.CompartidasConmigo.Remove(aEliminar);

            bool sigueCompartida = usuarioOriginal.CompartidasPorMi.Any(buscadora => buscadora.Clave.Equals(claveADejarDeCompartir));
            if (!sigueCompartida) {
                claveADejarDeCompartir.EsCompartida = false;
                controladoraClave.Modificar(claveADejarDeCompartir);
            }

        }

        public Encriptador GetEncriptadorClave() {
            DataAccessEncriptador accesoEncriptador = new DataAccessEncriptador();
            IEnumerable<Encriptador> encriptadores = accesoEncriptador.GetTodos();
            Encriptador retorno = encriptadores.FirstOrDefault();
            if (retorno != null)
            {
                return retorno;
            }
            else
            {
                retorno = new Encriptador();
                accesoEncriptador.Agregar(retorno);
                return retorno;
            }
        }
    }
}