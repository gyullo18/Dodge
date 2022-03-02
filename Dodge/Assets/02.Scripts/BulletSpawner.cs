using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // 불릿가져오기 - 담아올 변수 설정 > 게임오브젝트
    // 생성할 불릿의 원본 프리펩
    public GameObject bulletPrefab;


    // 업데이트에서 불릿을 시간 처리시켜 랜덤 생성하기 위한 변수 생성
    // 1. 최소 생성주기
    public float spawnRateMin = 0.5f;
    // 2. 최대 생성 주기
    public float spawnRateMax = 3f;
    // 3. 실제 생성 주기(보안)
    private float spawnRate;
    // 4. 최근 생성 시점에서 지난 시간을 담음.
    private float timeAfterSpawn;

    // 플레이어 위치 -- 발사할 대상
    private Transform target;

    void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;

        // 불릿 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 값 지정 > spawnRate에 할당.
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);


        // target 초기화
        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 그 오브젝트의 위치값을 가져와라.
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        // timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면 시작.
        if (timeAfterSpawn >= spawnRate)
        {
            // 불릿 복제 생성Instantiate(생성할 오브젝트) 
            // bullet prefab의 복제본을 transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);

            // 다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            // 누적된 시간 리셋
            timeAfterSpawn = 0f;
        }
    }
}
