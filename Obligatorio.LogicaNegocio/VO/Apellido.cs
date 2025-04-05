using Obligatorio.LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Apellido
    {
        public string Value { get; }

        public Apellido(string value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value)) throw new ApellidoException("Apellido inválido");
        }
    }
}
