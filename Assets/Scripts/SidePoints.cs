using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePoints : MonoBehaviour
{
    [SerializeField] private Transform _oppositePoint; //������ �� ������ �����
    [SerializeField] private Transform _target; //������ �� ������ ���������

    [SerializeField] private bool _leftSide; //���� ��� �������� ����� ������� ������

    void Update()
    {
        if (_leftSide) //�������� ����� ������� ������
        {
            if (transform.position.x > _target.position.x) //�������� ����� �� ����� ������� ������
            {
                MoveToOppositePoint();
            }
        }
        else
        {
            if (transform.position.x < _target.position.x) //�������� ����� �� ������ ������� ������
            {
                MoveToOppositePoint();
            }
        }
    }

    void MoveToOppositePoint() => _target.position = new Vector2(_oppositePoint.position.x, _target.position.y); //����������� ��������� ����� ������� �� X
}
