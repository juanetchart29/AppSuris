using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppSuris.Server.Models
{
    public class Articulos

    {

        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("precio")]
        public decimal Precio { get; set; }

        [JsonPropertyName("deposito")]
        public int Deposito { get; set; }



    }

    public class TypeArticulos
    {
        [JsonPropertyName("articulos")]
        public List<Articulos> Articulos { get; set; } = new List<Articulos>();
    }
}

}
