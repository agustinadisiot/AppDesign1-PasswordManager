using Negocio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeNegocio
{
    public class ControladoraCategoria: IControladora<Categoria>
    {
        private const int _largoNombreMinimo = 3;
        private const int _largoNombreMaximo = 15;

        public void Verificar(Categoria aVerificar)
        {
            this.VerificarNombre(aVerificar);
        }

        public void Modificar(Categoria nueva)
        {
            this.Verificar(nueva);
            DataAccessCategoria acceso = new DataAccessCategoria();
            acceso.Modificar(nueva);
        }

        public void VerificarNombre(Categoria aVerificar)
        {
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.Nombre, _largoNombreMinimo, _largoNombreMaximo);
        }

        public bool EsListaClavesVacia(Categoria aVerificar)
        {
            bool noHayClaves = (aVerificar.Claves.Count == 0);
            return noHayClaves;
        }

        public void AgregarClave(Clave claveIngresada, Categoria categoriaIngresada)
        {
            ControladoraClave controladoraClave = new ControladoraClave();
            controladoraClave.Verificar(claveIngresada);

            if (this.YaExisteClave(claveIngresada, categoriaIngresada)) throw new ObjetoYaExistenteException();

            categoriaIngresada.Claves.Add(claveIngresada);

            DataAccessCategoria acceso = new DataAccessCategoria();
            acceso.Modificar(categoriaIngresada);
        }

        public void BorrarClave(Clave ingreso, Categoria contenedora)
        {
            if (this.EsListaClavesVacia(contenedora)) {
                throw new ObjetoInexistenteException();
            }
            if (!this.YaExisteClave(ingreso, contenedora)) {
                throw new ObjetoInexistenteException();
            }

            Clave aBorrar = this.GetClave(ingreso, contenedora);

            contenedora.Claves.Remove(aBorrar);

            ControladoraClave controladoraClave = new ControladoraClave();
            controladoraClave.Borrar(aBorrar);

            DataAccessCategoria acceso = new DataAccessCategoria();
            acceso.Modificar(contenedora);
        }

        public Clave GetClave(Clave aBuscar, Categoria categoriaIngresada)
        {
            if (this.EsListaClavesVacia(categoriaIngresada)) {
                throw new ObjetoInexistenteException();
            }


            Clave retorno = categoriaIngresada.Claves.Find(clave => clave.Equals(aBuscar));
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public bool YaExisteClave(Clave aBuscar, Categoria contenedora)
        {
            return (contenedora.Claves.Contains(aBuscar));
        }

        public void ModificarClave(Clave claveVieja, Clave claveNueva, Categoria contenedora)
        {
            bool igualSitioyUsuario = claveVieja.Equals(claveNueva);

            if (!this.YaExisteClave(claveVieja, contenedora)) throw new ObjetoInexistenteException();
            if (!igualSitioyUsuario && this.YaExisteClave(claveNueva, contenedora)) throw new ObjetoYaExistenteException();

            Clave aModificar = this.GetClave(claveVieja, contenedora);


            aModificar.UsuarioClave = claveNueva.UsuarioClave;
            aModificar.Sitio = claveNueva.Sitio;
            aModificar.Nota = claveNueva.Nota;
            aModificar.Codigo = claveNueva.Codigo;

            ControladoraClave controladoraClave = new ControladoraClave();
            controladoraClave.Modificar(aModificar);

            

            DataAccessCategoria acceso = new DataAccessCategoria();
            acceso.Modificar(contenedora);
        }

        public List<Clave> GetListaClavesColor(string color, Categoria contenedora)
        {
            List<Clave> todasLasClaves = this.GetListaClaves(contenedora);
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ControladoraEncriptador controladoraEncriptador = new ControladoraEncriptador();

            try
            {
                IEnumerable<Clave> desencriptadas = todasLasClaves.Select(buscadora => controladoraEncriptador.Desencriptar(buscadora));
                return desencriptadas.ToList().FindAll(buscadora => nivelSeguridad.GetNivelSeguridad(buscadora.Codigo) == color);
            }
            catch (Exception)
            {
                return todasLasClaves.FindAll(buscadora => nivelSeguridad.GetNivelSeguridad(buscadora.Codigo) == color);
            }
        }

        public List<Clave> GetListaClaves(Categoria categoria)
        {
            return categoria.Claves;
        }

        public bool EsListaTarjetasVacia(Categoria aVerificar)
        {
            bool noHayTarjetas = aVerificar.Tarjetas.Count == 0;
            return noHayTarjetas;
        }

        public void AgregarTarjeta(Tarjeta tarjetaIngresada, Categoria categoriaIngresada)
        {
            ControladoraTarjeta controladoraTarjeta = new ControladoraTarjeta();

            controladoraTarjeta.Verificar(tarjetaIngresada);

            if (this.YaExisteTarjeta(tarjetaIngresada, categoriaIngresada)) throw new ObjetoYaExistenteException();
           
            categoriaIngresada.Tarjetas.Add(tarjetaIngresada);
            DataAccessCategoria acceso = new DataAccessCategoria();
            acceso.Modificar(categoriaIngresada);
        }

        public Tarjeta GetTarjeta(Tarjeta aBuscar, Categoria categoriaIngresada)
        {
            if (this.EsListaTarjetasVacia(categoriaIngresada)) throw new ObjetoInexistenteException();
            
            Tarjeta retorno = categoriaIngresada.Tarjetas.Find(tarjeta => tarjeta.Equals(aBuscar));
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public List<Tarjeta> GetListaTarjetas(Categoria categoria)
        {
            return categoria.Tarjetas;
        }
        
        public bool YaExisteTarjeta(Tarjeta aBuscar, Categoria aVerificar)
        {
            return (aVerificar.Tarjetas.Contains(aBuscar));
        }

        public void BorrarTarjeta(Tarjeta ingreso, Categoria contenedora)
        {
            if (this.EsListaTarjetasVacia(contenedora) || !this.YaExisteTarjeta(ingreso,contenedora))
            {
                throw new ObjetoInexistenteException();
            }

            Tarjeta aBorrar = this.GetTarjeta(ingreso, contenedora);

            contenedora.Tarjetas.Remove(aBorrar);

            ControladoraTarjeta controladoraTarjeta = new ControladoraTarjeta();
            controladoraTarjeta.Borrar(aBorrar);

            DataAccessCategoria acceso = new DataAccessCategoria();
            acceso.Modificar(contenedora);
        }

        public void ModificarTarjeta(Tarjeta tarjetaVieja, Tarjeta tarjetaNueva, Categoria contenedora)
        {

            bool igualNumero = tarjetaVieja.Equals(tarjetaNueva);

            if (!this.YaExisteTarjeta(tarjetaVieja, contenedora)) throw new ObjetoInexistenteException();
            if (!igualNumero && this.YaExisteTarjeta(tarjetaNueva, contenedora)) throw new ObjetoYaExistenteException();

            Tarjeta aModificar = this.GetTarjeta(tarjetaVieja, contenedora);

            aModificar.Nombre = tarjetaNueva.Nombre;
            aModificar.Numero = tarjetaNueva.Numero;
            aModificar.Tipo = tarjetaNueva.Tipo;
            aModificar.Codigo = tarjetaNueva.Codigo;
            aModificar.Nota = tarjetaNueva.Nota;
            aModificar.Vencimiento = tarjetaNueva.Vencimiento;

            ControladoraTarjeta controladoraTarjeta = new ControladoraTarjeta();
            controladoraTarjeta.Modificar(aModificar);

            DataAccessCategoria acceso = new DataAccessCategoria();
            acceso.Modificar(contenedora);
        }
    }
}