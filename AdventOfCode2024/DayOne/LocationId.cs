using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2024.DayOne
{
    public struct LocationId: IComparable<LocationId>
    {
        public int Id { get; private set; }

        public static LocationId Create(string unvalidatedId)
        {
           return new LocationId
           {
               Id = int.Parse(unvalidatedId)
           };
        }

        public int CompareTo(LocationId other)
        {
            return Comparer<int>.Default.Compare(Id, other.Id);
        }

    }
}