namespace ApiRestIPSPROAA.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public Boolean Estado { get; set;}
        public Cargo Cargo { get; set; }
    }
}
