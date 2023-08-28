using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private NavMeshAgent _navMeshAgent;
    private Animator _anim;
    private Vector3 _target;
    [SerializeField]
    private GameObject _coin;
    [SerializeField]
    public AudioClip _coinEffect;
    private bool _coinDropped;
    RaycastHit hit;
    public AudioClip NormalFootStepsClip, MarbleFootstepsClip;
    public bool _normalFootSteps, _marbleFootSteps;
    public bool _isMoving;
    void Start()
    {
        _isMoving = false;
           _navMeshAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isMoving = true;
            AudioManager.Instance.StopFootSteps();
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin,out hitInfo))
            {
                _navMeshAgent.SetDestination(hitInfo.point);
                _anim.SetBool("Walk", true);
                _target = hitInfo.point;


                if (_normalFootSteps)
                {
                    AudioManager.Instance.PlayFootSteps(NormalFootStepsClip);
                }

                if (_marbleFootSteps)
                {
                    AudioManager.Instance.PlayFootSteps(MarbleFootstepsClip);
                }

            }

        }


        if (Input.GetMouseButtonDown(1))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
           
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 5, QueryTriggerInteraction.Ignore))
            {
               
                if (Vector3.Distance(hit.point, transform.position) <= 20)
                {
                    if (hit.transform.tag == "Floor" && !_coinDropped)
                    {
                        _anim.SetTrigger("Throw");
                        _coinDropped = true;
                        StartCoroutine(WaitCoin());

                    }
                }
                else
                {
                  Debug.Log("Can't throw");
                }
            }
 
        }


        float distance = Vector3.Distance(transform.position, _target);

        if (distance < 1.0f)
        {
            _isMoving = false;
            AudioManager.Instance.StopFootSteps();
              _anim.SetBool("Walk", false);
        }
    }

    private IEnumerator WaitCoin()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(_coin, hit.point, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_coinEffect, hit.point, 1);
        SendGuardToCoin(hit.point);
        yield return new WaitForSeconds(10.0f);
        _coinDropped = false;
    }

    private void SendGuardToCoin(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");

        foreach( var guard in guards)
        {
            
            Guard_AI _ai = guard.GetComponent<Guard_AI>();
            _ai.coinPos = coinPos;
            _ai.CoinToss();


        }
    }
}
