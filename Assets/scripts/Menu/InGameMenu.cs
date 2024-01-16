using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ShowMenu(GameObject menu)
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    public void Resume(GameObject menu)
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu(int nextLVL)
    {
        GlobalData.lvl = nextLVL;
        SceneManager.LoadScene("Load");
        Time.timeScale = 1f;
        //StartCoroutine(LoadLevelAsinc());
    }
    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void False()
    {
        SceneManager.LoadScene("Load");
        Time.timeScale = 1f;
    }
}
