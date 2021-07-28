using System;
using System.Collections.Generic;
using UnityEngine;
using WiresGame.Elements;
using WiresGame.Libraries;

namespace WiresGame
{
    public class ElementsSpawner : MonoBehaviour
    {
        [SerializeField] private Element _template;
        [SerializeField] private ColorListsInitializer _colorListsInitializer;

        public event Action Spawned;

        public void SpawnElementsInElementsBoards(IReadOnlyList<ElementsBoard> boards, int elementsCountOnOneBoard)
        {
            _colorListsInitializer.InitColorsLists(elementsCountOnOneBoard, boards.Count, out List<IReadOnlyList<Color>> colorsForBoards);

            for (int i = 0; i < elementsCountOnOneBoard; i++)
            {
                for (int j = 0; j < boards.Count; j++)
                {
                    Element element = Instantiate(_template, boards[j].transform);
                    element.SetColor(colorsForBoards[j][i]);
                    boards[j].AddElement(element);
                }
            }

            Spawned?.Invoke();
        }
    }
}
