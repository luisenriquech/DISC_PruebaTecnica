namespace DISC_PruebaTecnica.DTO.JWT
{
    public class JWTdto
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
        public int TimeSession { get; set; }

    }
}