using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestList
{
    public static class Helper
    {
        public static LinkedListNode<T>

        Node<T>(this LinkedList<T> l, int index)
        {
            LinkedListNode<T> x = l.First;
            while ((index--) > 0)
            {
                x = x.Next;
            }
            return x;
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                var path = @"C:\Users\SMN\Desktop\Text1.txt";
                var data = new List<string>();
                var text = File.ReadAllLines(path);
                foreach (var lines in text)
                {
                    var split = lines.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    data.Add(split.ToString());
                }
                var timer = new Stopwatch();

                timer.Start();
                data.Add("Конец");
                timer.Stop();
                Console.WriteLine($" Производительность вставки в List<T> в конце: {timer.ElapsedTicks} tick");

                timer.Reset();
                timer.Start();
                data.Insert(data.Count / 2, "Середина!!!");
                timer.Stop();
                Console.WriteLine($"Производительность вставки в List<T> в середине : {timer.ElapsedTicks} tick");

                timer.Reset();
                timer.Start();
                data.Insert(0, "Начало");
                timer.Stop();
                Console.WriteLine($"Производительность вставки в List <T> в начале : {timer.ElapsedTicks} tick");
                Console.WriteLine();

                var data1 = new LinkedList<string>();
                foreach (var lines in text)
                {
                    var split = lines.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    data1.AddLast(split.ToString());
                }

                timer.Reset();
                timer.Start();
                data1.AddFirst("Начало");
                timer.Stop();
                Console.WriteLine($"Производительность вставки в LinkedList<T> в начале: {timer.ElapsedTicks} tick");

                LinkedListNode<string> midl = data1.Node(data1.Count / 2);

                timer.Reset();
                timer.Start();
                data1.AddAfter(midl, "Середина!!!");
                timer.Stop();
                Console.WriteLine($"Производительность вставки в LinkedList<T> в середине списка: {timer.ElapsedTicks} tick");

                timer.Reset();
                timer.Start();
                data1.AddLast("Конец");
                timer.Stop();
                Console.WriteLine($"Производительность вставки в LinkedList<T> в конце списка : {timer.ElapsedTicks} tick");

                Console.ReadKey();



            }
        }
    }
}