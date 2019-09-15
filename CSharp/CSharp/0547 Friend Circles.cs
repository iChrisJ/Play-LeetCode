using System;

namespace CSharp._0547_Friend_Circles
{
	public class Solution
	{
		// FIXIT: Need to optimize it, reduce redundant union
		public int FindCircleNum(int[][] M)
		{
			if (M == null || M.Length == 0)
				return 0;
			int N = M.Length;
			UnionFind uf = new UnionFind(M);

			for (int i = 0; i < N; i++)
			{
				int first = -1;
				for (int j = 0; j < N; j++)
				{
					if (M[i][j] == 1 && M[j][i] == 1)
						uf.Union(i * N + j, j * N + i);
					if (M[i][j] == 1)
						if (first == -1)
							first = j;
						else
							uf.Union(i * N + first, i * N + j);
				}
			}
			return uf.Count;
		}

		private class UnionFind
		{
			private int[] Parent { get; set; }
			public int Count { get; private set; }
			public int[] Rank { get; private set; }

			public UnionFind(int[][] grid)
			{
				if (grid == null || grid.Length == 0 || grid.Length != grid[0].Length)
					throw new Exception("Incorrect Parameters.");
				Count = 0;
				int N = grid.Length;
				Parent = new int[N * N];
				Array.Fill<int>(Parent, -1);
				Rank = new int[N * N];

				for (int i = 0; i < N; i++)
				{
					for (int j = 0; j < N; j++)
					{
						if (grid[i][j] == 1)
						{
							Parent[i * N + j] = i * N + j;
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

			public void Union(int node1, int node2)
			{
				int root1 = Find(node1);
				int root2 = Find(node2);

				if (root1 != root2)
				{
					if (Rank[root1] > Rank[root2])
						Parent[root2] = root1;
					else if (Rank[root1] < Rank[root2])
						Parent[root1] = root2;
					else
					{
						Parent[root2] = root1;
						Rank[root1] += 1;
					}
					Count -= 1;
				}
			}
		}
	}
}