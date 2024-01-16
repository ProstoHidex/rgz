using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public void setStars(int n)
    {
        if (n == 0)
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }

        if (n == 1)
            star1.SetActive(true);

        if (n == 2)
            star2.SetActive(true);

        if (n == 3)
            star3.SetActive(true);
    }
}
