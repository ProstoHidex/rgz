using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript1 : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent nav;
    private Transform target;
    public float lookRadius;
    public float biteTime=0;
    public static ZombieScript1 instance;
    public int currHealth=10000;

    void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius) 
        {
            animator.SetBool("isRun", true);
            nav.SetDestination(target.position);
            if(distance<=nav.stoppingDistance)
            {
                animator.SetBool("isBite", true);
                animator.SetBool("isRun", false);
                biteTime += 0.02f;
                if(biteTime>=5f)
                {
                    PlayerMove.instance.curHealth -= Random.Range(5,13);
                    biteTime = 0;
                }
                LookTarget();
            }
            else
            {
                animator.SetBool("isBite", false);
                animator.SetBool("isRun", true);
            }

        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
    private void LookTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime*5f);
    }

    public void HurtEnemy(int damageToGive)
    {
        currHealth -= damageToGive;
        if (currHealth <= 0)
        {
            animator.SetBool("isDead",true);
        }
    }
}
