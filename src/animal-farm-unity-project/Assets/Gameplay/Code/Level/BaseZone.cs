using System;
using Gameplay.Agent;
using Gameplay.Generic;
using UnityEngine;

namespace Gameplay.Level
{
    public class BaseZone : MonoBehaviour
    {
        private const string AgentTag = "Agent";

        [SerializeField] private int scorePerAgent;
        
        private GameSession _gameSession;

        private void Awake()
        {
            _gameSession = GameplayServiceLocator.Get<GameSession>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(AgentTag)) 
                DeliverAgent(other.GetComponent<AgentBehaviour>());
        }

        private void DeliverAgent(AgentBehaviour agent)
        {
            agent.ChangeStateTo(AgentState.Delivered);
            
            _gameSession.AddScore(scorePerAgent);
        }
    }
}