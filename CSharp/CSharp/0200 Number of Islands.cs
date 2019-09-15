using System;
using System.Collections.Generic;

namespace CSharp._0200_Number_of_Islands
{
	/// <summary>
	/// DFS
	/// </summary>
	public class Solution
	{
		private int[,] d = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
		private int rows, colums;
		private bool[,] visited;

		public int NumIslands(char[][] grid)
		{
			if (grid == null || grid.Length == 0)
				return 0;
			rows = grid.Length;
			colums = grid[0].Length;
			visited = new bool[rows, colums];

			int res = 0;
			for (int i = 0; i < grid.Length; i++)
			{
				for (int j = 0; j < grid[i].Length; j++)
				{
					if (grid[i][j] == '1' && !visited[i, j])
					{
						res++;
						DFS(grid, i, j);
					}
				}
			}
			return res;
		}

		private void DFS(char[][] grid, int x, int y)
		{
			visited[x, y] = true;
			for (int i = 0; i < 4; i++)
			{
				int newx = x + d[i, 0];
				int newy = y + d[i, 1];

				if (InArea(newx, newy) && !visited[newx, newy] && grid[newx][newy] == '1')
					DFS(grid, newx, newy);
			}
		}

		private bool InArea(int x, int y)
		{
			return x >= 0 && x < rows && y >= 0 && y < colums;
		}
	}

	/// <summary>
	/// BFS
	/// </summary>
	public class Solution2
	{
		private int[,] d = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
		private int rows, colums;
		private bool[,] visited;

		public int NumIslands(char[][] grid)
		{
			if (grid == null || grid.Length == 0)
				return 0;
			rows = grid.Length;
			colums = grid[0].Length;
			visited = new bool[rows, colums];

			int res = 0;
			for (int i = 0; i < grid.Length; i++)
			{
				for (int j = 0; j < grid[i].Length; j++)
				{
					if (grid[i][j] == '1' && !visited[i, j])
					{
						res++;
						BFS(grid, i, j);
					}
				}
			}
			return res;
		}

		private void BFS(char[][] grid, int x, int y)
		{
			visited[x, y] = true;
			Queue<(int, int)> queue = new Queue<(int, int)>();
			queue.Enqueue((x, y));

			while (queue.Count != 0)
			{
				(int, int) top = queue.Dequeue();

				for (int i = 0; i < 4; i++)
				{
					int newx = top.Item1 + d[i, 0];
					int newy = top.Item2 + d[i, 1];
					if (InArea(newx, newy) && !visited[newx, newy] && grid[newx][newy] == '1')
					{
						visited[newx, newy] = true;
						queue.Enqueue((newx, newy));
					}
				}
			}
		}

		private bool InArea(int x, int y)
		{
			return x >= 0 && x < rows && y >= 0 && y < colums;
		}
	}

	/// <summary>
	/// Union Find
	/// </summary>
	public class Solution3
	{
		private int[,] d = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
		private int rows, colums;

		public int NumIslands(char[][] grid)
		{
			if (grid == null || grid.Length == 0)
				return 0;
			rows = grid.Length;
			colums = grid[0].Length;

			UnionFind uf = new UnionFind(grid);

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < colums; j++)
				{
					if (grid[i][j] == '0')
						continue;
					for (int k = 0; k < 4; k++)
					{
						int newx = i + d[k, 0];
						int newy = j + d[k, 1];
						if (newx >= 0 && newy >= 0 && newx < rows && newy < colums && grid[newx][newy] == '1')
							uf.Union(i * colums + j, newx * colums + newy);
					}
				}
			}
			return uf.Count;
		}

		private class UnionFind
		{
			private int[] Parent { get; set; }
			public int Count { get; private set; }
			public int[] Rank { get; private set; }

			public UnionFind(char[][] grid)
			{
				if (grid == null || grid.Length == 0)
					throw new Exception("Incorrect Parameters.");
				Count = 0;
				Parent = new int[grid.Length * grid[0].Length];
				Array.Fill<int>(Parent, -1);
				Rank = new int[grid.Length * grid[0].Length];

				for (int i = 0; i < grid.Length; i++)
				{
					for (int j = 0; j < grid[0].Length; j++)
					{
						if (grid[i][j] == '1')
						{
							Parent[i * grid[0].Length + j] = i * grid[0].Length + j;
							Count += 1;
						}
					}
				}
			}

			public int Find(int i)
			{
				if (Parent[i] != i)
					Parent[i] = Find(Parent[i]);
				return Parent[i];
			}

			public void Union(int x, int y)
			{
				int rootx = Find(x);
				int rooty = Find(y);

				if (rootx != rooty)
				{
					if (Rank[rootx] > Rank[rooty])
						Parent[rooty] = rootx;
					else if (Rank[rootx] < Rank[rooty])
						Parent[rootx] = rooty;
					else
					{
						Parent[rooty] = rootx;
						Rank[rootx] += 1;
					}
					Count -= 1;
				}
			}
		}
	}
}
