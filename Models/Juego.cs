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
        public int Guantes { get; set; }
        [JsonProperty]
        
        public int GolpesAlJefe { get; set; }
          [JsonProperty]
        
        public int Cafeteras { get; set; }
        
        public Juego(string Nombre, int SalaActual, int LlavesEncontradas, bool TieneGuante, int GolpesAlJefe)
        {
            this.Nombre = Nombre;
            this.SalaActual =1;
            this.LlavesEncontradas = 0;
            this.Guantes = 0;
            this.GolpesAlJefe = 0;
            this.Cafeteras = 0;

        }

}