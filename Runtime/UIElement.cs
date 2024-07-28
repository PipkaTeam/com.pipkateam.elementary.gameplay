using UnityEngine;

namespace Elementary.Gameplay
{
    public class UIElement : MonoBehaviour
    {
        private Player ownerPlayer;

        public Player GetOwnerPlayer()
        {
            if (ownerPlayer == null)
            {
                Debug.LogWarning("[Elementary Gameplay][UIElement] GetOwnerPlayer warning: ownerPlayer is null!");
            }

            Debug.Log($"[Elementary Gameplay][UIElement] GetOwnerPlayer called. Current ownerPlayer: {ownerPlayer}");
            return ownerPlayer;
        }

        public void SetOwnerPlayer(Player newOwnerPlayer)
        {
            if (newOwnerPlayer == null)
            {
                Debug.LogError("[Elementary Gameplay][UIElement] SetOwnerPlayer error: Trying to set ownerPlayer to null!");
                return;
            }

            Debug.Log($"[Elementary Gameplay][UIElement] SetOwnerPlayer called. Previous ownerPlayer: {ownerPlayer}, New ownerPlayer: {newOwnerPlayer}");
            ownerPlayer = newOwnerPlayer;
        }

        protected virtual void Start()
        {
            Debug.Log($"[Elementary Gameplay][UIElement] initialized.");
        }

        public void RemoveFromUI()
        {
            Destroy(gameObject);
        }

        public T GetUIElementFromParent<T>() where T : UIElement
        {
            return GetComponentInParent<T>();
        }

        public T GetUIElementFromChildren<T>() where T : UIElement
        {
            return GetComponentInChildren<T>();
        }
    }
}