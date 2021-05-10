using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Clave
    {
        private string _usuario;
        private string _codigo;
        private string _sitio;
        private string _nota;
        private DateTime _fechaModificacion;
        public bool EsCompartida;
        private const int _largoUsuarioYClaveMinimo = 5;
        private const int _largoUsuarioYClaveMaximo = 25;
        private const int _largoSitioMinimo = 3;
        private const int _largoSitioMaximo = 25;
        private const int _largoNotaMinimo = 0;
        private const int _largoNotaMaximo = 250;
        private Random _aleatorio;

        public Clave()
        {
            _aleatorio = new Random();
            this.EsCompartida = false;
        }

        public string UsuarioClave
        {
            get { return _usuario; }
            set { this._usuario = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoUsuarioYClaveMinimo, _largoUsuarioYClaveMaximo); }
        }

        public string Codigo
        {
            get { return _codigo; }
            set { CambioClave(value); }
        }


        private void CambioClave(string ingreso) {

            try
            {
                this._codigo = VerificadoraString.VerificarLargoEntreMinimoYMaximo(ingreso, _largoUsuarioYClaveMinimo, _largoUsuarioYClaveMaximo);
                this.ActualizarFechaModificacion();
            }
            catch (LargoIncorrectoException) {
                throw new LargoIncorrectoException();
            }
        }

        public string Sitio
        {
            get { return _sitio; }
            set { this._sitio = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoSitioMinimo, _largoSitioMaximo); }
        }

        public string Nota
        {
            get { return _nota; }
            set { this._nota = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNotaMinimo, _largoNotaMaximo); }
        }

        public DateTime FechaModificacion
        {
            get { return this._fechaModificacion; }
            set { this._fechaModificacion = value; }
        }


        public string GetNivelSeguridad()
        {
            const int largoRojoMaximo = 7;
            const int largoNaranjaMaximo = 13;

            string rojo = "rojo",
                naranja = "naranja",
                amarillo = "amarillo",
                verdeClaro = "verde claro",
                verdeOscuro = "verde oscuro";

            if (this.Codigo.Length <= largoRojoMaximo) return rojo;
            if(this.Codigo.Length <= largoNaranjaMaximo) return naranja;

            bool tieneMin = false,
                tieneMay = false,
                tieneNum = false,
                tieneSim = false;

            foreach (char caracter in this.Codigo)
            {
                if (!tieneMay || !tieneMin || !tieneMin || !tieneSim)
                {
                    tieneMin = tieneMin || VerificadoraString.EsMinuscula(caracter);
                    tieneMay = tieneMay || VerificadoraString.EsMayuscula(caracter);
                    tieneNum = tieneNum || VerificadoraString.EsNumero(caracter);
                    tieneSim = tieneSim || VerificadoraString.EsSimbolo(caracter);
                }
                else return verdeOscuro;
            }
            if(tieneMin && tieneMay) return (tieneNum && tieneSim) ? verdeOscuro : verdeClaro;

            return amarillo;   
        }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (this.GetType() != objeto.GetType()) throw new ObjetoIncorrectoException();
            Clave aIgualar = (Clave)objeto;
            bool mismoSitio = aIgualar.Sitio.ToUpper() == this.Sitio.ToUpper();
            bool mismoUsuario = aIgualar.UsuarioClave == this.UsuarioClave;
            return (mismoSitio && mismoUsuario);
        }

        private void ActualizarFechaModificacion()
        {
            this._fechaModificacion = System.DateTime.Now.Date;
        }

        public void GenerarClave(ClaveAGenerar parametros)
        {
            bool parametrosVacios = !(parametros.IncluirMayusculas || parametros.IncluirMinusculas || parametros.IncluirNumeros || parametros.IncluirSimbolos);
            if (parametrosVacios) throw new ClaveGeneradaVaciaException();

            List<string> categoriasDisponibles = new List<string>();
            const string incluirMayusculas = "Mayusculas";
            const string incluirMinusculas = "Minusculas";
            const string incluirNumeros = "Numeros";
            const string incluirSimbolos = "Simbolos";

            int largo = parametros.Largo;
            char[] resultado = new char[largo];
            bool[] ocupado = new bool[largo];

            if (parametros.IncluirMayusculas)
            {
                categoriasDisponibles.Add(incluirMayusculas);
                int pos = this.GenerarPosicion(largo, ocupado);
                resultado[pos] = VerificadoraString.GenerarMayuscula(this._aleatorio);
                ocupado[pos] = true;
            }
            if (parametros.IncluirMinusculas)
            {
                categoriasDisponibles.Add(incluirMinusculas);
                int pos = this.GenerarPosicion(largo, ocupado);
                resultado[pos] = VerificadoraString.GenerarMinuscula(this._aleatorio);
                ocupado[pos] = true;
            }
            if (parametros.IncluirNumeros)
            {
                categoriasDisponibles.Add(incluirNumeros);
                int pos = this.GenerarPosicion(largo, ocupado);
                resultado[pos] = VerificadoraString.GenerarNumero(this._aleatorio);
                ocupado[pos] = true;
            }
            if (parametros.IncluirSimbolos)
            {
                categoriasDisponibles.Add(incluirSimbolos);
                int pos = this.GenerarPosicion(largo, ocupado);
                resultado[pos] = VerificadoraString.GenerarSimbolo(this._aleatorio);
                ocupado[pos] = true;
            }
            
            for(int i = 0;  i< largo; i++)
            {
                if (!ocupado[i])
                {
                    ocupado[i] = true;
                    int posCategoriaElegida = this._aleatorio.Next(categoriasDisponibles.Count);
                    string categoriaElegida = categoriasDisponibles[posCategoriaElegida];
                    switch (categoriaElegida)
                    {
                        case incluirMayusculas:
                            resultado[i] = VerificadoraString.GenerarMayuscula(this._aleatorio);
                            break;
                        case incluirMinusculas:
                            resultado[i] = VerificadoraString.GenerarMinuscula(this._aleatorio);
                            break;
                        case incluirNumeros:
                            resultado[i] = VerificadoraString.GenerarNumero(this._aleatorio);
                            break;
                        case incluirSimbolos:
                            resultado[i] = VerificadoraString.GenerarSimbolo(this._aleatorio);
                            break;
                        default:
                            throw new CaracterInesperadoException();
                            break;
                    }
                }
            }
            this.Codigo = new string(resultado);
        }

        private int GenerarPosicion(int largo, bool[] ocupado)
        {
            int pos = this._aleatorio.Next(largo);
            while (ocupado[pos])
            {
                pos = this._aleatorio.Next(largo);
            }
            return pos;
        }
    }
}