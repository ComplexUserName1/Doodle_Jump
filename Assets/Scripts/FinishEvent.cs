using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEvent : MonoBehaviour
{
    float time = 0f;    //����� ��� �������
    [SerializeField] GameObject Finish; //��� �����
    [SerializeField] GameObject FinishMenu; //���� ������
    [SerializeField] GameObject Pause;  //������ �����
    void Update()
    {
        if (gameObject.name == "Finish")    //�������� �� ��� �����, ���� ������ ��������� � ����
            enabled = false;    //����� Update() �� ������������
        time = time + Time.deltaTime;   //����������� ������� ��� �������
        if (time >= 60f)    //�������� �� ����������� ������ ��� ��������� ������
        {
            Finish.SetActive(true);     //��������� ����� ������
            gameObject.GetComponent<CameraFollow>().enabled = false;    //��������� ������ ��� ������������ ������, ����� ����� ���� ���������� �� ����� ������
            Pause.SetActive(false);     //������� ������ ����� ��� ������������
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Doodler")   //���� ����� ������ � ����� ������, �� ������� ���������� � ������ ����������� ���� ������ ��� ������ ������������ ��������
        {
            Time.timeScale = 0;     //������������ ������� �����
            Finish.GetComponent<FinishEvent>().enabled = false;     //��������� ������ FinishEvent
            gameObject.SetActive(false);    //��������� � ������ ������ ����� ������
            FinishMenu.SetActive(true);     //���������� ���� ������ ��� ������������
        }
    }
}
