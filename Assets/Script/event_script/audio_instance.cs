using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_instance : MonoBehaviour
{
    /// <summary> インスタンス化させたいオブジェクト </summary>
    public GameObject audio_Obj;
    /// <summary> 当たったコライダーのタグ名 </summary>
    public string tagName;

   /// <summary> 親オブジェクト </summary>
    private GameObject[] oya_obj;

    /// <summary> インスタンス化させたい場所 子のオブジェクト </summary>
    private GameObject instance_pos;

    public virtual  void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagName)
        {
            oya_obj = GameObject.FindGameObjectsWithTag(tagName);
            foreach (GameObject oya in oya_obj)
            {
                if (other.gameObject == oya)
                {
                    instance_pos = oya.transform.GetChild(0).gameObject;
                    
                        Instantiate(audio_Obj, instance_pos.transform.position, Quaternion.Inverse(transform.rotation));
                        Debug.Log(instance_pos);
                    Destroy(oya);
                }
            }
        }
    }
}
