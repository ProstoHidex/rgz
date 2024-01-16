using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILod : MonoBehaviour
{
    public Slider progressBar;
    public GameObject text;

    //int lvl = GlobalData.SharedInstance.lvl;


    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevelAsinc());

    }

    private IEnumerator LoadLevelAsinc()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(GlobalData.lvl);
        Debug.Log(GlobalData.lvl);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            progressBar.value = asyncLoad.progress;

            if (asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
            {
                text.SetActive(true);
                progressBar.value = 1.0f;

                if (Input.anyKeyDown)
                    asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
