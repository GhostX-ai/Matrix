﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix
{
    class MyWorld
    {
        public char[] world { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            List<MyWorld> li = new List<MyWorld>();
            while (true)
            {
                Task.Run(() =>
                {
                    for (int i = 0; i < new Random().Next(100, 1000); i++)
                    {
                        li.Add(new MyWorld()
                        {
                            Left = new Random().Next(100),
                            world = World(),
                            Top = new Random().Next(2, 8)
                        });
                    }
                }).Wait();
                Task.Run(() =>
                {
                    Show(li);
                    li.Clear();
                }).Wait();
            }
        }
        static char[] World()
        {
            string world = "";
            for (char i = 'a'; i <= 'z'; i++)
            {
                if (new Random().Next(0, 4) == 1)
                {
                    world += i;
                }
            }
            return world.ToCharArray();
        }
        static void Show(List<MyWorld> symbols)
        {
            int w = 0;
            for (int i = 0; i < 10; i++)
            {
                foreach (var x in symbols)
                {
                    Console.CursorTop = i + x.Top;
                    foreach (var z in x.world)
                    {
                        Console.CursorLeft = x.Left;
                        if (w == x.world.Length - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (w == x.world.Length - 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        Console.WriteLine(z);
                        w++;
                    }
                    w = 0;
                }
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}
