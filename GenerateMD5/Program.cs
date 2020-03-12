using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GenerateMD5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tasks = new List<Task>();
            foreach (var fileString in args)
            {
                Console.WriteLine(fileString);
                var task = Task.Factory.StartNew(() => TryGetFileMD5(fileString));
                tasks.Add(task);
            }

            Console.WriteLine("Processing...");
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        private static void TryGetFileMD5(string fileString)
        {
            try
            {
                if (File.Exists(fileString))
                {
                    var md5 = "";
                    using (var fileStream = File.OpenRead(fileString))
                    {
                        md5 = GetMD5(fileStream);
                    }

                    WriteLine($"[Success]{fileString}: {md5}", ConsoleColor.Green);
                }
                else
                {
                    WriteLine($"[Skip]{fileString}: File not exist,skipped.", ConsoleColor.Gray);
                }
            }
            catch (Exception e)
            {
                WriteLine($"[Error]{fileString}: {e}", ConsoleColor.Red);
            }
        }

        private static string GetMD5(Stream stream)
        {
            using (var mi = MD5.Create())
            {
                var newBuffer = mi.ComputeHash(stream);
                var stringBuilder = new StringBuilder();
                for (var i = 0; i < newBuffer.Length; i++) stringBuilder.Append(newBuffer[i].ToString("x2"));
                return stringBuilder.ToString();
            }
        }

        private static void WriteLine(string text, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}