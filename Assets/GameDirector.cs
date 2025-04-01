using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;   //UI ���� ���ӽ����̽��� �߰��ϴ� ����

public class GameDirector : MonoBehaviour
{
    /*
     * HpGauge Image Object�� ������ ��� ����
     * ���� ��ũ��Ʈ�� ����� HP �������� �����Ϸ��� ���� ��ũ��Ʈ�� HP �������� ��ü�� ������ �� �־�� ��
     * �׷��� ���ؼ� Object ������ �����ؼ� HpGauge Image Object�� ����
     */
    GameObject gHpGauge = null;
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
    }
}
