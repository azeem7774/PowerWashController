using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PWN
{
    public class LoadingScreen : MonoBehaviour
    {
        public Action OnLoadingComplete;
        [SerializeField] private float m_FakeLoadingTime;
        [SerializeField] private Image m_Forground;
        WaitForSeconds wait;
        private void OnEnable()
        {
            m_Forground.fillAmount = 0;
            wait = new WaitForSeconds(0.5f);
            StartCoroutine(CompleteLoadingBar());
        }
        private void Start()
        {
            //StartCoroutine(CompleteLoadingBar());

        }

        private IEnumerator CompleteLoadingBar()
        {
            float elapsedTime = 0;
            while (m_FakeLoadingTime > elapsedTime)
            {
                m_Forground.fillAmount = Mathf.Lerp(0, 0.99f, elapsedTime / m_FakeLoadingTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            m_Forground.fillAmount = 1;
            yield return wait;
            OnLoadingComplete?.Invoke();
        }
    }
}

