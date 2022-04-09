using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;       // ���������� ��� �������

    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();    // ��� ����� ����� ������

        for (int i = 0; i < 20; i++)                // ���� For, ������� ����������� 10 ���
        {
            SpawnerPosition.x = Random.Range(-3.5f, 3.5f);  // ������� �� ��� �
            SpawnerPosition.y += Random.Range(.5f, 1.5f);      // ������� �� ��� � 

            Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);  // �������� ��������
        }
    }
}
