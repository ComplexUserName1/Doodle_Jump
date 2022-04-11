using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionScript : MonoBehaviour
{
    [SerializeField] Transform BackGround;      //объект фона уровня
    [SerializeField] private Transform LeftPoint;   //левая граница экрана
    [SerializeField] private Transform RightPoint;  //правая граница экрана
    void Start()
    {
        if (Screen.height < 1280)   //для экранов телефонов с Screen.height < 1280
        {
            BackGround.localScale = new Vector3(BackGround.localScale.x * 1.3f, BackGround.localScale.y, BackGround.localScale.z);  //увеличение фона уровня
            LeftPoint.position = new Vector3(LeftPoint.position.x - 0.4f, LeftPoint.position.y, LeftPoint.position.z);              //смещение левой границы
            RightPoint.position = new Vector3(RightPoint.position.x + 0.4f, RightPoint.position.y, RightPoint.position.z);          //смещение правой границы
        }
        if ((Screen.height >= 1280) && (Screen.height < 2960))  //для экранов телефонов с (Screen.height >= 1280) && (Screen.height < 2960)
        {
            BackGround.localScale = new Vector3(BackGround.localScale.x * 1.2f, BackGround.localScale.y, BackGround.localScale.z);  //увеличение фона уровня
            LeftPoint.position = new Vector3(LeftPoint.position.x - 0.2f, LeftPoint.position.y, LeftPoint.position.z);              //смещение левой границы
            RightPoint.position = new Vector3(RightPoint.position.x + 0.2f, RightPoint.position.y, RightPoint.position.z);          //смещение правой границы
        }
    }
}
