using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_instace : MonoBehaviour
{
    [Tooltip("�C���X�^���X���������I�u�W�F�N�g���i�[")]
    public GameObject obj;

    [Tooltip("�I�u�W�F�N�g�����悤�̊i�[�ϐ�")]
    private GameObject destroyObj;

    [Tooltip("�o�����������ꏊ�̃I�u�W�F�N�g�i�[")]
    public GameObject Instance_place;

    private bool trigger_juge = true;

    private float time;

    // Update is called once per frame
    void Update()
    {
        if (destroyObj)
        {
            time += 1 * Time.deltaTime;
            if (time >= 10)
            {
                Destroy(destroyObj);
            }
        }
        else if(destroyObj == null)
        {
            return;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "event")
        {
            time += 1;
            if (trigger_juge)
            {
               destroyObj = Instantiate(obj, Instance_place.transform.position, Quaternion.Inverse(transform.rotation)) as GameObject;
                trigger_juge = false;
            }
        }
       
    }
}
