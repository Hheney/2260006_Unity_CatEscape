using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;   //UI 관련 네임스페이스를 추가하는 역할
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class GameDirector : MonoBehaviour
{
    /*
     * HpGauge Image Object를 저장할 멤버 변수
     * 감독 스크립트를 사용해 HP 게이지를 갱신하려면 감독 스크립트가 HP 게이지의 실체를 조작할 수 있어야 함
     * 그러기 위해서 Object 변수를 선언해서 HpGauge Image Object를 저장
     */
    GameObject gHpGauge = null;
    GameObject gRestartButton = null;
    GameObject gTextGameover = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
         * HpGauge 오브젝트 찾기
         * 씬 안에서 오브젝트를 찾는 메소드 : Find
         * Find 메소드는 오브젝트 이름을 인수로 전달하고, 인수 이름이 씬에 존재하면 해당 오브젝트를 반환
         * 플레이어의 좌표를 구하기 위해서 플레이어를 검색하여 오브젝트 변수에 저장
         * 각 오브젝트 상자에 대등하는 오브젝트를 씬 안에서 찾아 넣어야 함
         */
        gHpGauge = GameObject.Find("hpgauge");

        //불러오기
        gRestartButton = GameObject.Find("RestartButton");  //재시작 버튼 오브젝트
        gTextGameover = GameObject.Find("TextGameover");    //게임오버 문구 오브젝트

        //비활성화
        gRestartButton.SetActive(false);    //게임 시작시 재시작 버튼 비활성화
        gTextGameover.SetActive(false);     //게임 시작시 게임 오버 문구 비활성화

    }

    // Update is called once per frame
    void Update()
    {
        
    }

         /*
         * 나중에 화살 컨트롤러에서 HP 게이지 표시를 줄이는 처리를 호출할 것을 고려해
         * HP 게이지의 처리는 public 메소드를 작성
         * 화살과 플레이어가 충돌했을 때 화살 컨트롤러가 f_DecreaseHp() 메소드를 호출함
         * 메소드의 기능은 화살과 플레이어가 충돌했을 때 Image 오브젝트(hpGauge)의 fillAmount를 줄여
         * Hp게이지를 표시하는 비율을 10% 낮춤
         */
    public void f_DecreaseHp()
    {
        /*
         * 유니티 오브젝트는 GameObject라는 빈 상자에 설정 자료(컴포넌트)를 추가해서 기느을 확장함
         * 예 : 오브젝트를 물리적으로 움직이게 하려면 Rigidbody 컴퍼넌트 추가
         * 예 : 소리를 내게 하려면 AudioSource 컴포넌트 추가
         * 예 : 자체 기능을 늘리고 싶다면 스크립트 컴포넌트를 추가함
         * 컴포넌트 접근 방법 : GetComponent<>()
         * GetComponent는 게임 오브젝트에 대해'XX 컴포넌트를 주세요'라고 부탁하면,
         * 해당되는 컴포넌트(기능)을 돌려주는 메소드
         * 예 : AudioSource 컴포넌트를 원하면 → GetComponent<AudioSource>()
         * 예 : Text 컴포넌트를 원하면 → GetComponent<Text>()
         * 예 : 직접 만든 스크립트도 컴포넌트의 일종이므로 GetComponent 메소드를 사용해서 구할 수 있음
         * 
         * 화살과 플레이어가 충돌했을 때 Image 오브젝트(HpGauge)의 fillAmount를 줄여
         * HP 게이지를 표시하는 비율을 10% 낮춤
         */
        gHpGauge.GetComponent<Image>().fillAmount -= 0.1f;

        //1번 방식(씬 전환)
        /*
        if (gHpGauge.GetComponent<Image>().fillAmount == 0.0f)
        {
            SceneManager.LoadScene("EndScene");
        }
        */
        
        //2번 방식(시간을 멈춤)
        if (gHpGauge.GetComponent<Image>().fillAmount == 0.0f)
        {
            f_GameOver();
        }
    }

    //SetActive or Behaviour.enabled

    /*
     * [Unity Manual]
     * Time Class
     * time : 프로젝트 재생 시작 후 경과한 시간 초 단위로 반환합니다.
     * deltaTime : 마지막 프레임이 완료된 후 경과한 시간을 초 단위로 반환합니다. 
     *             이 값은 게임이나 앱이 실행될 때 초당 프레임(FPS) 속도에 따라 다릅니다.
     */


    //플레이어의 체력이 0이되면 게임을 멈추고, 게임 오버 문구와 재시작 버튼을 띄우는 메소드
    void f_GameOver()
    {
        Time.timeScale = 0.0f; //게임 내 시간흐름 멈춤

        gTextGameover.SetActive(true);  //게임 오버 문구 활성화
        gRestartButton.SetActive(true); //재시작 버튼 문구 활성화
    }

    //게임 재시작 버튼 기능을 위한 메소드, 게임의 시간을 다시 흐르게 하고 게임씬을 다시 불러온다.
    //OnClick 사용을 위한 public 접근 제어
    public void f_GameRestart()
    {
        Time.timeScale = 1.0f; //게임 내 시간흐름

        SceneManager.LoadScene("GameScene"); //게임 씬 재로드
    }
}
