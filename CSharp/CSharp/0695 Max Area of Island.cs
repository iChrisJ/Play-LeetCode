using System;

namespace LeetCodeInCS._0695_Max_Area_of_Island
{
	public class Solution
	{
		private static int[,] d = new int[,] { { 1, 0 }, { 0, -1 }, { -1, 0 }, { 0, 1 } };
		private bool[,] visited;

		public int MaxAreaOfIsland(int[][] grid)
		{
			if (grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length == 0)
				return 0;

			int X = grid.Length;
			int Y = grid[0].Length;
			visited = new bool[X, Y];

			int res = 0;

			for (int i = 0; i < X; i++)
			{
				for (int j = 0; j < Y; j++)
				{
					if (grid[i][j] == 1 && visited[i, j] == false)
					{
						int area = 0;
						DFS(grid, i, j, X, Y, ref area);
						res = Math.Max(res, area);
					}
				}
			}
			return res;
		}

		private void DFS(int[][] grid, int i, int j, int X, int Y, ref int area)
		{
			if (i >= 0 && i < X && j >= 0 && j < Y
				&& grid[i][j] == 1 && visited[i, j] == false)
			{
				area++;
				visited[i, j] = true;

				for (int k = 0; k < 4; k++)
				{
					int newx = i + d[k, 0];
					int newy = j + d[k, 1];
					DFS(grid, newx, newy, X, Y, ref area);
				}
			}
		}
	}
}
