using UnityEngine;
using TMPro;
using ButchersGames;

namespace Game.MenuComponents
{
    public class LevelTextVisualizer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private string _textBeforeNumber;

        private void Start()
        {
            _levelText.text = _textBeforeNumber + (LevelManager.CurrentLevel);
        }
    }
}