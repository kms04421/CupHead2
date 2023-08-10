using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Select : MonoBehaviour
{
    public TMP_Text start;
    public TMP_Text option;
    public TMP_Text dlc;
    public TMP_Text exit;

    public GameObject startMenu;
    private int cursorNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region 커서이동
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cursorNum++;

            if (cursorNum ==4)
            {
                cursorNum = 0;
            }    
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {

            cursorNum--;

            if (cursorNum == -1)
            {
                cursorNum = 3;
            }
        }
        if(cursorNum == 0)
        {
            start.color = new Color(248 / 255.0f, 240 / 255.0f, 240 / 255.0f);
            option.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
            dlc.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
            exit.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
        }
        else if(cursorNum == 1)
        {
            start.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
            option.color = new Color(248 / 255.0f, 240 / 255.0f, 240 / 255.0f);
            dlc.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
            exit.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
        }
        else if(cursorNum == 2)
        {
            start.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
            option.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
            dlc.color = new Color(248 / 255.0f, 240 / 255.0f, 240 / 255.0f);
            exit.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
        }
        else if(cursorNum == 3)
        {
            start.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
            option.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
            dlc.color = new Color(149 / 255.0f, 147 / 255.0f, 147 / 255.0f);
            exit.color = new Color(248 / 255.0f, 240 / 255.0f, 240 / 255.0f);
        }
        #endregion

        if(cursorNum ==0 &&Input.GetKeyDown(KeyCode.Return))
        {
            startMenu.SetActive(true);
        }
        if (cursorNum == 1 && Input.GetKeyDown(KeyCode.Return))
        {

        }
        if (cursorNum == 2 && Input.GetKeyDown(KeyCode.Return))
        {

        }
        if (cursorNum == 3 && Input.GetKeyDown(KeyCode.Return))
        {
            Application.Quit();
        }
    }
}
