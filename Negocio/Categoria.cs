using System.Collections.Generic;

namespace Negocio
{
    public class Categoria
    {
        public Categoria()
        {
            this.Claves = new List<Clave>();
            this.Tarjetas = new List<Tarjeta>();
        }

        public string Nombre { get; set; }

        public int Id { get; set; }

        public List<Clave> Claves { get; set; }

        public List<Tarjeta> Tarjetas { get; set; }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Categoria aIgualar = (Categoria)objeto;
            return aIgualar.Nombre.ToUpper() == this.Nombre.ToUpper();
        }
    }
}