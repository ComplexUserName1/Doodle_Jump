using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;       // переменная для префаба
    public GameObject platformPrefabHorizontal;
    public GameObject platformPrefabVertical;
    public GameObject BrokenPlatformPrefab;
    [SerializeField] private Transform LeftPoint;
    [SerializeField] private Transform RightPoint;

    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();    // нам нужен новый вектор

        for (int i = 0; i < 20; i++)                // цикл For, который выполняется 10 раз
        {
            SpawnerPosition.x = Random.Range(LeftPoint.position.x, RightPoint.position.x);  // позиция по оси х
            SpawnerPosition.y += Random.Range(.5f, 1.5f);      // позиция по оси у 

            Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);  // создание префабов
            if (i == 10)
            {
                Instantiate(platformPrefabHorizontal, SpawnerPosition, Quaternion.identity);  // создание префабов горизонтальных платформ
                Instantiate(platformPrefabVertical, SpawnerPosition, Quaternion.identity);  // создание префабов вертикальных платформ
                Instantiate(BrokenPlatformPrefab, SpawnerPosition, Quaternion.identity);  // создание префабов сломанных платформ
            }
        }
    }
}
