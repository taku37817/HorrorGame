using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace F
{
    public class RaycastBass : MonoBehaviour
    {
        public float dis = 3f;

        public float rayDis;

        public float distanse = 0.5f;
        public float maxDistabnse = 100f;

        private int num = 0;

        [Tooltip("Eボタン案内画像取得")]
        public Image eButton;
        [Tooltip("Eボタンオブジェクト取得")]
        public GameObject eBottunImageObj;

        [Tooltip("カメラを取得する変数")]
        public GameObject camera;

        //カメラについている、カメラ制御スクリプト取得変数
        private cameraSc camScript;

        [Tooltip("プレイヤーのオブジェクト取得")]
        public GameObject playerObj;
        //プレイヤーオブジェクトに付いてる、moveスクリプト取得
        private Move stopMove;
        //プレイヤーオジェクトに付いている、Anima スクリプト取得
        private Anima anima;

        [Tooltip("アイテムと自分との距離")]
        public float Item_MyObj_Distnce = 1f;

        //アイテムを見てる時のスクリプト取得
        private Look lookobj;

        [Tooltip("アイテム見てる見てないかの判定")]
        public bool hold = false;

        //アイテムのゲームオブジェクトを取得する変数。
        private GameObject item_object;

        //翻訳テキストの表示、非表示の変数
        private textActiv active;

        //ドアアニメーション再生のスクリプト取得変数
        private doorjudgment door_juge;

        [Tooltip("メッセージオブジェクトの名前")]
        private string message_ObjName;

        [Tooltip("メッセージオブジェクト取得")]
        private GameObject[] message_Obj;

        [Tooltip("voice_audioスクリプト取得")]
        private voice_audio_instance voice_Audio_Instance;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            eButton = eBottunImageObj.GetComponent<Image>();

            camScript = camera.GetComponent<cameraSc>();

            stopMove = playerObj.GetComponent<Move>();

            anima = playerObj.GetComponent<Anima>();

            message_Obj = GameObject.FindGameObjectsWithTag("message");
        }
        public void cursorview()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                num += 1;
            }
            if (num == 1)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            if (num == 2)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                num = 0;
            }
        }
        // Update is called once per frame
        void Update()
        {
            eButton.enabled = false;
            cursorview();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistabnse, Color.red);
            Vector3 pos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit = new RaycastHit();
            if (hold == false)
            {
                stopMove.moveUse();
                anima.enabled = true;
            }
            if (Physics.Raycast(ray, out hit, distanse))
            {
                rayDis = hit.distance;
                if (hit.collider == null)
                {
                    return;
                }
                if (hit.collider.tag == "Door" && rayDis < dis)
                {
                    eButton.enabled = true;
                    item_object = hit.collider.gameObject;
                    door_juge = item_object.GetComponent<doorjudgment>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        door_juge.jugement();
                    }
                }

                if (hold)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        lookobj.lookkaijo();
                        hold = false;
                        camScript.enabled = true;
                        anima.enabled = true;

                        active.falseActive();
                        if (voice_Audio_Instance == null)
                        {
                            return;
                        }
                        voice_Audio_Instance.audio_instance();
                    }

                }

                else if (hold == false)
                {
                    if (hit.collider.tag == "Battery" || hit.collider.tag == "message")
                    {
                        item_object = hit.collider.gameObject;

                        message_ObjName = hit.collider.name;
                        active = item_object.GetComponent<textActiv>();
                        lookobj = item_object.GetComponent<Look>();
                        voice_Audio_Instance = item_object.GetComponent<voice_audio_instance>();
                        eButton.enabled = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            //位置回転一致関数呼び出し
                            lookobj.Position_Rotation_much();

                            hold = true;
                            camScript.enabled = false;
                            anima.enabled = false;
                            eButton.enabled = false;
                            if (hit.collider.tag == "message")
                            {
                                active.trueActiv();
                            }
                        }
                    }
                }
                Debug.Log(hold);
            }
        }
    }
}