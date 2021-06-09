﻿namespace Dominio
{
    public class Filtrada
    {
        public string Texto { get; set; }
        public Filtrada()
        {
        }

        public Filtrada(string texto)
        {
            this.Texto = texto;
        }
        public override string ToString()
        {
            return this.Texto;
        }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (this.GetType() != objeto.GetType()) throw new ObjetoIncorrectoException();
            Filtrada aIgualar = (Filtrada)objeto;
            bool mismoTexto = aIgualar.Texto == this.Texto;
            return (mismoTexto);
        }
    }
}