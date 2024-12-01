using Gameplay.Character;
using Gameplay.Generic;
using UnityEngine;

namespace Gameplay.Agent
{
    public class AgentBehaviour : MonoBehaviour
    {
        public AgentSettings agentSettings;

        private AgentsGroupLeader _character;
        
        [field: SerializeField] 
        public AgentState State { get; private set; }

        private void Awake()
        {
            _character = GameplayServiceLocator.Get<AgentsGroupLeader>();
        }

        private void Update()
        {
            if (State == AgentState.Following)
                Follow();
            else if (State == AgentState.Delivered) 
                Deliver();
        }

        public void ChangeStateTo(AgentState state) => 
            State = state;

        private void Follow() => 
            transform.position = Vector3.MoveTowards(
                transform.position, 
                _character.transform.position, 
                agentSettings.moveSpeed * Time.deltaTime);

        private void Deliver() => 
            Destroy(gameObject);
    }
}