using System.Collections.Generic;
using UnityEngine;

namespace WiresGame.Libraries
{
    public abstract class CharacteristicsLibrary<T> : ScriptableObject
    {
        [SerializeField] private List<T> _characteristics;

        public IReadOnlyList<T> GetCharacteristics()
        {
            return _characteristics;
        }
    }
}