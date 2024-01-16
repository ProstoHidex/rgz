using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamageEnemy : MonoBehaviour
{
    public int damage = 25;
    public GameObject hitEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<ZombieScript1>().HurtEnemy(damage);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
}
