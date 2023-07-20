using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class PlayerPositionHandler : MonoBehaviour
    {
        [SerializeField] private Transform m_PlayerPosition;
        [SerializeField] private PlayersEventHandler m_PlayersEventHandler;
        [SerializeField] private Vector3 m_PositionOffset;
        private void OnEnable()
        {
            m_PlayersEventHandler = GetComponent<PlayersEventHandler>();
            Subcribe();

        }
        void Start()
        {
            //transform.position = m_PlayerPosition.position;
            LoadPlayerPosition();
        }



        public void SetPlayerPosition(Transform _transform) => transform.position = _transform.position ;

        void LoadPlayerPosition() => transform.position = PlayerPosition.GetPlayerPosition(transform.position);

        void SavePlayerPosition() => PlayerPosition.SavePlayerPosition(transform.position + m_PositionOffset);
        void Subcribe() => m_PlayersEventHandler.OnItemSelected += SavePlayerPosition;
        void Unsubscribe() => m_PlayersEventHandler.OnItemSelected -= SavePlayerPosition;
        private void OnDisable()
        {
            Unsubscribe();
        }
    }
}

