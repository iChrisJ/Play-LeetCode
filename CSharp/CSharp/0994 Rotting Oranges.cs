using System;
using System.Collections.Generic;

namespace CSharp._0994_Rotting_Oranges
{
	public class Solution
	{
		private int[,] direction = new int[,] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

		public int OrangesRotting(int[][] grid)
		{
			if (grid == null && grid.Length == 0)
				throw new Exception("Incorrect parameters.");

			int M = grid.Length;
			int N = grid[0].Length;

			Queue<(int, int)> queue = new Queue<(int, int)>();

			for (int i = 0; i < M; i++)
				for (int j = 0; j < N; j++)
					if (grid[i][j] == 2)
						queue.Enqueue((i, j));

			int res = 0;

			while (queue.Count != 0)
			{
				int levelCount = queue.Count;
				bool hasRotten = false;
				for (int i = 0; i < levelCount; i++)
				{
					(int, int) front = queue.Dequeue();
					for (int j = 0; j < 4; j++)
					{
						int newx = front.Item1 + direction[j, 0];
						int newy = front.Item2 + direction[j, 1];
						if (newx >= 0 && newx < M && newy >= 0 && newy < N && grid[newx][newy] == 1)
						{
							grid[newx][newy] = 2;
							hasRotten = true;
							queue.Enqueue((newx, newy));
						}
					}
				}
				if (hasRotten)
					res++;
			}

			for (int i = 0; i < M; i++)
				for (int j = 0; j < N; j++)
					if (grid[i][j] == 1)
						return -1;
			return res;
		}
	}
}
