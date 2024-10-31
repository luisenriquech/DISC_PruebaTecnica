namespace DISC_PruebaTecnica.DTO.JWT
{
    public class usrLoginDto
    {
        public int IdUsuario { get; set; }
        public int IdPuesto { get; set; }
        public int IdRol { get; set; }
        public string? NombreUsuario { get; set; }        
        public bool? Activo { get; set; }
        
    }
}