using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance { get { return _instance; } }

    public AudioSource voiceOver;
    public AudioSource FootSteps;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        voiceOver.clip = clipToPlay;
        voiceOver.PlayOneShot(voiceOver.clip);
    }

    public void PlayFootSteps(AudioClip clipToPlay)
    {
        FootSteps.clip = clipToPlay;
        StartCoroutine("WaitForFootSteps");

    }

    public void StopFootSteps()
    {
        StopCoroutine("WaitForFootSteps");
        FootSteps.Stop();

    }

    public IEnumerator WaitForFootSteps()
    {
        while(true)
        {
            FootSteps.PlayOneShot(FootSteps.clip);
            yield return new WaitForSeconds(0.7f);
        }
       
    }
}


   
