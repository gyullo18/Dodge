using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public float rotationSpeed2 = -60f;
    // �� �����Ӵ� 60����....
    void Update()
    {
    // �빮�� - ���
    // Rotate �޼���� �Է°�(�Ű�����)�� x, y, z�࿡ ���� ȸ������ �ް�,
    // ���� ȸ�� ���¿��� �Էµ� ����ŭ ��������� �� ȸ��.
    // �ʴ� 60������ ���� Time.deltaTime.
     transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);  
    }   
}
