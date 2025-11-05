using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreCliente { get; set; }

        public List<ArticuloFactura> Articulos { get; set; } = new List<ArticuloFactura>();

        [NotMapped]
        public decimal Total => CalcularTotal();

        private decimal CalcularTotal()
        {
            decimal total = 0;
            if (Articulos != null)
            {
                foreach (var articulo in Articulos)
                {
                    total += articulo.Precio * articulo.Cantidad;
                }
            }
            return total;
        }
    }
}
public class ArticuloFactura
{
    [Key]
    public int Id { get; set; }

    public int FacturaId { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public int Cantidad { get; set; } = 1;

    [Required]
    public decimal Precio { get; set; }

    [NotMapped]
    public decimal Subtotal => Cantidad * Precio;
}
