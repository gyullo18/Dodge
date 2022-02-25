using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�̵��� ����� ������ٵ� ������Ʈ(public:���������� -- ������ �Ҵ�)
    //����Ƽ������ public - ����Ƽ �����Ϳ��� Ȯ�� ����
    public Rigidbody playerRigidbody;
    //�̵� �ӷ� ����
    public float speed = 6f;
    //�� �ڽ��� ���� ���� - GameObject
    public GameObject my;
    // �빮�� - ������ ����, �ҹ��� - ����

    private void Start()
    {
        // �̿�ȭ : ���� ���� �� ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playRigidbody�� �Ҵ�
        // <������ ������ ����>  ----- ����Ƽ Inspector�� Rigidbody�� �Ҵ����� �ʾƵ� �ڵ����� ����.
        playerRigidbody = GetComponent<Rigidbody>();
    }


    // �÷��̾� Object�� �ش��ϴ� �޼���
    void Update()
    {
        // �ݺ� ��� �޼��� > �������Ӵ� �ѹ���. ��, 1/60�� �ѹ�
        // ������� �Է� �κ� ó��(input Ŭ����).
        // ������� �������� �Է°��� �����ؼ� ����.
        float xInput = Input.GetAxis("Horizontal"); // GetAxis : �࿡ ���� �Է°��� ���ڷ� ��ȯ�ϴ� �޼���
        // Ű���� : 'A', �� : -���� : -1.0f
        // Ű���� : 'D', �� : +���� : +1.0f
        float zInput = Input.GetAxis("Vertical");
        // Ű���� : 'W', �� : +���� : +1.0f
        // Ű���� : 's', �� : -���� : -1.0f

        // ���� �̵��ӵ� = �Է°� * �̵� �ӷ��� ����� ����.
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // vector3 �ӵ��� (xSpeed, 0f, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        // Rigidbody�� �������� ��X -> �ӵ��� newVelocity�� �Ҵ�
        playerRigidbody.velocity = newVelocity;
    }



    //(1) -- ���̷�Ʈ ���
    void DirectInput()
    {
        // ������� �Է� �κ� ó��(input Ŭ����)
        if (Input.GetKey(KeyCode.UpArrow) == true)
        // �� ����Ű �Է��� ������ ��� z
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow) == true)
        // �Ʒ� ����Ű �Է��� ������ ��� -z
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        // ������ ����Ű �Է��� ������ ��� x
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) == true)
        // ���� ����Ű �Է��� ������ ��� -x
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
    }

    // ���ο� �޼��� ����
    // void = ��ɸ� �۵��ϴ� �޼���(��ȯ���� x)
    public void Die()
    {
        // GameObject�� �����ؼ� on(true)/off(false) ��Ű��
        my.SetActive(false);
        //gameObject.SetActive(false);
    }
}
