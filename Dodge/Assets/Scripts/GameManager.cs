using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI ���� ���̺귯��
using UnityEngine.SceneManagement;  // �� ���� ���� ���̺귯��

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText; // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime; // ���� �ð�
    private bool isGameover; // ���ӿ��� ����

    // Start is called before the first frame update
    void Start()
    {
        // ���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ���ӿ����� �ƴ� ����
        if(!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            // ���ӿ��� ���¿��� R Ű�� ���� ���
            if(Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene ���� �ε�
                // SceneManger.LoadScene(0);    - SampleScene ���� ���� ������ 0�̱� ������ �̿� ���� �ڵ带 �ۼ��ص� ��.
                SceneManager.LoadScene("SampleScene");

            }
        }
    }

    // ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    // PlayerController ��ũ��Ʈ���� GameManager ������Ʈ�� �����Ͽ� EndGame() �޼��带 �����ϵ��� public���� ����
    public void EndGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        /*
            NOTE. PlayerPrefs
            
            - � ��ġ�� ����(���α׷��� ���� ���� ���� ��ǻ��)�� �����ϰ� ���߿� �ҷ����� �޼��带 �����ϴ� ����Ƽ�� ����� Ŭ����
            - Key-Value ������ �����͸� ���ÿ� ����
            # PlayerPrefs.SetFloat(string key, float value);
            - float ���� �����ϴ� �޼���
            # PlayerPrefs.GetFloat(string key);
            - ����� ���� �ҷ����� �޼���

            CAUTION. SetInt(), GetInt(), SetString(), GetString()
            - float �ܿ��� int�� string�� �����ϰ� ������ �� ����.
            - �־��� Ű�� ����� ���� �������� �ʴ� ��� �� ����Ʈ���� ��ȯ
            �� GetInt(), GetFloat() ����Ʈ�� = 0, GetString() ����Ʈ�� = ""  
        */
        // BestTime Ű�� ������ ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if(surviveTime > bestTime)
        {
            // �ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;
            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // �ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recordText.text = "Best Time: " + (int)bestTime;
    }
    
    
}
