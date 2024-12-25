using System;
using System.Collections.Generic;

namespace BibleViewer.Entity
{
	public sealed class BibleChapter(int value) : IComparable<BibleChapter>
	{
		public int Value => value;
		public SortedSet<int> Lines { get; } = new SortedSet<int>();

		public override int GetHashCode()
		{
			return value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
				return true;
			if (obj is not BibleChapter other)
				return false;
			return Value == other.Value;
		}

		public int CompareTo(BibleChapter other)
		{
			return Value.CompareTo(other.Value);
		}
	}
}
