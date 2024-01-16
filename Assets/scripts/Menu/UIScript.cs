using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIScript : MonoBehaviour
{
    public GameObject levelSelection;
    public GameObject menuPanel;
    // Start is called before the first frame update
    public void menuStart(Button Start)
    {
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);

        if (levelSelection.activeSelf == true)
            levelSelection.SetActive(false);
        else
            levelSelection.SetActive(true);
    }

    public void levelSelectionHide()
    {
        levelSelection.SetActive(false);
    }

    // Update is called once per frame
    public void menuExit()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        menuPanel.SetActive(false);
    }
    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void lvlSelect(int nextLVL)
    {
        GlobalData.lvl = nextLVL;
        SceneManager.LoadScene("Level");
        Time.timeScale = 1f;

    }

}
