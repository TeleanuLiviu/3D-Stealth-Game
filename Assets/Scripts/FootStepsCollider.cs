using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (this.gameObject.tag == "NormalFloor")
            {
                other.GetComponent<Player>()._normalFootSteps = true;
                other.GetComponent<Player>()._marbleFootSteps = false;
                if(other.GetComponent<Player>()._isMoving)
                    AudioManager.Instance.PlayFootSteps(other.GetComponent<Player>().NormalFootStepsClip);
            }
            else
            if (this.gameObject.tag == "MarbleFloor")
            {
                other.GetComponent<Player>()._normalFootSteps = false;
                other.GetComponent<Player>()._marbleFootSteps = true;
                if (other.GetComponent<Player>()._isMoving)
                    AudioManager.Instance.PlayFootSteps(other.GetComponent<Player>().MarbleFootstepsClip);
            }
        }
       
    }
}
