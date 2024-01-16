using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData
{ 
    public static int lvl; // поле хранящее данные

    public static Dictionary<string, GameObject> prefs = new Dictionary<string, GameObject>();

    public static List<GameObject> objects = new List<GameObject>();
}
