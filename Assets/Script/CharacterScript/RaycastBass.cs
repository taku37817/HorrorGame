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

        [Tooltip("E�{�^���ē��摜�擾")]
        public Image eButton;
        [Tooltip("E�{�^���I�u�W�F�N�g�擾")]
        public GameObject eBottunImageObj;

        [Tooltip("�J�������擾����ϐ�")]
        public GameObject camera;

        //�J�����ɂ��Ă���A�J��������X�N���v�g�擾�ϐ�
        private cameraSc camScript;

        [Tooltip("�v���C���[�̃I�u�W�F�N�g�擾")]
        public GameObject playerObj;
        //�v���C���[�I�u�W�F�N�g�ɕt���Ă�Amove�X�N���v�g�擾
        private Move stopMove;
        //�v���C���[�I�W�F�N�g�ɕt���Ă���AAnima �X�N���v�g�擾
        private Anima anima;

        [Tooltip("�A�C�e���Ǝ����Ƃ̋���")]
        public float Item_MyObj_Distnce = 1f;

        //�A�C�e�������Ă鎞�̃X�N���v�g�擾
        private Look lookobj;

        [Tooltip("�A�C�e�����Ă錩�ĂȂ����̔���")]
        public bool hold = false;

        //�A�C�e���̃Q�[���I�u�W�F�N�g���擾����ϐ��B
        private GameObject item_object;

        //�|��e�L�X�g�̕\���A��\���̕ϐ�
        private textActiv active;

        //�h�A�A�j���[�V�����Đ��̃X�N���v�g�擾�ϐ�
        private doorjudgment door_juge;

        [Tooltip("���b�Z�[�W�I�u�W�F�N�g�̖��O")]
        private string message_ObjName;

        [Tooltip("���b�Z�[�W�I�u�W�F�N�g�擾")]
        private GameObject[] message_Obj;

        [Tooltip("voice_audio�X�N���v�g�擾")]
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
                            //�ʒu��]��v�֐��Ăяo��
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