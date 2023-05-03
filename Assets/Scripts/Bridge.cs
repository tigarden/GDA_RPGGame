using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bridge : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    private NavMeshObstacle _navMeshObstacle;
    [SerializeField] private GameObject _fire;

    private float _minForceValue = 15;
    private float _maxForceValue = 20;

    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    public void Break()
    {
        // Вырезаем отверстие в навмеш (чтобы игрок там больше не смог пройти)
        _navMeshObstacle.enabled = true;
        
        foreach (var body in _rigidbodies)
        {
            body.isKinematic = false;

            // Генерируем случайную силу.
            var forceValue = Random.Range(_minForceValue, _maxForceValue);

            // Генерируем случайное направление.
            var direction = Random.insideUnitSphere;
            
            // Придаем силу каждому rigidbody.
            body.AddForce(direction * forceValue);
        }
    }

    public void OnBridgeExit()
    {
        _fire.SetActive(true);
    }
}