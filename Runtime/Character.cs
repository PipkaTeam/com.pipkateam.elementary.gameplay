using UnityEngine;

namespace Elementary.Gameplay
{
    public class Character : MonoBehaviour
    {
        private Player ownerPlayer;

        protected virtual void Start()
        {
            Debug.Log($"[Elementary Gameplay][Character] initialized.");
        }

        public Player GetOwnerPlayer()
        {
            if (ownerPlayer == null)
            {
                Debug.LogWarning("[Elementary Gameplay][Character] GetOwnerPlayer warning: ownerPlayer is null!");
            }

            Debug.Log($"[Elementary Gameplay][Character] GetOwnerPlayer called. Current ownerPlayer: {ownerPlayer}");
            return ownerPlayer;
        }

        public void SetOwnerPlayer(Player newOwnerPlayer)
        {
            if (newOwnerPlayer == null)
            {
                Debug.LogError("[Elementary Gameplay][Character] SetOwnerPlayer error: Trying to set ownerPlayer to null!");
                return;
            }

            Debug.Log($"[Elementary Gameplay][Character] SetOwnerPlayer called. Previous ownerPlayer: {ownerPlayer}, New ownerPlayer: {newOwnerPlayer}");
            ownerPlayer = newOwnerPlayer;
        }
    }
}