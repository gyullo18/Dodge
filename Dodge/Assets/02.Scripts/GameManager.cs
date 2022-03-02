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
        else
        {
            // ** 던전에서 필드로 나갈때도 이용 **
            // private void OnTriggerEnter(Collider other) 
            // if(other.tag == "Field"){
            // SceneManager.LoadScene("Field")}
            // 게임 오버인 상태에서 "space"키를 누른다면,
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                // 게임 재시작 = SampleScene 씬을 리로드.
                SceneManager.LoadScene("SampleScene");
                //SceneManager.LoadScene(0); -- Build Setting > Scenes In Build의 index 번호
            }
        }
    }

    // 새로운 메서드 - 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame ()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameover = true;

        // 게임오버 텍스트 게임 오브젝트 활성화 - () : 체크박스
        gameOverText.SetActive(true);

        //// 오브젝트 내의 컴포넌트인 타임 텍스트 활성화 - 필드(변수)
        //timeText.enabled = true;

        // 기록을 데이터로 저장하는 방법
        // PlayerPrefs(Player Preference) -- key : value 형태로 저장.
        // value 형태에 따라 달라짐 -- 문자열, 정수형, 소수형
        // Get -- 값을 읽어온다 - 가져온다
        // Set -- 값을 쓴다.
        // ex)돈 : 1000원을 데이터 저장
        // PlayerPrefs.SetInt("Money", 1000);
        // ex2) 닉네임
        // PlayerPrefs.SetString("Nick", "5징");
        // 데이터 가져오기
        // Debug.Log(PlayerPrefs.GetInt("Money"));
        // Debug.Log(PlayerPrefs.GetString("Nick"));
        // 폴더안에 데이터 파일로 생성.(오프라인 저장 방식)

        // 'BestTime'키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록과 현재 생존 시간 비교
        if(bestTime < surviveTime)
        {
            // 최고 기록 값을 현재 생존 시간 값으로 변경.
            bestTime = surviveTime;
            // 변경된 최고 기록을 'bestTime' 키로 저장.
            PlayerPrefs.SetFloat("BestTime", bestTime);

        }

        // 최고기록을 recordText 컴포넌트에 표시.
        recordText.text = "BestTime :" + (int)bestTime;
    }
}
