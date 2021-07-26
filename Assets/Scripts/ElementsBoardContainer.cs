using System.Collections.Generic;
using UnityEngine;
using WiresGame.Elements;

namespace WiresGame
{
    [System.Serializable]
    class ElementsConecter
    {
        [SerializeField] private List<ElementsBoard> _elementsBoards;

        public IReadOnlyList<ElementsBoard> Boards => _elementsBoards;
    }
}
