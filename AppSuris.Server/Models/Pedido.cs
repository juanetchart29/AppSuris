using System.Text.Json.Serialization;

namespace AppSuris.Server.Helpers
{
    public class Pedido
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("vendedorId")]
        public int VendedorId { get; set; }

        [JsonPropertyName("articulosIds")] // el codigo de los articulos, queda mal poner articulosCodigos
        public List<string> ArticulosIds { get; set; } = new List<string>();

        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }
    }
    public class TypePedido
    {
        [JsonPropertyName("pedidos")]
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
