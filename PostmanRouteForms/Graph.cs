using System.Numerics;

namespace PostmanRouteForms
{
	internal readonly struct MyNode : IEqualityOperators<MyNode, MyNode, bool>
	{
		internal int X { get; }
		internal int Y { get; }
		internal bool IsOffice { get; }

		internal MyNode(int x, int y, bool isOffice = false)
		{
			X = x;
			Y = y;
			IsOffice = isOffice;
		}

		public static bool operator ==(MyNode left, MyNode right)
		{
			return left.X == right.X && left.Y == right.Y && left.IsOffice == right.IsOffice;
		}

		public static bool operator !=(MyNode left, MyNode right)
		{
			return !(left == right);
		}
	}

	internal readonly struct MyEdge
	{
		internal MyNode From { get; }
		internal MyNode To { get; }
		internal int Weight { get; }
		internal MyEdge(MyNode first, MyNode second)
		{
			From = first;
			To = second;
			Weight = Math.Abs(first.X - second.X) + Math.Abs(first.Y - second.Y);
		}
		internal bool Contains(MyNode node)
		{
			return From == node || To == node;
		}
		internal MyNode? GetOtherEnd(MyNode node)
		{
			if (From == node) return To;
			else if (To == node) return From;
			else return null;
		}
	}

	internal struct MyGraph
	{
		private readonly List<MyEdge> _edges;
		private readonly int _needToDeliver;

		internal MyGraph(CellStatus[,] cells)
		{
			var nodes = ToNodeList(cells).ToList();
			_needToDeliver = nodes.Count - 1;
			_edges = ToEdges(nodes).ToList();
		}

		internal IEnumerable<(int x, int y, int leftToDeliver, uint leftInBag)> GetPaths(uint bagCapacity)
		{
			var needToDeliver = _needToDeliver;
			var inBagLetters = bagCapacity;
			var notTraversedEdges = new LinkedList<MyEdge>(_edges);
			var post = FindPostOffice(_edges);
			var currentNode = post;
			while (needToDeliver != 0)
			{
				MyEdge shortestEdge;
				var (oldNeed, oldBag) = (needToDeliver, inBagLetters);
				if (inBagLetters == 0)
				{
					shortestEdge = FindSmallestPath(_edges, currentNode, post);
					inBagLetters = bagCapacity;
				}
				else
				{
					shortestEdge = FindSmallestPath(notTraversedEdges, currentNode);
					inBagLetters--;
					needToDeliver--;
				}
				notTraversedEdges.Remove(shortestEdge);
				var previousNode = currentNode;
				currentNode = shortestEdge.GetOtherEnd(currentNode)!.Value;
				for (var currX = previousNode.X; currX != currentNode.X; currX += previousNode.X > currentNode.X ? -1 : 1)
					yield return (currX, previousNode.Y, oldNeed, oldBag);
				for (var currY = previousNode.Y; currY != currentNode.Y; currY += previousNode.Y > currentNode.Y ? -1 : 1)
					yield return (currentNode.X, currY, oldNeed, oldBag);

			}
		}

		internal static MyEdge FindSmallestPath(IEnumerable<MyEdge> edges, MyNode from)
		{
			return edges.Where((edge) => edge.Contains(from)).OrderBy(edge => edge.Weight).First();
		}

		internal static MyEdge FindSmallestPath(IEnumerable<MyEdge> edges, MyNode from, MyNode to)
		{
			return edges.Where((edge) => edge.Contains(from) && edge.Contains(to)).First();
		}

		internal static MyNode FindPostOffice(IEnumerable<MyEdge> edges)
		{
			var edge = edges.Where(edge => edge.From.IsOffice || edge.To.IsOffice).First();
			return edge.From.IsOffice ? edge.From : edge.To;
		}

		private static IEnumerable<MyNode> ToNodeList(CellStatus[,] cells)
		{
			for (var i = 0; i < cells.GetLength(0); i++)
			{
				for (var j = 0; j < cells.GetLength(1); j++)
				{
					if (cells[i, j] is CellStatus.PostBox || cells[i, j] is CellStatus.PostOffice)
						yield return new MyNode(j, i, cells[i, j] is CellStatus.PostOffice);
				}
			}
		}

		private static IEnumerable<MyEdge> ToEdges(List<MyNode> nodes)
		{
			for (var i = 0; i < nodes.Count; i++)
			{
				foreach (var secondNode in nodes.Skip(i + 1))
				{
					yield return new MyEdge(nodes[i], secondNode);
				}
			}
		}
	}
}
