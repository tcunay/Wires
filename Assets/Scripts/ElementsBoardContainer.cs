using System.Collections.Generic;
using UnityEngine;
using WiresGame.Elements;

namespace WiresGame
{
    [System.Serializable]
    class ElementsBoardsContainer
    {
        [SerializeField] private List<ElementsBoard> _elementsBoards;

        public IReadOnlyList<ElementsBoard> Boards => _elementsBoards;

        private Spawner _spawner;
    }
}
