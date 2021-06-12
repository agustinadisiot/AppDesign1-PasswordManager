﻿namespace LogicaDeNegocio
{
    public class ClaveCompartida
    {
        public ControladoraUsuario Original { get; set; }
        public ControladoraUsuario Destino { get; set; }
        public ControladoraClave Clave { get; set; }
        public int Id { get; set; }
        public int OriginalId { get; set; }
        public int DestinoId { get; set; }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            ClaveCompartida aIgualar = (ClaveCompartida)objeto;
            bool igualOriginal = this.Original.Equals(aIgualar.Original);
            bool igualDestino = this.Destino.Equals(aIgualar.Destino);
            bool igualClave = this.Clave.Equals(aIgualar.Clave);
            return (igualOriginal && igualDestino && igualClave);
        }
    }
}
