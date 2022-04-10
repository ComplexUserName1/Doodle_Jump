using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour
{
    Animator anim;
    public float PlatformSpeed;
    bool isCollision;
    [SerializeField] private Transform LeftPoint;
    [SerializeField] private Transform RightPoint;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCollision)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - PlatformSpeed * Time.deltaTime);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)            // столкновения (ну только это когда оно заканчивается)
    {
        if (collision.collider.name == "DeadZone")                  // если платформа встретилась с объектом с именем DeadZone
        {
            float RandX = Random.Range(LeftPoint.position.x, RightPoint.position.x);                // то задаем новую позицию по х
            float RandY = Random.Range(transform.position.y + 18f, transform.position.y + 20f); // и новую позицию по у

            transform.position = new Vector3(RandX, RandY, 0);      // перемещаем объект по заданным координатам
            anim.SetBool("isBroken", false);
            isCollision = false;
        }
        if (collision.collider.name == "Doodler")                  // если платформа встретилась с объектом с именем DeadZone
        {
            anim.SetBool("isBroken", true);
            isCollision = true;
        }
    }

}
