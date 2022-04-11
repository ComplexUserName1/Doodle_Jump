using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pause_menu;     //меню паузы
    [SerializeField] GameObject pause_button;   //кнопка паузы
    void Pause()            //метод для паузы, который использует кнопка канваса
    {
        pause_button.SetActive(false);          //деактивируем кнопку паузы для игрока
        Time.timeScale = 0;                 //замораживаем игровое время
        pause_menu.SetActive(true);         //активируем меню паузы для игрока
    }
    void Resume()       //метод для продолжения игры, который использует кнопка канваса
    {
        pause_menu.SetActive(false);        //деактивируем меню паузы для игрока
        Time.timeScale = 1;             //возобновляем игровое время
        pause_button.SetActive(true);       //активируем кнопку паузы для игрока
    }
}
