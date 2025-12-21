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
        public static string GenerarClaveSegura(int longitud = 10)
        {
            const string minusculas = "abcdefghijklmnopqrstuvwxyz";
            const string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numeros = "0123456789";
            const string especiales = "!@#$%&*?";

            string todos = minusculas + mayusculas + numeros + especiales;
            Random rnd = new Random();

            // Garantizar al menos uno de cada tipo
            StringBuilder clave = new StringBuilder();
            clave.Append(minusculas[rnd.Next(minusculas.Length)]);
            clave.Append(mayusculas[rnd.Next(mayusculas.Length)]);
            clave.Append(numeros[rnd.Next(numeros.Length)]);
            clave.Append(especiales[rnd.Next(especiales.Length)]);

            // Completar el resto
            for (int i = 4; i < longitud; i++)
            {
                clave.Append(todos[rnd.Next(todos.Length)]);
            }

            // Mezclar caracteres
            return new string(clave
                .ToString()
                .OrderBy(c => rnd.Next())
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
