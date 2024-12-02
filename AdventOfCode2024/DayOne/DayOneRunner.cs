namespace AdventOfCode2024.DayOne
{
    public static class DayOneRunner
    {
        public static int FindDistanceBetweenLocations()
        {
            Input.LeftElvenLocations.Sort();
            Input.RightElvenLocations.Sort();

            return Input.LeftElvenLocations
                .Zip(Input.RightElvenLocations)
                .Sum(e =>
                {
                    var (firstLocation, secondLocation) = e;

                    return Math.Abs(secondLocation.Id - firstLocation.Id);
                });
        }

        public static int FindSimilarityScore()
        {
            Input.LeftElvenLocations.Sort();
            Input.RightElvenLocations.Sort();

            // Location of right list * Repetition of itself
            Dictionary<LocationId, int> similarityComparison = new();
            
            foreach (var location in Input.RightElvenLocations)
            {
                bool isLocationMemoized = similarityComparison.TryAdd(location, 1);
                if (!isLocationMemoized)
                {
                    similarityComparison[location] += 1;
                }
            }

            var similarityScore = 0;
            foreach(var location in Input.LeftElvenLocations)
            {
                if(similarityComparison.TryGetValue(location, out var score))
                {
                    similarityScore += score * location.Id;
                }
            }

            return similarityScore;
        }

    }
}
