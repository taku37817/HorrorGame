using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class doorjudgment : MonoBehaviour
{
    private Animator door;

    private AudioSource audioSource;

    public AudioClip[] audioClip;
    public int jugenum;
    private bool close_door2_judge;

    private bool audio_bool;
    public AnimatorStateInfo Anim_State_info;
    private void Start()
    {
        door = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        close_door2_judge = true;
        audio_bool = true;
    }
    public void jugement()
    {
        jugenum += 1;
        if (jugenum == 1)
        {
            door.SetBool("Open", true);
            door.SetBool("Close", false);
            audioSource.PlayOneShot(audioClip[0]);
            close_door2_judge = false;
        }
        if (jugenum == 2)
        {
            door.SetBool("Open", false);
            door.SetBool("Close", true);
            audioSource.PlayOneShot(audioClip[1]);
            close_door2_judge = true;

            jugenum = 0;
        }
    }
    private void Update()
    {
        StartCoroutine(close_judge());
        Debug.Log(close_door2_judge);
    }
    IEnumerator close_judge()
    {
        Anim_State_info = door.GetCurrentAnimatorStateInfo(0);
        if (Anim_State_info.IsTag("Close_tag") && Anim_State_info.normalizedTime > 1.0f)
        {
            if (close_door2_judge)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = audioClip[2];
                    audioSource.Play();
                    Debug.Log("‚µ‚Ü‚Á‚½");
                    close_door2_judge = false;
                }
            }
        }
        yield return null;
    }
}
