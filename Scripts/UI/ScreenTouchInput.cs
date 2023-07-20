using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PWN
{
    public class ScreenTouchInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public static Action OnScreenPointerDown, OnScreenPointerUp;

        private void Start()
        {

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnScreenPointerDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnScreenPointerUp?.Invoke();
        }
    }
}

