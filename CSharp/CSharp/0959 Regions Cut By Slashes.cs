namespace LeetCodeInCS._0959_Regions_Cut_By_Slashes
{
	public class Solution
	{
		private int[,] d = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
		public int RegionsBySlashes(string[] grid)
		{
			if (grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length == 0)
				return 0;

			int N = grid.Length;
			int[,] blocks = new int[N * 3, N * 3];

			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					switch (grid[i][j])
					{
						case ' ':
							break;
						case '\\':
							blocks[i * 3 + 0, j * 3 + 0] = 1;
							blocks[i * 3 + 1, j * 3 + 1] = 1;
							blocks[i * 3 + 2, j * 3 + 2] = 1;
							break;
						case '/':
							blocks[i * 3 + 0, j * 3 + 2] = 1;
							blocks[i * 3 + 1, j * 3 + 1] = 1;
							blocks[i * 3 + 2, j * 3 + 0] = 1;
							break;
					}
				}
			}

			int count = 0;
			for (int i = 0; i < N * 3; i++)
			{
				for (int j = 0; j < N * 3; j++)
				{
					if (blocks[i, j] == 0)
					{
						DFS(blocks, i, j);
						count++;
					}
				}
			}
			return count;
		}

		private void DFS(int[,] blocks, int x, int y)
		{
			blocks[x, y] = 2; // mark it as read;

			int M = blocks.GetLength(0);

			for (int i = 0; i < 4; i++)
			{
				int newx = x + d[i, 0];
				int newy = y + d[i, 1];

				if (newx >= 0 && newx < M && newy >= 0 && newy < M && blocks[newx, newy] == 0)
					DFS(blocks, newx, newy);
			}
		}
	}
}
