using System;
using BalancedBinarySearchTreeApp.Models;
using BalancedBinarySearchTreeApp.View;

namespace BalancedBinarySearchTreeApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var node1 = new Node(123);
            var node2 = new Node(1234);

            Console.WriteLine(node1 > node2);

            var array = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            foreach (var VARIABLE in array[0..^1])
            {
                Console.Write($"{VARIABLE}, ");
            }
            Console.WriteLine(array[^1]);
            var tree = new Tree(array);
            Console.WriteLine(tree.Root);
            
            //tree.Root.Print2D(tree.Root);
            
            //tree.Delete(10);
            
            tree.Root.Print2D(tree.Root);

            Console.WriteLine(tree.Find(123));

            foreach (var var in tree.LevelOrder())
            {
                Console.Write(var + ", ");
            }

            Console.WriteLine();
            foreach (var var in tree.InOrder())
            {
                Console.Write(var + ", ");
            }

            Console.WriteLine();
            foreach (var var in tree.PreOrder())
            {
                Console.Write(var + ", ");
            }
            
            Console.WriteLine();
            foreach (var var in tree.PostOrder())
            {
                Console.Write(var + ", ");
            }

            Console.WriteLine();
            Console.WriteLine(tree.Height(tree.Root));
            Console.WriteLine(tree.Depth(new Node(5)));
            

            Console.WriteLine(tree.IsBalanced(tree.Root));
        }
    }
}