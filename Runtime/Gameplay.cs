using System;
using UnityEngine;

namespace Elementary.Gameplay
{
    public class Gameplay : MonoBehaviour
    {
        [SerializeField]
        private Player playerPrefab;

        [SerializeField]
        private UI UIPrefab;

        [SerializeField]
        private Character characterPrefab;

        public event Action<Character> OnCharacterSpawned;

        private Player player;

        private Vector3 spawnPointPosition  = new Vector3(0, 0, 0);
        private Quaternion spawnPointRotation = Quaternion.identity;

        protected virtual void Start()
        {
            SpawnPoint startSpawnPoint = FindSpawnPoint();

            if (startSpawnPoint)
            {
                SetSpawnPointPosition(startSpawnPoint.transform.position);
            }

            SpawnPlayer();
            SpawnUI();
            SpawnCharacter();
        }

        public Player GetPlayer()
        {
            return player;
        }

        private void SpawnPlayer()
        {
            if (playerPrefab == null)
            {
                Debug.LogWarning("[Elementary Gameplay][Gameplay] SpawnPlayer warning: Player prefab is not assigned in the inspector.");
            }
            else
            {
                player = Instantiate(playerPrefab);
                player.SetGameplay(this);
                Debug.Log("[Elementary Gameplay][Gameplay] SpawnPlayer: Player instantiated successfully.");
            }
        }

        private void SpawnUI()
        {
            if (UIPrefab == null)
            {
                Debug.LogWarning("[Elementary Gameplay][Gameplay] SpawnUI warning: UI prefab is not assigned in the inspector.");
            }
            else
            {
                UI newUI = Instantiate(UIPrefab);
                newUI.SetOwnerPlayer(player);
                player.SetUI(newUI);
                Debug.Log("[Elementary Gameplay][Gameplay] SpawnUI: UI instantiated and owner player set successfully.");
            }
        }

        protected void SpawnCharacter()
        {
            if (characterPrefab == null)
            {
                Debug.LogWarning("[Elementary Gameplay][Gameplay] SpawnCharacter warning: Character prefab is not assigned in the inspector.");
            }
            else
            {
                Character newCharacter = Instantiate(characterPrefab, spawnPointPosition, spawnPointRotation);
                newCharacter.SetOwnerPlayer(player);
                player.SetCharacter(newCharacter);
                Debug.Log("[Elementary Gameplay][Gameplay] SpawnCharacter: Character instantiated and owner player set successfully.");

                OnCharacterSpawned?.Invoke(newCharacter);
            }
        }

        private SpawnPoint FindSpawnPoint()
        {
            SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>();
            
            if (spawnPoint)
            {
                return spawnPoint;
            }

            return null;
        }

        public Vector3 GetSpawnPointPosition()
        {
            return spawnPointPosition;
        }

        public void SetSpawnPointPosition(Vector3 newSpawnPointPosition)
        {
            spawnPointPosition = newSpawnPointPosition;
        }

        public Quaternion GetSpawnPointRotation()
        {
            return spawnPointRotation;
        }

        public void SetSpawnPoinRotation(Quaternion newSpawnPointRotation)
        {
            spawnPointRotation = newSpawnPointRotation;
        }
    }
}