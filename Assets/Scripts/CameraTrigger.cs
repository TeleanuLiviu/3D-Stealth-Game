using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    public Transform _camersPosition;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Camera.main.transform.position = _camersPosition.position;
        }
    }


}
