using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;   //UI 관련 네임스페이스를 추가하는 역할
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    /*
     * HpGauge Image Object를 저장할 멤버 변수
     * 감독 스크립트를 사용해 HP 게이지를 갱신하려면 감독 스크립트가 HP 게이지의 실체를 조작할 수 있어야 함
     * 그러기 위해서 Object 변수를 선언해서 HpGauge Image Object를 저장
     */
    GameObject gHpGauge = null;
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

        if (gHpGauge.GetComponent<Image>().fillAmount == 0.0f)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
