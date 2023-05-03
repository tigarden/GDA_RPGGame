using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private Vector3 _destination;

        private Camera _camera;
        public bool IsHaveBuff { get; private set; } = false;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            // Перемещаем персонажа в направлении _destination.
            _navMeshAgent.SetDestination(_destination);

            // TODO: Получите точку, по которой кликнули мышью и задайте ее вектор в поле _destination.
            TryGetDestination();
        }
    
        private void TryGetDestination()
        {
            if (!Input.GetMouseButtonDown(0)) return;
        
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hitInfo))
            {
                _destination = hitInfo.point;
            }
        }
    }
}