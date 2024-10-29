using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppSuris.Server.Helpers
{
    public class Vendedores
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }
    }

    public class TypeVendedores
    {
        [JsonPropertyName("vendedores")]
        public List<Vendedores> Vendedores { get; set; } = new List<Vendedores>();
    }
}
