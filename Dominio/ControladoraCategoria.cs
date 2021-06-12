using Negocio;
using Repositorio;
using System;
using System.Collections.Generic;

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

        public void Modificar(Categoria vieja, Categoria nueva)
        {
            this.Verificar(vieja);
            this.Verificar(nueva);

            nueva.Id = vieja.Id;
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

        public void BorrarClave(Clave claveABorrar, Categoria categoriaIngresada)
        {
            if (this.EsListaClavesVacia(categoriaIngresada)) {
                throw new ObjetoInexistenteException();
            }
            if (!this.YaExisteClave(claveABorrar, categoriaIngresada)) {
                throw new ObjetoInexistenteException();
            }
            categoriaIngresada.Claves.Remove(claveABorrar);

            DataAccessCategoria acceso = new DataAccessCategoria();
            acceso.Modificar(categoriaIngresada);
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

            ControladoraClave controladoraClave = new ControladoraClave();
            controladoraClave.Modificar(claveVieja, claveNueva);
        }

        public List<Clave> GetListaClavesColor(string color, Categoria contenedora)
        {
            List<Clave> todasLasClaves = this.GetListaClaves(contenedora);
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            return todasLasClaves.FindAll(buscadora => nivelSeguridad.GetNivelSeguridad(buscadora.Codigo) == color);
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

        public void BorrarTarjeta(Tarjeta aBorrar, Categoria contenedora)
        {
            if (this.EsListaTarjetasVacia(contenedora) || !this.YaExisteTarjeta(aBorrar,contenedora))
            {
                throw new ObjetoInexistenteException();
            }
            contenedora.Tarjetas.Remove(aBorrar);
            DataAccessCategoria acceso = new DataAccessCategoria();
            acceso.Modificar(contenedora);
        }

        public void ModificarTarjeta(Tarjeta tarjetaVieja, Tarjeta tarjetaNueva, Categoria contenedora)
        {

            bool igualNumero = tarjetaVieja.Equals(tarjetaNueva);

            if (!this.YaExisteTarjeta(tarjetaVieja, contenedora)) throw new ObjetoInexistenteException();
            if (!igualNumero && this.YaExisteTarjeta(tarjetaNueva, contenedora)) throw new ObjetoYaExistenteException();

            ControladoraTarjeta controladoraTarjeta = new ControladoraTarjeta();
            controladoraTarjeta.Modificar(tarjetaVieja, tarjetaNueva);
        }
    }
}