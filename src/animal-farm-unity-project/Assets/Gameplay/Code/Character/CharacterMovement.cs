using UnityEngine;

namespace Gameplay.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private const float MinimumDistanceToTarget = 0.1f;

        [SerializeField] private float moveSpeed; 
        [SerializeField] private Vector3 targetPosition;
        [SerializeField] private bool isMoving;
        
        private void Update()
        {
            ListenInput();

            if (isMoving) 
                MoveToTarget();
        }

        private void ListenInput()
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            isMoving = true;
        }

        private void MoveToTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < MinimumDistanceToTarget) 
                isMoving = false;
        }
    }
}