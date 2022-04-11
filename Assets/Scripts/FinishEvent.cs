using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEvent : MonoBehaviour
{
    float time = 0f;    //врем€ дл€ таймера
    [SerializeField] GameObject Finish; //сам финиш
    [SerializeField] GameObject FinishMenu; //меню финиша
    [SerializeField] GameObject Pause;  //кнопка паузы
    void Update()
    {
        if (gameObject.name == "Finish")    //проверка на сам финиш, если скрипт прикреплЄн к нему
            enabled = false;    //метод Update() не используетс€
        time = time + Time.deltaTime;   //наращивание времени дл€ таймера
        if (time >= 60f)    //проверка на прохождение минуты дл€ по€влени€ финиша
        {
            Finish.SetActive(true);     //активаци€ линии финиша
            gameObject.GetComponent<CameraFollow>().enabled = false;    //отключает скрипт дл€ передвижени€ камеры, чтобы игрок смог допрыгнуть до линии финиша
            Pause.SetActive(false);     //убираем кнопку паузы дл€ пользовател€
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Doodler")   //если игрок входит в линию финиша, то уровень проходитс€ и игроку открываетс€ меню финиша дл€ выбора последующего действи€
        {
            Time.timeScale = 0;     //замораживаем игровое врем€
            Finish.GetComponent<FinishEvent>().enabled = false;     //отключаем скрипт FinishEvent
            gameObject.SetActive(false);    //отключаем в данном случае линию финиша
            FinishMenu.SetActive(true);     //активируем меню финиша дл€ пользовател€
        }
    }
}
