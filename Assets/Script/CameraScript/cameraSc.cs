using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSc : MonoBehaviour
{
    [Range(0.1f, 10f)]
    public float sensitivy = 5f;
    [Range(0.1f, 2f)]
    public float smooth = 0.1f;

    public Vector2 MinMaxAngle = new Vector2(-90, 90);

    public GameObject player;

    [SerializeField]
    [Tooltip("ボーン")]
    private Transform head;
    //[SerializeField]
    //[Tooltip("足ボーン")]
    //private Transform hip;
    private float yRot;
    private float xRot;

    private float currentYRot;
    private float currentXRot;

    private float yRotVelocity;
    private float xRotvelocity;

    private void Update()
    {
        yRot += Input.GetAxis("Mouse X") * sensitivy;
        xRot -= Input.GetAxis("Mouse Y") * sensitivy;

        xRot = Mathf.Clamp(xRot, MinMaxAngle.x, MinMaxAngle.y);


        currentXRot = Mathf.SmoothDamp(currentXRot, xRot, ref xRotvelocity, smooth);
        currentYRot = Mathf.SmoothDamp(currentYRot, yRot, ref yRotVelocity, smooth);
        player.transform.rotation = Quaternion.Euler(currentXRot, currentYRot, 0);

    }
    private void LateUpdate()
    {
        head.rotation = Quaternion.Euler(head.eulerAngles.x + currentXRot, head.eulerAngles.y, head.eulerAngles.z);
        //hip.rotation = Quaternion.Euler(hip.eulerAngles.x, hip.eulerAngles.y + currentYRot, hip.eulerAngles.z);
    }
}

