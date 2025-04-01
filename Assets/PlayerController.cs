using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float fMaxPosition = 10.0f; //�÷��̾ ��, �� �̵��� ����â�� ����� �ʵ��� Vector �ִ밪 ���� ����
    [SerializeField] float fMinPosition = -10.0f; //�÷��̾ ��, �� �̵��� ����â�� ����� �ʵ��� Vector �ּҰ� ���� ����
    float fPositionX = 0.0f; 

    //git

    //private ���������ڸ� ������� �ʾƵ� �⺻������ private ���������� ������ �ǹ̸� �ٽ��ѹ� ����Ű�� ���� ���
    /*
    private float fLimitXPosRange = 0.0f;   //X��ǥ�� ���� ���� ����
    private const float fMinPosX = -10.5f;      //X��ǥ�� �ּҰ� ���
    private const float fMaxPosX = 10.5f;       //X��ǥ�� �ִ밪 ���
    private const float fGroundPosY = -3.6f;    //���� y��ǥ�� ���
    */

    /*
     * Start �޼ҵ�
     * �̸� ���ǵ� Ư�� �̺�Ʈ �Լ��μ�, �� Ư�� �Լ����� C#������ �Լ��� �޼ҵ��� ��
     * MonoBehaviour Ŭ������ �ʱ�ȭ �� �� ȣ��Ǵ� �̺�Ʈ �Լ�
     * ���α׷��� ������ �� �� ���� ȣ���� �Ǵ� �Լ��� ���� ������Ʈ�� �޾ƿ��ų� ������Ʈ�� �ٸ� �Լ����� ����ϱ� ���� �ʱ�ȭ ���ִ� ���
     * ��, Start() �޼ҵ�� ��ũ��Ʈ �ν��Ͻ��� Ȱ��ȭ�� ��쿡�� ù ��° ������ ������Ʈ ���� ȣ���ϹǷ� �� ���� ����
     * �� ���¿� ���Ե� ��� ������Ʈ�� ���� Update�� �� ���� ȣ��� ��� ��ũ��Ʈ�� ���� Start �Լ��� ȣ��
     * ���� �����÷��� ���� ������Ʈ�� �ν��Ͻ�ȭ�� ���� ������� ����
     */
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
         * ����̽� ���ɿ� ���� ���� ����� ���� ���ֱ�
         * � ������ ��ǻ�Ϳ��� �����ص� ���� �ӵ��� �����̵��� �ϴ� ó��
         * ����Ʈ���� 60, ����� PC�� 300�� �� �� �ִ� ����̽� ���ɿ� ���� ���� ���ۿ� ������ ��ĥ �� ����
         * �����ӷ���Ʈ�� 60���� ����
         */
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Ű�� �������� �����ϱ� ���ؼ��� Input Ŭ������ GetKeyDown �޼ҵ带 �����
         * �� �޼ҵ�� �Ű������� ������ Ű�� ������ ���� true�� �� �� ��ȯ�Ѵ�.
         * GetKeyDown �޼ҵ�� ���ݱ��� ����ϴ� GetMouseButtonDown �޼ҵ�� ����ϹǷ� ���� ������ �� ���� ��
         * Ű�� ���� ���� : GetKeyDown()
         * Ű�� ������ �ִ� ���� : GetKey()
         * Ű�� �����ٰ� �� ���� : GetKeyUp()
         */

        //���� ȭ��ǥ Ű�� ������ �� �� Input.GetKeyDown(KeyCode.LeftArrow)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Translate �޼ҵ� : ������Ʈ�� ���� ��ǥ���� �μ� ����ŭ �̵���Ű�� �޼ҵ�
            transform.Translate(-2, 0, 0); //�������� -3��ŭ �̵�
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(2, 0, 0); //���������� 3��ŭ �̵�
        }

        /*
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 3, 0); //���� 3��ŭ �̵�
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -3, 0); //�Ʒ��� 3��ŭ �̵�
        }*/


        /*
         * Mathf.Clamp(value, min, max) �޼ҵ�
         * Ư�� ���� ��� ������ ���ѽ�Ű���� �� �� ����ϴ� �޼ҵ�
         * value ���� ���� : min <= value <= max
         * �ּ�/�ִ밪�� �����Ͽ� ������ ���� �̿��� ���� ���� �ʵ��� �� �� ���
         * �÷��̾ ������ �� �ִ� �ּ�(fMinPositionX) / �ִ�(fMaxPostionX) �������� �����Ͽ� �� ������ ����� �ʵ����Ѵ�.
         */

        fPositionX = Mathf.Clamp(transform.position.x, fMinPosition, fMaxPosition);
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);

        /*
        //Clamp �޼ҵ带 ����ϸ� �Ű������� �Ű������� ������ fMinPosX, fMaxPosX ���������� return ���� ���ѵȴ�.
        fLimitXPosRange = Mathf.Clamp(transform.position.x, fMinPosX, fMaxPosX);

        transform.position = new Vector2(fLimitXPosRange, fGroundPosY);
        */
    }
}
