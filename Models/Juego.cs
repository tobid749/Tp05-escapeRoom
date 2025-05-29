namespace Tp05_escapeRoom.Models;
using Newtonsoft.Json;
public class Juego {
    
    [JsonProperty]
      public string Nombre { get; set; }
      [JsonProperty]
        public int SalaActual { get; set; }
        [JsonProperty]
        public int LlavesEncontradas { get; set; }
        [JsonProperty]
        public bool TieneGuante { get; set; }
        [JsonProperty]
        
        public int GolpesAlJefe { get; set; }
        
        public Juego(string Nombre, int SalaActual, int LlavesEncontradas, bool TieneGuante, int GolpesAlJefe)
        {
            this.Nombre = Nombre;
            this.SalaActual =1;
            this.LlavesEncontradas = 0;
            this.TieneGuante = false;
            this.GolpesAlJefe = 0;

        }

}