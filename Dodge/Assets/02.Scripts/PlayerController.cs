using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //이동에 사용할 리지드바디 컴포넌트(public:접근제한자 -- 데이터 할당)
    //유니티에서의 public - 유니티 에디터에서 확인 가능
    public Rigidbody playerRigidbody;
    //이동 속력 변수
    public float speed = 6f;
    //내 자신을 담을 변수 - GameObject
    public GameObject my;
    // 대문자 - 데이터 형태, 소문자 - 변수

    private void Start()
    {
        // 이원화 : 게임 시작 시 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playRigidbody에 할당
        // <가져올 데이터 형태>  ----- 유니티 Inspector에 Rigidbody를 할당하지 않아도 자동으로 해줌.
        playerRigidbody = GetComponent<Rigidbody>();
    }


    // 플레이어 Object에 해당하는 메서드
    void Update()
    {
        // 반복 재생 메서드 > 한프레임당 한번씩. 즉, 1/60에 한번
        // 사용자의 입력 부분 처리(input 클래스).
        // 수평축과 수직축의 입력값을 감지해서 저장.
        float xInput = Input.GetAxis("Horizontal"); // GetAxis : 축에 대한 입력값을 숫자로 반환하는 메서드
        // 키보드 : 'A', ← : -방향 : -1.0f
        // 키보드 : 'D', → : +방향 : +1.0f
        float zInput = Input.GetAxis("Vertical");
        // 키보드 : 'W', ↑ : +방향 : +1.0f
        // 키보드 : 's', ↓ : -방향 : -1.0f

        // 실제 이동속도 = 입력값 * 이동 속력을 사용해 결정.
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // vector3 속도를 (xSpeed, 0f, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        // Rigidbody의 물리적인 힘X -> 속도에 newVelocity를 할당
        playerRigidbody.velocity = newVelocity;
    }



    //(1) -- 다이렉트 방식
    void DirectInput()
    {
        // 사용자의 입력 부분 처리(input 클래스)
        if (Input.GetKey(KeyCode.UpArrow) == true)
        // 위 방향키 입력이 감지된 경우 z
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow) == true)
        // 아래 방향키 입력이 감지된 경우 -z
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        // 오른쪽 방향키 입력이 감지된 경우 x
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) == true)
        // 왼쪽 방향키 입력이 감지된 경우 -x
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
    }

    // 새로운 메서드 정의
    // void = 기능만 작동하는 메서드(반환값이 x)
    public void Die()
    {
        // GameObject에 접근해서 on(true)/off(false) 시키기
        my.SetActive(false);
        //gameObject.SetActive(false);

        // Secene에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기.
        GameManager gameManager = FindObjectOfType<GameManager>();

        // 실행 -- 변수에 접근
        gameManager.EndGame();
    }
}
