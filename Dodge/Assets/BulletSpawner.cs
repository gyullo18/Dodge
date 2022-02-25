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
        timeAfterSpawn = 0;

        // �Ҹ� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� �� ���� > spawnRate�� �Ҵ�.
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);


        // target �ʱ�ȭ
        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� �� ������Ʈ�� ��ġ���� �����Ͷ�.
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        // �Ҹ� ���� ����(������ ������Ʈ) 
        Instantiate(bulletPrefab);
        // �ð� ����

        // �Ҹ� �߻�
    }
}
