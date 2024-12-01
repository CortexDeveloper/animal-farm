using Gameplay.Generic;
using Gameplay.Level;
using UnityEngine;

namespace Gameplay.Agent
{
    public class AgentSpawner : MonoBehaviour
    {
        [SerializeField] private float minSpawnInterval;
        [SerializeField] private float maxSpawnInterval;
        [SerializeField] private float timeToSpawn;
        
        private AgentFactory _agentFactory;
        private PatrolZone _patrolZone;
        
        private void Awake()
        {
            _agentFactory = GameplayServiceLocator.Get<AgentFactory>();
            _patrolZone = GameplayServiceLocator.Get<PatrolZone>();
        }

        private void Update()
        {
            if (timeToSpawn <= 0)
            {
                timeToSpawn = Random.Range(minSpawnInterval, maxSpawnInterval);
                SpawnAgent();
            }
            
            timeToSpawn -= Time.deltaTime;
        }

        private void SpawnAgent()
        {
            var position = _patrolZone.GetRandomPosition();
            _agentFactory.Create(position);
        }
    }
}