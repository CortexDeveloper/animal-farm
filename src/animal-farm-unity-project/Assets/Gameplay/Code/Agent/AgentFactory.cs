using UnityEngine;

namespace Gameplay.Agent
{
    [CreateAssetMenu(fileName = nameof(AgentFactory), menuName = "Gameplay/Agent Factory")]
    public class AgentFactory : ScriptableObject
    {
        public Transform agentPrefab;
        public AgentSettings agentSettings;
        
        public AgentBehaviour Create(Vector3 position)
        {
            var agentInstance = Instantiate(agentPrefab);
            var agentBehaviour = agentInstance.GetComponent<AgentBehaviour>();
            agentBehaviour.agentSettings = agentSettings;
            agentBehaviour.transform.position = position;
            
            return agentBehaviour;
        }
    }
}