using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class ControladoraEncriptador
    {

        public Clave Encriptar(Clave aEncriptar) {
            using (Aes miAes = Aes.Create()) {
                ControladoraAdministrador controladoraAdministrador = new ControladoraAdministrador();
                Encriptador encriptador = controladoraAdministrador.GetEncriptadorClave();
                miAes.Key = Convert.FromBase64String(encriptador.Key);
                miAes.IV = Convert.FromBase64String(encriptador.IV);
                Clave copia = new Clave()
                {
                    Id = aEncriptar.Id,
                    Nota = aEncriptar.Nota,
                    Sitio = aEncriptar.Sitio,
                    DataBreaches = aEncriptar.DataBreaches,
                    UsuarioClave = aEncriptar.UsuarioClave,
                    EsCompartida = aEncriptar.EsCompartida,
                    FechaModificacion = aEncriptar.FechaModificacion,
                    Codigo = Convert.ToBase64String(EncryptStringToBytes_Aes(aEncriptar.Codigo, miAes.Key, miAes.IV))
                };

                return copia;
            }
        }

        public Clave Desencriptar(Clave aDesencriptar) {
            using (Aes miAes = Aes.Create())
            {
                ControladoraAdministrador controladoraAdministrador = new ControladoraAdministrador();
                Encriptador encriptador = controladoraAdministrador.GetEncriptadorClave();
                miAes.Key = Convert.FromBase64String(encriptador.Key);
                miAes.IV = Convert.FromBase64String(encriptador.IV);
                
                Clave copia = new Clave()
                {
                    Id = aDesencriptar.Id,
                    Nota = aDesencriptar.Nota,
                    Sitio = aDesencriptar.Sitio,
                    DataBreaches = aDesencriptar.DataBreaches,
                    UsuarioClave = aDesencriptar.UsuarioClave,
                    EsCompartida = aDesencriptar.EsCompartida,
                    FechaModificacion = aDesencriptar.FechaModificacion,
                    Codigo = DecryptStringFromBytes_Aes(Convert.FromBase64String(aDesencriptar.Codigo), miAes.Key, miAes.IV)
            };
                return copia;
            }
        }

        private byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
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
        private string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
