using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;    // ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody;  // �̵��� ����� ������ٵ� ������Ʈ
    // Start is called before the first frame update
    void Start()
    {
        // ���� ������Ʈ���� RIgidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        // ������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        /*
            NOTE. transform ����

            # Transform ������Ʈ : ���� ������Ʈ�� ��ġ, ũ��, ȸ���� ����ϴ� ������Ʈ
            - ���ǻ� ����Ƽ�� C# ��ũ��Ʈ���� �ڽ��� ���� ������Ʈ�� Transform ������Ʈ�� �ڵ� �󿡼� transform ������ ��� ���� ����!
            �� Transform ������Ʈ�� GetComponent<Transform>() ���� ����Ͽ� ���� ã�ƿ��� ���� �ʿ� X
            - Transform Ÿ�� transform ������ �ڽ��� ���� ������Ʈ�� Ʈ������ ������Ʈ�� �ٷ� �����ϴ� ����
            # transform.forward  : transform ������ transform ������Ʈ�� �ٷ� ������ ����,
                                  ���� ���� ������Ʈ�� ���� ����(Z�� ����)�� ��Ÿ���� Vector3 Ÿ�� forward ����
                                  (�̶� forward ������ Transform ������Ʈ�� �����ϴ� ���)
            
            CAUTION. Transform - Ÿ��, transfrom - ����
        */
        bulletRigidbody.velocity = transform.forward * speed;

        /*
            NOTE. Destroy() �޼���
            
            # Destory(Object obj);          : ���� ������Ʈ obj�� ��� �ı�
            # Destroy(Object obj, float t); : ���� ������Ʈ obj�� t�� �ڿ� �ı�
        */
        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }
    /*  �浹 �̺�Ʈ �޼���

            NOTE. OnCollision �迭 : �Ϲ� �浹
            
            - �Ϲ����� �ݶ��̴��� ���� �� ���� ������Ʈ�� �浹�� �� �ڵ����� �����.
            - �浹�� �� �ݶ��̴��� �� ������� �ʰ� �о.
            
            # Collition Ÿ�� : �浹 ���� ������ ��Ƶδ� �ܼ��� ���� �����̳�
            - OnCollition �迭 �޼��尡 ����� ���� �޼��� �Է����� �浹 ���� ������ Collision Ÿ������ ����.

            # OnCollisionEnter(Collision collision) : �浹�� ����
            # OnCollisionStay(Collision collision)  : �浹�ϴ� ����
            # OnCollisionExit(Collision collision)  : �浹�ߴٰ� �и��Ǵ� ����
            �� �Է����� ���� collition�� ���� �浹�� ���� ���� ������Ʈ, �浹 ����, �浹 ǥ���� ���� ���� �� �� ����.

            
            NOTE. OnTrigger �迭 : Ʈ���� �浹
            
            - �浹�� �� ���� ������Ʈ�� �ݶ��̴� �� �ּ� �ϳ��� Ʈ���� �ݶ��̴���� �ڵ����� �����.
            - �浹�� �� ���� ������Ʈ�� ���� �״�� �����.
            
            # Collider Ÿ�� : 
            - OnTrigger �迭�� �޼��尡 ����� ���� �޼��� �Է����� �浹�� ���� ���� ������Ʈ�� �ݶ��̴� ������Ʈ�� Collider Ÿ������ ����.
            
            # OnTriggerEnter (Collider other) : �浹�� ����
            # OnTriggerStay (Collider other) : �浹�ϴ� ����
            # OnTriggerExit (Collider other) : �浹�ߴٰ� �и��Ǵ� ����

            - Ʈ���� �浹�� ���θ� �о�� �ʰ� �״�� ����ϱ� ������, �������� �ݹ߷��̳� ��Ȯ�� �浹 ����, ��·� ���� ���� X
            �� �浹�� ���� ���� ������Ʈ(�� �ݶ��̴� ������Ʈ)�� ���� ����.

            CAUTION. OnTrigger �迭�� �޼���� �ڽ��� Ʈ���� �ݶ��̴��� �ƴϴ��� ����
            - �浹�� �� �ݶ��̴� �� �ϳ� �̻��� Ʈ���� �ݶ��̴����, ���� ��ο��� OnCollition�� �ƴ� OnTrigger �迭�� �޼��尡 �����.
        */
    // other - �浹�� ���� ���� ������Ʈ�� �ݶ��̴� ������Ʈ
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            // �������κ��� PlayerController ������Ʈ�� �������� �� ������ ��� (Player ���� ������Ʈ�� PlayerController ��ũ��Ʈ�� ������Ʈ�� �߰��ϱ� ������, �Ǽ��� ����ϱ� ���� if��)
            if (playerController != null)
            {
                // ���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.Die();
            }
        }
    }
}
