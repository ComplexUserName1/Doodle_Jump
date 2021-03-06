using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float forceJump;                                         // ?????????? ??? ???? ??????
    [SerializeField] bool HorizontalPlatform;           //???? ??? ??????????? ?????????????? ?????????
    [SerializeField] bool VerticalPlatform;             //???? ??? ??????????? ???????????? ?????????
    [SerializeField] bool BrokenPlatform;               //???? ??? ??????????? ????????? ?????????
    [SerializeField] float PlatformSpeed;               //???????? ???????????? ?????????
    bool MovingRight;               //???? ??? ?????????, ??????? ???????? ?????????????
    bool MovingUp;                  //???? ??? ?????????, ??????? ???????? ???????????
    [SerializeField] private Transform LeftPoint;       //????? ??????? ?????? ??? ????????????? ????????
    [SerializeField] private Transform RightPoint;      //?????? ??????? ?????? ??? ????????????? ????????
    Vector3 StartPosition;          //????????? ??????? ?????????

    void Start()
    {
        PlatformStartingPosition();         //?????????? ????????? ??????? ????????? ? ?????? ????? ??? ?????? ??????????????? ????????
    }

    void OnCollisionEnter2D(Collision2D collision)           // ????????????
    {
        if (collision.relativeVelocity.y < 0)                       // ???? ????????????? ???????? ?????? 0, ?? ???? ????? ??????
        {
            Player.instance.DoodleRigid.velocity = Vector2.up * forceJump;  // ????????? ?????? ? ?????????? ?? ??????? "Doodle"
        }
    }

    void OnCollisionExit2D(Collision2D collision)            // ???????????? (?? ?????? ??? ????? ??? ?????????????)
    {
        if (collision.collider.name == "DeadZone")                  // ???? ????????? ??????????? ? ???????? ? ?????? DeadZone
        {
            float RandX = Random.Range(LeftPoint.position.x, RightPoint.position.x);                // ?? ?????? ????? ??????? ?? ?
            float RandY = Random.Range(transform.position.y + 18f, transform.position.y + 20f); // ? ????? ??????? ?? ?

            transform.position = new Vector3(RandX, RandY, 0);      // ?????????? ?????? ?? ???????? ???????????
            PlatformStartingPosition();             //?????????? ????????? ??????? ????????? ? ?????? ????? ??? ?????? ??????????????? ????????
        }
    }
    void FixedUpdate()
    {
        if (HorizontalPlatform) //???????? ?? ?????????????? ?????????
        {
            HorizontalPlatformMove(); //????? ?????? ??? ???????????? ?????????????? ?????????
        }
        else if (VerticalPlatform) //???????? ?? ???????????? ?????????
        {
            VerticalPlatformMove(); //????? ?????? ??? ???????????? ???????????? ?????????
        }
    }
    void PlatformStartingPosition()
    {
        StartPosition = transform.position; //?????????? ????????? ??????? ?????????
        if ((HorizontalPlatform) && (transform.position.x < 0f))    //???? ?????????????? ????????? ????????? ? ????? ???????? ??????, ?? ??? ???????? ??????
        {
            MovingRight = true; //????????? ???????? ????? ??? ???????????? ?????????
        }
        else if ((HorizontalPlatform) && (transform.position.x > 0f)) //???? ?????????????? ????????? ????????? ? ?????? ???????? ??????, ?? ??? ???????? ?????
        {
            MovingRight = false; //????????? ???????? ????? ??? ???????????? ?????????
        }
        if (VerticalPlatform) //???? ??? ???????????? ?????????, ?? ??? ???????? ?????
        {
            MovingUp = true; //????????? ???????? ????? ??? ???????????? ?????????
        }
    }
    void HorizontalPlatformMove()
    {
        if (transform.position.x < LeftPoint.position.x) //???? ??????? ????????? ????? ?? ????? ??????? ??????, ?? ??? ?????? ????????????? ??????
        {
            MovingRight = true; //????????? ???????? ????? ??? ???????????? ?????????
        }
        else if (transform.position.x > RightPoint.position.x)  //???? ??????? ????????? ????? ?? ?????? ??????? ??????, ?? ??? ?????? ????????????? ?????
        {
            MovingRight = false;    //????????? ???????? ????? ??? ???????????? ?????????
        }
        if (MovingRight)    //???????? ??????????? ?????????
        {
            transform.position = new Vector2(transform.position.x + PlatformSpeed * Time.deltaTime, transform.position.y);  //??????????? ??????? ????????? ??????
        }
        else
        {
            transform.position = new Vector2(transform.position.x - PlatformSpeed * Time.deltaTime, transform.position.y);  //??????????? ??????? ????????? ???????
        }
    }
    void VerticalPlatformMove()
    {
        if (transform.position.y < StartPosition.y - 3f)    //???? ??????? ????????? ????? ?? ?????? ??????? ????????????, ?? ??? ?????? ????????????? ????? 
        {
            MovingUp = true;    //????????? ???????? ????? ??? ???????????? ?????????
        }
        else if (transform.position.y > StartPosition.y + 3f)   //???? ??????? ????????? ????? ?? ??????? ??????? ????????????, ?? ??? ?????? ????????????? ???? 
        {
            MovingUp = false;   //????????? ???????? ????? ??? ???????????? ?????????
        }
        if (MovingUp)   //???????? ??????????? ?????????
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + PlatformSpeed * Time.deltaTime);  //??????????? ??????? ????????? ?????
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - PlatformSpeed * Time.deltaTime);  //??????????? ??????? ????????? ????
        }
    }
}
