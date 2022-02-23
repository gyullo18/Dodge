using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //이동에 사용할 리지드바디 컴포넌트(public:접근제한자 -- 데이터 할당)
    //유니티에서의 public - 유니티 에디터에서 확인 가능
    public Rigidbody playerRigidbody;
    //이동 속력 변수
    public float speed = 8f;

    void Start()
    {
        // 반복 재생 메서드 > 한프레임당 한번씩. 즉, 1/60에 한번
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
