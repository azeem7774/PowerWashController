using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PWN
{
    public class GameRunTimeRepository : MonoBehaviour
    {
        private static ItemToClean m_ItemToClean;
        private static CleaningViewCamerasHandler m_CleaningViewCameraHandler;
        public static ItemToClean CurrentItemToClean 
        {
            get
            {
                return m_ItemToClean;
            }

            set
            {
                m_ItemToClean = value;
            }
        }

        public CleaningViewCamerasHandler CurrentCleaningViewCamera
        {
            get
            {
                return m_CleaningViewCameraHandler;
            }

            set
            {
                m_CleaningViewCameraHandler = value;
            }
        }
        private void OnEnable()
        {
            ItemToClean.OnInteract += SetInstanceItemToClean;
        }

        private void SetInstanceItemToClean(ItemToClean instance) => m_ItemToClean = instance;
        private void SetNullItemToClean() => m_ItemToClean = null;
        private void OnDisable()
        {
            ItemToClean.OnInteract -= SetInstanceItemToClean;
        }
    }
}

