using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionScript : MonoBehaviour
{
    [SerializeField] Transform BackGround;      //������ ���� ������
    [SerializeField] private Transform LeftPoint;   //����� ������� ������
    [SerializeField] private Transform RightPoint;  //������ ������� ������
    void Start()
    {
        if (Screen.height < 1280)   //��� ������� ��������� � Screen.height < 1280
        {
            BackGround.localScale = new Vector3(BackGround.localScale.x * 1.3f, BackGround.localScale.y, BackGround.localScale.z);  //���������� ���� ������
            LeftPoint.position = new Vector3(LeftPoint.position.x - 0.4f, LeftPoint.position.y, LeftPoint.position.z);              //�������� ����� �������
            RightPoint.position = new Vector3(RightPoint.position.x + 0.4f, RightPoint.position.y, RightPoint.position.z);          //�������� ������ �������
        }
        if ((Screen.height >= 1280) && (Screen.height < 2960))  //��� ������� ��������� � (Screen.height >= 1280) && (Screen.height < 2960)
        {
            BackGround.localScale = new Vector3(BackGround.localScale.x * 1.2f, BackGround.localScale.y, BackGround.localScale.z);  //���������� ���� ������
            LeftPoint.position = new Vector3(LeftPoint.position.x - 0.2f, LeftPoint.position.y, LeftPoint.position.z);              //�������� ����� �������
            RightPoint.position = new Vector3(RightPoint.position.x + 0.2f, RightPoint.position.y, RightPoint.position.z);          //�������� ������ �������
        }
    }
}
