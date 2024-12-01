using Gameplay.Generic;
using TMPro;
using UnityEngine;

namespace Gameplay.HUD
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreDisplay : MonoBehaviour
    {
        private TMP_Text _scoreText;
        private GameSession _gameSession;
        
        private void Awake()
        {
            _scoreText = GetComponent<TMP_Text>();
            _gameSession = GameplayServiceLocator.Get<GameSession>();
            _gameSession.OnScoreChanged += UpdateScore;
        }

        private void OnDestroy() => 
            _gameSession.OnScoreChanged -= UpdateScore;

        private void UpdateScore() => 
            _scoreText.text = _gameSession.Score.ToString();
    }
}