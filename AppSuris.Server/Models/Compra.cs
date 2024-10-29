using System.Text.Json.Serialization;

namespace AppSuris.Server.Helpers
{
    public class Compra
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("vendedorId")]
        public int VendedorId { get; set; }

        [JsonPropertyName("articulosIds")]
        public List<string> ArticulosIds { get; set; } = new List<string>();

        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }
    }
    public class TypeCompra
    {
        [JsonPropertyName("compras")]
        public List<Compra> Compras { get; set; } = new List<Compra>();
    }
}
