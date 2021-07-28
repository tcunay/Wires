﻿using System;
using System.Collections.Generic;
using UnityEngine;
using WiresGame.Elements;
using WiresGame.Libraries;

namespace WiresGame
{
    public class ElementsSpawner : MonoBehaviour
    {
        [SerializeField] private Element _template;
        [SerializeField] private ColorsLibrary _colorsLibrary;

        public event Action Spawned;

        public void SpawnElementsInElementConecter(IReadOnlyList<ElementsBoard> boards , int elementsCountOnOneBoard)
        {
            InitColorsListsByElementsBords(elementsCountOnOneBoard, boards.Count, out List<IReadOnlyList<Color>> colorsForBoards);

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