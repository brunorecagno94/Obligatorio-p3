namespace Obligatorio.LogicaNegocio.VO
{
    public record EntregaEficiente
    {
        public bool Value { get; }

        public EntregaEficiente(bool value)
        {
            Value = value;
        }

    }
}
