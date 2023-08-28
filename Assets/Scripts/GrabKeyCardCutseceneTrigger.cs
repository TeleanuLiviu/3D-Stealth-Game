using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardCutseceneTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject GrabCutScene;
    [SerializeField]
    public GameObject CameraPos;
    private bool _scenePlayed;
    [SerializeField]
    private AudioSource Rain;

    private void Start()
    {
        _scenePlayed = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player" && !_scenePlayed)
        {
            AudioManager.Instance.StopFootSteps();
            Rain.Stop();
            GameManager.Instance.HasCard = true;
            _scenePlayed = true;
            GrabCutScene.SetActive(true);
            other.transform.position = new Vector3(-2.63f, -0.24f, -109.11f);
            other.transform.rotation = Quaternion.Euler(0f, 96.93f, 0f);
            StartCoroutine(WaitforCutsecene());
        }
    }

    private IEnumerator WaitforCutsecene()
    {
        yield return new WaitForSeconds(7.0f);
        GrabCutScene.SetActive(false);
        Camera.main.transform.position = CameraPos.transform.position;
        Camera.main.transform.rotation = CameraPos.transform.rotation;
        Rain.Play();
    }
}
