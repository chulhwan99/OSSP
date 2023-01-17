using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리

//MonoBehaviour 클래스는 기본적으로 Unity 스크립트가 상속하는 클래스
public class GameManager : MonoBehaviour {
    public GameObject gameoverText; // 게임오버시 활성화 할 텍스트 게임 오브젝트
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임 오버 상태
    //bulletSpawner 상태를 조절하기 위한 변수
    public GameObject BulletSpawner1; 
    public GameObject BulletSpawner2;
    public GameObject BulletSpawner3;
    public GameObject[] arr;

    //싱글톤 패턴을 위해 인스턴스를 미리 생성하고 가져옴
    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>();
        }

        return instance;
    }
    private static GameManager instance;

    void Start() {
        // 생존 시간과 게임 오버 상태를 초기화
        surviveTime = 0;
        isGameover = false;
    }

    void Update() {
        // 게임 오버가 아닌 동안
        if (!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 통해 표시
            timeText.text = "Time: " + (int) surviveTime;
            //생존시간에 따라서 BulletSpawner를 추가로 배치해서 난이도가 상승하도록 만들어줌
            if(surviveTime > 5){
                BulletSpawner1.SetActive(true);
            }
            if(surviveTime > 14){
                BulletSpawner2.SetActive(true);
            }
            if(surviveTime > 20){
                BulletSpawner3.SetActive(true);
            }
        }
        else
        {
            // 게임 오버인 상태에서 키보드 R키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    //모든 총알을 삭제하는 아이템 함수
    public void destroyItem(){
        //GameObject배열인 arr에 Tag가 Bullet인 GameObject를 배열로 받음
        arr = GameObject.FindGameObjectsWithTag("Bullet");
        //arr 배열에 있는 모든 GameObject를 Destroy함
        for(int i = 0; i < arr.Length; i++){
            Destroy(arr[i]);
        }
        
    }

    // surviveTime에 input값을 더해주는 함수
    public void add_surviveTime(float input) {
        surviveTime += input;
    }

    //surviveTime을 return하는 함수
    public int get_surviveTime() {
        return (int)surviveTime;
    }

    // 현재 게임을 게임 오버 상태로 변경하는 메서드
    public void EndGame() {
        // 현재 상태를 게임 오버 상태로 전환
        isGameover = true;
        // 게임 오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        // BestTime 키로 저장된, 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            // 최고 기록의 값을 현재 생존 시간의 값으로 변경 
            bestTime = surviveTime;
            // 변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 기록을 recordText 텍스트 컴포넌트를 통해 표시
        recordText.text = "Best Time: " + (int) bestTime;
    }
}