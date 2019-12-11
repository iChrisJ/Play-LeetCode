using System;
using System.Collections.Generic;

namespace LeetCodeInCS._1222_Queens_That_Can_Attack_the_King
{
	public class Solution
	{
		public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
		{
			IList<IList<int>> res = new List<IList<int>>();

			if (queens == null || queens.Length == 0 || king == null || king.Length < 2)
				return res;

			HashSet<(int, int)> queenSet = new HashSet<(int, int)>();
			foreach (int[] queen in queens)
				queenSet.Add((queen[0], queen[1]));

			int x = king[0], y = king[1];
			while (y < 8)
			{
				if (queenSet.Contains((x, y)))
				{
					res.Add(new List<int> { x, y });
					break;
				}
				else
					y++;
			}

			x = king[0];
			y = king[1];
			while (x < 8 && y < 8)
			{
				if (queenSet.Contains((x, y)))
				{
					res.Add(new List<int> { x, y });
					break;
				}
				else
				{
					x++;
					y++;
				}
			}

			x = king[0];
			y = king[1];
			while (x < 8)
			{
				if (queenSet.Contains((x, y)))
				{
					res.Add(new List<int> { x, y });
					break;
				}
				else
					x++;
			}

			x = king[0];
			y = king[1];
			while (x < 8 && y >= 0)
			{
				if (queenSet.Contains((x, y)))
				{
					res.Add(new List<int> { x, y });
					break;
				}
				else
				{
					x++;
					y--;
				}
			}

			x = king[0];
			y = king[1];
			while (y >= 0)
			{
				if (queenSet.Contains((x, y)))
				{
					res.Add(new List<int> { x, y });
					break;
				}
				else
				{
					y--;
				}
			}

			x = king[0];
			y = king[1];
			while (x >= 0 && y >= 0)
			{
				if (queenSet.Contains((x, y)))
				{
					res.Add(new List<int> { x, y });
					break;
				}
				else
				{
					x--;
					y--;
				}
			}

			x = king[0];
			y = king[1];
			while (x >= 0)
			{
				if (queenSet.Contains((x, y)))
				{
					res.Add(new List<int> { x, y });
					break;
				}
				else
				{
					x--;
				}
			}

			x = king[0];
			y = king[1];
			while (x >= 0 && y < 8)
			{
				if (queenSet.Contains((x, y)))
				{
					res.Add(new List<int> { x, y });
					break;
				}
				else
				{
					x--;
					y++;
				}
			}

			return res;
		}
	}
}
