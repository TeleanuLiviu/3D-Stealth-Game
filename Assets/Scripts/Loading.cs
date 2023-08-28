using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    [SerializeField]
    public Image LoadingBar;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

        while(!operation.isDone)
        {
            LoadingBar.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
        }
    }


}
