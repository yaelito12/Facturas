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