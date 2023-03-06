using System.Security.Cryptography;
using System.Text;

namespace MvcCoreUtilidades.Helpers
{
    public class HelperCryptography
    {
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
