using System;
using UnityEngine;
using CnControls;
using System.Collections;

namespace PWN
{
    public class Hose : MonoBehaviour
    {
        public float maxPower = 20f;
        public float minPower = 5f;
        public float m_Power = 0f;

        [HideInInspector]

        public float changeSpeed = 5;
        public ParticleSystem[] hoseWaterSystems;
        //public Renderer systemRenderer;

        public GameObject[] HitEffect;

        public float RaySpread_Limit_X;
        public float RaySpread_Limit_Y;

        public float MaxLength, hitOffset;
        public Vector3 EffectOffset;
        public LayerMask TargetLayer;

        [HideInInspector]
        public MaskCamera _maskScript_0, _maskScript_1, _maskScript_2, _maskScript_3, _maskScript_4, _maskScript_5, _maskScript_6;
        [HideInInspector]
        public MaskCamera _maskScript_7, _maskScript_8, _maskScript_9, _maskScript_10, _maskScript_11, _maskScript_12, _maskScript_13, _maskScript_14, _maskScript_15, _maskScript_16, _maskScript_17, _maskScript_18;

        RaycastHit hit_0, hit_1, hit_2, hit_3, hit_4, hit_5, hit_6;
        RaycastHit hit_7, hit_8, hit_9, hit_10, hit_11, hit_12, hit_13, hit_14, hit_15, hit_16, hit_17, hit_18;

        [HideInInspector]

        float _delay = 0.75f, Max_delay = 0.75f;
        private bool CastRay = false;

        [Range(0.001f, 15f)] public float RayDistance_MaxLimit;

        public bool isSpread_1 = true, isSpread_2 = true, isSpread_3 = true, isSpread_4 = true, isSpread_5 = true, isSpread_6 = true, isSpread_7 = true, isSpread_8 = true, isSpread_9 = true;
        public Transform mNozle;
        public float rayLimitX;
        [Obsolete]
        private void Awake()
        {
            mNozle = transform.parent;
            foreach (var item in hoseWaterSystems)
            {
                item.enableEmission = false;
            }
        }
        void Start()
        {
            GameManager.Instance.DisableObject(HitEffect);
            _delay = Max_delay;

            /*if (GameManager.Instance.Rotate)
            {
                RaySpread_Limit_X = 0.000f;
                RaySpread_Limit_Y = 0.015f;
            }
            else
            {
                RaySpread_Limit_X = rayLimitX;
                RaySpread_Limit_Y = 0.000f;
            }*/
        }

