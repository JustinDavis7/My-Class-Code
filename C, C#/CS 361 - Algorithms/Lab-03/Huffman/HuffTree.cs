using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    public class HuffTree<TItem, TWeight> where TWeight : IComparable<TWeight>
    {
        private class Node<TItemP, TWeightP> where TWeightP : IComparable<TWeightP>
        {
            public TItemP Item;
            public TWeightP Weight;
            public Node<TItemP, TWeightP> Left;
            public Node<TItemP, TWeightP> Right;
        }

        private readonly Node<TItem, TWeight> _root;

        public HuffTree(Dictionary<TItem, TWeight> frequencies)
        {
            var priorityQueue = new PriorityQueue<Node<TItem, TWeight>, TWeight>();

            foreach (var (item, weight) in frequencies)
            {
                priorityQueue.Enqueue(new Node<TItem, TWeight> { Item = item, Weight = weight }, weight);
            }


            while (priorityQueue.Count != 1)
            {
                var min1 = priorityQueue.Dequeue();
                var min2 = priorityQueue.Dequeue();
                //dynamic casts the variable so that on runtime, the computer knows it can add these.
                var newNode = new Node<TItem, TWeight> {Left = min1, Right = min2, Weight = (dynamic) min1.Weight + (dynamic) min2.Weight};

                priorityQueue.Enqueue(newNode, newNode.Weight);
            }

            _root = priorityQueue.Dequeue();
        }

        public Dictionary<char, string> Encoding(Dictionary<TItem, TWeight> frequencies)
        {
            var _look_up_table = new Dictionary<char, string>();
            foreach (var item in frequencies)
            {
                var _encode_value = HuffTreeSearch(item.Key);
                _look_up_table.Add((dynamic) item.Key, _encode_value);
            }
            return _look_up_table;
        }

        public string HuffTreeSearch(TItem character)
        {
            string _encoded_Value = "";
            var _check = true;
            PreorderTree(_root, ref _encoded_Value, character, ref _check);
            return _encoded_Value;
        }

        private static void PreorderTree(Node<TItem, TWeight> root, ref string _encoded_value, TItem character, ref bool _check)
        {
            var _continue = true;
            while (_continue)
            {
                if (root.Left != null)
                {
                    _encoded_value += "0";
                    PreorderTree(root.Left, ref _encoded_value, character, ref _check);
                    if ((dynamic)root.Item == (dynamic)character)
                    {
                       _continue = false;
                    }
                    if (_continue == false || _check == false)
                        break;
                    else
                        _encoded_value = _encoded_value.Substring(0, _encoded_value.Length - 1);
                }
                if (root.Right != null)
                {
                    _encoded_value += "1";
                    PreorderTree(root.Right, ref _encoded_value, character, ref _check);
                    if ((dynamic)root.Item == (dynamic)character)
                    {
                        _continue = false;
                    }
                    if (_continue == false || _check == false)
                        break;
                    else
                        _encoded_value = _encoded_value.Substring(0, _encoded_value.Length - 1);
                }
                if ((dynamic)root.Item == (dynamic)character)
                {
                    _continue = false;
                    _check = false;
                    break;
                }
                else
                    break;
            }
        }
    }
}
