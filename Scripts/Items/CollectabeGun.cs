using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class CollectabeGun : Item, IInteractable
    {
        void Start()
        {

        }

        public void Interact()
        {
            //StartCoroutine(TurnOffModels());
        }

        IEnumerator TurnOffModels()
        {
            yield return new WaitForSeconds(2);
            m_Model.SetActive(false);
            m_ParcleEfx.SetActive(false);
        }
    }
}

