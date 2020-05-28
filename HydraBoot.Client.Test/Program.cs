using System;
using HydraBootClient = HydraBoot.Client.MainCore;

namespace HydraBoot.Client.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            HydraBootClient _HydraBoot = new HydraBootClient("localhost", "1000");
            var salida = _HydraBoot.Get("HydraBoot");
            Console.WriteLine("HydraBoot Client Test");
            Console.ReadLine();
        }
    }
}
