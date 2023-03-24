using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // UI�� ����Ϸ��� �� ������ ������� �մϴ�.

public class UIManager : MonoBehaviour
{
    // �츮�� ��ũ��Ʈ�� �ۼ��ϴ� ����, ��� ������Ʈ������ ����ϰ� ���� ������Ʈ�� ���� �� �ֽ��ϴ�.
    public static UIManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    [Header("HP�� ǥ���� �̹���")]
    public Image image_HP;
    [Header("�ð��� ǥ���� �ؽ�Ʈ")]
    public Text text_Timer;
    [Header("���� ���� UI")]
    public GameObject ui_GameOver;

    public void SetTimer(int value)             // Ÿ�̸� UI�� �ش� ������ ǥ���մϴ�.
    {
        if (text_Timer != null)
        {
            text_Timer.text = $"{value}";
        }
    }

    public void SetHP(int nowHP, int maxHP)     // HP UI�� �ش� ������ ǥ���մϴ�.
    {
        if (image_HP != null)
        {
            image_HP.fillAmount = (float)nowHP / maxHP;
        }
    }

    public void SetGameOver()
    {
        if(ui_GameOver != null)
        {
            ui_GameOver.SetActive(true);
        }
    }

}
