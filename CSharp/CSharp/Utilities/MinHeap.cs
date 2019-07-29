using System;
using System.Collections.Generic;

namespace CSharp.Utilities
{
	public class MinHeap<T>
	{
		private List<T> heap;

		private Comparer<T> comparer;

		public int Count
		{
			get { return heap.Count; }
		}

		public MinHeap()
		{
			heap = new List<T>();
			comparer = Comparer<T>.Default;
		}

		public MinHeap(Comparer<T> comparer)
		{
			heap = new List<T>();
			this.comparer = comparer;
		}

		public void Insert(T Item)
		{
			heap.Add(Item);
			ShiftUp(heap.Count - 1);
		}

		private void ShiftUp(int i)
		{
			while (i - 1 >= 0 && comparer.Compare(heap[i], heap[(i - 1) / 2]) < 0)
			{
				T temp = heap[i];
				heap[i] = heap[(i - 1) / 2];
				heap[(i - 1) / 2] = temp;

				i = (i - 1) / 2;
			}
		}

		public T ExtractMin()
		{
			if (heap.Count <= 0)
				throw new AccessViolationException("The minheap is empty");
			T min = heap[0];
			heap[0] = heap[heap.Count - 1];
			heap.RemoveAt(heap.Count - 1);
			ShiftDown(0);
			return min;
		}

		private void ShiftDown(int i)
		{
			while (2 * i + 1 < heap.Count)
			{
				int j = 2 * i + 1;
				if (j + 1 < heap.Count && comparer.Compare(heap[j], heap[j + 1]) > 0)
					j++;
				if (comparer.Compare(heap[i], heap[j]) < 0)
					break;

				T temp = heap[i];
				heap[i] = heap[j];
				heap[j] = temp;

				i = j;
			}
		}

		public T Top()
		{
			if (Count == 0)
				throw new AccessViolationException("The MinHeap is empty.");
			return heap[0];
		}
	}
}
