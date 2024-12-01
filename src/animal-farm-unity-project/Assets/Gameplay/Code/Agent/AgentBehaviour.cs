using Gameplay.Character;
using Gameplay.Generic;
using Gameplay.Level;
using UnityEngine;

namespace Gameplay.Agent
{
    public class AgentBehaviour : MonoBehaviour
    {
        private const float MinimumDistanceToTarget = 0.1f;
        
        public AgentSettings agentSettings;

        private AgentsGroupLeader _character;
        private PatrolZone _patrolZone;
        private Vector3 _patrolPosition;
        
        [field: SerializeField] 
        public AgentState State { get; private set; }

        private void Awake()
        {
            _character = GameplayServiceLocator.Get<AgentsGroupLeader>();
            _patrolZone = GameplayServiceLocator.Get<PatrolZone>();
        }

        private void Update()
        {
            if (State == AgentState.Idle)
                Idle();
            else if (State == AgentState.Following)
                Follow();
            else if (State == AgentState.Delivered) 
                Deliver();
        }

        public void ChangeStateTo(AgentState state) => 
            State = state;

        public void Deactivate()
        {
            ChangeStateTo(AgentState.Idle);
            gameObject.SetActive(false);
        }
        
        private void Idle()
        {
            MoveTo(agentSettings.idleSpeed, _patrolPosition);

            if (Vector3.Distance(transform.position, _patrolPosition) < MinimumDistanceToTarget)
                _patrolPosition = _patrolZone.GetRandomPosition();
        }

        private void Follow() => 
            MoveTo(agentSettings.followSpeed, _character.transform.position);

        private void MoveTo(float speed, Vector3 position) => 
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

        private void Deliver() => 
            Destroy(gameObject);
    }
}