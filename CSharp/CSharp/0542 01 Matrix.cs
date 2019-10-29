using System.Collections.Generic;

namespace LeetCodeInCS._0542_01_Matrix
{
	public class Solution
	{
		private int[,] direction = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

		public int[][] UpdateMatrix(int[][] matrix)
		{
			if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
				return matrix;

			int rows = matrix.Length;
			int cols = matrix[0].Length;

			Queue<(int, int)> queue = new Queue<(int, int)>();

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (matrix[i][j] == 0)
						queue.Enqueue((i, j));
					else
						matrix[i][j] = int.MaxValue;
				}
			}

			while (queue.Count != 0)
			{
				(int, int) front = queue.Dequeue();

				for (int i = 0; i < 4; i++)
				{
					int x = front.Item1 + direction[i, 0];
					int y = front.Item2 + direction[i, 1];

					if (x >= 0 && x < rows && y >= 0 && y < cols
						&& matrix[x][y] > matrix[front.Item1][front.Item2] + 1)
					{
						matrix[x][y] = matrix[front.Item1][front.Item2] + 1;
						queue.Enqueue((x, y));
					}
				}
			}
			return matrix;
		}
	}
}
