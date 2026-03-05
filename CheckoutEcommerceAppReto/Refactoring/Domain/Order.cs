namespace Refactoring.Domain
{
    public class Order
    {
        public required string NombreCliente { get; set; }
        public required string EmailCliente { get; set; }
        public required string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; } = 1000;
        public required string MedioPago { get; set; }
        public decimal TotalOrden => Cantidad * PrecioUnitario;
    }
}
