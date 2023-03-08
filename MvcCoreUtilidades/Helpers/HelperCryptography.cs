using System.Security.Cryptography;
using System.Text;

namespace MvcCoreUtilidades.Helpers
{
    public class HelperCryptography
    {
        public static string Salt { get; set; }

        private static string GenerateSalt()
        {
            Random random = new Random();
            string salt = "";
            for(int i = 0; i <= 50; i++)
            {
                int alet = random.Next(0, 255);
                char letra = Convert.ToChar(alet);
                salt += letra;
            }
            return salt;
        }

        public static string EncriptarContenido(string contenido, bool comparar)
        {
            if(comparar == false)
            {
                Salt = GenerateSalt();
            }
            string contenidoSalt = contenido + Salt;
            SHA256 sHA256 = SHA256.Create();
            byte[] salida;
            UnicodeEncoding encoding = new UnicodeEncoding();
            salida = encoding.GetBytes(contenidoSalt);
            for(int i = 1; i <= 24; i++)
            {
                salida = sHA256.ComputeHash(salida);
            }
            sHA256.Clear();
            string resultado = encoding.GetString(salida);
            return resultado;
        }

        public static string EncriptarTextoBasico(string contenido)
        {
            byte[] entrada;
            byte[] salida;

            UnicodeEncoding encoding = new UnicodeEncoding();
            SHA1Managed sha1 = new SHA1Managed();

            entrada = encoding.GetBytes(contenido);
            salida = sha1.ComputeHash(entrada);
            string resultado = encoding.GetString(salida);

            return resultado;
        }
    }
}
