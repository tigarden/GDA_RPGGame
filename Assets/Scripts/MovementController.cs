using System;
using UnityEngine;
using UnityEngine.AI;

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

    // Potion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potion"))
        {
            gameObject.GetComponent<Outline>().OutlineWidth = 2;
            IsHaveBuff = true;
            Destroy(other.gameObject);
        }
    }

    private void TryGetDestination()
    {
        var mousePosition = Input.mousePosition;
        var ray = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            var hitPosition = hitInfo.point;

            if (Input.GetMouseButtonDown(0))
            {
                _destination = hitPosition;
            }
        }
    }
}