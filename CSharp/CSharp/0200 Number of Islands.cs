namespace CSharp._0200_Number_of_Islands
{
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
}
