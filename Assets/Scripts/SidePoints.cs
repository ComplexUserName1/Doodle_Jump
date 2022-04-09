using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePoints : MonoBehaviour
{
    [SerializeField] private Transform _oppositePoint; //ссылка на другой поинт
    [SerializeField] private Transform _target; //ссылка на нашего персонажа

    [SerializeField] private bool _leftSide; //флаг для проверки левой стороны экрана

    private void Update()
    {
        if (_leftSide) //проверка левой стороны экрана
        {
            if (transform.position.x > _target.position.x) //персонаж зашёл за левую границу экрана
            {
                MoveToOppositePoint();
            }
        }
        else
        {
            if (transform.position.x < _target.position.x) //персонаж зашёл за правую границу экрана
            {
                MoveToOppositePoint();
            }
        }
    }

    private void MoveToOppositePoint() => _target.position = new Vector2(_oppositePoint.position.x, _target.position.y); //присваиваем персонажу новую позицию по X
}
