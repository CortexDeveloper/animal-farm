using Gameplay.Agent;
using UnityEngine;

namespace Gameplay.Character
{
    public class AgentsGroupLeader : MonoBehaviour
    {
        private const string AgentTag = "Agent";

        [SerializeField] private float maxAgentsInGroup;
        [SerializeField] private int currentGroupSize;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (currentGroupSize >= maxAgentsInGroup)
                return;
            
            if (other.CompareTag(AgentTag)) 
                TryPickupAgent(other.GetComponent<AgentBehaviour>());
        }

        public void ReleaseAgent() => 
            currentGroupSize--;

        private void TryPickupAgent(AgentBehaviour agent)
        {
            if (agent.State != AgentState.Idle)
                return;
            
            agent.ChangeStateTo(AgentState.Following);
            currentGroupSize++;
        }
    }
}