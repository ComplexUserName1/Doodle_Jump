using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;                          // ���� �� ������ ����������, �� � ������� ������������� �����

public class Player : MonoBehaviour
{
    public static Player instance;                          // ��� ������ �����, ����� �� ����� ������������ ���������� � ���� ������� � ������ ��������

    float horizontal;                                       // ���������� ��� �������������
    public Rigidbody2D DoodleRigid;                         // ��������� RB ��� �������

    void Start()
    {
        if (instance == null)                               // ����� ��� �������, ���� ����� ���� ��������� ������������ ���������� � ������ ��������
        {
            instance = this;
        }
    }


    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)    // ���� ��������� �������
        {
            horizontal = Input.acceleration.x;                  // �� ���������� ������������ �� ��� �
        }

        if (Input.acceleration.x > 0)                           // ���� ������ ������������� ������ ����
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;    // �� ������ �������������� ������
        }

        if (Input.acceleration.x < 0)                           // ���� ������ ������������� ������ ����
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;     // �� ������ ������������� �������
        }

        DoodleRigid.velocity = new Vector2(Input.acceleration.x * 10f, DoodleRigid.velocity.y);     //  ��������� ���� � �������������, ���� �� �� ������ �������������� � ������ �������
    }

    public void OnCollisionEnter2D(Collision2D collision)       // ������������ �������
    {
        if (collision.collider.name == "DeadZone")              // ���� ������ ������������ � �������� � ������ "DeadZone"
        {
            SceneManager.LoadScene(0);                          // �� ������� ���������������
        }
    }
}