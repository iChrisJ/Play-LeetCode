using System;
using System.Collections.Generic;

namespace LeetCodeInCS.Utilities
{
	public class PriorityQueue<T>
	{
		#region Fields and Properities

		private List<T> data;

		private Comparer<T> comparer;

		public int Count
		{
			get { return data.Count; }
		}

		#endregion Fields and Properities

		#region Constructors

		public PriorityQueue() : this(Comparer<T>.Default)
		{
		}

		public PriorityQueue(Comparer<T> comparer)
		{
			data = new List<T>();
			this.comparer = comparer;
		}

		#endregion Constructors

		#region Methods

		public void Enqueue(T item)
		{
			data.Add(item);
			ShiftUp(data.Count - 1);
		}

		private void ShiftUp(int index)
		{
			while (index > 0 && comparer.Compare(data[index], data[(index - 1) / 2]) > 0)
			{
				T temp = data[index];
				data[index] = data[(index - 1) / 2];
				data[(index - 1) / 2] = temp;

				index = (index - 1) / 2;
			}
		}

		public T Peek()
		{
			if (Count <= 0)
				throw new InvalidOperationException("The priority queue in empty.");
			return data[0];
		}

		public T Dequeue()
		{
			if (data.Count <= 0)
				throw new InvalidOperationException("The priority queue in empty.");

			T res = data[0];

			data[0] = data[data.Count - 1];
			data.RemoveAt(data.Count - 1);
			ShiftDown(0);

			return res;
		}

		private void ShiftDown(int index)
		{
			while (2 * index + 1 < data.Count)
			{
				int next = 2 * index + 1;
				if (next + 1 < data.Count && comparer.Compare(data[next + 1], data[next]) > 0)
					next += 1;

				if (comparer.Compare(data[next], data[index]) < 0)
					break;

				T temp = data[index];
				data[index] = data[next];
				data[next] = temp;

				index = next;
			}
		}

		#endregion Methods
	}
}
