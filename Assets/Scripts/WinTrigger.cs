using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject WinCutsecene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && GameManager.Instance.HasCard)
        {
            WinCutsecene.SetActive(true);
            AudioManager.Instance.StopFootSteps();
        }

        else if (other.tag == "Player" && !GameManager.Instance.HasCard)
        {
            Debug.Log("Please provide key");
        }
    }
}
