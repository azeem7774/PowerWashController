using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Items m_Item;
        [SerializeField] protected GameObject m_Model;
        [SerializeField] protected GameObject m_ParcleEfx;
        [SerializeField] private bool m_ItemToOffAfterInteract;

        public bool ItemToOffAfterInteract => m_ItemToOffAfterInteract;

        public GameObject Model => m_Model;
        public GameObject ParticleEFx => m_ParcleEfx;
        public Items Items => m_Item;
    }
    public enum Items
    {
        Gun,
        Window,
        WashingSuit
    }
}
