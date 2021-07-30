using System;
using System.Collections.Generic;

namespace WiresGame
{
    public class Shuffler<T>
    {
        private Random _random = new Random();

        public IReadOnlyList<T> CreateNewShuffleList(IReadOnlyList<T> sourceItems, int count)
        {
            CreateNewList(sourceItems, count, out List<T> newList);

            return Shuffle(newList);
        }

        private List<T> Shuffle(List<T> target)
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

        private void CreateNewList(IReadOnlyList<T> source, int count, out List<T> newList)
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