        /*private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(hit_0.point, 0.025f);
        }*/
        /*private void Update()
        {
            if (CnInputManager.GetButtonDown("Fire"))
            {
                if (!GameManager.Instance.FireButtonGlow.activeInHierarchy)
                {
                    if (!GameManager.Instance.FireButtonGlow.activeSelf)
                    {
                        GameManager.Instance.FireButtonGlow.SetActive(true);
                        GameManager.Instance.ThrowWater = true;
                        SoundManager.Instance.Play_Spray();
                        print("ThrowWater = true");

                        if (GameManager.Instance.Tutorial_Obj[0].activeInHierarchy && GameManager.Instance.Tutorial_Obj[0].activeSelf)
                        {
                            if (PlayerPrefs.GetInt("Tutorial") == 1)
                            {
                                print("Tutorial played ");
                                GameManager.Instance.DisableObject(GameManager.Instance.Tutorial_Obj);
                            }
                            else
                            {
                                print("Tutorial not played ");
                                GameManager.Instance.DisableObject_Delay(GameManager.Instance.Tutorial_Obj[0]);

                                GameManager.Instance.EnableObject_Delay(GameManager.Instance.Tutorial_Obj[1]);
                                Analytics_Mediator.Instance.Tutorial_GunOn();

                            }
                        }
                    }
                }
                else
                {
                    if (GameManager.Instance.FireButtonGlow.activeSelf)
                    {
                        GameManager.Instance.FireButtonGlow.SetActive(false);
                        GameManager.Instance.ThrowWater = false;
                        SoundManager.Instance.Stop_Spray();
                        print("ThrowWater = false");
                    }
                }

                //systemRenderer.enabled = !systemRenderer.enabled;

            }

            if (CnInputManager.GetButtonDown("Rotate"))
            {
                if (!GameManager.Instance.RotateButtonGlow.activeInHierarchy)
                {
                    if (!GameManager.Instance.RotateButtonGlow.activeSelf)
                    {
                        GameManager.Instance.RotateButtonGlow.SetActive(true);
                        GameManager.Instance.Rotate = true;
                        *//*GameManager.Instance.gunAnimator.Play("Pressure_New_Animation");*//*

                        print("Rotate = true");
                        if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 0)
                        {
                            mNozle.localRotation = Quaternion.Euler(90, 0, 0);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 1)
                        {
                            mNozle.localRotation = Quaternion.Euler(0, 0, 90);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 2)
                        {
                            Debug.Log("Here");
                            mNozle.localRotation = Quaternion.Euler(0, 0, 90);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 3)
                        {
                            Debug.Log("Here");
                            mNozle.localRotation = Quaternion.Euler(0, 0, 90);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 4)
                        {
                            mNozle.localRotation = Quaternion.Euler(90, 0, 0);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 5)
                        {
                            mNozle.localRotation = Quaternion.Euler(90, 0, 0);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 6)
                        {
                            mNozle.localRotation = Quaternion.Euler(90, 0, 0);
                        }
                        GameManager.Instance.Gun_Selection[PlayerPrefs.GetInt("MySelected_Gun_Id")].Crosshair[PlayerPrefs.GetInt("MySelected_Nozzle_Id")].transform.localRotation = Quaternion.Euler(0, 0, 90);
                        SoundManager.Instance.Play_Clean();   //  optional
                        Analytics_Mediator.Instance.Level_No_Nozzle_Rotated();
                        //if (GameManager.Instance.Tutorial_Obj[0].activeInHierarchy && GameManager.Instance.Tutorial_Obj[0].activeSelf)
                        //{
                        //    if (PlayerPrefs.GetInt("Tutorial") == 1)
                        //    {
                        //        print("Tutorial played ");
                        //        GameManager.Instance.DisableObject(GameManager.Instance.Tutorial_Obj);
                        //    }
                        //    else
                        //    {
                        //        print("Tutorial not played ");
                        //        GameManager.Instance.DisableObject_Delay(GameManager.Instance.Tutorial_Obj[0]);
                        //        GameManager.Instance.EnableObject_Delay(GameManager.Instance.Tutorial_Obj[1]);
                        //    }
                        //}
                    }
                }
                else
                {
                    if (GameManager.Instance.RotateButtonGlow.activeSelf)
                    {
                        GameManager.Instance.RotateButtonGlow.SetActive(false);
                        GameManager.Instance.Rotate = false;
                        *//*GameManager.Instance.gunAnimator.Play("Pressure_New_Animation");*//*
                        print("Rotate = false");

                        if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 0)
                        {
                            mNozle.localRotation = Quaternion.Euler(0, 0, 0);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 1)
                        {
                            mNozle.localRotation = Quaternion.Euler(-90, 0, 90);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 2)
                        {
                            mNozle.localRotation = Quaternion.Euler(-90, 0, 90);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 3)
                        {
                            mNozle.localRotation = Quaternion.Euler(-90, 0, 90);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 4)
                        {
                            mNozle.localRotation = Quaternion.Euler(0, 0, 0);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 5)
                        {
                            mNozle.localRotation = Quaternion.Euler(0, 0, 0);
                        }
                        else if (PlayerPrefs.GetInt("MySelected_Gun_Id") == 6)
                        {
                            mNozle.localRotation = Quaternion.Euler(0, 0, 0);
                        }



                        GameManager.Instance.Gun_Selection[PlayerPrefs.GetInt("MySelected_Gun_Id")].Crosshair[PlayerPrefs.GetInt("MySelected_Nozzle_Id")].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        SoundManager.Instance.Play_Clean();   //  optional
                        Analytics_Mediator.Instance.Level_No_Nozzle_Rotated();
                    }
                }

                //systemRenderer.enabled = !systemRenderer.enabled;

                if (GameManager.Instance.Rotate)
                {
                    RaySpread_Limit_X = 0.000f;
                    RaySpread_Limit_Y = 0.015f;
                }
                else
                {
                    RaySpread_Limit_X = rayLimitX;
                    RaySpread_Limit_Y = 0.000f;
                }
            }

            if (GameManager.Instance.ThrowWater)
            {
                if (!CastRay)
                {
                    if (_delay > 0)
                    {
                        _delay -= Time.deltaTime;
                    }
                    else
                    {
                        CastRay = true;

                    }
                }
            }
        }*/
       /* private void FixedUpdate()
        {
            if (GameManager.Instance.ThrowWater)//CnInputManager.GetButton("Fire")
            {
                m_Power = Mathf.Lerp(m_Power, GameManager.Instance.ThrowWater ? maxPower : minPower, Time.deltaTime * changeSpeed);

                if (GameManager.Instance.gunAnimator)
                {
                    if (!GameManager.Instance.gunAnimator.isActiveAndEnabled) GameManager.Instance.gunAnimator.enabled = true;
                }

                if (CastRay)
                {
                    if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward), out hit_0, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))//CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                    {
                        Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward) * MaxLength), Color.cyan, 1);

                        EnableHitEffect(HitEffect, hit_0, 0);

                        if (hit_0.collider.CompareTag("Cleanable"))
                        {
                            if (hit_0.collider.TryGetComponent(out MaskCamera maskCamera))
                            {
                                _maskScript_0 = maskCamera;
                                _maskScript_0.texturecord_0 = hit_0.textureCoord;
                            }

                            if (hit_0.collider.TryGetComponent(out CleaningProcess _cleaningProcess))
                            {
                                GameManager.Instance.CleanPercentage_Text.text = _cleaningProcess.fillpercent.ToString();    //  previous dev
                                GameManager.Instance.CleanPartName_Text.text = _cleaningProcess.PartName;    //  previous dev
                                GameManager.Instance.CleanPercentage_Bar.fillAmount = _cleaningProcess.fillpercent / 100f;    //  previous dev
                            }
                        }
                    }
                    else
                    {
                        DisableHitEffect(HitEffect, 0);


                        if (_maskScript_0) _maskScript_0.texturecord_0 = null;
                    }

                    if (isSpread_1)
                    {
                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X, RaySpread_Limit_Y, 0)), out hit_1, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_1.distance < RayDistance_MaxLimit ? hit_1.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X, RaySpread_Limit_Y, 0)) * MaxLength), Color.cyan, 1);/// (hit_1.distance < RayDistance_MaxLimit ? hit_1.distance : RayDistance_MaxLimit)

                            EnableHitEffect(HitEffect, hit_1, 1);

                            if (hit_1.collider.CompareTag("Cleanable"))
                            {
                                if (hit_1.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_1 = maskCamera;
                                    _maskScript_1.texturecord_1 = hit_1.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 1);

                            if (_maskScript_1) _maskScript_1.texturecord_1 = null;
                        }

                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X, RaySpread_Limit_Y, 0)), out hit_2, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_2.distance < RayDistance_MaxLimit ? hit_2.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X, RaySpread_Limit_Y, 0)) * MaxLength), Color.cyan, 1);/// (hit_2.distance < RayDistance_MaxLimit ? hit_2.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_2, 2);

                            if (hit_2.collider.CompareTag("Cleanable"))
                            {
                                if (hit_2.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_2 = maskCamera;
                                    _maskScript_2.texturecord_2 = hit_2.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 2);
                            if (_maskScript_2) _maskScript_2.texturecord_2 = null;
                        }
                    }

                    if (isSpread_2)
                    {
                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 2, RaySpread_Limit_Y * 2, 0)), out hit_3, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_3.distance < RayDistance_MaxLimit ? hit_3.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 2, RaySpread_Limit_Y * 2, 0)) * MaxLength), Color.cyan, 1);/// (hit_3.distance < RayDistance_MaxLimit ? hit_3.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_3, 3);

                            if (hit_3.collider.CompareTag("Cleanable"))
                            {
                                if (hit_3.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_3 = maskCamera;
                                    _maskScript_3.texturecord_3 = hit_3.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 3);
                            if (_maskScript_3) _maskScript_3.texturecord_3 = null;
                        }

                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 2, RaySpread_Limit_Y * 2, 0)), out hit_4, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_4.distance < RayDistance_MaxLimit ? hit_4.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 2, RaySpread_Limit_Y * 2, 0)) * MaxLength), Color.cyan, 1);/// (hit_4.distance < RayDistance_MaxLimit ? hit_4.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_4, 4);

                            if (hit_4.collider.CompareTag("Cleanable"))
                            {
                                if (hit_4.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_4 = maskCamera;
                                    _maskScript_4.texturecord_4 = hit_4.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 4);
                            if (_maskScript_4) _maskScript_4.texturecord_4 = null;
                        }
                    }

                    if (isSpread_3)
                    {
                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 3, RaySpread_Limit_Y * 3, 0)), out hit_5, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_5.distance < RayDistance_MaxLimit ? hit_5.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 3, RaySpread_Limit_Y * 3, 0)) * MaxLength), Color.cyan, 1);/// (hit_5.distance < RayDistance_MaxLimit ? hit_5.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_5, 5);

                            if (hit_5.collider.CompareTag("Cleanable"))
                            {
                                if (hit_5.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_5 = maskCamera;
                                    _maskScript_5.texturecord_5 = hit_5.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 5);
                            if (_maskScript_5) _maskScript_5.texturecord_5 = null;
                        }

                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 3, RaySpread_Limit_Y * 3, 0)), out hit_6, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_6.distance < RayDistance_MaxLimit ? hit_6.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 3, RaySpread_Limit_Y * 3, 0)) * MaxLength), Color.cyan, 1);/// (hit_6.distance < RayDistance_MaxLimit ? hit_6.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_6, 6);

                            if (hit_6.collider.CompareTag("Cleanable"))
                            {
                                if (hit_6.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_6 = maskCamera;
                                    _maskScript_6.texturecord_6 = hit_6.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 6);
                            if (_maskScript_6) _maskScript_6.texturecord_6 = null;
                        }
                    }

                    if (isSpread_4)
                    {
                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 4, RaySpread_Limit_Y * 4, 0)), out hit_7, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_7.distance < RayDistance_MaxLimit ? hit_7.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 4, RaySpread_Limit_Y * 4, 0)) * MaxLength), Color.cyan, 1);/// (hit_7.distance < RayDistance_MaxLimit ? hit_7.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_7, 7);

                            if (hit_7.collider.CompareTag("Cleanable"))
                            {
                                if (hit_7.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_7 = maskCamera;
                                    _maskScript_7.texturecord_7 = hit_7.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 7);
                            if (_maskScript_7) _maskScript_7.texturecord_7 = null;
                        }

                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 4, RaySpread_Limit_Y * 4, 0)), out hit_8, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_8.distance < RayDistance_MaxLimit ? hit_8.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 4, RaySpread_Limit_Y * 4, 0)) * MaxLength), Color.cyan, 1);/// (hit_8.distance < RayDistance_MaxLimit ? hit_8.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_8, 8);

                            if (hit_8.collider.CompareTag("Cleanable"))
                            {
                                if (hit_8.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_8 = maskCamera;
                                    _maskScript_8.texturecord_8 = hit_8.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 8);
                            if (_maskScript_8) _maskScript_8.texturecord_8 = null;
                        }
                    }

                    if (isSpread_5)
                    {
                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 5, RaySpread_Limit_Y * 5, 0)), out hit_9, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_9.distance < RayDistance_MaxLimit ? hit_9.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 5, RaySpread_Limit_Y * 5, 0)) * MaxLength), Color.cyan, 1);/// (hit_9.distance < RayDistance_MaxLimit ? hit_9.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_9, 9);

                            if (hit_9.collider.CompareTag("Cleanable"))
                            {
                                if (hit_9.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_9 = maskCamera;
                                    _maskScript_9.texturecord_9 = hit_9.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 9);
                            if (_maskScript_9) _maskScript_9.texturecord_9 = null;
                        }

                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 5, RaySpread_Limit_Y * 5, 0)), out hit_10, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_10.distance < RayDistance_MaxLimit ? hit_10.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 5, RaySpread_Limit_Y * 5, 0)) * MaxLength), Color.cyan, 1);/// (hit_10.distance < RayDistance_MaxLimit ? hit_10.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_10, 10);

                            if (hit_10.collider.CompareTag("Cleanable"))
                            {
                                if (hit_10.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_10 = maskCamera;
                                    _maskScript_10.texturecord_10 = hit_10.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 10);
                            if (_maskScript_10) _maskScript_10.texturecord_10 = null;
                        }

                    }

                    if (isSpread_6)
                    {
                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 6, RaySpread_Limit_Y * 6, 0)), out hit_11, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_11.distance < RayDistance_MaxLimit ? hit_11.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 6, RaySpread_Limit_Y * 6, 0)) * MaxLength), Color.cyan, 1);/// (hit_11.distance < RayDistance_MaxLimit ? hit_11.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_11, 11);

                            if (hit_11.collider.CompareTag("Cleanable"))
                            {
                                if (hit_11.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_11 = maskCamera;
                                    _maskScript_11.texturecord_11 = hit_11.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 11);
                            if (_maskScript_11) _maskScript_11.texturecord_11 = null;
                        }

                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 6, RaySpread_Limit_Y * 6, 0)), out hit_12, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_12.distance < RayDistance_MaxLimit ? hit_12.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 6, RaySpread_Limit_Y * 6, 0)) * MaxLength), Color.cyan, 1);/// (hit_12.distance < RayDistance_MaxLimit ? hit_12.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_12, 12);

                            if (hit_12.collider.CompareTag("Cleanable"))
                            {
                                if (hit_12.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_12 = maskCamera;
                                    _maskScript_12.texturecord_12 = hit_12.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 12);
                            if (_maskScript_12) _maskScript_12.texturecord_12 = null;
                        }

                    }

                    if (isSpread_7)
                    {
                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 7, RaySpread_Limit_Y * 7, 0)), out hit_13, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_7.distance < RayDistance_MaxLimit ? hit_7.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 7, RaySpread_Limit_Y * 7, 0)) * MaxLength), Color.cyan, 1);/// (hit_7.distance < RayDistance_MaxLimit ? hit_7.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_13, 13);

                            if (hit_13.collider.CompareTag("Cleanable"))
                            {
                                if (hit_13.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_13 = maskCamera;
                                    _maskScript_13.texturecord_13 = hit_13.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 13);
                            if (_maskScript_13) _maskScript_13.texturecord_13 = null;
                        }

                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 7, RaySpread_Limit_Y * 7, 0)), out hit_14, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_8.distance < RayDistance_MaxLimit ? hit_8.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 7, RaySpread_Limit_Y * 7, 0)) * MaxLength), Color.cyan, 1);/// (hit_8.distance < RayDistance_MaxLimit ? hit_8.distance : RayDistance_MaxLimit)
                            if (HitEffect[14])
                                EnableHitEffect(HitEffect, hit_14, 14);

                            if (hit_14.collider.CompareTag("Cleanable"))
                            {
                                if (hit_14.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_14 = maskCamera;
                                    _maskScript_14.texturecord_14 = hit_14.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 14);
                            if (_maskScript_14) _maskScript_14.texturecord_14 = null;
                        }
                    }

                    if (isSpread_8)
                    {
                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 8, RaySpread_Limit_Y * 8, 0)), out hit_15, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_9.distance < RayDistance_MaxLimit ? hit_9.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 8, RaySpread_Limit_Y * 8, 0)) * MaxLength), Color.cyan, 1);/// (hit_9.distance < RayDistance_MaxLimit ? hit_9.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_15, 15);

                            if (hit_15.collider.CompareTag("Cleanable"))
                            {
                                if (hit_15.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_15 = maskCamera;
                                    _maskScript_15.texturecord_15 = hit_15.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 15);
                            if (_maskScript_15) _maskScript_15.texturecord_15 = null;
                        }

                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 8, RaySpread_Limit_Y * 8, 0)), out hit_16, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_10.distance < RayDistance_MaxLimit ? hit_10.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 8, RaySpread_Limit_Y * 8, 0)) * MaxLength), Color.cyan, 1);/// (hit_10.distance < RayDistance_MaxLimit ? hit_10.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_16, 16);

                            if (hit_16.collider.CompareTag("Cleanable"))
                            {
                                if (hit_16.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_16 = maskCamera;
                                    _maskScript_16.texturecord_16 = hit_16.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 16);
                            if (_maskScript_16) _maskScript_16.texturecord_16 = null;
                        }

                    }

                    if (isSpread_9)
                    {
                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 9, RaySpread_Limit_Y * 9, 0)), out hit_17, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_11.distance < RayDistance_MaxLimit ? hit_11.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward + new Vector3(RaySpread_Limit_X * 9, RaySpread_Limit_Y * 9, 0)) * MaxLength), Color.cyan, 1);/// (hit_11.distance < RayDistance_MaxLimit ? hit_11.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_17, 17);

                            if (hit_17.collider.CompareTag("Cleanable"))
                            {
                                if (hit_17.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_17 = maskCamera;
                                    _maskScript_17.texturecord_17 = hit_17.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 17);
                            if (_maskScript_17) _maskScript_17.texturecord_17 = null;
                        }

                        if (Physics.Raycast(PlayerReferanceManager.Instance.mCamera.transform.position, PlayerReferanceManager.Instance.mCamera.transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 9, RaySpread_Limit_Y * 9, 0)), out hit_18, MaxLength, TargetLayer, QueryTriggerInteraction.UseGlobal))/// (hit_12.distance < RayDistance_MaxLimit ? hit_12.distance : RayDistance_MaxLimit)CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit_0.collider != null)
                        {
                            Debug.DrawRay(transform.position, (transform.TransformDirection(Vector3.forward - new Vector3(RaySpread_Limit_X * 9, RaySpread_Limit_Y * 9, 0)) * MaxLength), Color.cyan, 1);/// (hit_12.distance < RayDistance_MaxLimit ? hit_12.distance : RayDistance_MaxLimit)
                            EnableHitEffect(HitEffect, hit_18, 18);

                            if (hit_18.collider.CompareTag("Cleanable"))
                            {
                                if (hit_18.collider.TryGetComponent(out MaskCamera maskCamera))
                                {
                                    _maskScript_18 = maskCamera;
                                    _maskScript_18.texturecord_18 = hit_18.textureCoord;
                                }
                            }
                        }
                        else
                        {
                            DisableHitEffect(HitEffect, 18);
                            if (_maskScript_18) _maskScript_18.texturecord_18 = null;
                        }

                    }
                }
            }
            else
            {
                if (CastRay)
                {
                    CastRay = false;
                    _delay = Max_delay;
                }

                if (GameManager.Instance.gunAnimator) if (GameManager.Instance.gunAnimator.isActiveAndEnabled) GameManager.Instance.gunAnimator.enabled = false;

                GameManager.Instance.DisableObject(HitEffect);

                m_Power = Mathf.Lerp(m_Power, GameManager.Instance.ThrowWater ? maxPower : minPower, Time.deltaTime * changeSpeed);
            }

            foreach (var system in hoseWaterSystems)
            {
                ParticleSystem.MainModule mainModule = system.main;
                mainModule.startSpeed = m_Power;
                var emission = system.emission;
                emission.enabled = (m_Power > minPower * 1.1f);
            }
        }*/

       /* void EnableHitEffect(GameObject[] _HitEffect, RaycastHit raycastHit, int index)
        {
            if (_HitEffect[index] != null)
            {
                _HitEffect[index].SetActive(true);
                _HitEffect[index].transform.position = raycastHit.point - EffectOffset + raycastHit.normal * hitOffset;
                _HitEffect[index].transform.rotation = Quaternion.identity;
            }
        }

        void DisableHitEffect(GameObject[] _HitEffect, int index)
        {
            if (_HitEffect[index] != null)
            {
                _HitEffect[index].SetActive(false);
            }
        }*/


    }


}