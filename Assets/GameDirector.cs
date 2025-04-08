using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;   //UI ���� ���ӽ����̽��� �߰��ϴ� ����
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class GameDirector : MonoBehaviour
{
    /*
     * HpGauge Image Object�� ������ ��� ����
     * ���� ��ũ��Ʈ�� ����� HP �������� �����Ϸ��� ���� ��ũ��Ʈ�� HP �������� ��ü�� ������ �� �־�� ��
     * �׷��� ���ؼ� Object ������ �����ؼ� HpGauge Image Object�� ����
     */
    GameObject gHpGauge = null;
    GameObject gRestartButton = null;
    GameObject gTextGameover = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
         * HpGauge ������Ʈ ã��
         * �� �ȿ��� ������Ʈ�� ã�� �޼ҵ� : Find
         * Find �޼ҵ�� ������Ʈ �̸��� �μ��� �����ϰ�, �μ� �̸��� ���� �����ϸ� �ش� ������Ʈ�� ��ȯ
         * �÷��̾��� ��ǥ�� ���ϱ� ���ؼ� �÷��̾ �˻��Ͽ� ������Ʈ ������ ����
         * �� ������Ʈ ���ڿ� ����ϴ� ������Ʈ�� �� �ȿ��� ã�� �־�� ��
         */
        gHpGauge = GameObject.Find("hpgauge");

        //�ҷ�����
        gRestartButton = GameObject.Find("RestartButton");  //����� ��ư ������Ʈ
        gTextGameover = GameObject.Find("TextGameover");    //���ӿ��� ���� ������Ʈ

        //��Ȱ��ȭ
        gRestartButton.SetActive(false);    //���� ���۽� ����� ��ư ��Ȱ��ȭ
        gTextGameover.SetActive(false);     //���� ���۽� ���� ���� ���� ��Ȱ��ȭ

    }

    // Update is called once per frame
    void Update()
    {
        
    }

         /*
         * ���߿� ȭ�� ��Ʈ�ѷ����� HP ������ ǥ�ø� ���̴� ó���� ȣ���� ���� �����
         * HP �������� ó���� public �޼ҵ带 �ۼ�
         * ȭ��� �÷��̾ �浹���� �� ȭ�� ��Ʈ�ѷ��� f_DecreaseHp() �޼ҵ带 ȣ����
         * �޼ҵ��� ����� ȭ��� �÷��̾ �浹���� �� Image ������Ʈ(hpGauge)�� fillAmount�� �ٿ�
         * Hp�������� ǥ���ϴ� ������ 10% ����
         */
    public void f_DecreaseHp()
    {
        /*
         * ����Ƽ ������Ʈ�� GameObject��� �� ���ڿ� ���� �ڷ�(������Ʈ)�� �߰��ؼ� ����� Ȯ����
         * �� : ������Ʈ�� ���������� �����̰� �Ϸ��� Rigidbody ���۳�Ʈ �߰�
         * �� : �Ҹ��� ���� �Ϸ��� AudioSource ������Ʈ �߰�
         * �� : ��ü ����� �ø��� �ʹٸ� ��ũ��Ʈ ������Ʈ�� �߰���
         * ������Ʈ ���� ��� : GetComponent<>()
         * GetComponent�� ���� ������Ʈ�� ����'XX ������Ʈ�� �ּ���'��� ��Ź�ϸ�,
         * �ش�Ǵ� ������Ʈ(���)�� �����ִ� �޼ҵ�
         * �� : AudioSource ������Ʈ�� ���ϸ� �� GetComponent<AudioSource>()
         * �� : Text ������Ʈ�� ���ϸ� �� GetComponent<Text>()
         * �� : ���� ���� ��ũ��Ʈ�� ������Ʈ�� �����̹Ƿ� GetComponent �޼ҵ带 ����ؼ� ���� �� ����
         * 
         * ȭ��� �÷��̾ �浹���� �� Image ������Ʈ(HpGauge)�� fillAmount�� �ٿ�
         * HP �������� ǥ���ϴ� ������ 10% ����
         */
        gHpGauge.GetComponent<Image>().fillAmount -= 0.1f;

        //1�� ���(�� ��ȯ)
        /*
        if (gHpGauge.GetComponent<Image>().fillAmount == 0.0f)
        {
            SceneManager.LoadScene("EndScene");
        }
        */
        
        //2�� ���(�ð��� ����)
        if (gHpGauge.GetComponent<Image>().fillAmount == 0.0f)
        {
            f_GameOver();
        }
    }

    //SetActive or Behaviour.enabled

    /*
     * [Unity Manual]
     * Time Class
     * time : ������Ʈ ��� ���� �� ����� �ð� �� ������ ��ȯ�մϴ�.
     * deltaTime : ������ �������� �Ϸ�� �� ����� �ð��� �� ������ ��ȯ�մϴ�. 
     *             �� ���� �����̳� ���� ����� �� �ʴ� ������(FPS) �ӵ��� ���� �ٸ��ϴ�.
     */


    //�÷��̾��� ü���� 0�̵Ǹ� ������ ���߰�, ���� ���� ������ ����� ��ư�� ���� �޼ҵ�
    void f_GameOver()
    {
        Time.timeScale = 0.0f; //���� �� �ð��帧 ����

        gTextGameover.SetActive(true);  //���� ���� ���� Ȱ��ȭ
        gRestartButton.SetActive(true); //����� ��ư ���� Ȱ��ȭ
    }

    //���� ����� ��ư ����� ���� �޼ҵ�, ������ �ð��� �ٽ� �帣�� �ϰ� ���Ӿ��� �ٽ� �ҷ��´�.
    //OnClick ����� ���� public ���� ����
    public void f_GameRestart()
    {
        Time.timeScale = 1.0f; //���� �� �ð��帧

        SceneManager.LoadScene("GameScene"); //���� �� ��ε�
    }
}
