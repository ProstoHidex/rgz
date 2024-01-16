using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMove : MonoBehaviour
{
    [Range(50f, 200f)]
    public float mSpeed = 150f;

    float TimerVictory = 5f;

    public float interaction_range = 2;

    public TMP_Text description;

    public Transform holder;

    public ItemInstance activeItem;

    public TMP_Text health; 

    public LayerMask items;

    public GameObject player;

    Rigidbody rb; 

    public static PlayerMove instance;

    public Animator anim;

    public int curHealth=100;

    public GameObject DeadPanel;

    public GiveDamageEnemy damage;

    public TMP_Text timerBack;

    public TMP_Text Score;

    public GameObject WinPanel;

    public int objects;

    private int count;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
        activeItem = null;
        count = 0;
    }
    private void FixedUpdate()
    {
        float xMove = Input.GetAxisRaw("Horizontal");//проверка нажатия кнопок a,d
        float zMove = Input.GetAxisRaw("Vertical");//проверка нажатия кнопок w,s

        Vector3 dir = new Vector3(xMove, 0, zMove);//получение направления движения в плоскости X|Z
        dir.Normalize();                          //нормализация вектора движения

        Vector3 v = transform.TransformDirection(dir) * mSpeed * Time.fixedDeltaTime;//вектор скорости объекта = направление движения * скорость * время с прошедшего вызова этой функции
        v.y = rb.velocity.y; //восстановление смещения по оси Y
        rb.velocity = v;
    }
    void LateUpdate()
    {
        health.text = "Health:" + curHealth.ToString();
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, interaction_range, items))
        {
            if (hit.transform.GetComponent<ItemContainer>().transform.parent != holder)
                description.text = hit.transform.GetComponent<ItemContainer>().item.itemData.item_name;

            if (Input.GetKeyDown(KeyCode.E))
            {
                ItemInstance item = hit.transform.GetComponent<ItemContainer>().item;
                int amount = hit.transform.GetComponent<ItemContainer>().amount;
                int remaining = GetComponent<Inventory>().addItems(item, amount);
                hit.transform.GetComponent<ItemContainer>().pickUp(remaining);
            }
        }
        else
            description.text = "";

        //if (Input.GetMouseButtonDown(1))
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        if(Input.GetButtonDown("Fire1"))
        {
            if (activeItem != null)
                anim.SetTrigger(activeItem.itemData.action);
        }   
    }
    public void Update()
    {
        timerBack.text = "NextLevelTime" + " " + TimerVictory.ToString("f0");

        if(count>=objects)
        {
            WinPanel.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PkdUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetText();

        }
    }
    public void SetText()
    {
        Score.text = "Score: " + count.ToString();
    }
    public void use(int i)
    {
        ItemInstance item = GetComponent<Inventory>().getItem(i);
        if (item == null) return;

        if (item.use(this))
            GetComponent<Inventory>().removeItem(i);
    }
    public void drop(int i)
    {
        ItemInstance item = GetComponent<Inventory>().getItem(i);
        if (item == null) return;

        if (activeItem == item)
        {
            Destroy(holder.transform.GetChild(0).gameObject);
            activeItem = null;
        }

        GetComponent<Inventory>().dropItem(i);
    }

    public void HurtPlayer(int damageToGive)
    {
        curHealth -= damageToGive;

        if (curHealth < 0)
        {
            DeadPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
