using UnityEngine;
using UnityEngine.EventSystems;

namespace Elementary.Gameplay
{
    public class UI : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvasPrefab;

        private Canvas canvas;

        private Player ownerPlayer;

        protected virtual void Start()
        {
            Debug.Log($"[Elementary Gameplay][UI] initialized.");
            SpawnCanvas();
        }

        private void SpawnCanvas()
        {
            if (canvasPrefab == null)
            {
                Debug.LogError("[Elementary Gameplay][UI] SpawnCanvas error: Canvas prefab is not assigned. Please assign a canvas prefab in the inspector.");
                return;
            }

            canvas = Instantiate(canvasPrefab);

            if (canvas == null)
            {
                Debug.LogError("[Elementary Gameplay][UI] SpawnCanvas error: Failed to retrieve Canvas component from the instantiated prefab.");
            }
            else
            {
                Debug.Log("[Elementary Gameplay][UI] SpawnCanvas: Canvas successfully instantiated.");
            }

            if (FindObjectOfType<EventSystem>() == null)
            {
                Debug.Log("[Elementary Gameplay][UI] SpawnCanvas: No EventSystem found, creating a new one.");
                GameObject eventSystem = new GameObject("EventSystem");
                eventSystem.AddComponent<EventSystem>();
                eventSystem.AddComponent<StandaloneInputModule>();
                Debug.Log("[Elementary Gameplay][UI] SpawnCanvas: EventSystem created.");
            }
        }

        protected UIElement SpawnUIElement(UIElement uiElementPrefab)
        {
            if (canvasPrefab == null)
            {
                Debug.LogError("[Elementary Gameplay][UI] SpawnUIElement error: Canvas prefab is not assigned. Please assign a canvas prefab in the inspector.");
                return null;
            }

            if (uiElementPrefab == null)
            {
                Debug.LogError("[Elementary Gameplay][UI] SpawnUIElement error: UIElement prefab is not assigned.");
                return null;
            }

            UIElement newUIElement = Instantiate(uiElementPrefab, canvas.transform);
            newUIElement.SetOwnerPlayer(ownerPlayer);

            Debug.Log($"[Elementary Gameplay][UI] SpawnUIElement: UIElement {uiElementPrefab.name} instantiated and owner player set.");

            UIElement[] childrenUIElements = newUIElement.GetComponentsInChildren<UIElement>();

            foreach (UIElement childrenUIElement in childrenUIElements)
            {
                childrenUIElement.SetOwnerPlayer(ownerPlayer);
                Debug.Log($"[Elementary Gameplay][UI] SpawnUIElement: Child UIElement {childrenUIElement.name} owner player set.");
            }

            return newUIElement;
        }

        protected void RemoveUIElement(UIElement uiElement)
        {
            if (uiElement == null)
            {
                Debug.LogError("[Elementary Gameplay][UI] RemoveUIElement error: UIElement is null.");
                return;
            }

            uiElement.RemoveFromUI();
            Debug.Log($"[Elementary Gameplay][UI] RemoveUIElement: UIElement {uiElement.name} removed from UI.");
        }

        public Player GetOwnerPlayer()
        {
            if (ownerPlayer == null)
            {
                Debug.LogWarning("[Elementary Gameplay][UI] GetOwnerPlayer warning: ownerPlayer is null!");
            }

            Debug.Log($"[Elementary Gameplay][UI] GetOwnerPlayer called. Current ownerPlayer: {ownerPlayer}");
            return ownerPlayer;
        }

        public void SetOwnerPlayer(Player newOwnerPlayer)
        {
            if (newOwnerPlayer == null)
            {
                Debug.LogError("[Elementary Gameplay][UI] SetOwnerPlayer error: Trying to set ownerPlayer to null!");
                return;
            }

            Debug.Log($"[Elementary Gameplay][UI] SetOwnerPlayer called. Previous ownerPlayer: {ownerPlayer}, New ownerPlayer: {newOwnerPlayer}");
            ownerPlayer = newOwnerPlayer;
        }
    }
}