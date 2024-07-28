using System;
using UnityEngine;

namespace Elementary.Gameplay
{
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(AudioListener))]
    public class CameraManager : MonoBehaviour
    {
        [SerializeField]
        private Vector3 offset = new Vector3(0, 0, -10);

        [SerializeField]
        private float speed = 5.0f;

        private Transform target;

        private Player ownerPlayer;

        protected virtual void Start ()
        {
            Debug.Log($"[Elementary Gameplay][CameraManager] initialized.");

            if(ownerPlayer.GetCharacter<Character>())
            {
                SetTarget(ownerPlayer.GetCharacter<Character>().transform);
            }

            Gameplay gameplay = FindAnyObjectByType<Gameplay>();
            gameplay.OnCharacterSpawned += OnCharacterSpawned;
        }

        private void OnCharacterSpawned(Character character)
        {
            SetTarget(character.transform);
        }

        public Player GetOwnerPlayer()
        {
            if (ownerPlayer == null)
            {
                Debug.LogWarning("[Elementary Gameplay][CameraManager] GetOwnerPlayer warning: ownerPlayer is null!");
            }

            Debug.Log($"[Elementary Gameplay][CameraManager] GetOwnerPlayer called. Current ownerPlayer: {ownerPlayer}");
            return ownerPlayer;
        }

        public void SetOwnerPlayer(Player newOwnerPlayer)
        {
            if (newOwnerPlayer == null)
            {
                Debug.LogError("[Elementary Gameplay][CameraManager] SetOwnerPlayer error: Trying to set ownerPlayer to null!");
                return;
            }

            Debug.Log($"[Elementary Gameplay][CameraManager] SetOwnerPlayer called. Previous ownerPlayer: {ownerPlayer}, New ownerPlayer: {newOwnerPlayer}");
            ownerPlayer = newOwnerPlayer;
        }

        public void SetTarget(Transform newTarget)
        {
            if (newTarget == null)
            {
                Debug.LogError("[Elementary Gameplay][CameraManager] UpdateTarget error: Trying to set target to null!");
                return;
            }

            Debug.Log($"[Elementary Gameplay][CameraManager] UpdateTarget called. Previous target: {target}, New target: {newTarget}");
            target = newTarget;
        }

        private void LateUpdate()
        {
            if (target != null)
            {
                Vector3 desiredPosition = target.position + offset;
                transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * speed);
            }
        }
    }
}
