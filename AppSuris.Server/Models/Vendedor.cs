using System.Text.Json.Serialization;

namespace AppSuris.Server.Models
{
    public class Vendedor
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }
    }

    public class TypeVendedor
    {
        [JsonPropertyName("vendedores")]
        public List<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
    }
}
