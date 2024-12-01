using UnityEngine;

namespace Gameplay.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private const float MinimumDistanceToTarget = 0.1f;
        
        public CharacterMovementSettings movementSettings;
        
        private Vector3 _targetPosition;
        private bool _isMoving;
        
        private void Update()
        {
            ListenInput();

            if (_isMoving) 
                MoveToTarget();
        }

        private void ListenInput()
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition.z = 0;
            _isMoving = true;
        }

        private void MoveToTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, movementSettings.moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _targetPosition) < MinimumDistanceToTarget) 
                _isMoving = false;
        }
    }
}