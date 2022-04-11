using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void SceneLoad(int index)       //метод для смены сцены, который использует кнопка канваса
    {
        Time.timeScale = 1;         //возобновляем игровое время
        SceneManager.LoadScene(index);      //загружаем другую сцену
    }
}
