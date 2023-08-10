using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    //�������ؽ�Ʈ ������Ʈ
    public GameObject Create1;
    public GameObject Create2;
    public GameObject Create3;
    //���������ؽ�Ʈ ������Ʈ
    public GameObject Ex1;
    public GameObject Ex2;
    public GameObject Ex3;
    //���������ؽ�Ʈ �����ϱ����� ����
    public TMP_Text ExText1;
    public TMP_Text ExText2;
    public TMP_Text ExText3;
    //���� �������÷�
    public GameObject Slot1Color;
    public GameObject Slot2Color;
    public GameObject Slot3Color;
    //���� �ʷϻ��÷�
    public GameObject Slot1ColorMug;
    public GameObject Slot2ColorMug;
    public GameObject Slot3ColorMug;
    //���� ����� ����
    public GameObject Slot1CupHead;
    public GameObject Slot2CupHead;
    public GameObject Slot3CupHead;
    //���� �ӱ��� ����
    public GameObject Slot1CupMug;
    public GameObject Slot2CupMug;
    public GameObject Slot3CupMug;
    //���� �÷��� ���� �ؽ�Ʈ
    public GameObject Slot1choice;
    public GameObject Slot2choice;
    public GameObject Slot3choice;
    //���� ����弱��
    public GameObject Slot1CupHeadChoice;
    public GameObject Slot2CupHeadChoice;
    public GameObject Slot3CupHeadChoice;
    //���� �ӱ��� ����
    public GameObject Slot1CupMugChoice;
    public GameObject Slot2CupMugChoice;
    public GameObject Slot3CupMugChoice;
    //���Ե����� Ȯ�ο� ����
    private bool isEnter1 =false;
    private bool isEnter2 =false;
    private bool isEnter3 =false;
    //1~3���Լ���Ŀ��
    private int cursorNum;
    //���Գ��ο��� �̵��ϴ� 0~1Ŀ��
    private int choiceNum1;
    private int choiceNum2;
    private int choiceNum3;
    //�޴� üũ
    private bool isMenu;
    private bool isChoice;
    //���ѷα� ������Ʈ
    public GameObject Prologue;
    /*public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;*/

    // Start is called before the first frame update
    void Start()
    {
        cursorNum = 0;
        choiceNum1 = 0;
        choiceNum2 = 0;
        choiceNum3 = 0;
        isMenu = true;
        isChoice = false;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogFormat("{0},{1},{2}", isEnter1, isEnter2, isEnter3);
        #region Ŀ���̵�
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (isEnter1 == false && isEnter2 == false && isEnter3 == false)
            {
                cursorNum++;

                if (cursorNum == 3)
                {
                    cursorNum = 0;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isEnter1 == false && isEnter2 == false && isEnter3 == false)
            {
                cursorNum--;

                if (cursorNum == -1)
                {
                    cursorNum = 2;
                }
            }
        }

        if(cursorNum == 0)
        {
            Slot1Color.SetActive(true);
            Slot2Color.SetActive(false);
            Slot3Color.SetActive(false);
        }
        else if(cursorNum == 1)
        {
            Slot1Color.SetActive(false);
            Slot2Color.SetActive(true);
            Slot3Color.SetActive(false);
        }
        else if(cursorNum == 2)
        {
            Slot1Color.SetActive(false);
            Slot2Color.SetActive(false);
            Slot3Color.SetActive(true);
        }
        #endregion

        #region ������ �ؽ�Ʈ
        /*
        //����1�� �����Ͱ� ������
        Ex1.SetActive(true);
        //ExText1.text =
        //����2�� �����Ͱ� ������
        Ex2.SetActive(true);
        //ExText2.text =
        //����3�� �����Ͱ� ������
        Ex3.SetActive(true);
        //ExText3.text = 

        //����1�� �����Ͱ� ������
        Create1.SetActive(true);
        //����2�� �����Ͱ� ������
        Create2.SetActive(true);
        //����3�� �����Ͱ� ������
        Create3.SetActive(true);
        */
        #endregion

        #region ���Լ���
        if(cursorNum == 0&& Input.GetKeyDown(KeyCode.Return))
        {
            isChoice = true;
            isMenu = false;
            isEnter1 = true;
            Slot1choice.SetActive(true);
            Slot1CupHead.SetActive(true);
            Slot1CupMug.SetActive(true);
        }
        else if(cursorNum == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            isChoice = true;
            isMenu = false;
            isEnter2 = true;
            Slot2choice.SetActive(true);
            Slot2CupHead.SetActive(true);
            Slot2CupMug.SetActive(true);
        }
        else if(cursorNum == 2 && Input.GetKeyDown(KeyCode.Return))
        {
            isChoice= true;
            isMenu = false;
            isEnter3 = true;
            Slot3choice.SetActive(true);
            Slot3CupHead.SetActive(true);
            Slot3CupMug.SetActive(true);
        }
        #endregion

        #region ���Գ�����
        if(cursorNum ==0 && isEnter1 == true && Input.GetKeyDown(KeyCode.Escape))
        {
            isChoice = false;
            isEnter1 = false;
            Slot1choice.SetActive(false);
            Slot1CupHead.SetActive(false);
            Slot1CupMug.SetActive(false);
            Slot1ColorMug.SetActive(false);
            Slot1Color.SetActive(false);
            Slot1CupMugChoice.SetActive(false);
            Slot1CupHeadChoice.SetActive(false);
            Invoke("ExitChoice", 1f);

        }
        else if(cursorNum == 1 && isEnter2 == true && Input.GetKeyDown(KeyCode.Escape))
        {
            isChoice = false;
            isEnter2 = false;
            Slot2choice.SetActive(false);
            Slot2CupHead.SetActive(false);
            Slot2CupMug.SetActive(false);
            Slot2ColorMug.SetActive(false);
            Slot2Color.SetActive(false);
            Slot2CupMugChoice.SetActive(false);
            Slot2CupHeadChoice.SetActive(false);
            Invoke("ExitChoice", 1f);
        }
        else if(cursorNum == 2 && isEnter3 == true && Input.GetKeyDown(KeyCode.Escape))
        {
            isChoice = false;
            isEnter3 = false;
            Slot3choice.SetActive(false);
            Slot3CupHead.SetActive(false);
            Slot3CupMug.SetActive(false);
            Slot3ColorMug.SetActive(false);
            Slot3Color.SetActive(false);
            Slot3CupMugChoice.SetActive(false);
            Slot3CupHeadChoice.SetActive(false);
            Invoke("ExitChoice", 1f);
        }
        #endregion

        #region ĳ���� �����ϴ� Ŀ���̵��ϱ� 
        if (cursorNum ==0 && isEnter1 == true && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            choiceNum1--;
            if( choiceNum1 == -1)
            {
                choiceNum1 = 1;
            }
        }
        if (cursorNum == 0 && isEnter1 == true && Input.GetKeyDown(KeyCode.RightArrow))
        {
            choiceNum1++;
            if(choiceNum1 == 2)
            {
                choiceNum1 = 0;
            }
        }
        if (cursorNum == 1 && isEnter2 == true && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            choiceNum2--;
            if (choiceNum2 == -1)
            {
                choiceNum2 = 1;
            }
        }
        if (cursorNum == 1 && isEnter2 == true && Input.GetKeyDown(KeyCode.RightArrow))
        {
            choiceNum2++;
            if (choiceNum2 == 2)
            {
                choiceNum2 = 0;
            }
        }
        if (cursorNum == 2 && isEnter3 == true && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            choiceNum3--;
            if (choiceNum3 == -1)
            {
                choiceNum3 = 1;
            }
        }
        if (cursorNum == 2 && isEnter3 == true && Input.GetKeyDown(KeyCode.RightArrow))
        {
            choiceNum3++;
            if (choiceNum3 == 2)
            {
                choiceNum3 = 0;
            }
        }
        #endregion

        #region ĳ������ Ŀ���̵��� ���� ����
        if (cursorNum == 0 && isEnter1 == true)
        {
            if(choiceNum1 ==0)
            {
                Slot1Color.SetActive(true);
                Slot1ColorMug.SetActive(false);
                Slot1CupHeadChoice.SetActive(true);
                Slot1CupMugChoice.SetActive(false);
            }
            else if(choiceNum1 ==1)
            {
                Slot1Color.SetActive(false);
                Slot1ColorMug.SetActive(true);
                Slot1CupHeadChoice.SetActive(false);
                Slot1CupMugChoice.SetActive(true);
            }
        }
        if (cursorNum == 1 && isEnter2 == true)
        {
            if (choiceNum2 == 0)
            {
                Slot2Color.SetActive(true);
                Slot2ColorMug.SetActive(false);
                Slot2CupHeadChoice.SetActive(true);
                Slot2CupMugChoice.SetActive(false);
            }
            else if (choiceNum2 == 1)
            {
                Slot2Color.SetActive(false);
                Slot2ColorMug.SetActive(true);
                Slot2CupHeadChoice.SetActive(false);
                Slot2CupMugChoice.SetActive(true);
            }
        }
        if (cursorNum == 2 && isEnter3 == true)
        {
            if (choiceNum3 == 0)
            {
                Slot3Color.SetActive(true);
                Slot3ColorMug.SetActive(false);
                Slot3CupHeadChoice.SetActive(true);
                Slot3CupMugChoice.SetActive(false);
            }
            else if (choiceNum3 == 1)
            {
                Slot3Color.SetActive(false);
                Slot3ColorMug.SetActive(true);
                Slot3CupHeadChoice.SetActive(false);
                Slot3CupMugChoice.SetActive(true);
            }
        }
        #endregion

        #region ĳ���� ���� ����â ������
        if(isEnter1 ==false && isEnter2 == false && isEnter3 ==false && isChoice ==false 
            && isMenu ==true&& Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);

        }
        #endregion
    }

    public void Slot(int number)
    {
        DataManager.dataInstance.nowSlot = number;
        //1.����� �����Ͱ� ������
        Create();
        //2.����� �����Ͱ� ������
        //�ҷ������ؼ� ���Ӿ����� �Ѿ��
        DataManager.dataInstance.LoadData();
        //DataManager.dataInstance.
    }

    public void Create()
    {
        Prologue.SetActive(true);
    }
    public void GoGame()
    {
        //DataManager.dataInstance.playerData.progress =
        SceneManager.LoadScene("CupHead");
    }

    public void ExitChoice()
    {
        isMenu = true;
    }
}
