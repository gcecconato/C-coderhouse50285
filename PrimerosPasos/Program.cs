// See https://aka.ms/new-console-template for more information

using Desafio1_PrimerosPasos;
using System;

class Program
{
    static void Main(string[] args)
    {
        //Prueba sencilla
        Usuario usuario1 = new Usuario(1,"Juan","Perez","JPEREZ","123.","-");
        usuario1.IdUsuario = 3;
        Console.WriteLine(usuario1.IdUsuario);
    }
}
