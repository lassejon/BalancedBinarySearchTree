using System;
using System.Collections.Generic;

namespace BalancedBinarySearchTreeApp.Models
{
    public class Node : IComparable<Node>, IEquatable<Node>
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node()
        {
            Value = int.MinValue;
            Left = null;
            Right = null;
        }

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
        
        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
        
        public void Print2DUtil(Node root, int space)
        {
            var COUNT = 10;
            // Base case
            if (root == null)
                return;
 
            // Increase distance between levels
            space += COUNT;
 
            // Process right child first
            Print2DUtil(root.Right, space);
 
            // Print current node after space
            // count
            Console.Write("\n");
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            Console.Write(root.Value + "\n");
 
            // Process left child
            Print2DUtil(root.Left, space);
        }
 
        // Wrapper over print2DUtil()
        public void Print2D(Node root)
        {
            // Pass initial space count as 0
            Print2DUtil(root, 0);
        }

        public int CompareTo(Node other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var valueComparison = Nullable.Compare<int>(Value, other.Value);
            if (valueComparison != 0) return valueComparison;
            var leftNodeComparison = Comparer<Node>.Default.Compare(Left, other.Left);
            return leftNodeComparison != 0 ? leftNodeComparison : Comparer<Node>.Default.Compare(Right, other.Right);
        }
        
        public static bool operator >  (Node operand1, Node operand2)
        {
            return operand1.Value > operand2.Value;
        }

        // Define the is less than operator.
        public static bool operator <  (Node operand1, Node operand2)
        {
            return operand1.Value < operand2.Value;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=  (Node operand1, Node operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=  (Node operand1, Node operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }
        
        public bool Equals(Node otherNode)
        {
            return Value == otherNode.Value;
        }

        public override bool Equals(object other)
        {
            return other is Node otherNode && Equals(otherNode);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}