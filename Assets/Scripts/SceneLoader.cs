using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void SceneLoad(int index)       //����� ��� ����� �����, ������� ���������� ������ �������
    {
        Time.timeScale = 1;         //������������ ������� �����
        SceneManager.LoadScene(index);      //��������� ������ �����
    }
}
