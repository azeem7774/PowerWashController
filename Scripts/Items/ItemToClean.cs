using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class ItemToClean : Item, IInteractable
    {
        public Action OnItemCleanInteract;
        public static Action<ItemToClean> OnInteract;
        void Start()
        {

        }

        public void Interact()
        {
            OnItemCleanInteract?.Invoke();
            OnInteract?.Invoke(this);
        }

    }
}

