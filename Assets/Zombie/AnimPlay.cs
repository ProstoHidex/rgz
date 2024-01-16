using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlay : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim= GetComponent<Animator>();
        anim.SetBool("idle",true);
    }
}
