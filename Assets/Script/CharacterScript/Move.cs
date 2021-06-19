using UnityEngine;

namespace F
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Run,
        Jump
    }
    [RequireComponent(typeof(CharacterController), typeof(Rigidbody))]

    public class Move : MonoBehaviour
    {
        [Range(0.1f, 15f)]
        public float speed = 3.0f;
        [Range(0.1f, 20f)]
        public float runSpeed = 5.0f;

        [Range(0.1f, 10f)]
        [Tooltip("重力")]
        public float gravity = 9.8f;
        [Range(0.1f, 15f)]
        [Tooltip("ジャンプ力")]
        public float jumpPower = 10f;

        private CharacterController characterController;

        private GameObject Camera;
        private Vector3 moveDir = Vector3.zero;

        [Tooltip("Use スクリプトがついている、オブジェクト取得")]
        public GameObject PlayerObj;
        Use Use_script_Hold_hensu;
        private void Start()
        {
            Camera = GameObject.Find("Camera");
            characterController = GetComponent<CharacterController>();
            Use_script_Hold_hensu = PlayerObj.GetComponent<Use>();
        }
        private void Update()
        {
            bool use_Hold_judge = Use_script_Hold_hensu.hold;
            charaMove();
            if (use_Hold_judge == false)
            {
                characterController.enabled = true;
            }
            else if (use_Hold_judge)
            {
                characterController.enabled = false;
            }
        }

        public void charaMove()
        {
            float moveH = Input.GetAxis("Horizontal");
            float moveV = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveH, 0, moveV);

            if (movement.sqrMagnitude > 1)
            {
                movement.Normalize();
            }

            Vector3 desireMove = Camera.transform.forward * movement.z + Camera.transform.right * movement.x;
            moveDir.x = desireMove.x * 5f;
            moveDir.z = desireMove.z * 5f;
        }
        public void moveUse()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                characterController.Move(moveDir * Time.fixedDeltaTime * runSpeed);
            }
            else
            {
                characterController.Move(moveDir * Time.fixedDeltaTime * speed);
            }

            moveDir.y -= gravity * Time.deltaTime;

            if (characterController.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDir.y = jumpPower;
                }
            }
        }
    }

}