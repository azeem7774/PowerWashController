using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN 
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private void Awake()
        {
            Instance = this;
        }
        public void DisableObject(GameObject[] gos)
        {
            //logic
        }
    }
}

