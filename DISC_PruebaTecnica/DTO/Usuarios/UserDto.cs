namespace DISC_PruebaTecnica.DTO.Usuarios
{
    public class UserDto
    {      

        public string Usuario { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public int IdRol { get; set; }
        public int IdPuesto { get; set; }
    }

    public class User1Dto
    {

        public string Usuario1 { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; }
        public int IdPuesto { get; set; }
    }
}
