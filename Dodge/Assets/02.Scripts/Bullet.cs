using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    // 이동에 사용할 리지드바디 컴포넌트
    private Rigidbody bulletRigidbody;
    // 탄알 이동 속력
    public float speed = 10f;

    void Start()
    {
        // 복제 생성하는 순간 실행되기 위함.
        //리지드 바디 초기화 - 게임 오브젝트에서 Rigidbody를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();

        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        // 축약법 - vector3(x,y,z) > 앞(forward) = 0,0,1, 오(right), 위(up), 뒤(forward * -1) 
        // 전역좌표 - 위도, 경도 > 지역좌표 - 내 기준의 위도, 경도(0,0)
        // transform.position : 내가 바라보는 방향 > 지역좌표
        bulletRigidbody.velocity = transform.forward * speed;

        // 일정시간 후에 프리펩 파괴(파괴시킬 오브젝트 - 내 자신, 지연시간) 
        //Destroy : 매개 변수 갯수에 따라 메서드가 다르게 실행
        Destroy(gameObject, 3f);

    }
    // 충돌 처리 trigger-enter
    // 메서드를 만들어서 rigidbody가 실행.
    // rigidbody : 충돌난 상대방의 정보를 collider로 보내줌.
    //트리거 충돌 시 자동으로 실행되는 메서드.
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player태그를 가졌나?
        if(other.tag == "Player")
        {
            // 상대방(충돌한) 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 PlayerController컴포넌트를 가져오는데 성공했다면,
            if (playerController != null)
            {
                // playerController 컴포넌트의 Die() 메서드 실행.
                playerController.Die();
            };
        }
    }
}
