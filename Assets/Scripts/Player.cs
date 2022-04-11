using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;                          // меня не забудь подключить, мы ж уровень перезагружать будем

public class Player : MonoBehaviour
{
    [SerializeField] GameObject DeathMenu;  //меню смерти
    [SerializeField] GameObject Finish;     //сам финиш
    [SerializeField] GameObject FinishMenu; //меню финиша
    public static Player instance;                          // это штучка нужна, чтобы мы могли использовать переменные в этом скрипте в других скриптах

    float horizontal;                                       // переменная для акселерометра
    public Rigidbody2D DoodleRigid;                         // публичный RB для дудлика

    void Start()
    {
        if (instance == null)                               // пишем эти строчки, чтоб можно было корректно использовать переменные в других скриптах
        {
            instance = this;
        }
    }


    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Main_Menu") // если выбрана сцена главного меню, то метод FixedUpdate() не используется
        {
            enabled = false;
        }
        if (Application.platform == RuntimePlatform.Android)    // если платформа Андроид
        {
            horizontal = Input.acceleration.x;                  // то подключаем акселерометр по оси х
        }

        if (Input.acceleration.x > 0)                           // если наклон акселерометра меньше нуля
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;    // то объект поворачивается налево
        }

        if (Input.acceleration.x < 0)                           // если наклон акселерометра больше нуля
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;     // то объект поворачивется направо
        }

        DoodleRigid.velocity = new Vector2(Input.acceleration.x * 10f, DoodleRigid.velocity.y);     //  добавляем силу к акселерометру, чтоб он не просто разворачивался в разные стороны
    }

    void OnCollisionEnter2D(Collision2D collision)       // столкновение объекта
    {
        if (collision.collider.name == "DeadZone")              // если дудлик сталкивается с объектом с именем "DeadZone"
        {
            Time.timeScale = 0;                                 //остонавливаем время игры
            DeathMenu.SetActive(true);                          //включаем меню смерти для игрока
            Finish.GetComponent<FinishEvent>().enabled = false; //отключаем скрипт FinishEvent
            FinishMenu.SetActive(false);                        //отключаем GameObject FinishMenu
        }
    }
}
