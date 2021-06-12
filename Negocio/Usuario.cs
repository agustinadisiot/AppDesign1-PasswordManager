using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Negocio
{
    public class Usuario
    {

        public List<Categoria> Categorias { get; set; }

        public Usuario()
        {
            this.Categorias = new List<Categoria>();
            this.CompartidasConmigo = new List<ClaveCompartida>();
            this.CompartidasPorMi = new List<ClaveCompartida>();
            this.DataBreaches = new List<DataBreach>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string ClaveMaestra { get; set; }
        public List<ClaveCompartida> CompartidasPorMi { get; set; }

        public List<ClaveCompartida> CompartidasConmigo { get; set; }

        public List<DataBreach> DataBreaches { get; set; }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Usuario aIgualar = (Usuario)objeto;
            return aIgualar.Nombre.ToUpper() == this.Nombre.ToUpper();
        }

    }
}