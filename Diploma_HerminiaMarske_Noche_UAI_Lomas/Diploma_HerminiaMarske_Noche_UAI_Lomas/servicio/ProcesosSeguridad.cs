using System;
using System.Security.Cryptography;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.servicio
{
    public static class ProcesosSeguridad
    {
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
        public static string Hash(string password, int iterations)
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
    }
}
