using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    public static bool cursorLock = true; //���������/���������� �������
    public Transform player;//������ �� ������ ������
    public Transform cam;//������ �� ������ ������

    [Range(50f, 100f)]
    public float xSens = 70f;//���������������� ���� �� ��� X
    [Range(50f, 100f)]
    public float ySens = 70f;//���������������� ���� �� ��� Y

    Quaternion center; //��������� ������� ������ �� ������

    // Start is called before the first frame update
    void Start()
    {
        center = cam.localRotation;//��������� ���������� �������� ������
    }

    // Update is called once per frame
    void Update()
    {
        //��������� �������� ������ �� ��� X
        float mouseY = Input.GetAxis("Mouse Y")*ySens*Time.deltaTime;
        Quaternion yRot=cam.localRotation*Quaternion.AngleAxis(mouseY,-Vector3.right);
        //������ �������� �� ����� ��� 90 ��������
        if (Quaternion.Angle(center, yRot) < 90f)
            cam.localRotation = yRot; //������� ������

        //��������� �������� ������ ��� Y
        float mouseX = Input.GetAxis("Mouse X") * xSens *Time.deltaTime;
        Quaternion xRot = player.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);

        player.localRotation = xRot;//������� ������

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
