using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    // �̵��� ����� ������ٵ� ������Ʈ
    private Rigidbody bulletRigidbody;
    // ź�� �̵� �ӷ�
    public float speed = 10f;

    void Start()
    {
        // ���� �����ϴ� ���� ����Ǳ� ����.
        //������ �ٵ� �ʱ�ȭ - ���� ������Ʈ���� Rigidbody�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();

        // ������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        // ���� - vector3(x,y,z) > ��(forward) = 0,0,1, ��(right), ��(up), ��(forward * -1) 
        // ������ǥ - ����, �浵 > ������ǥ - �� ������ ����, �浵(0,0)
        // transform.position : ���� �ٶ󺸴� ���� > ������ǥ
        bulletRigidbody.velocity = transform.forward * speed;

        // �����ð� �Ŀ� ������ �ı�(�ı���ų ������Ʈ - �� �ڽ�, �����ð�) 
        //Destroy : �Ű� ���� ������ ���� �޼��尡 �ٸ��� ����
        Destroy(gameObject, 3f);

    }
    // �浹 ó�� trigger-enter
    // �޼��带 ���� rigidbody�� ����.
    // rigidbody : �浹�� ������ ������ collider�� ������.
    //Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���.
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player�±׸� ������?
        if(other.tag == "Player")
        {
            // ����(�浹��) ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            // �������κ��� PlayerController������Ʈ�� �������µ� �����ߴٸ�,
            if (playerController != null)
            {
                // playerController ������Ʈ�� Die() �޼��� ����.
                playerController.Die();
            };
        }
    }
}
