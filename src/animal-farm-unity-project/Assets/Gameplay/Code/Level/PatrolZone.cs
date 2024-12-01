using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Level
{
    public class PatrolZone : MonoBehaviour
    {
        private BoxCollider2D _boxCollider;
        
        private void Awake() => 
            _boxCollider = GetComponent<BoxCollider2D>();

        public Vector2 GetRandomPosition()
        {
            var bounds = _boxCollider.bounds;

            var randomX = Random.Range(bounds.min.x, bounds.max.x);
            var randomY = Random.Range(bounds.min.y, bounds.max.y);

            return new Vector2(randomX, randomY);
        }
    }
}