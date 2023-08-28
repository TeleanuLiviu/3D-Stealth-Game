using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour
{
    private Transform playerTransform;
    public Transform startCamera;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = startCamera.position;
        transform.rotation = startCamera.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform);
    }
}
