using UnityEngine;
using TMPro;

namespace WiresGame.TopLists
{
    public class TopListCell : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _score;

        public void Init(string name, int score)
        {
            _name.text = name;
            _score.text = score.ToString();
        }
    }
}