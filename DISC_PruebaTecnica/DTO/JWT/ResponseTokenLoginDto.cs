namespace DISC_PruebaTecnica.DTO.JWT
{
    public class ResponseTokenLoginDto
    {
        public string? token { get; set; }
        public string? nombre { get; set; }
        public string? email { get; set; }
        public int idRol { get; set; }
        public int idPuesto { get; set; }
        public DateTime? Caducidad { get; set; }
        public int MinutosSesion { get; set; }
    }
}
