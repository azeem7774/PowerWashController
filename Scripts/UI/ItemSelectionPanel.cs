using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PWN
{
    public class ItemSelectionPanel : MonoBehaviour
    {
        [SerializeField] private Button m_YesButton;
        public Action OnClickYes;
        private void Start() => m_YesButton.onClick.AddListener(OnClickYesButton);

        private void OnClickYesButton() => OnClickYes?.Invoke();
    }
}

