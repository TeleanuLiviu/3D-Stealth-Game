using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    
    public AudioSource VOCoin;
    private bool _voPlayed;
    private void Start()
    {
        _voPlayed = false;
           VOCoin = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player" && !_voPlayed)
        {
            _voPlayed = true;
            AudioManager.Instance.PlayVoiceOver(VOCoin.clip);
            

        }
    }
}
