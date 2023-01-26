using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI 관련 라이브러리
using UnityEngine.SceneManagement;  // 씬 관리 관련 라이브러리

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트

    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임오버 상태

    // Start is called before the first frame update
    void Start()
    {
        // 생존 시간과 게임오버 상태 초기화
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 게임오버가 아닌 동안
        if(!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            // 게임오버 상태에서 R 키를 누른 경우
            if(Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene 씬을 로드
                // SceneManger.LoadScene(0);    - SampleScene 씬은 빌드 순법이 0이기 때문에 이와 같은 코드를 작성해도 됨.
                SceneManager.LoadScene("SampleScene");

            }
        }
    }

    // 현재 게임을 게임오버 상태로 변경하는 메서드
    // PlayerController 스크립트에서 GameManager 컴포넌트로 접근하여 EndGame() 메서드를 실행하도록 public으로 지정
    public void EndGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameover = true;
        // 게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        /*
            NOTE. PlayerPrefs
            
            - 어떤 수치를 로컬(프로그램을 실행 중인 현재 컴퓨터)에 저장하고 나중에 불러오는 메서드를 제공하는 유니티에 내장된 클래스
            - Key-Value 단위로 데이터를 로컬에 저장
            # PlayerPrefs.SetFloat(string key, float value);
            - float 값을 저장하는 메서드
            # PlayerPrefs.GetFloat(string key);
            - 저장된 값을 불러오는 메서드

            CAUTION. SetInt(), GetInt(), SetString(), GetString()
            - float 외에도 int와 string을 저장하고 가져올 수 있음.
            - 주어진 키로 저장된 값이 존재하지 않는 경우 → 디폴트값을 반환
            ▷ GetInt(), GetFloat() 디폴트값 = 0, GetString() 디폴트값 = ""  
        */
        // BestTime 키로 지정된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if(surviveTime > bestTime)
        {
            // 최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            // 변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        recordText.text = "Best Time: " + (int)bestTime;
    }
    
    
}
