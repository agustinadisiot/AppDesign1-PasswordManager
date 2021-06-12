﻿using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    class UsuarioTypeConfiguration : EntityTypeConfiguration<ControladoraUsuario>
    {
        public UsuarioTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Nombre).IsRequired();
            this.Property(x => x.ClaveMaestra).IsRequired();
            this.HasMany<ControladoraCategoria>(usuario => usuario.Categorias);
            this.HasMany<DataBreach>(usuario => usuario.DataBreaches);/*
            this.HasMany<ClaveCompartida>(usuario => usuario.CompartidasConmigo).WithRequired(cc => cc.Destino).WillCascadeOnDelete(false);
            this.HasMany<ClaveCompartida>(usuario => usuario.CompartidasPorMi).WithRequired(cc => cc.Original).WillCascadeOnDelete(false);*/
        }
    }
}
