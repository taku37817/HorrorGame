using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_audio_Destory : MonoBehaviour
{
    private AudioSource audiosource;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.Play();

        StartCoroutine(Checking(() => {
            Destroy(gameObject); 
        }));
    }

    public delegate void functionType();
    private IEnumerator Checking(functionType callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!audiosource.isPlaying)
            {
                callback();
                break;
            }
        }
    }
}
