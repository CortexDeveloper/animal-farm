using Gameplay.Character;
using Gameplay.Generic;
using UnityEngine;

namespace Gameplay.Level
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform character; 
        
        private void Awake()
        {
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            GameplayServiceLocator.Register(new GameSession());
            GameplayServiceLocator.Register(character.GetComponent<AgentsGroupLeader>());
        }
    }
}