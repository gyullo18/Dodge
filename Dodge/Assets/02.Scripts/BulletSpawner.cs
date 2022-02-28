using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // �Ҹ��������� - ��ƿ� ���� ���� > ���ӿ�����Ʈ
    // ������ �Ҹ��� ���� ������
    public GameObject bulletPrefab;


    // ������Ʈ���� �Ҹ��� �ð� ó������ ���� �����ϱ� ���� ���� ����
    // 1. �ּ� �����ֱ�
    public float spawnRateMin = 0.5f;
    // 2. �ִ� ���� �ֱ�
    public float spawnRateMax = 3f;
    // 3. ���� ���� �ֱ�(����)
    private float spawnRate;
    // 4. �ֱ� ���� �������� ���� �ð��� ����.
    private float timeAfterSpawn;

    // �÷��̾� ��ġ -- �߻��� ���
    private Transform target;

    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;

        // �Ҹ� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� �� ���� > spawnRate�� �Ҵ�.
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);


        // target �ʱ�ȭ
        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� �� ������Ʈ�� ��ġ���� �����Ͷ�.
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        // timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ� ����.
        if (timeAfterSpawn >= spawnRate)
        {
            // �Ҹ� ���� ����Instantiate(������ ������Ʈ) 
            // bullet prefab�� �������� transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            // ������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            // ������ �ð� ����
            timeAfterSpawn = 0f;
        }
    }
}
