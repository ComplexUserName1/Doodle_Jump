using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float forceJump;                                         // переменная для силы прыжка
    public bool HorizontalPlatform;
    public bool VerticalPlatform;
    public bool BrokenPlatform;
    public float PlatformSpeed;
    bool MovingRight;
    bool MovingUp;
    [SerializeField] private Transform LeftPoint;
    [SerializeField] private Transform RightPoint;
    Vector3 StartPosition;

    private void Start()
    {
        PlatformStartingPosition();
    }

    public void OnCollisionEnter2D(Collision2D collision)           // столкновения
    {
        if (collision.relativeVelocity.y < 0)                       // если относительная скорость меньше 0, ну вниз летит короче
        {
            Player.instance.DoodleRigid.velocity = Vector2.up * forceJump;  // добавляем прыжок к переменной из скрипта "Doodle"
        }
    }

    public void OnCollisionExit2D(Collision2D collision)            // столкновения (ну только это когда оно заканчивается)
    {
        if (collision.collider.name == "DeadZone")                  // если платформа встретилась с объектом с именем DeadZone
        {
            float RandX = Random.Range(LeftPoint.position.x, RightPoint.position.x);                // то задаем новую позицию по х
            float RandY = Random.Range(transform.position.y + 18f, transform.position.y + 20f); // и новую позицию по у

            transform.position = new Vector3(RandX, RandY, 0);      // перемещаем объект по заданным координатам
            PlatformStartingPosition();
        }
    }
    void FixedUpdate()
    {
        if (HorizontalPlatform)
        {
                if (transform.position.x < LeftPoint.position.x)
                {
                    MovingRight = true;
                }
                else if (transform.position.x > RightPoint.position.x)
                {
                    MovingRight = false;
                }
                if (MovingRight)
                {
                    transform.position = new Vector2(transform.position.x + PlatformSpeed * Time.deltaTime, transform.position.y);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x - PlatformSpeed * Time.deltaTime, transform.position.y);
                }
        }
        else if (VerticalPlatform)
        {
            if (transform.position.y < StartPosition.y - 3f)
            {
                MovingUp = true;
            }
            else if (transform.position.y > StartPosition.y + 3f)
            {
                MovingUp = false;
            }
            if (MovingUp)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + PlatformSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - PlatformSpeed * Time.deltaTime);
            }
        }
    }
    private void PlatformStartingPosition()
    {
        StartPosition = transform.position;
        if ((HorizontalPlatform) && (transform.position.x < 0f))
        {
            MovingRight = true;
        }
        else if ((HorizontalPlatform) && (transform.position.x > 0f))
        {
            MovingRight = false;
        }
        if (VerticalPlatform)
        {
            MovingUp = true;
        }
    }
}
