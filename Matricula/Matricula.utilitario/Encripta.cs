using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Matricula.utilitario
{

    public class Encripta
    {

        string key = "mikey";

        /// <summary>
        /// Encripta el texto pasado por parámetro
        /// </summary>
        /// <param name="texto"> representa el texto que se desea encriptar </param>
        /// <returns> retorna el texto ya cifrado  </returns>
        public string Encriptar(string texto)
        {
            byte[] keyArray; //arreglo de bytes donde se guarda la llave
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);//Guarda el texto que se pasa por parámetro para encriptar

            //Se utilizan las clases de encriptación del Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));//Se guarda la llave para que se le realice hashing
            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //Se empieza con la transformación de la cadena
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //Arregl donde se guarda la cadena cifrada
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena, aquí el texto ya está encriptado
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }

        /// <summary>
        /// Desencripta el texto encriptado que se le pase por parámetro
        /// </summary>
        /// <param name="textoEncriptado"> representa al texto que se desea desencriptar </param>
        /// <returns> retorna el texto desencriptado </returns>
        public string Desencriptar(string textoEncriptado)
        {
            byte[] keyArray;//Convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

            //Se llama a las clases que tienen los algoritmos de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

            tdes.Clear();
            //Retorna el texto desencriptado
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

    }
}
