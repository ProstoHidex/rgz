using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class levelSelection : MonoBehaviour
{
    public Image[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        int curLVL = PlayerPrefs.GetInt("Scenes", 1);
        //Debug.Log(PlayerPrefs.GetInt("Scenes", 1));
        //Debug.Log(starse);

        for (int i = 0; i < buttons.Length; i++)
        {
            //PlayerPrefs.GetInt(i + "Scene", 0);
            if (buttons[i].GetComponent<ButtonScript>() != null)
            {
                buttons[i].GetComponent<ButtonScript>().setStars(PlayerPrefs.GetInt(i+"Scene", 0));
                Debug.Log(i + "Scene = " + PlayerPrefs.GetInt(i + "Scene", 0));

                //buttons[i].GetComponent<ButtonScript>().setStars(PlayerPrefs.GetInt(i + "Scene", 0));
            }


            if (i + 1 > curLVL)
            {
                buttons[i].GetComponent<Button>().interactable = false;
                
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
