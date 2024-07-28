using UnityEngine;

namespace Elementary.Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private CameraManager cameraManagerPrefab;

        private UI ui;
        private Character character;
        private Gameplay gameplay;

        protected virtual void Start()
        {
            Debug.Log($"[Elementary Gameplay][UI] initialized.");
            SpawnCameraManager();
        }

        private void SpawnCameraManager()
        {
            if (cameraManagerPrefab == null)
            {
                Debug.LogError("[Elementary Gameplay][Player] SpawnCameraManager error: CameraManagerPrefab is not assigned!");
                return;
            }

            CameraManager newCameraManager = Instantiate(cameraManagerPrefab);
            newCameraManager.SetOwnerPlayer(this);
            Debug.Log("[Elementary Gameplay][Player] SpawnCameraManager: CameraManager spawned and owner player set.");
        }

        public T GetUI<T>() where T : UI
        {
            Debug.Log($"[Elementary Gameplay][Player] GetUI called. Current UI: {ui}");
            
            if (ui is T uiComponent)
            {
                return uiComponent;
            }
            else
            {
                Debug.LogWarning($"[Elementary Gameplay][Player] GetUI warning: The UI is either null or not of type {typeof(T).Name}");
                return null;
            }
        }

        public void SetUI(UI newUI)
        {
            if (newUI == null)
            {
                Debug.LogWarning("[Elementary Gameplay][Player] SetUI warning: Trying to set UI to null!");
            }
            Debug.Log($"[Elementary Gameplay][Player] SetUI called. Previous UI: {ui}, New UI: {newUI}");
            ui = newUI;
        }

        public T GetCharacter<T>() where T : Character
        {
            Debug.Log($"[Elementary Gameplay][Player] GetCharacter called. Current character: {character}");

            if (character is T characterComponent)
            {
                return characterComponent;
            }
            else
            {
                Debug.LogWarning($"[Elementary Gameplay][Player] GetCharacter warning: The character is either null or not of type {typeof(T).Name}");
                return null;
            }
        }

        public void SetCharacter(Character newCharacter)
        {
            if (newCharacter == null)
            {
                Debug.LogWarning("[Elementary Gameplay][Player] SetCharacter warning: Trying to set character to null!");
            }
            Debug.Log($"[Elementary Gameplay][Player] SetCharacter called. Previous character: {character}, New character: {newCharacter}");
            character = newCharacter;
        }

        public T GetGameplay<T>() where T : Gameplay
        {
            Debug.Log($"[Elementary Gameplay][Player] GetGameplay called. Current Gameplay: {gameplay}");

            if (gameplay is T gameplayComponent)
            {
                return gameplayComponent;
            }
            else
            {
                Debug.LogWarning($"[Elementary Gameplay][Player] GetGameplay warning: The Gameplay is either null or not of type {typeof(T).Name}");
                return null;
            }
        }

        public void SetGameplay(Gameplay newGameplay)
        {
            if (newGameplay == null)
            {
                Debug.LogWarning("[Elementary Gameplay][Player] SetGameplay warning: Trying to set Gameplay to null!");
            }

            Debug.Log($"[Elementary Gameplay][Player] SetGameplay called. Previous Gameplay: {gameplay}, New Gameplay: {newGameplay}");
            gameplay = newGameplay;
        }
    }
}