using System;

namespace LeetCodeInCS._0130_Surrounded_Regions
{
	public class Solution2
	{
		private int[,] d = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

		public void Solve(char[][] board)
		{
			if (board == null || board.Length == 0 || board[0] == null || board[0].Length == 0)
				return;

			for (int i = 0; i < board.Length; i++)
				for (int j = 0; j < board[0].Length; j++)
					if ((i == 0 || i == board.Length - 1 || j == 0 || j == board[0].Length - 1) && board[i][j] == 'O')
						DFS(board, i, j);

			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[0].Length; j++)
				{
					if (board[i][j] == '#')
						board[i][j] = 'O';
					else if (board[i][j] == 'O')
						board[i][j] = 'X';
				}
			}
		}

		private void DFS(char[][] board, int x, int y)
		{
			if (board[x][y] == 'O')
			{
				board[x][y] = '#';
				for (int i = 0; i < 4; i++)
				{
					int newx = x + d[i, 0];
					int newy = y + d[i, 1];
					if (newx >= 0 && newx < board.Length && newy >= 0 && newy < board[0].Length && board[newx][newy] == 'O')
						DFS(board, newx, newy);
				}
			}
		}
	}

	public class Solution
	{
		private int[,] d = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
		private int rows, colums;
		private bool[,] visited;

		public void Solve(char[][] board)
		{
			if (board == null || board.Length == 0)
				return;

			rows = board.Length;
			colums = board[0].Length;
			visited = new bool[rows, colums];
			UnionFind uf = new UnionFind(rows * colums);

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < colums; j++)
				{
					if (board[i][j] == 'O' && !visited[i, j])
					{
						for (int k = 0; k < 4; k++)
						{
							int x = i + d[k, 0];
							int y = j + d[k, 1];

							if (x < 0 || x >= rows || y < 0 || y >= colums)
							{
								uf.Surrounded[i * colums + j] = false;
								uf.Surrounded[uf.Find(i * colums + j)] = false;
							}
							else if (x >= 0 && x < rows && y >= 0 && y < colums && visited[x, y])
								uf.UnionElements(i * colums + j, x * colums + y);
						}
					}
				}
			}

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < colums; j++)
				{
					if (board[i][j] == 'O' && uf.Surrounded[uf.Find(i * colums + j)])
						board[i][j] = 'X';
				}
			}
		}
	}

	public class UnionFind
	{
		private int[] parent;

		private int[] rank;

		public bool[] Surrounded { get; set; }

		public int Size
		{
			get { return parent.Length; }
		}

		public UnionFind(int size)
		{
			parent = new int[size];
			rank = new int[size];
			Surrounded = new bool[size];

			for (int i = 0; i < size; i++)
			{
				parent[i] = i;
				rank[i] = 1;
				Surrounded[i] = true;
			}
		}

		public int Find(int p)
		{
			if (p < 0 || p >= Size)
				throw new ArgumentException("The p is out of bound.");

			while (p != parent[p])
			{
				parent[p] = parent[parent[p]];
				p = parent[p];
			}

			return p;
		}

		public bool IsConnected(int p, int q)
		{
			return Find(p) == Find(q);
		}

		public void UnionElements(int p, int q)
		{
			int pRoot = Find(p);
			int qRoot = Find(q);

			if (Surrounded[p] == false || Surrounded[q] == false)
				Surrounded[p] = Surrounded[q] = Surrounded[pRoot] = Surrounded[qRoot] = false;

			if (pRoot == qRoot)
				return;

			if (rank[pRoot] < rank[qRoot])
				parent[pRoot] = qRoot;
			else if (rank[pRoot] > rank[qRoot])
				parent[qRoot] = pRoot;
			else
			{
				parent[pRoot] = qRoot;
				rank[qRoot] += 1;
			}
		}
	}
}
