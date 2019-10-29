namespace LeetCodeInCS._0079_Word_Search
{
	public class Solution
	{
		private int[,] d = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
		private int rows, colums;
		private bool[,] visited;

		public bool Exist(char[][] board, string word)
		{
			if (board.Length == 0)
				return false;
			rows = board.Length;
			colums = board[0].Length;

			visited = new bool[rows, colums];

			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[i].Length; j++)
				{
					if (SearchWord(board, word, 0, i, j))
						return true;
				}
			}
			return false;
		}

		private bool SearchWord(char[][] board, string word, int index, int startx, int starty)
		{
			if (index == word.Length - 1)
				return board[startx][starty] == word[index];

			if (board[startx][starty] == word[index])
			{
				visited[startx, starty] = true;
				for (int i = 0; i < 4; i++)
				{
					int newx = startx + d[i, 0];
					int newy = starty + d[i, 1];
					if (IsArea(newx, newy) && !visited[newx, newy] && SearchWord(board, word, index + 1, newx, newy))
						return true;
				}
				visited[startx, starty] = false;
			}
			return false;
		}

		private bool IsArea(int x, int y)
		{
			return x >= 0 && x < rows && y >= 0 && y < colums;
		}
	}
}
