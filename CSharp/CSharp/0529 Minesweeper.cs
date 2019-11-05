namespace LeetCodeInCS._0529_Minesweeper
{
	public class Solution
	{
		private static int[,] d = new int[,] { { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 }, { -1, 0 }, { -1, 1 } };
		private static bool[,] visited;

		public char[][] UpdateBoard(char[][] board, int[] click)
		{
			int X = board.Length;
			int Y = board[0].Length;
			char[][] res = new char[X][];
			visited = new bool[X, Y];

			for (int i = 0; i < X; i++)
			{
				res[i] = new char[Y];
				for (int j = 0; j < Y; j++)
					res[i][j] = board[i][j];
			}

			int x = click[0], y = click[1];

			if (board[x][y] == 'M')
				res[x][y] = 'X';
			else if (board[x][y] == 'E')
				DFS(board, res, x, y);

			return res;
		}

		private void DFS(char[][] board, char[][] res, int x, int y)
		{
			int X = board.Length;
			int Y = board[0].Length;

			if (board[x][y] == 'E' && visited[x, y] == false)
			{
				visited[x, y] = true;
				int mineCount = 0;

				for (int i = 0; i < 8; i++)
				{
					int newx = x + d[i, 0];
					int newy = y + d[i, 1];

					if (newx >= 0 && newx < X && newy >= 0 && newy < Y && board[newx][newy] == 'M')
						mineCount++;
				}

				if (mineCount > 0)
					res[x][y] = char.Parse(mineCount.ToString());
				else
				{
					res[x][y] = 'B';
					for (int i = 0; i < 8; i++)
					{
						int newx = x + d[i, 0];
						int newy = y + d[i, 1];

						if (newx >= 0 && newx < X && newy >= 0 && newy < Y && board[newx][newy] == 'E' && !visited[newx, newy])
							DFS(board, res, newx, newy);
					}
				}
			}
		}
	}
}
