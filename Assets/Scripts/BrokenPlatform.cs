using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour
{
    Animator anim;  //���������� ��� ������ � Animator �������
    [SerializeField] float PlatformSpeed;   //�������� ������������ ���������
    bool isCollision;   //
    [SerializeField] private Transform LeftPoint;   //����� ������� ������
    [SerializeField] private Transform RightPoint;  //������ ������� ������

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();     //����������� Animator ��� ������ � ��� (� ����� ������ ��������� �������� bool ����� isBroken)
    }

    void FixedUpdate()
    {
        if (isCollision)        //�������� ���������� �� ��������� ����������
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - PlatformSpeed * Time.deltaTime);      //��������� ��������� ��������� ���� � ���� ������
        }
    }

    void OnCollisionExit2D(Collision2D collision)            // ������������ (�� ������ ��� ����� ��� �������������)
    {
        if (collision.collider.name == "DeadZone")                  // ���� ��������� ����������� � �������� � ������ DeadZone
        {
            float RandX = Random.Range(LeftPoint.position.x, RightPoint.position.x);                // �� ������ ����� ������� �� �
            float RandY = Random.Range(transform.position.y + 18f, transform.position.y + 20f); // � ����� ������� �� �

            transform.position = new Vector3(RandX, RandY, 0);      // ���������� ������ �� �������� �����������
            anim.SetBool("isBroken", false);
            isCollision = false;
        }
        if (collision.collider.name == "Doodler")                  // ���� ��������� ����������� � �������� � ������ Doodler
        {
            anim.SetBool("isBroken", true);                         // �������� �������� ������� ���������
            isCollision = true;                                     //���� ��� ������� ������ true
        }
    }

}
