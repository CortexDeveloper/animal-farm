using System;

namespace Gameplay.Generic
{
    public class GameSession
    {
        public event Action OnScoreChanged; 

        public int Score { get; private set; }

        public void AddScore(int score)
        {
            Score += score;
            
            OnScoreChanged?.Invoke();
        }
    }
}