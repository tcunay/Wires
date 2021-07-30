using System.Collections.Generic;
using UnityEngine;
using WiresGame.Libraries;
using Random = UnityEngine.Random;

namespace WiresGame
{
    [System.Serializable]
    public class ColorListsInitializer
    {
        [SerializeField] private ColorsLibrary _colorsLibrary;

        private Shuffler<Color> _shuffler = new Shuffler<Color>();

        public void InitColorsLists(int forOneListCount, int listsCount, out List<IReadOnlyList<Color>> colorsLists)
        {
            colorsLists = new List<IReadOnlyList<Color>>();
            List<Color> colors = new List<Color>(forOneListCount);

            for (int i = 0; i < _colorsLibrary.Characteristics.Count; i++)
            {
                colors.Add(_colorsLibrary.Characteristics[i]);
            }

            for (int i = 0; i < forOneListCount - _colorsLibrary.Characteristics.Count; i++)
            {
                colors.Add(Random.ColorHSV(0, 1));
            }

            for (int i = 0; i < listsCount; i++)
            {
                colorsLists.Add(_shuffler.CreateNewShuffleList(colors, forOneListCount));
            }
        }
    }
}