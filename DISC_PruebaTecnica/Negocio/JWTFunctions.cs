using DISC_PruebaTecnica.DTO.JWT;
using DISC_PruebaTecnica.Models;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DISC_PruebaTecnica.Negocio
{
    public class JWTFunctions
    {
        #region "Validación de token"
        public static usrLoginDto validateToken(ClaimsIdentity identity)
        {

            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return null;
                }
                else
                {
                    PruebaTecnicaContext _context = new PruebaTecnicaContext();
                    var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;                 
                    if (id != null)
                    {

                        Usuario usr = _context.Usuarios.FirstOrDefault(x => x.IdUsuario == Int32.Parse(id));
                        if (usr != null)
                        {
                            usrLoginDto usrLogin = new usrLoginDto() { Activo = usr.Activo, IdUsuario = usr.IdUsuario, NombreUsuario = usr.Usuario1, IdRol = usr.IdRol, IdPuesto = usr.IdPuesto};
                            return usrLogin;
                        }
                        else return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        #endregion

        #region "Encriptar y desencriptar AES"

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;
                rijAlg.Key = key;
                rijAlg.IV = iv;
                // Create a decrytor to perform the stream transform.
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                try
                {
                    // Create the streams used for decryption.
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }
            return plaintext;
        }
        private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            byte[] encrypted;
            // Create a RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
        public static string DecryptStringAES(string cipherText, HashDto hashDto)
        {
            var keybytes = Encoding.UTF8.GetBytes(hashDto.keybytes);
            var iv = Encoding.UTF8.GetBytes(hashDto.iv);

            var encrypted = Convert.FromBase64String(cipherText);
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
            return string.Format(decriptedFromJavascript);
        }
        public static string EncryptStringAES(string cipherText, HashDto hashDto)
        {
            var keybytes = Encoding.UTF8.GetBytes(hashDto.keybytes);
            var iv = Encoding.UTF8.GetBytes(hashDto.iv);
            var decriptedFromJavascript = EncryptStringToBytes(cipherText, keybytes, iv);
            var encrypted = Convert.ToBase64String(decriptedFromJavascript);
            return string.Format(encrypted);
        }
        #endregion

        #region "Encriptar Sha 256"
        public static string EncryptToSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convertimos el arreglo de bytes a una cadena hexadecimal
                StringBuilder hashString = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashString.Append(b.ToString("x2"));
                }
                return hashString.ToString();
            }
        }
        #endregion
    }
}
