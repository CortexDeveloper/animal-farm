using Gameplay.Agent;
using Gameplay.Character;
using Gameplay.Level;
using UnityEngine;

namespace Gameplay.Generic
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private AgentsGroupLeader character; 
        [SerializeField] private PatrolZone patrolZone; 
        [SerializeField] private AgentFactory agentFactory; 
        
        private void Awake()
        {
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            GameplayServiceLocator.Register(new GameSession());
            GameplayServiceLocator.Register(character);
            GameplayServiceLocator.Register(patrolZone);
            GameplayServiceLocator.Register(agentFactory);
        }
    }
}