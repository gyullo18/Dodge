using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�̵��� ����� ������ٵ� ������Ʈ(public:���������� -- ������ �Ҵ�)
    //����Ƽ������ public - ����Ƽ �����Ϳ��� Ȯ�� ����
    public Rigidbody playerRigidbody;
    //�̵� �ӷ� ����
    public float speed = 8f;

    void Start()
    {
        // �ݺ� ��� �޼��� > �������Ӵ� �ѹ���. ��, 1/60�� �ѹ�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
