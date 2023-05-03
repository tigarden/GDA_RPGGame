using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public bool IsBuffed => _isBuffed;

        [SerializeField] private float highlightWidth;
        private bool _isBuffed;

        private void Awake()
        {
            _isBuffed = false;
        }

        public void UsePotion()
        {
            gameObject.GetComponent<Outline>().OutlineWidth = highlightWidth;
            _isBuffed = true;
        }
    }
}