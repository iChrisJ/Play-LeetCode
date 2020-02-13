namespace LeetCodeInCS._0037_Sudoku_Solver
{
	public class Solution
	{
		private bool[,] rows;
		private bool[,] cols;
		private bool[,] boxes;
		private int n;

		public void SolveSudoku(char[][] board)
		{
			n = board.Length;
			rows = new bool[n, n + 1];
			cols = new bool[n, n + 1];
			boxes = new bool[n, n + 1];

			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					if (board[i][j] != '.')
					{
						int d = int.Parse(board[i][j].ToString());
						rows[i, d] = true;
						cols[j, d] = true;
						boxes[i / 3 + (j / 3) * 3, d] = true;
					}

			PutDigit(board, 0);
		}

		private bool PutDigit(char[][] board, int index)
		{
			if (index == n * n)
				return true;

			int x = index / n;
			int y = index % n;
			if (board[x][y] != '.')
				return PutDigit(board, index + 1);

			for (char i = '1'; i <= '9'; i++)
			{
				int d = int.Parse(i.ToString());
				if (!rows[x, d] && !cols[y, d] && !boxes[x / 3 + (y / 3) * 3, d])
				{
					board[x][y] = i;
					rows[x, d] = true;
					cols[y, d] = true;
					boxes[x / 3 + (y / 3) * 3, d] = true; ;

					if (PutDigit(board, index + 1))
						return true;

					boxes[x / 3 + (y / 3) * 3, d] = false; ;
					cols[y, d] = false;
					rows[x, d] = false;
					board[x][y] = '.';
				}
			}
			return false;
		}

		/*
		public static void Main()
		{
			char[][] board = new char[][]
			{
				new char[]{'5','3','.','.','7','.','.','.','.'},
				new char[]{'6','.','.','1','9','5','.','.','.'},
				new char[]{'.','9','8','.','.','.','.','6','.'},
				new char[]{'8','.','.','.','6','.','.','.','3'},
				new char[]{'4','.','.','8','.','3','.','.','1'},
				new char[]{'7','.','.','.','2','.','.','.','6'},
				new char[]{'.','6','.','.','.','.','2','8','.'},
				new char[]{'.','.','.','4','1','9','.','.','5'},
				new char[]{'.','.','.','.','8','.','.','7','9'}
			};
			new Solution().SolveSudoku(board);
		}
		 */

	}
}
