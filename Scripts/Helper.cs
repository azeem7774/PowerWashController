using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public static class Helper
    {
        public static void ToggleSingleGameObject(GameObject go, bool enable) => go.SetActive(enable);

        public static void ToggleMultipleGameObjects(GameObject[] gos, bool enable)
        {
            for (int i = 0; i < gos.Length; i++) gos[i].SetActive(enable);
        }
        public static void ToggleGameObjectsWithStartIndex(GameObject[] gos, int index, bool enable)
        {
            for (int i = index; i < gos.Length; i++) gos[i].SetActive(enable);
        }
        public static void SwitchBetweenTwoGameObjects(GameObject go1, GameObject go2)
        {
            go1.SetActive(true);
            go2.SetActive(false);
        }
    }
}

