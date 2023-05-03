using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Open()
    {
        _animator.SetTrigger("open");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            Open();
        }
    }
}