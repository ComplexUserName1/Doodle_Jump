using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;       // переменная для префаба

    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();    // нам нужен новый вектор

        for (int i = 0; i < 20; i++)                // цикл For, который выполняется 10 раз
        {
            SpawnerPosition.x = Random.Range(-3.5f, 3.5f);  // позиция по оси х
            SpawnerPosition.y += Random.Range(.5f, 1.5f);      // позиция по оси у 

            Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);  // создание префабов
        }
    }
}
