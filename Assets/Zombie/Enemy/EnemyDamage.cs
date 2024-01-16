using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageToGive = 17;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {

            other.gameObject.GetComponent<PlayerMove>().HurtPlayer(damageToGive);

        }
    }
}
