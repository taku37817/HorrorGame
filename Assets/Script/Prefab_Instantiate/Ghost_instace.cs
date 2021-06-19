using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_instace : MonoBehaviour
{
    [Tooltip("インスタンスさせたいオブジェクトを格納")]
    public GameObject obj;

    [Tooltip("オブジェクト消すようの格納変数")]
    private GameObject destroyObj;

    [Tooltip("出現させたい場所のオブジェクト格納")]
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
