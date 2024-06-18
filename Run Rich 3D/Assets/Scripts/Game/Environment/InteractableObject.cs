using UnityEngine;
using Game.PlayerComponents;

namespace Game.Environment
{
    public abstract class InteractableObject : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out var player))
            {
                InteractWithPlayer(player);
            }
        }

        protected abstract void InteractWithPlayer(Player player);
    }
}
