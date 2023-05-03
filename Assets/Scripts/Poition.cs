using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Poition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            other.gameObject.GetComponent<PlayerController>().UsePotion();
            Destroy(gameObject);
        }
    }
}
