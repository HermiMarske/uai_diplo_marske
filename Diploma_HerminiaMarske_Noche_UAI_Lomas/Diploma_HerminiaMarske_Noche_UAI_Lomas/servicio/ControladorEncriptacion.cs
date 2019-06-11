using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    public static class ControladorEncriptacion
    {
        private const string Key = "f2EnEMVQy6WCT2_OynNWk_ysrYBB_oEY";
        private static byte[] IV = { 225, 30, 40, 17, 200, 45, 7, 21, 55, 76, 111, 193, 69, 98, 4, 15 };

        /// <summary>
        /// Salt única aleatoria
        /// </summary>
        private const string SaltKey = "$9OvZM46T6E4ku1l8nxtnsnWxHKEBWGIUTvC0CElZ$V1$";

        /// <summary>
        /// Tamaño del salt.
        /// </summary>
        private const int SaltSize = 16;

        /// <summary>
        /// Tamaño del hash.
        /// </summary>
        private const int HashSize = 20;

        /// <summary>
        /// Genera un hash en base a un password
        /// </summary>
        /// <param name="password">Contraseña.</param>
        /// <param name="iterations">Iteraciones.</param>
        /// <returns>Hash cifrado.</returns>
        private static string Hash(string password, int iterations)
        {
            // Create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            // Create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            // Combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);

            // Format hash with extra information
            return string.Format("{0}{1}${2}", SaltKey, iterations, base64Hash);
        }

        /// <summary>
        /// Crea un password de forma genérica con 10000 iteraciones
        /// </summary>
        /// <param name="password">Contraseña.</param>
        /// <returns>Hash cifrado.</returns>
        public static string Hash(string password)
        {
            return Hash(password, 10000);
        }

        /// <summary>
        /// Valida si soporta Hash
        /// </summary>
        /// <param name="hashString">El hash.</param>
        /// <returns>boolean</returns>
        public static bool SoportaHash(string hashString)
        {
            return hashString.Contains(SaltKey);
        }

        /// <summary>
        /// Verifica si la contraseña es válida.
        /// </summary>
        /// <param name="password">La contraseña.</param>
        /// <param name="hashedPassword">El hash.</param>
        /// <returns>boolean</returns>
        public static bool VerificarPass(string password, string hashedPassword)
        {
            // Validad hash
            if (!SoportaHash(hashedPassword))
            {
                throw new NotSupportedException("Tipo de Hash no soportado");
            }

            // Extraer iteraciones y el Base64
            var splittedHashString = hashedPassword.Replace(SaltKey, "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            // Obtener bytes del hash
            var hashBytes = Convert.FromBase64String(base64Hash);

            // Obtener salt
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Crear hash con el salt recibido
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Get result
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Encripta de forma reversible utilizando AES un texto
        /// </summary>
        /// <param name="textoAEncriptar">El texto que se va a encriptar</param>
        /// <returns>Texto ya encriptado</returns>
        public static string Encrypt(string textoAEncriptar)
        {
            if (Key == null || Key.Length == 0)
            {
                throw new ArgumentNullException("Clave no puede ser nula o vacía");
            }
            if (textoAEncriptar == null || textoAEncriptar.Length == 0)
            {
                throw new ArgumentNullException("Texto no puede ser nulo o vacío");
            }
            byte[] bytes = Encoding.Unicode.GetBytes(textoAEncriptar);

            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(Key));
            crypt.IV = IV;
            crypt.Padding = PaddingMode.PKCS7;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream =
                   new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        /// <summary>
        /// Desencripta un texto ya encriptado previamente usando AES
        /// </summary>
        /// <param name="textoADesencriptar">El texto que se va a desencriptar</param>
        /// <returns>Texto ya desencriptado</returns>
        public static string Decrypt(string textoADesencriptar)
        {
            if (Key == null || Key.Length == 0)
            {
                throw new ArgumentNullException("Clave no puede ser nula o vacía");
            }
            if (textoADesencriptar == null || textoADesencriptar.Length == 0)
            {
                throw new ArgumentNullException("Texto no puede ser nulo o vacío");
            }
            byte[] bytes = Convert.FromBase64String(textoADesencriptar);
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(Key));
            crypt.IV = IV;
            crypt.Padding = PaddingMode.PKCS7;

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                using (CryptoStream cryptoStream =
                   new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[bytes.Length];
                    cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                    return Encoding.Unicode.GetString(decryptedBytes).Replace("\0", "");
                }
            }
        }
    }
}
