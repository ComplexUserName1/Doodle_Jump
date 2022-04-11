using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;       // переменна€ дл€ префаба обычной платформы
    [SerializeField] GameObject platformPrefabHorizontal;   //переменна€ дл€ префаба горизонтальной платформы
    [SerializeField] GameObject platformPrefabVertical; //переменна€ дл€ префаба вертикальной платформы
    [SerializeField] GameObject BrokenPlatformPrefab;   //переменна€ дл€ префаба сломанной платформы
    [SerializeField] private Transform LeftPoint;   //позици€ левой границы экрана
    [SerializeField] private Transform RightPoint;  //позици€ правой границы экрана

    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();    // нам нужен новый вектор

        for (int i = 0; i < 20; i++)                // цикл For, который выполн€етс€ 20 раз
        {
            SpawnerPosition.x = Random.Range(LeftPoint.position.x, RightPoint.position.x);  // позици€ по оси х
            SpawnerPosition.y += Random.Range(.5f, 1.5f);      // позици€ по оси у 

            Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);  // создание префабов
            if (i == 10) //создание по одному экзмепл€ру специальных платформ
            {
                Instantiate(platformPrefabHorizontal, SpawnerPosition, Quaternion.identity);  // создание префабов горизонтальных платформ
                Instantiate(platformPrefabVertical, SpawnerPosition, Quaternion.identity);  // создание префабов вертикальных платформ
                Instantiate(BrokenPlatformPrefab, SpawnerPosition, Quaternion.identity);  // создание префабов сломанных платформ
            }
        }
    }
}
