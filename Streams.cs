using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;
namespace cs
{
    internal class Streams
    {
        static void Main(string[] args)
        {
            WriteLine("адрес");
            string addr_patt = @"^[A-Za-z]([a-z])* ([a-z])*, [A-Za-z]([a-z])* ([a-z])*, ([0-9])* ([a-z])*, ([0-9])* ([a-z])*$", address = ReadLine();
            Regex reg_addr = new Regex(addr_patt);
            WriteLine(reg_addr.IsMatch(address) ? "правильно" : "ошибка");
            WriteLine("0=запись, 1=считывание");
            int choice = Convert.ToInt32(ReadLine());
            switch (choice)
            {
                case 0:
                    WriteLine("путь к файлу");
                    string file_path = ReadLine();
                    using (FileStream stream = new FileStream(file_path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        using (BinaryWriter writer = new BinaryWriter(stream, Encoding.Unicode))
                        {
                            writer.Write(address);
                        }
                        WriteLine("вывод адреса выполнен");
                    }
                    break;
                case 1:
                    WriteLine("путь к файлу");
                    file_path = ReadLine();
                    FileStream flow = new FileStream(file_path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                    byte[] new_byte = new byte[(int)flow.Length];
                    using (FileStream flux = new FileStream(file_path, FileMode.Open))
                    {
                        using (BinaryReader reader = new BinaryReader(flux, Encoding.Unicode))
                        {
                            WriteLine(reader.ReadString());
                        }
                        WriteLine("ввод адреса выполнен");
                    }
                    break;
                default:
                    WriteLine("ошибка");
                    break;
            }
        }
    }
}