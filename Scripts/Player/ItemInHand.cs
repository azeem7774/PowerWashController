using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class ItemInHand : MonoBehaviour
    {
        [SerializeField] private Transform m_HandsTransform;
        [SerializeField] private GameObject[] m_ItemsInHand;

        private void Start()
        {
            Helper.ToggleMultipleGameObjects(m_ItemsInHand, false);
        }

        public void TrunOnItemInHand(int Index) => Helper.ToggleSingleGameObject(m_ItemsInHand[Index], true);
    }
}

