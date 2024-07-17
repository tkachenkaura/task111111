using System;

namespace DataStructuresLib
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; private set; }
        public int Count { get; private set; }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(value);
            }
            else
            {
                AddTo(Root, value);
            }
            Count++;
        }

        private void AddTo(TreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        private TreeNode<T> Find(T value)
        {
            TreeNode<T> current = Root;
            while (current != null)
            {
                int result = value.CompareTo(current.Value);
                if (result < 0)
                {
                    current = current.Left;
                }
                else if (result > 0)
                {
                    current = current.Right;
                }
                else
                {
                    return current;
                }
            }
            return null;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public T[] ToArray()
        {
            T[] result = new T[Count];
            int index = 0;
            ToArray(Root, result, ref index);
            return result;
        }

        private void ToArray(TreeNode<T> node, T[] array, ref int index)
        {
            if (node == null) return;
            ToArray(node.Left, array, ref index);
            array[index++] = node.Value;
            ToArray(node.Right, array, ref index);
        }
    }
}
