using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard_AI : MonoBehaviour
{

    public List<Transform> WayPoints;
    public int _target;
    public NavMeshAgent _agent;
    public bool _reverse;
    public bool _pauseMovement;
    private Animator _anim;
    public bool coinDropped;
    public Vector3 coinPos;
    public bool Closer;
    void Start()
    {
       
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        
    }

    
    void Update()
    {
        if(WayPoints.Count>0 && WayPoints[_target]!=null && !_pauseMovement && !coinDropped)
        {
            _anim.SetBool("Walk", true);
            _agent.SetDestination(WayPoints[_target].position);

            float distance = Vector3.Distance(transform.position, WayPoints[_target].position);

            if (distance < 1.0f )
            {
               
                if(_target == 0 || _target == WayPoints.Count-1)
                {
                    _pauseMovement = true;
                    StartCoroutine("WaitforMoving");
                }

                else
                {
                    if(_reverse)
                    {
                        _target--;
                        if(_target<=0)
                        {
                            _reverse = false;
                            _target = 0;
                        }
                    }
                    else
                    {
                        _target++;
                    }
                }

               
               
                
            }

           
        }

        else if(coinDropped)
        {


            float distance = Vector3.Distance(transform.position, coinPos);

            if (distance<=10f)
            {
                Closer = true;
            }

            if(Closer)
            {
                _anim.SetBool("Walk", true);
                _agent.SetDestination(coinPos);
            }
            

            if (distance < 2.0f)
            {
                Closer = false;
                StartCoroutine(WaitforMoveCoin());
            }

        

        }
      

       
    }

    public void CoinToss()
    {
        float distance = Vector3.Distance(transform.position, coinPos);

        if(distance<=10f)
        {
            
            coinDropped = true;
            _agent.Resume();
            _agent.velocity = Vector3.one;
            _agent.stoppingDistance = 1.0f;
        }
      
    }


    public IEnumerator WaitforMoveCoin()
    {
        
        _anim.SetBool("Walk", false);
       
        yield return new WaitForSeconds(Random.Range(20.0f, 30.0f));
       
        coinDropped = false;
        
        _agent.stoppingDistance = 0;

    }

    public IEnumerator WaitforMoving()
    {
       
       
        if (_target == 0)
        {
            _anim.SetBool("Walk", false);
            _agent.Stop();
            _agent.velocity = Vector3.zero;
            yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
            if(_pauseMovement)
                _target++;
            _pauseMovement = false;
            _reverse = false;
            _agent.Resume();
            _agent.velocity = Vector3.one;


        }


        else if (_target == WayPoints.Count - 1)
        {
            
            _anim.SetBool("Walk", false);
            _agent.Stop();
            _agent.velocity = Vector3.zero;
            yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
            if (_pauseMovement)
                _target --;
            _pauseMovement = false;
            _reverse = true;
            _agent.Resume();
            _agent.velocity = Vector3.one;

        }

       
        
        
    }
}
