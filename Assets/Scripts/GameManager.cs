using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
        
    }

    public bool HasCard
    {
        get;
        set;
    }

    public PlayableDirector IntroCutscene;


    public void Awake()
    {
        _instance = this;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            IntroCutscene.time = 60.0f; 
            

        }

        if(IntroCutscene.time>62.0f)
        {
            IntroCutscene.gameObject.SetActive(false);
        }
        
    }



}
