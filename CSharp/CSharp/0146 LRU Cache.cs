using System.Collections.Generic;

namespace LeetCodeInCS._0146_LRU_Cache
{
	public class LRUCache
	{
		private class Node<T>
		{
			public Node(T value)
			{
				Value = value;
			}

			public Node<T> Next { get; set; }

			public Node<T> Previous { get; set; }

			public T Value { get; set; }
		}

		private int capacity;

		private Dictionary<int, Node<(int, int)>> dict;
		private Node<(int, int)> head;
		private Node<(int, int)> tail;

		public LRUCache(int capacity)
		{
			this.capacity = capacity;
			dict = new Dictionary<int, Node<(int, int)>>(capacity);
			head = new Node<(int, int)>((-1, -1));
			tail = new Node<(int, int)>((-1, 1));
			head.Next = tail;
			tail.Previous = head;
		}

		public int Get(int key)
		{
			if (dict.ContainsKey(key))
			{
				Node<(int, int)> node = dict[key];

				MoveToFirst(node);

				return node.Value.Item2;
			}
			return -1;
		}

		public void Put(int key, int value)
		{
			if (dict.ContainsKey(key))
			{
				Node<(int, int)> node = dict[key];

				MoveToFirst(node);

				node.Value = (key, value);
			}
			else
			{
				if (dict.Count == capacity)
				{
					Node<(int, int)> last = tail.Previous;
					tail.Previous = last.Previous;
					last.Previous.Next = tail;

					dict.Remove(last.Value.Item1);

					last = null;
				}
				Node<(int, int)> node = new Node<(int, int)>((key, value));

				head.Next.Previous = node;
				node.Next = head.Next;
				head.Next = node;
				node.Previous = head;

				dict.Add(key, node);
			}
		}

		private void MoveToFirst(Node<(int, int)> node)
		{
			Node<(int, int)> prev = node.Previous;
			Node<(int, int)> next = node.Next;

			prev.Next = next;
			next.Previous = prev;

			head.Next.Previous = node;
			node.Next = head.Next;
			head.Next = node;
			node.Previous = head;
		}

		//static void Main()
		//{
		//	LRUCache cache = new LRUCache(2 /* capacity */ );

		//	cache.Put(1, 1);
		//	cache.Put(2, 2);
		//	cache.Get(1);       // returns 1
		//	cache.Put(3, 3);    // evicts key 2
		//	cache.Get(2);       // returns -1 (not found)
		//	cache.Put(4, 4);    // evicts key 1
		//	cache.Get(1);       // returns -1 (not found)
		//	cache.Get(3);       // returns 3
		//	cache.Get(4);       // returns 4
		//}
	}
}
