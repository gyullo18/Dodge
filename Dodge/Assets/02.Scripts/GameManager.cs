using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI�� ������ ���� - ���� ���̺귯��.
using UnityEngine.UI;
// Scene ���� ���̺귯��.
using UnityEngine.SceneManagement;

// 1. ���ӿ��� ����
// 2. �����ð� ����
// 3. ���ӿ��� �ؽ�Ʈ ���� ���� UI����
// 4. ���ӿ��� �� ������ϴ� ���

public class GameManager : MonoBehaviour
{
    // ���ӿ����� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public GameObject gameOverText;
    // �����ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text timeText;
    // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;

    // ���� �����ð��� ��Ƶ� ����
    private float surviveTime;
    // ���ӿ��� ���� -- �׾����� true, ������� false.
    private bool isGameover;




    void Start()
    {
        // ���� �����ð� �� ���ӿ��� ���� �ʱ�ȭ
        surviveTime = 0f;
        isGameover = false;
    }

    void Update()
    {
        // ���ӿ����� �ƴ� ���� -- false�� �ƴ϶��
        if(!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText ������Ʈ�� text�ʵ带 �̿��� ǥ��
            timeText.text = "Time :" + (int)surviveTime;
            //timeText.text = "" + (int)surviveTime;
            //timeText.text = surviveTime.ToString();
        }
    }

    // ���ο� �޼��� - ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame ()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        
        // ���ӿ��� �ؽ�Ʈ Ȱ��ȭ

    }
}
