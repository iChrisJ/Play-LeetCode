using System;
using System.Collections.Generic;

namespace LeetCodeInCS._1020_Number_of_Enclaves
{
	public class Solution
	{
		private static int[,] d = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

		public int NumEnclaves(int[][] A)
		{
			if (A == null || A.Length < 1 || A[0] == null || A[0].Length < 1)
				throw new ArgumentException("Invalid parameter.");

			int X = A.Length, Y = A[0].Length;

			for (int i = 0; i < X; i++)
			{
				for (int j = 0; j < Y; j++)
				{
					if (((i == 0) || (i == X - 1) || (j == 0) || (j == Y - 1)) && A[i][j] == 1)
					{
						A[i][j] = 2;
						DFS(A, i, j);
					}
				}
			}

			int res = 0;
			for (int i = 0; i < X; i++)
			{
				for (int j = 0; j < Y; j++)
				{
					if (A[i][j] == 1)
						res++;
				}
			}
			return res;
		}

		private void DFS(int[][] A, int x, int y)
		{
			for (int i = 0; i < 4; i++)
			{
				int newx = x + d[i, 0], newy = y + d[i, 1];
				if (newx >= 0 && newx < A.Length && newy >= 0 && newy < A[0].Length && A[newx][newy] == 1)
				{
					A[newx][newy] = 2;
					DFS(A, newx, newy);
				}
			}
		}
	}

	public class Solution2
	{
		private static int[,] d = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

		public int NumEnclaves(int[][] A)
		{
			if (A == null || A.Length < 1 || A[0] == null || A[0].Length < 1)
				throw new ArgumentException("Invalid parameter.");

			int X = A.Length, Y = A[0].Length;

			Queue<(int, int)> queue = new Queue<(int, int)>();

			for (int i = 0; i < X; i++)
			{
				for (int j = 0; j < Y; j++)
				{
					if (((i == 0) || (i == X - 1) || (j == 0) || (j == Y - 1)) && A[i][j] == 1)
						queue.Enqueue((i, j));
				}
			}

			while (queue.Count != 0)
			{
				(int, int) front = queue.Dequeue();

				A[front.Item1][front.Item2] = 2;
				for (int i = 0; i < 4; i++)
				{
					int newx = front.Item1 + d[i, 0], newy = front.Item2 + d[i, 1];
					if (newx >= 0 && newx < A.Length && newy >= 0 && newy < A[0].Length && A[newx][newy] == 1)
						queue.Enqueue((newx, newy));
				}

			}

			int res = 0;
			for (int i = 0; i < X; i++)
			{
				for (int j = 0; j < Y; j++)
				{
					if (A[i][j] == 1)
						res++;
				}
			}
			return res;
		}
	}
}
