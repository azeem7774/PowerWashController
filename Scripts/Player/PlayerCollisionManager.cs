using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerCollisionManager : MonoBehaviour
    {
        private PlayerAnimationController m_PlayerAnimatorController;

        public static Action OnTriggerWithInteractable;
        public static Action<GameObject> GetGameObjectInfoWithAction;
        public Action OnTriggerInteractable;
        public Action<int> OnPlayerCollisionForVFX;
        public Action<Transform> OnTriggerObjectPosition;
        public Action<ItemToClean> OnTriggerWithItemToClean;
        IInteractable m_Interactable;
        ItemToClean m_ItemToClean;
        Item m_Item;
        void Start()
        {
            m_PlayerAnimatorController = GetComponent<PlayerAnimationController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IInteractable>(out m_Interactable))
            {
                m_Interactable.Interact();
                m_PlayerAnimatorController.SetAnimatorSpeed(0); // this piece of code should be in its own class (PlayerAnimatorController)
                InvokeAllEvents(other.gameObject);
            }
        }
        private void InvokeAllEvents(GameObject go)
        {
            OnTriggerWithInteractable?.Invoke();
            GetGameObjectInfoWithAction(go);
            OnTriggerInteractable?.Invoke();

        }

        private void OnTriggerExit(Collider other)
        {
            m_Interactable = null;
        }
    }
}

