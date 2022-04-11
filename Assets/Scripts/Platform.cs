using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float forceJump;                                         // переменная для силы прыжка
    [SerializeField] bool HorizontalPlatform;           //флаг для определения горизонтальной платформы
    [SerializeField] bool VerticalPlatform;             //флаг для определения вертикальной платформы
    [SerializeField] bool BrokenPlatform;               //флаг для определения сломанной платформы
    [SerializeField] float PlatformSpeed;               //скорость передвижения платформы
    bool MovingRight;               //флаг для платформы, которая движется горизонтально
    bool MovingUp;                  //флаг для платформы, которая движется вертикально
    [SerializeField] private Transform LeftPoint;       //левая граница экрана для распределения платформ
    [SerializeField] private Transform RightPoint;      //правая граница экрана для распределения платформ
    Vector3 StartPosition;          //стартовая позиция платформы

    void Start()
    {
        PlatformStartingPosition();         //запоминаем стартовую позицию платформы и меняем флаги для работы передвигающихся платформ
    }

    void OnCollisionEnter2D(Collision2D collision)           // столкновения
    {
        if (collision.relativeVelocity.y < 0)                       // если относительная скорость меньше 0, ну вниз летит короче
        {
            Player.instance.DoodleRigid.velocity = Vector2.up * forceJump;  // добавляем прыжок к переменной из скрипта "Doodle"
        }
    }

    void OnCollisionExit2D(Collision2D collision)            // столкновения (ну только это когда оно заканчивается)
    {
        if (collision.collider.name == "DeadZone")                  // если платформа встретилась с объектом с именем DeadZone
        {
            float RandX = Random.Range(LeftPoint.position.x, RightPoint.position.x);                // то задаем новую позицию по х
            float RandY = Random.Range(transform.position.y + 18f, transform.position.y + 20f); // и новую позицию по у

            transform.position = new Vector3(RandX, RandY, 0);      // перемещаем объект по заданным координатам
            PlatformStartingPosition();             //запоминаем стартовую позицию платформы и меняем флаги для работы передвигающихся платформ
        }
    }
    void FixedUpdate()
    {
        if (HorizontalPlatform) //проверка на горизонтальную платформу
        {
            HorizontalPlatformMove(); //вызов метода для передвижения горизонтальной платформы
        }
        else if (VerticalPlatform) //проверка на вертикальную платформу
        {
            VerticalPlatformMove(); //вызов метода для передвижения вертикальной платформы
        }
    }
    void PlatformStartingPosition()
    {
        StartPosition = transform.position; //запоминаем стартовую позицию платформы
        if ((HorizontalPlatform) && (transform.position.x < 0f))    //если горизонтальная платформа появилась в левой половине экрана, то она движется вправо
        {
            MovingRight = true; //изменение значения флага для передвижения платформы
        }
        else if ((HorizontalPlatform) && (transform.position.x > 0f)) //если горизонтальная платформа появилась в правой половине экрана, то она движется влево
        {
            MovingRight = false; //изменение значения флага для передвижения платформы
        }
        if (VerticalPlatform) //если это вертикальная платформа, то она движется вверх
        {
            MovingUp = true; //изменение значения флага для передвижения платформы
        }
    }
    void HorizontalPlatformMove()
    {
        if (transform.position.x < LeftPoint.position.x) //если позиция платформы зашла за левую границу экрана, то она начнёт передвигаться вправо
        {
            MovingRight = true; //изменение значения флага для передвижения платформы
        }
        else if (transform.position.x > RightPoint.position.x)  //если позиция платформы зашла за правую границу экрана, то она начнёт передвигаться влево
        {
            MovingRight = false;    //изменение значения флага для передвижения платформы
        }
        if (MovingRight)    //проверка направления платформы
        {
            transform.position = new Vector2(transform.position.x + PlatformSpeed * Time.deltaTime, transform.position.y);  //передвигаем позицию платформы налево
        }
        else
        {
            transform.position = new Vector2(transform.position.x - PlatformSpeed * Time.deltaTime, transform.position.y);  //передвигаем позицию платформы направо
        }
    }
    void VerticalPlatformMove()
    {
        if (transform.position.y < StartPosition.y - 3f)    //если позиция платформы зашла за нижнюю границу дозволенного, то она начнёт передвигаться вверх 
        {
            MovingUp = true;    //изменение значения флага для передвижения платформы
        }
        else if (transform.position.y > StartPosition.y + 3f)   //если позиция платформы зашла за верхнюю границу дозволенного, то она начнёт передвигаться вниз 
        {
            MovingUp = false;   //изменение значения флага для передвижения платформы
        }
        if (MovingUp)   //проверка направления платформы
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + PlatformSpeed * Time.deltaTime);  //передвигаем позицию платформы вверх
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - PlatformSpeed * Time.deltaTime);  //передвигаем позицию платформы вниз
        }
    }
}
