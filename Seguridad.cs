using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Proyecto_Final_PrograIV
{
    public static class Seguridad
    {

       
        public static string GenerarPassword(int longitud = 10)
        {
            const string minusculas = "abcdefghijklmnopqrstuvwxyz";
            const string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numeros = "0123456789";
            const string simbolos = "!@#$%&*";

            string caracteres = minusculas + mayusculas + numeros + simbolos;

            Random rnd = new Random();
            StringBuilder password = new StringBuilder();

            // Asegurar al menos uno de cada tipo
            password.Append(minusculas[rnd.Next(minusculas.Length)]);
            password.Append(mayusculas[rnd.Next(mayusculas.Length)]);
            password.Append(numeros[rnd.Next(numeros.Length)]);
            password.Append(simbolos[rnd.Next(simbolos.Length)]);

            // Completar el resto
            for (int i = password.Length; i < longitud; i++)
            {
                password.Append(caracteres[rnd.Next(caracteres.Length)]);
            }

            // Mezclar el resultado
            return new string(password
                .ToString()
                .OrderBy(x => rnd.Next())
                .ToArray());
        }



        public static string GenerarHash(string texto)
        {


            using (SHA256 sha256 = SHA256.Create())
            {


                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
