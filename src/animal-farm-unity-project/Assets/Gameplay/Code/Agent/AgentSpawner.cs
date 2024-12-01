using Gameplay.Generic;
using Gameplay.Level;
using UnityEngine;
using UnityEngine.Pool;

namespace Gameplay.Agent
{
    public class AgentSpawner : MonoBehaviour
    {
        [SerializeField] private float minSpawnInterval;
        [SerializeField] private float maxSpawnInterval;
        [SerializeField] private float timeToSpawn;
        
        private AgentFactory _agentFactory;
        private PatrolZone _patrolZone;
        
        private ObjectPool<GameObject> _pool;
        
        private void Awake()
        {
            _agentFactory = GameplayServiceLocator.Get<AgentFactory>();
            _patrolZone = GameplayServiceLocator.Get<PatrolZone>();
            
            _pool = new ObjectPool<GameObject>(
                createFunc: () => _agentFactory.Create(),
                actionOnGet: agent => agent.SetActive(true),
                actionOnRelease: agent => agent.GetComponent<AgentBehaviour>().Deactivate(),
                actionOnDestroy: Destroy,
                defaultCapacity: 10,
                maxSize: 30
            );
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
            var agent = _pool.Get();
            agent.transform.position = _patrolZone.GetRandomPosition();
        }
    }
}