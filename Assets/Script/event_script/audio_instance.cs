using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_instance : MonoBehaviour
{
    /// <summary> �C���X�^���X�����������I�u�W�F�N�g </summary>
    public GameObject audio_Obj;
    /// <summary> ���������R���C�_�[�̃^�O�� </summary>
    public string tagName;

   /// <summary> �e�I�u�W�F�N�g </summary>
    private GameObject[] oya_obj;

    /// <summary> �C���X�^���X�����������ꏊ �q�̃I�u�W�F�N�g </summary>
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
