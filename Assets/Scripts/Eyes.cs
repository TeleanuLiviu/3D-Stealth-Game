using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField]
    public GameObject GameOverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            AudioManager.Instance.StopFootSteps();
            GameOverCutscene.SetActive(true);
           
        }
    }
}
