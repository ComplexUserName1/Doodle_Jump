using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;       // ���������� ��� ������� ������� ���������
    [SerializeField] GameObject platformPrefabHorizontal;   //���������� ��� ������� �������������� ���������
    [SerializeField] GameObject platformPrefabVertical; //���������� ��� ������� ������������ ���������
    [SerializeField] GameObject BrokenPlatformPrefab;   //���������� ��� ������� ��������� ���������
    [SerializeField] private Transform LeftPoint;   //������� ����� ������� ������
    [SerializeField] private Transform RightPoint;  //������� ������ ������� ������

    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();    // ��� ����� ����� ������

        for (int i = 0; i < 20; i++)                // ���� For, ������� ����������� 20 ���
        {
            SpawnerPosition.x = Random.Range(LeftPoint.position.x, RightPoint.position.x);  // ������� �� ��� �
            SpawnerPosition.y += Random.Range(.5f, 1.5f);      // ������� �� ��� � 

            Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);  // �������� ��������
            if (i == 10) //�������� �� ������ ���������� ����������� ��������
            {
                Instantiate(platformPrefabHorizontal, SpawnerPosition, Quaternion.identity);  // �������� �������� �������������� ��������
                Instantiate(platformPrefabVertical, SpawnerPosition, Quaternion.identity);  // �������� �������� ������������ ��������
                Instantiate(BrokenPlatformPrefab, SpawnerPosition, Quaternion.identity);  // �������� �������� ��������� ��������
            }
        }
    }
}
