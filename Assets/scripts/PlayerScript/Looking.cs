using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    public static bool cursorLock = true; //включение/выключение курсора
    public Transform player;//ссылка на модель игрока
    public Transform cam;//ссылка на камеру игрока

    [Range(50f, 100f)]
    public float xSens = 70f;//чувствительность мыши по оси X
    [Range(50f, 100f)]
    public float ySens = 70f;//чувствительность мыши по оси Y

    Quaternion center; //начальный поворот камеры по центру

    // Start is called before the first frame update
    void Start()
    {
        center = cam.localRotation;//получение начального поворота камеры
    }

    // Update is called once per frame
    void Update()
    {
        //получение поворота вокруг по оси X
        float mouseY = Input.GetAxis("Mouse Y")*ySens*Time.deltaTime;
        Quaternion yRot=cam.localRotation*Quaternion.AngleAxis(mouseY,-Vector3.right);
        //запрет поворота на более чем 90 градусов
        if (Quaternion.Angle(center, yRot) < 90f)
            cam.localRotation = yRot; //поворот камеры

        //получение поворота вокруг оси Y
        float mouseX = Input.GetAxis("Mouse X") * xSens *Time.deltaTime;
        Quaternion xRot = player.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);

        player.localRotation = xRot;//поворот игрока

        if(cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if(Input.GetKeyDown(KeyCode.Escape))
                cursorLock = false;
        }
        else
        {
            Cursor.lockState= CursorLockMode.None;
            Cursor.visible = true;
            if(Input.GetKeyDown(KeyCode.Escape))
                cursorLock = true;
        }
    }

}
