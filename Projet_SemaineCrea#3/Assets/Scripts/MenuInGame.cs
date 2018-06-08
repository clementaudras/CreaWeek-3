using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;
using DG.Tweening;

public class MenuInGame : MonoBehaviour {

    public GameObject Selector;
    public bool MenuActivate = false;
    public bool ButtonSelect = true;
    public bool canNav;
	
	// Update is called once per frame
	void Update ()
    {
        if (XCI.GetButtonDown(XboxButton.Start, XboxController.Any) || Input.GetKeyDown(KeyCode.P))
        {
            MenuActivate = !MenuActivate;
            ButtonSelect = true;
        }


        if (MenuActivate)
        {
            Time.timeScale = 0.01f;
            transform.GetChild(0).gameObject.SetActive(true);           
            if (XCI.GetButtonDown(XboxButton.A, XboxController.First) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (ButtonSelect)
                {
                    MenuActivate = !MenuActivate;
                }
                else
                {
                    SceneManager.LoadScene("Menu");
                }
            }
            if (XCI.GetAxis(XboxAxis.LeftStickY, XboxController.First) >= 0.7f && canNav || Input.GetKeyDown(KeyCode.UpArrow))
            {
                canNav = false;
                ButtonSelect = !ButtonSelect;
            }
            if (XCI.GetAxis(XboxAxis.LeftStickY, XboxController.First) <= -0.7f && canNav || Input.GetKeyDown(KeyCode.DownArrow))
            {
                canNav = false;
                ButtonSelect = !ButtonSelect;
            }
            if (XCI.GetAxis(XboxAxis.LeftStickY, XboxController.First) == 0)
            {
                canNav = true;
            }
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        if (ButtonSelect)
        {
            Selector.transform.DOLocalMoveY(22, 0.001f);
        }
        else
        {
            Selector.transform.DOLocalMoveY(-40, 0.001f);
        }
    }
}
