using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI를 만지기 위함 - 관련 라이브러리.
using UnityEngine.UI;
// Scene 관련 라이브러리.
using UnityEngine.SceneManagement;

// 1. 게임오버 상태
// 2. 생존시간 갱신
// 3. 게임오버 텍스트 같은 게임 UI갱신
// 4. 게임오버 시 재시작하는 기능

public class GameManager : MonoBehaviour
{
    // 게임오버시 활성화할 텍스트 게임 오브젝트
    public GameObject gameOverText;
    // 생존시간을 표시할 텍스트 컴포넌트
    public Text timeText;
    // 최고 기록을 표시할 텍스트 컴포넌트
    public Text recordText;

    // 실제 생존시간을 담아둘 변수
    private float surviveTime;
    // 게임오버 상태 -- 죽었으면 true, 살았으면 false.
    private bool isGameover;




    void Start()
    {
        // 실제 생존시간 및 게임오버 상태 초기화
        surviveTime = 0f;
        isGameover = false;
    }

    void Update()
    {
        // 게임오버가 아닌 동안 -- false가 아니라면
        if(!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 컴포넌트의 text필드를 이용해 표시
            timeText.text = "Time :" + (int)surviveTime;
            //timeText.text = "" + (int)surviveTime;
            //timeText.text = surviveTime.ToString();
        }
    }

    // 새로운 메서드 - 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame ()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameover = true;
        
        // 게임오버 텍스트 활성화

    }
}
