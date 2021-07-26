using System;
using System.Collections.Generic;
using UnityEngine;
using WiresGame.Elements;
using WiresGame.Libraries;

namespace WiresGame
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Element _template;
        [SerializeField] private ColorsLibrary _colorsLibrary;
        [SerializeField] private ElementsConecter _elementsConecter;

        public event Action Spawned;

        public void SpawnElements(int elementsCountOnOneBoard)
        {
            InitColorsListsByElementsBords(elementsCountOnOneBoard, _elementsConecter.Boards.Count, out List<IReadOnlyList<Color>> colorsForBoards);

            for (int i = 0; i < elementsCountOnOneBoard; i++)
            {
                for (int j = 0; j < _elementsConecter.Boards.Count; j++)
                {
                    Element element = Instantiate(_template, _elementsConecter.Boards[j].transform);
                    element.SetColor(colorsForBoards[j][i]);
                    _elementsConecter.Boards[j].AddElement(element);
                }
            }

            Spawned?.Invoke();
        }

        private void InitColorsListsByElementsBords(int elementsCountOnOneBoard, int listsCount, out List<IReadOnlyList<Color>> colorsForBoards)
        {
            colorsForBoards = new List<IReadOnlyList<Color>>();

            for (int i = 0; i < listsCount; i++)
            {
                colorsForBoards.Add(Shuffler<Color>.CreateNewShuffleList(_colorsLibrary.Characteristics, elementsCountOnOneBoard));
            }
        }
    }
}
