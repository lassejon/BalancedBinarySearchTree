using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedBinarySearchTreeApp.Models
{
    public class Tree
    {
        public Node Root { get; private set; }
        
        
        public Tree()
        {
            Root = null;
        }

        public Tree(int[] array)
        {
            array = array.Distinct().ToArray();
            Array.Sort(array);
            Root = BuildTree(array, 0, array.Length - 1);
        }

        private Node BuildTree(int[] array, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            
            var middle = (start + end) / 2;
            var node = new Node(array[middle])
            {
                Left = BuildTree(array, start, middle - 1),
                Right = BuildTree(array, middle + 1, end)
            };

            return node;
        }

        public void Delete(Node node)
        {
            DeleteRecursive(Root, node);
        }
        
        public void Delete(int value)
        {
            var node = new Node(value);
            DeleteRecursive(Root, node);
        }
        
        private Node DeleteRecursive(Node root, Node node)
        {
            if (root is null)
            {
                return null;
            }

            if (node < root)
            {
                root.Left = DeleteRecursive(root.Left, node);
            }
            else if (node > root)
            {
                root.Right = DeleteRecursive(root.Right, node);
            }
            else
            {
                if (root.Left is null)
                {
                    return root.Right;
                }
                
                if (root.Right is null)
                {
                    return root.Left;
                }
                
                root.Value = MinNode(root.Right).Value;
                root.Right = DeleteRecursive(root.Right, root);
            }

            return root;
        }

        private static Node MinNode(Node root)
        {
            var currentNode = root;
            while (currentNode.Left is not null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode;
        }
        
        public int Height(Node root) {
            if (root == null) {
                return -1;
            }

            var leftHeight = Height(root.Left) + 1;
            var rightHeight = Height(root.Right) + 1;

            return leftHeight > rightHeight ? leftHeight : rightHeight;
        }

        public int Depth(Node node)
        {
            var depth = 0;
            var current = Root;
            while (current is not null)
            {
                if (current.Equals(node))
                {
                    return depth;
                }

                current = node < current ? current.Left : current.Right;
                depth++;
            }

            return depth;
        }

        public bool IsBalanced(Node node)
        {
            if (node is null)
            {
                return true;
            }
            var leftHeight = Height(node.Left);
            var rightHeight = Height(node.Right);

            return Math.Abs(leftHeight - rightHeight) <= 1 && IsBalanced(node.Left) && IsBalanced(node.Right);
        }

        public void ReBalance()
        {
            var values = InOrder();
            var enumerable = values as int[] ?? values.ToArray();
            Root = BuildTree(enumerable, 0, enumerable.Length);
        }
        
        public IEnumerable<int> LevelOrder()
        {
            var visited = new List<int>();
            var toVisit = new Queue<Node>();

            var current = Root;
            do
            {
                visited.Add(current.Value);
                if (current.Left is not null)
                {
                    toVisit.Enqueue(current.Left);
                }

                if (current.Right is not null)
                {
                    toVisit.Enqueue(current.Right);
                }

                current = toVisit.Dequeue();
            } while (toVisit.Count != 0);

            visited.Add(current.Value);
            return visited;
        }

        public Node Find(int value)
        {
            var node = new Node(value);
            var current = Root;
            while (current is not null)
            {
                if (node.Equals(current))
                {
                    return current;
                }

                if (node < current)
                {
                    current = current.Left;
                    continue;
                }

                if (node > current)
                {
                    current = current.Right;
                }
            }

            return null;
        }

        public void Insert(Node node)
        {
            var currentNode = Root;
            var parentNode = new Node();
            while (currentNode is not null)
            {
                parentNode = currentNode;
                currentNode = node < currentNode ? currentNode.Left : currentNode.Right;
                
                if (node.Equals(currentNode))
                {
                    return;
                }
            }

            if (node < parentNode)
            {
                parentNode.Left = node;
            }
            else
            {
                parentNode.Right = node;
            }
        }

        public IEnumerable<int> InOrder()
        {
            var visited = new List<int>();
            var toVisit = new Stack<Node>();

            var current = Root;
            while (current is not null || toVisit.Count != 0)
            {
                while (current is not null)
                {
                    toVisit.Push(current);
                    current = current.Left;
                }

                current = toVisit.Pop();
                visited.Add(current.Value);
                current = current.Right;
            }

            return visited;
        }

        public IEnumerable<int> PreOrder()
        {
            var visited = new List<int>();
            var toVisit = new Stack<Node>();
            
            var current = Root;
            toVisit.Push(current);
            while (toVisit.Count != 0)
            {
                visited.Add(current.Value);
                if (current.Right is not null)
                {
                    toVisit.Push(current.Right);
                }

                if (current.Left is not null)
                {
                    toVisit.Push(current.Left);
                }

                current = toVisit.Pop();
            }

            return visited;
        }

        public IEnumerable<int> PostOrder()
        {
            var visited = new List<int>();
            var toVisit = new Stack<Node>();

            toVisit.Push(Root);
            while (toVisit.Count != 0)
            {
                var current = toVisit.Pop();
                visited.Add(current.Value);

                if (current.Left is not null)
                {
                    toVisit.Push(current.Left);
                }

                if (current.Right is not null)
                {
                    toVisit.Push(current.Right);
                }
            }

            visited.Reverse();
            return visited;
        }

        public void Insert(int value)
        {
            var node = new Node(value);

            var currentNode = Root;
            var parentNode = new Node();
            while (currentNode is not null)
            {
                parentNode = currentNode;
                currentNode = node < currentNode ? currentNode.Left : currentNode.Right;
                
                if (node.Equals(parentNode))
                {
                    return;
                }
            }

            if (node < parentNode)
            {
                parentNode.Left = node;
            }
            else
            {
                parentNode.Right = node;
            }
        }
        
    }
}