using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    /*
        NOTE. Prefab
        
        # Prefab[������] : �̹� ���� ������Ʈ�� ������ �ϼ���, ���� ������ Game Object�� �ǹ�
    */
    public GameObject bulletPrefab;     // ź���� �����ϴ� �� ����� ���� ������
    public float spawnRateMin = 0.5f;   // �� ź���� �����ϴµ� �ɸ��� �ð��� �ּڰ�
    public float spawnRateMax = 3f;     // �� ź���� �����ϴµ� �ɸ��� �ð��� �ִ�

    private Transform target;           // ������ ��� ���� ������Ʈ�� Ʈ������ ������Ʈ
    private float spawnRate;            // ���� ź���� ������ ������ ��ٸ� �ð� (spawnRateMin�� spawnRateMax ������ ���������� ����)
    private float timeAfterSpawn;       // ������ ź�� ���� �������� �帥 �ð��� ǥ���ϴ� 'Ÿ�̸�'

    // Start is called before the first frame update
    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;

        /*
            NOTE. Random.Range()
            
            - float�� �Է¹��� ���� int�� �Է¹��� ���� ������ �ٸ�.
            # Random.Range(0, 3)   : 0, 1, 2 �߿� �ϳ��� int ������ ��µ�
            # Random.Range(0f, 3f) : 0f���� 3f ������ float ���� ��µ� (ex - 0.5f)
        */
        // ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        /*
            NOTE. FindObjectOfType() �޼���

            # FindObjcetOfType<Ÿ��>() : ���� <>�� � Ÿ���� ����ϸ� ���� �ִ� ��� ������Ʈ�� �˻��ؼ� �ش� Ÿ���� ������Ʈ�� ������.
            
            CAUTION. FindObjectOfType() �޼����� ó�����
            - ���� �����ϴ� ��� ������Ʈ�� �˻��Ͽ� ���ϴ� Ÿ���� ������Ʈ�� ã�� ������ ó�� ����� ŭ
            �� �ݵ�� Start() �޼���ó�� �ʱ⿡ �ѵ� �� ����Ǵ� �޼��忡���� ��� !

            CAUTION. FindObjectsOfType() �޼���
            # FindObjectOfType()  : �ش� Ÿ���� ������Ʈ�� �ϳ��� ã��.
            # FindObjectsOfType() : �ش� Ÿ���� ������Ʈ�� ��� ã�� �迭�� ��ȯ��.
        */
        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindObjectOfType <PlayerController>().transform;   
        // �� �ڵ�� �Ʒ� �� ���� �ڵ带 �� �ٷ� �ۼ��� �ڵ�    : �ش� ������Ʈ�� ���� ���� ������Ʈ�� Ʈ���� �� ������Ʈ�� transform���� �����Ͽ� target�� �Ҵ�
        // PlayerController playerController = FindObjectOfType<PlayerController>();
        // target = playerController.trasform
    }

    // Update is called once per frame
    void Update()   // ��ǻ�� ���ɿ� ���� �ʴ� �����Ӹ�ŭ �����.
    {
        /*
            NOTE. ���� ���� Time.deltaTime 

            # Time.deltaTime : ���� �����Ӱ� ���� ������ ������ �ð� ������ �ڵ����� �Ҵ��.
            ex) 1�ʿ� 60�������� �ӵ��� ȭ���� �����ϴ� ��ǻ�� �� Time.deltaTime �� ��  = 1/60 
            - �ʴ� �������� ��ǻ�� ���ɿ� ���� �޶����� ������, 
              Update() ���� ������ �ð� ������ �˱� ���� �������� ����.
            �� � ������ Time.deltaTime ���� ��� �����ϸ� Ư�� �������κ��� �ð��� �󸶳� �귶���� ǥ�� ���� !

            
            NOTE. Instantiate() �޼���

            # Instantiate(���� ������Ʈ) : ���� ������Ʈ�� ������ ���ο� ������Ʈ�� ������. (�ν��Ͻ� - �������κ��� ���� ������ ������Ʈ)
            # Instantiate(����, ��ġ, ȸ��) : �������� ������ ��ġ�� ȸ���� ����
            - ���� ���߿� �ǽð����� ������Ʈ�� ������ �� ��� !
            �� �������� �����ϰ�, ���ÿ� ������ ������ �޼��� ������� ��ȯ
        */
        // timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if(timeAfterSpawn >= spawnRate)
        {
            // ������ �ð��� ����
            timeAfterSpawn = 0f;

            // bulletPrefab�� ��������
            // transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            /*
                NOTE. Lookat() �޼���
                
                # LookAt() : �Է¹��� Ʈ�������� ���� ������Ʈ�� �ٶ󺸵��� �ڽ��� Ʈ������ ȸ���� ����
             */
            // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            // ������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
