using Gameplay.Agent;
using Gameplay.Character;
using Gameplay.Generic;
using UnityEngine;

namespace Gameplay.Level
{
    public class BaseZone : MonoBehaviour
    {
        private const string AgentTag = "Agent";

        [SerializeField] private int scorePerAgent;
        
        private GameSession _gameSession;
        private AgentsGroupLeader _agentsGroupLeader;

        private void Awake()
        {
            _gameSession = GameplayServiceLocator.Get<GameSession>();
            _agentsGroupLeader = GameplayServiceLocator.Get<AgentsGroupLeader>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(AgentTag)) 
                DeliverAgent(other.GetComponent<AgentBehaviour>());
        }

        private void DeliverAgent(AgentBehaviour agent)
        {
            agent.ChangeStateTo(AgentState.Delivered);
            
            _agentsGroupLeader.ReleaseAgent();
            _gameSession.AddScore(scorePerAgent);
        }
    }
}