using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{
    [SerializeField] private MovementController _player;
    [SerializeField] private Bridge _bridge;
    [SerializeField] private Chest _chest;
    [SerializeField] private GameObject _fire;
    [SerializeField] private GameObject _fireTrigger;

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, _bridge.transform.position) <= 4f)
        {
            if (!_player.IsHaveBuff)
            {
                _bridge.Break();
            }
        }

        if (Vector3.Distance(_player.transform.position, _chest.transform.position) <= 2f)
        {
            _chest.Open();
        }
        
        if (_fire.activeSelf == false && Vector3.Distance(_player.transform.position, _fireTrigger.transform.position) <= 0.5f)
        {
            _fire.SetActive(true);
        }
    }
}