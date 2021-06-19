using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voice_audio_instance : MonoBehaviour
{
    [Tooltip("���������ăI�[�f�B�I�I�u�W�F�N�g�擾")]
    [SerializeField] private GameObject _female_Help_Obj;

    [Tooltip("�q�I�u�W�F�N�g�擾")]
    [SerializeField] private GameObject child_Obj;

    public virtual void audio_instance()
    {
        Debug.Log(child_Obj);
        Transform child = GetComponentInChildren<Transform>();
        if (child_Obj == null || _female_Help_Obj == null)
        {
            return;
        }
        if (child_Obj)
        {
            Instantiate(_female_Help_Obj, child_Obj.transform.position, Quaternion.Inverse(transform.rotation));
            if (_female_Help_Obj)
            {
                Destroy(child_Obj); 
            }
        }
       
    }
}