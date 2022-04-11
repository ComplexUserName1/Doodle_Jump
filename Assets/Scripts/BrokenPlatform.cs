using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour
{
    Animator anim;  //переменная для работы с Animator объекта
    [SerializeField] float PlatformSpeed;   //скорость передвижения платформы
    bool isCollision;   //
    [SerializeField] private Transform LeftPoint;   //левая граница экрана
    [SerializeField] private Transform RightPoint;  //правая граница экрана

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();     //вытаскиваем Animator для работы с ним (в нашем случае изменения значения bool флага isBroken)
    }

    void FixedUpdate()
    {
        if (isCollision)        //персонаж столкнулся со сломанной платформой
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - PlatformSpeed * Time.deltaTime);      //переносим сломанную платформу вниз в зону смерти
        }
    }

    void OnCollisionExit2D(Collision2D collision)            // столкновения (ну только это когда оно заканчивается)
    {
        if (collision.collider.name == "DeadZone")                  // если платформа встретилась с объектом с именем DeadZone
        {
            float RandX = Random.Range(LeftPoint.position.x, RightPoint.position.x);                // то задаем новую позицию по х
            float RandY = Random.Range(transform.position.y + 18f, transform.position.y + 20f); // и новую позицию по у

            transform.position = new Vector3(RandX, RandY, 0);      // перемещаем объект по заданным координатам
            anim.SetBool("isBroken", false);
            isCollision = false;
        }
        if (collision.collider.name == "Doodler")                  // если платформа встретилась с объектом с именем Doodler
        {
            anim.SetBool("isBroken", true);                         // включаем анимацию поломки платформы
            isCollision = true;                                     //флаг для колизии делаем true
        }
    }

}
