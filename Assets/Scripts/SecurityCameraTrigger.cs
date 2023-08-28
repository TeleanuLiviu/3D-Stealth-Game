using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraTrigger : MonoBehaviour
{
    [SerializeField]
    public GameObject GameOverCutsecene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            Animator _anim = GetComponentInParent<Animator>();
            _anim.enabled = false;
            Color color = new Color(1f, 0.1f, 0f, 0.3f);
            renderer.material.SetColor("_TintColor", color);
            StartCoroutine(WaitforCutscene());
           
        }
    }

    private IEnumerator WaitforCutscene()
    {
        yield return new WaitForSeconds(1.0f);
        GameOverCutsecene.SetActive(true);
    }
}
