using System;
using System.Collections.Generic;

namespace WiresGame
{
    public static class Shuffler<T>
    {
        private static Random _random = new Random();

        public static IReadOnlyList<T> CreateNewShuffleList(IReadOnlyList<T> sourceItems, int count)
        {
            if (count > sourceItems.Count)
                throw new ArgumentOutOfRangeException();

            CreateNewList(sourceItems, count, out List<T> newList);

            return Shuffle(newList);
        }

        private static List<T> Shuffle(List<T> target)
        {
            // Fisher–Yates shuffle.
            for (int i = target.Count - 1; i >= 1; i--)
            {
                int j = _random.Next(i + 1);
                var temp = target[j];
                target[j] = target[i];
                target[i] = temp;
            }

            return target;
        }

        private static void CreateNewList(IReadOnlyList<T> source, int count, out List<T> newList)
        {
            newList = new List<T>();

            foreach (var item in source)
            {
                newList.Add(item);
            }

            newList = newList.GetRange(0, count);
        }
    }
}
