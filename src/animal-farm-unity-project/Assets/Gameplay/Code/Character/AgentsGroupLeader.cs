using System.Collections.Generic;
using Gameplay.Agent;
using UnityEngine;

namespace Gameplay.Character
{
    public class AgentsGroupLeader : MonoBehaviour
    {
        private const string AgentTag = "Agent";

        [SerializeField] private float maxAgentsInGroup;

        private Queue<AgentBehaviour> _agents = new();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_agents.Count >= maxAgentsInGroup)
                return;
            
            if (other.CompareTag(AgentTag)) 
                PickupAgent(other.GetComponent<AgentBehaviour>());
        }

        private void PickupAgent(AgentBehaviour agent) => 
            agent.ChangeStateTo(AgentState.Following);
    }
}