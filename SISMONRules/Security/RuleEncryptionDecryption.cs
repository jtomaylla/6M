using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.IO;

namespace SISMONRules.Security
{
    public class RuleEncryptionDecryption
    {
        /// <summary>
        /// Una cadena pseudoaleatoria de donde se generara la encriptacion
        /// </summary>
        /// <remarks>Puede ser de cualquier tamaño</remarks>
        private const string iFrasePasswd = "15646^&%$3(),>2134bgGz*-+e7hds";
        /// <summary>
        /// Valor para generar la llave de encriptacion.
        /// </summary>
        /// <remarks>Puede ser de cualquier tamaño</remarks>
        private const string iValor = "456^%43:;2323'32-0{][843";
        /// <summary>
        /// Nombre del Algoritmo.
        /// </summary>
        /// <remarks>Puede ser MD5 o SHA1. SHA1 es un poco mas lento pero es mas seguro</remarks>
        private const string iAlgHash = "SHA1";
        /// <summary>
        /// Numero de Iteraciones.
        /// </summary>
        /// <remarks>1 o 2 iteraciones son suficientes</remarks>
        private const int iNumIteraciones = 2;
        /// <summary>
        /// Vector Inicial
        /// </summary>
        /// <remarks>
        /// Debe ser de 16 caracteres exactamente
        /// </remarks>
        private const string iVectorInicial = "4587hst'3smd(@#&";
        /// <summary>
        /// Tamaño de la Llave
        /// </summary>
        /// <remarks>Puede ser de 128, 192 y 256</remarks>
        private const int iTamLlave = 256;

        /// <summary>
        /// Encripta con el algoritmo SHA1
        /// </summary>
        /// <param name="cadena">Cadena a encriptar</param>
        /// <returns>Cadena encriptada</returns>
        public static byte[] EncrypSHA1(string cadena)
        {
            // Generamos los arrays de Bytes de nuestras cadenas. Como iVectorInicial y iValor son cadenas
            // normales solo usamos Encoding.ASCII
            byte[] aVectorInicial = Encoding.ASCII.GetBytes(iVectorInicial);
            byte[] aValorRand = Encoding.ASCII.GetBytes(iValor);
            // Dado que cadena puede contener caracteres UNICODE, usaremos UTF8
            byte[] aCadena = Encoding.UTF8.GetBytes(cadena);

            // Generemos la contraseña
            PasswordDeriveBytes cont = new PasswordDeriveBytes(iFrasePasswd, aValorRand, iAlgHash, iNumIteraciones);
            // Obtengamos el array de la llave. Dividido en Bytes. (8 bits)
            byte[] aLlave = cont.GetBytes(iTamLlave / 8);

            // Usemos la clase Rijndael para la llave simetrica y usemos el modo Cipher Block Chaining (CBC)
            RijndaelManaged llaveSimetrica = new RijndaelManaged() { Mode = CipherMode.CBC };
            // Generemos el encriptador
            ICryptoTransform enc = llaveSimetrica.CreateEncryptor(aLlave, aVectorInicial);

            // Definamos donde tendremos los datos encriptados
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write);

            // Encriptemos
            cs.Write(aCadena, 0, aCadena.Length);

            // Terminemos
            cs.FlushFinalBlock();

            // Bajemos nuestros datos encriptados a un array de bytes
            byte[] aCipher = ms.ToArray();

            // Liberar la memoria de nuestros datos encriptados
            ms.Close();
            cs.Close();

            // Regresmos nuestro dato encriptado como una cadena base64
            //return Convert.ToBase64String(aCipher);
            return aCipher;
        }

        /// <summary>
        /// Descripta con el algoritmo TripleDES
        /// </summary>
        /// <param name="cadena">Cadena a desencriptar</param>
        /// <returns>Cadena desencriptada</returns>
        public static string DecrypSHA1(byte[] Pass)
        {
            string cadena = Convert.ToBase64String(Pass);
            // Generamos los arrays de Bytes de nuestras cadenas. Como iVectorInicial y iValor son cadenas
            // normales solo usamos Encoding.ASCII
            byte[] aVectorInicial = Encoding.ASCII.GetBytes(iVectorInicial);
            byte[] aValorRand = Encoding.ASCII.GetBytes(iValor);
            // Convertimos nuesta cadena encriptada (cipher) a un arrar
            byte[] aCipher = Convert.FromBase64String(cadena);

            // Generemos la contraseña
            PasswordDeriveBytes cont = new PasswordDeriveBytes(iFrasePasswd, aValorRand, iAlgHash, iNumIteraciones);
            // Obtengamos el array de la llave. Dividido en Bytes. (8 bits)
            byte[] aLlave = cont.GetBytes(iTamLlave / 8);

            // Usemos la clase Rijndael para la llave simetrica y usemos el modo Cipher Block Chaining (CBC)
            RijndaelManaged llaveSimetrica = new RijndaelManaged() { Mode = CipherMode.CBC };

            // Generemos el desencriptador
            ICryptoTransform desenc = llaveSimetrica.CreateDecryptor(aLlave, aVectorInicial);

            // Definamos donde tendremos los datos encriptados
            MemoryStream ms = new MemoryStream(aCipher);
            CryptoStream cs = new CryptoStream(ms, desenc, CryptoStreamMode.Read);

            // Definamos el arrar donde se colocaran nuestros datos desencriptados
            byte[] aCadena = new byte[aCipher.Length];

            // Comenzamos a desencriptar
            int tamB = cs.Read(aCadena, 0, aCadena.Length);

            // Liberemos la memoria
            ms.Close();
            cs.Close();

            // regresemos nuestra cadena desecriptada usando UTF8
            return Encoding.UTF8.GetString(aCadena, 0, tamB);

        }
    }
}
