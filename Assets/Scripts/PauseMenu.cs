using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pause_menu;     //���� �����
    [SerializeField] GameObject pause_button;   //������ �����
    void Pause()            //����� ��� �����, ������� ���������� ������ �������
    {
        pause_button.SetActive(false);          //������������ ������ ����� ��� ������
        Time.timeScale = 0;                 //������������ ������� �����
        pause_menu.SetActive(true);         //���������� ���� ����� ��� ������
    }
    void Resume()       //����� ��� ����������� ����, ������� ���������� ������ �������
    {
        pause_menu.SetActive(false);        //������������ ���� ����� ��� ������
        Time.timeScale = 1;             //������������ ������� �����
        pause_button.SetActive(true);       //���������� ������ ����� ��� ������
    }
}
