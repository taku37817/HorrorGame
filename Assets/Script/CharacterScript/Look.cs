using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
   // public GameObject Prayer;
    private Vector3 itemPoos;
    [Tooltip("��]�̊p�x�ݒ�")]
    public float _x;
    public float _y;
    public float _z;

    public Transform _target; 
    //private Quaternion itemRot;

    public float d = 1f;

    //[Tooltip("Quaternion.Euler�� X ��")]
    //public int Quaternion_X;
    //[Tooltip("Quaternion.Euler�� Y ��")]
    //public int Quaternion_Y;
    //[Tooltip("Quaternion.Euler�� Z ��")]
    //public int Quaternion_Z;
    private void Start()
    {
        itemPoos = transform.position;
        
    }
    public void lookkaijo()
    {
        Transform transf = this.transform;
        Vector3 angle = transf.eulerAngles;
        angle.x = _x;
        angle.y = _y;
        angle.z = _z;
        transform.position = itemPoos;
        //Item.transform.rotation = itemRot;
        transf.eulerAngles = angle;
    }

    /// <summary>
    /// Transform�̈ʒu�Ɖ�]�����킹��
    /// <param name="target">���Transform</param>
    /// <param name="move">target�ƈ�v������Transform</param>
    /// <param name="moveParent">���ۂɈړ��Ɖ�]������move�ƂȂ�Transform</param> 
    /// </summary>
    public void Position_Rotation_much()
    {
        //��]����
        //move��rotation���Atarget��rotation�Ɠ����ɂȂ�悤�ɂ��邽�߁AQuaternion���g�p����B
        var requireRot = _target.rotation * Quaternion.Inverse(transform.rotation);

        this.transform.rotation = requireRot * transform.rotation;
        
        //�ړ�����
        //�e�����ɉ�]����ƁA���̈ʒu�͂���邽�߁A�J�X��Ɉʒu�̍����̌v�Z�B
        var requiePos = _target.position - transform.position;

        this.transform.position += requiePos;


        //itemRot = Quaternion.Euler(Quaternion_X, Quaternion_Y, Quaternion_Z);

        //itemPoos = Prayer.transform.position;
        //itemRot = Item.transform.rotation;
        
        //var direction = Prayer.transform.position - transform.position * d;
        //direction.y = 0;

        //var lookRotation = Quaternion.LookRotation(direction,Z);
        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 5f);
    }
}
