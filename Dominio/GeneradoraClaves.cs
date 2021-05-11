using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class GeneradoraClaves
    {
        private Random _aleatorio;

        private const string _mayusculas = "Mayusculas";
        private const string _minusculas = "Minusculas";
        private const string _numeros = "Numeros";
        private const string _simbolos = "Simbolos";
        private int _largo;

        public bool IncluirMayusculas {get;set;}

        public bool IncluirMinusculas {get; set;}

        public bool IncluirNumeros { get; set; }

        public bool IncluirSimbolos { get; set; }

        public int Largo 
        {
            get { return this._largo; }
            set { this._largo = (value < 5 || value > 25) ? throw new LargoIncorrectoException(): value; } 
        }

        public GeneradoraClaves() {
            this._aleatorio = new Random();
            this._largo = 25;
        }

        public string Generar()
        {
            bool parametrosVacios = 
              !(this.IncluirMayusculas ||
                this.IncluirMinusculas ||
                this.IncluirNumeros ||
                this.IncluirSimbolos);

            if (parametrosVacios) throw new ClaveGeneradaVaciaException();

            List<string> tiposCaracteres = new List<string>();

            
            bool[] ocupado = new bool[this.Largo];

            char[] resultado = this.CargarNecesarios(tiposCaracteres, ocupado);

            this.LlenarRestantes(resultado, ocupado, tiposCaracteres);

            return new string(resultado);
        }

        private char[] CargarNecesarios(List<string> tiposCaracteres, bool[] ocupado) {
            char[] resultado = new char[this.Largo];
            if (this.IncluirMayusculas)
            {
                tiposCaracteres.Add(_mayusculas);
                int pos = this.GenerarPosicion(ocupado);
                resultado[pos] = this.GenerarMayuscula();
                ocupado[pos] = true;
            }
            if (this.IncluirMinusculas)
            {
                tiposCaracteres.Add(_minusculas);
                int pos = this.GenerarPosicion(ocupado);
                resultado[pos] = this.GenerarMinuscula();
                ocupado[pos] = true;
            }
            if (this.IncluirNumeros)
            {
                tiposCaracteres.Add(_numeros);
                int pos = this.GenerarPosicion(ocupado);
                resultado[pos] = this.GenerarNumero();
                ocupado[pos] = true;
            }
            if (this.IncluirSimbolos)
            {
                tiposCaracteres.Add(_simbolos);
                int pos = this.GenerarPosicion(ocupado);
                resultado[pos] = this.GenerarSimbolo();
                ocupado[pos] = true;
            }
            return resultado;
        }

        private void LlenarRestantes(char[] resultado, bool[] ocupado, List<string> tiposCaracteres) {
            for (int i = 0; i < this.Largo; i++)
            {
                if (!ocupado[i])
                {
                    ocupado[i] = true;
                    int posCategoriaElegida = this._aleatorio.Next(tiposCaracteres.Count);
                    string categoriaElegida = tiposCaracteres[posCategoriaElegida];
                    switch (categoriaElegida)
                    {
                        case _mayusculas:
                            resultado[i] = this.GenerarMayuscula();
                            break;
                        case _minusculas:
                            resultado[i] = this.GenerarMinuscula();
                            break;
                        case _numeros:
                            resultado[i] = this.GenerarNumero();
                            break;
                        case _simbolos:
                            resultado[i] = this.GenerarSimbolo();
                            break;
                        default:
                            throw new CaracterInesperadoException();
                            break;
                    }
                }
            }
        }

        private int GenerarPosicion(bool[] ocupado)
        {
            int pos = this._aleatorio.Next(this.Largo);
            while (ocupado[pos])
            {
                pos = this._aleatorio.Next(this.Largo);
            }
            return pos;
        }

        private char GenerarMayuscula()
        {
            const int asciiMayusculaMinimo = 65;
            const int asciiMayusculaMaximo = 90;
            char retorno = (char)(this._aleatorio.Next(asciiMayusculaMinimo, asciiMayusculaMaximo + 1));
            return retorno;
        }

        private char GenerarMinuscula()
        {
            const int asciiMinusculaMinimo = 97;
            const int asciiMinusculaMaximo = 122;
            char retorno = (char)this._aleatorio.Next(asciiMinusculaMinimo, asciiMinusculaMaximo + 1);
            return retorno;
        }

        private char GenerarNumero()
        {
            const int asciiDigitoMinimo = 48;
            const int asciiDigitoMaximo = 57;
            char retorno = (char)this._aleatorio.Next(asciiDigitoMinimo, asciiDigitoMaximo + 1);
            return retorno;
        }

        private char GenerarSimbolo()
        {
            const int asciiRango1Minimo = 32;
            const int asciiRango1Maximo = 47;
            const int asciiRango2Minimo = 58;
            const int asciiRango2Maximo = 64;
            const int asciiRango3Minimo = 91;
            const int asciiRango3Maximo = 96;
            const int asciiRango4Minimo = 123;
            const int asciiRango4Maximo = 126;
            const int rangoMinimo = 1;
            const int rangoMaximo = 5;

            int rango = this._aleatorio.Next(rangoMinimo, rangoMaximo);
            char resultado;
            switch (rango)
            {
                case 1:
                    resultado = (char)this._aleatorio.Next(asciiRango1Minimo, asciiRango1Maximo);
                    break;
                case 2:
                    resultado = (char)this._aleatorio.Next(asciiRango2Minimo, asciiRango2Maximo);
                    break;
                case 3:
                    resultado = (char)this._aleatorio.Next(asciiRango3Minimo, asciiRango3Maximo);
                    break;
                case 4:
                    resultado = (char)this._aleatorio.Next(asciiRango4Minimo, asciiRango4Maximo);
                    break;
                default:
                    throw new CaracterInesperadoException();
                    break;
            }
            return resultado;
        }

    }
}
