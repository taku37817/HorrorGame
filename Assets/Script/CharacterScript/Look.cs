using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
   // public GameObject Prayer;
    private Vector3 itemPoos;
    [Tooltip("回転の角度設定")]
    public float _x;
    public float _y;
    public float _z;

    public Transform _target; 
    //private Quaternion itemRot;

    public float d = 1f;

    //[Tooltip("Quaternion.Eulerの X 軸")]
    //public int Quaternion_X;
    //[Tooltip("Quaternion.Eulerの Y 軸")]
    //public int Quaternion_Y;
    //[Tooltip("Quaternion.Eulerの Z 軸")]
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
    /// Transformの位置と回転を合わせる
    /// <param name="target">基準のTransform</param>
    /// <param name="move">targetと一致させるTransform</param>
    /// <param name="moveParent">実際に移動と回転させるmoveとなるTransform</param> 
    /// </summary>
    public void Position_Rotation_much()
    {
        //回転処理
        //moveのrotationが、targetのrotationと同じになるようにするため、Quaternionを使用する。
        var requireRot = _target.rotation * Quaternion.Inverse(transform.rotation);

        this.transform.rotation = requireRot * transform.rotation;
        
        //移動処理
        //親を軸に回転すると、この位置はずれるため、開店後に位置の差分の計算。
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
