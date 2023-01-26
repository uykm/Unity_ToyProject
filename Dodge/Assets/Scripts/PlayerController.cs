using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    PlayerController ��ũ��Ʈ ����
    1. ������ ���ӿ� ��� �ݿ� X
    : ���� �߰��ϴ� AddForce() �޼��带 ����ؼ� ������ ������ �ӵ��� ���������� ������Ű�� ������, �ӵ��� ������ ������ �ð��� �ɸ�.
    �������� ���� ���� ���Ǿ� ���� ��ȯ�� �ݹ� �̷������ ����.
    2. �Է� ���� �ڵ尡 ������.
    : ����Ű�� �����ϴ� �ڵ带 �����ϰ� ����
    3. playerRigidbody�� ������Ʈ�� �巡��&������� �Ҵ��ϴ� ���� ������.
    : ������ ������Ʈ�� ������ �Ҵ��ϴ� ������ �ڵ�� ����.
*/
public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;   // �̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f;    // �̵� �ӷ�

    /*
        NOTE. GetComponent() �޼���
        # GetCompent<���ϴ� Ÿ��>();
        - ���ϴ� Ÿ���� ������Ʈ�� �ڽ��� ���� ������Ʈ���� ã�ƿ��� �޼���
        # ���׸�(Generic) ���
        - ���� <>, �ż��峪 Ŭ������ ���� Ÿ�Կ� ȣȯ�ǰ� ��.
    */
    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playerRigidbody �� �Ҵ� (3)
        playerRigidbody = GetComponent<Rigidbody>();
    }

    /*  
        NOTE. KeyCode

        # KeyCode : Ű������ Ű �ĺ��ڸ� ���� ����Ű�� ���� Ÿ��
        - KeyCode Ÿ���� ���������� ���ڷ� ����
        - ���ڷ� �� Ű �ĺ��ڸ� ��� �ܿ�� ���� �Ұ��� -> ���� ����Ű�� �ĺ���(273) X => KeyCode.UpArrow ���


        NOTE. Input.GetKey() �迭 �޼���

        - Ű������ �ĺ��ڸ� KeyCode Ÿ������ �Է¹���.
        - bool Input.Getkey(KeyCode key);
        # Input.GetKey() �޼���     : �ش� Ű�� '������ ����' true, �� �ܿ��� false ��ȯ
        # Input.GetKeyDown() �޼��� : �ش� Ű�� '������ ����' true, �� �ܿ��� false ��ȯ
    */


    void Update()   // Update() �޼���� 1�ʿ� ���� ���� �����.
    {
        /* 
        1. ������ ���ӿ� ��� �ݿ� X
        2. �Է� ���� �ڵ尡 ������.

        // ����Ƽ�� Input Ŭ���� - ������� �Է��� �����ϴ� �޼��带 ��Ƶ� ����
        if(Input.GetKey(KeyCode.UpArrow) == true)
        {   // ���� ����Ű �Է��� ������ ��� z �������� �� �ֱ�
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if(Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        */
        /*
            �� Input.Get(Ư�� Ű �Է�)�� ����� ���
            - ���� Ű�� �ٲ� ������ �Ź� �ڵ带 �����ϰ� �ٽ� �����ؾ� �� �� �̶� '�Է� �̸�'�� ���� ���� ����� ��� !

            NOTE. �Է� �̸�
            # �Է� �̸� �� [���� Ű]
            ex) 
            ���� ��) �߻� �� [���콺 ���� ��ư]
            ���� ��) �߻� �� [���콺 ������ ��ư]

            �� �ڵ�
            ���� ��)   if (���콺 ���� ��ư�� ����)
                       {
                            // �߻�
                       }
            ���� ��)   if ("�߻�"�� �����Ǵ� ��ư�� ����)
                       {
                            // �߻�
                       }
            
            �� ���� : �ڵ� (���� �߻� ���) �� �Է� �̸� ("�߻�") �� �Է� ��ġ (���콺 ���� ��ư)
            
            ����Ƽ���� ����ϴ� ��(Axis) => "�Է� �̸�"
            �� ���� �࿡ �����ϴ� ��ư�� ������ ������. 
            �� ���� ���� ����ϸ� ����� �Է�Ű�� ���� ����� �ʿ� X
            # �Է� �Ŵ��� - �� ���� ���
        */
        /*
            NOTE. GetAxis() �޼���
            # Input.GetAxis();
            - � �࿡ ���� �Է°��� ���ڷ� ��ȯ�ϴ� �޼��� 
            - ���ڷ� ��ȯ���� ���� ���� 
            : ���̽�ƽ ���� �پ��� �Է� ��ġ�� ���� ����
            ex) ���� �е��� �Ƴ��α� ��ƽ�� �̴� ���� ���� ���� ���̸� �߻���Ŵ
                * ��ƽ�� �������� ������ �б�   : -1.0
                * ��ƽ�� ������ ������ �α�     : 0
                * ��ƽ�� ���������� ������ �б� : +1.0 
                �� ��ƽ�� �������� '��¦' �о��� ��� �� -0.5 ������ ���� �� ����.

            �� Horizontal(����) ���� ���
                * Horizontal �࿡ �����Ǵ� Ű
                    - ���� ���� : ��(���� ����Ű), A Ű
                    - ���� ���� : ��(������ ����Ű), DŰ
                * Input.GetAxis("Horizontal")�� ��°�
                    - �� �Ǵ� A Ű�� ����  : -1.0
                    - �ƹ��͵� ������ ���� : 0
                    - �� �Ǵ� D Ű�� ����  : +1.0

            �� Vertical(����) ���� ���
                * Vertical �࿡ �����Ǵ� Ű
                    - ���� ���� : ��(�Ʒ��� ����Ű), S Ű
                    - ���� ���� : ��(���� ����Ű), W Ű
                * Input.GetAxis("Vertical")�� ��°�
                    - �� �Ǵ� S Ű�� ����  : -1.0
                    - �ƹ��͵� ������ ���� : 0
                    - �� �Ǵ� W Ű�� ����  : +1.0
        */
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");         // Input.GetKey() ��� Input.GetAxis() �޼��� ����
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;  // ���� ���� �̵� �ӵ�
        float zSpeed = zInput * speed;  // ���� ���� �̵� �ӵ�
        
        /*
            NOTE. Vector3
            # Vector3 vector = new Vector3(x, y, z);
            - ���� x, y, z �� ������ Ÿ��
            - ��ġ, ũ��, �ӵ�, ���� ���� ��Ÿ�� �� �ַ� ���
        */
        // Vector3 ���� newVeolocity�� (xSpeed, 0 , zSpeed)�� ����
        // newVelocity : X, Y, Z ���������� �ӵ��� Ÿ������ ���� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        /*
            NOTE. velocity
            - Rigidbody�� ����
            - velocity ������ ���ο� ���� �Ҵ��ϸ�, ���� ���� "�����" ���ο� ������ "����"��. (������ ���� X)
            �� AddForce() �޼��� : ���� �����ϰ� �ӷ��� ���������� ������Ŵ. (������ ���� O)
        */
        // ������ٵ��� �ӵ�(velocity)�� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;
    }

    // CATUTION. gameObject�� GameObject
    // gameObject - ����, GameObject - Ÿ��
    
    // ��� ���� ������Ʈ�� �����θ� ���� �Ѵ� ����� ���� ����.
    /*
        NOTE. SetActive()

        - ���� ������Ʈ�� ��Ÿ���� GameObject Ÿ�Կ� ����Ǿ� �ִ� �޼���
        - void SetActive(bool value);
    */
    public void Die()
    {
        // 1) gameObject�� ����� �ڽ��� ���� ������Ʈ�� ����
        // 2) ������ ���� ������Ʈ�� SetActive(false); �� ����
        gameObject.SetActive(false);

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        // ������ GameManager ������Ʈ�� EndGame() �޼��� ����
        gameManager.EndGame();
    }
}