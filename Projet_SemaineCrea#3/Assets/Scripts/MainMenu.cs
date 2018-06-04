using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class MainMenu : MonoBehaviour {


    [Header("Menu Information")]
    public string MenuState;

    public bool P1Ready = false;
    public bool P2Ready = false;
    public bool P3Ready = false;
    public bool P4Ready = false;

    public int MapSelected = 1;

    [Header("Nom Map")]
    public string m_2PMap1;
    public string m_2PMap2;
    public string m_2PMap3;
    public string m_3PMap1;
    public string m_3PMap2;
    public string m_3PMap3;
    public string m_4PMap1;
    public string m_4PMap2;
    public string m_4PMap3;



    [Header("To Declare")]
    public GameObject IntroMenuCanv;
    public GameObject PlayerMenuCanv;
    public GameObject MapMenuCanv;

    public GameObject P1ReadySprite;
    public GameObject P2ReadySprite;
    public GameObject P3ReadySprite;
    public GameObject P4ReadySprite;

    public GameObject Selector;

    [Header("Other")]
    public GameObject MapSelectionPlayer = null;
    bool canNav = true;
    int ConnectedPlayers = 1;

    void Start ()
    {
        MenuState = "Intro";
    }
	
	void Update ()
    {
        MapSelector();

        if (MenuState == "Intro")
        {
            Go_MenuIntro();
        }
        if (MenuState == "PlayerNum")
        {
            Go_MenuPlayer();
        }
        if (MenuState == "MapSelection")
        {
            Go_MenuMap();
        }
    }
    void Go_MenuIntro()
    {
        IntroMenuCanv.SetActive(true);
        PlayerMenuCanv.SetActive(false);
        MapMenuCanv.SetActive(false);

        if (XCI.GetButtonDown(XboxButton.Start, XboxController.First))
        {
            MenuState = "PlayerNum";
        }
    }
    void Go_MenuPlayer()
    {
        IntroMenuCanv.SetActive(false);
        PlayerMenuCanv.SetActive(true);
        MapMenuCanv.SetActive(false);
        ChangePlayerNum();
        // P1 controller
        if (XCI.GetButtonDown(XboxButton.A, XboxController.First) && ConnectedPlayers > 1 && P1Ready)
        {
            
            MenuState = "MapSelection";
        }

        if (XCI.GetButtonDown(XboxButton.B, XboxController.First) && !P1Ready)
        {
            MenuState = "Intro";
        }

        // Other
        //P1
        if (XCI.GetButtonDown(XboxButton.Start, XboxController.First))
        {
            P1Ready = true;
            P1ReadySprite.transform.GetChild(0).gameObject.SetActive(true);
            P1ReadySprite.GetComponent<Image>().enabled = false;
        }
        else if (XCI.GetButtonDown(XboxButton.B, XboxController.First))
        {
            P1Ready = false;
            P1ReadySprite.transform.GetChild(0).gameObject.SetActive(false);
            P1ReadySprite.GetComponent<Image>().enabled = true;
        }
        // P2
        if (XCI.GetButtonDown(XboxButton.Start, XboxController.Second))
        {
            P2Ready = true;
            P2ReadySprite.transform.GetChild(0).gameObject.SetActive(true);
            P2ReadySprite.GetComponent<Image>().enabled = false;
        }
        else if (XCI.GetButtonDown(XboxButton.B, XboxController.Second))
        {
            P2Ready = false;
            P2ReadySprite.transform.GetChild(0).gameObject.SetActive(false);
            P2ReadySprite.GetComponent<Image>().enabled = true;
        }

        // P3
        if (XCI.GetButtonDown(XboxButton.Start, XboxController.Third))
        {
            P3Ready = true;
            P3ReadySprite.transform.GetChild(0).gameObject.SetActive(true);
            P3ReadySprite.GetComponent<Image>().enabled = false;
        }
        else if (XCI.GetButtonDown(XboxButton.B, XboxController.Third))
        {
            P3Ready = false;
            P3ReadySprite.transform.GetChild(0).gameObject.SetActive(false);
            P3ReadySprite.GetComponent<Image>().enabled = true;
        }

        // P4
        if (XCI.GetButtonDown(XboxButton.Start, XboxController.Fourth))
        {
            P4Ready = true;
            P4ReadySprite.transform.GetChild(0).gameObject.SetActive(true);
            P4ReadySprite.GetComponent<Image>().enabled = false;
        }
        else if (XCI.GetButtonDown(XboxButton.B, XboxController.Fourth))
        {
            P4Ready = false;
            P4ReadySprite.transform.GetChild(0).gameObject.SetActive(false);
            P4ReadySprite.GetComponent<Image>().enabled = true;
        }

    }
    void Go_MenuMap()
    {
        IntroMenuCanv.SetActive(false);
        PlayerMenuCanv.SetActive(false);
        MapMenuCanv.SetActive(true);
        
        
        if (XCI.GetAxis(XboxAxis.LeftStickX, XboxController.First) >= 0.7f && canNav)
        {
            canNav = false;
            MapSelected += 1;
        }
        if (XCI.GetAxis(XboxAxis.LeftStickX, XboxController.First) <= -0.7f && canNav)
        {
            canNav = false;
            MapSelected -= 1;
        }
        if (XCI.GetAxis(XboxAxis.LeftStickX, XboxController.First) == 0)
        {
            canNav = true;
        }

        if (XCI.GetButtonDown(XboxButton.A, XboxController.First))
        {

        }
        if (XCI.GetButtonDown(XboxButton.Start, XboxController.First))
        {
            MenuState = "PlayerNum";
        }
    }

    void ChangePlayerNum()
    {
        if (P2Ready && P3Ready && P4Ready)
        {
            MapMenuCanv.transform.GetChild(2).gameObject.SetActive(true);
            MapMenuCanv.transform.GetChild(1).gameObject.SetActive(false);
            MapMenuCanv.transform.GetChild(0).gameObject.SetActive(false);
            ConnectedPlayers = 4;
            MapSelectionPlayer = MapMenuCanv.transform.GetChild(2).gameObject;
        }
        else if (P2Ready && P3Ready)
        {
            MapMenuCanv.transform.GetChild(2).gameObject.SetActive(false);
            MapMenuCanv.transform.GetChild(1).gameObject.SetActive(true);
            MapMenuCanv.transform.GetChild(0).gameObject.SetActive(false);
            ConnectedPlayers = 3;
            MapSelectionPlayer = MapMenuCanv.transform.GetChild(1).gameObject;
        }
        else if (P2Ready)
        {
            MapMenuCanv.transform.GetChild(2).gameObject.SetActive(false);
            MapMenuCanv.transform.GetChild(1).gameObject.SetActive(false);
            MapMenuCanv.transform.GetChild(0).gameObject.SetActive(true);
            ConnectedPlayers = 2;
            MapSelectionPlayer = MapMenuCanv.transform.GetChild(0).gameObject;
        }
    }
    void MapSelector()
    {
        //ajust
        if (MapSelected < 1)
        {
            MapSelected = 3;
        }
        if (MapSelected > 3)
        {
            MapSelected = 1;
        }
        //Place Slector
        if (MapSelected == 1)
        {
            Selector.transform.position = MapMenuCanv.transform.GetChild(0).GetChild(0).position;
        }
        if (MapSelected == 2)
        {
            Selector.transform.position = MapMenuCanv.transform.GetChild(0).GetChild(1).position;
        }
        if (MapSelected == 3)
        {
            Selector.transform.position = MapMenuCanv.transform.GetChild(0).GetChild(2).position;
        }
    }
    void LauchMap()
    {
        if (ConnectedPlayers == 2)
        {
            if (MapSelected == 1)
            {
                SceneManager.LoadScene(m_2PMap1);
            }
            else if (MapSelected == 2)
            {
                SceneManager.LoadScene(m_2PMap1);
            }
            else if (MapSelected == 3)
            {
                SceneManager.LoadScene(m_2PMap1);
            }
        }
        else if (ConnectedPlayers == 3)
        {
            if (MapSelected == 1)
            {
                SceneManager.LoadScene(m_3PMap1);
            }
            else if (MapSelected == 2)
            {
                SceneManager.LoadScene(m_3PMap2);
            }
            else if (MapSelected == 3)
            {
                SceneManager.LoadScene(m_3PMap3);
            }
        }
        else if (ConnectedPlayers == 4)
        {
            if (MapSelected == 1)
            {
                SceneManager.LoadScene(m_4PMap1);
            }
            else if (MapSelected == 2)
            {
                SceneManager.LoadScene(m_4PMap2);
            }
            else if (MapSelected == 3)
            {
                SceneManager.LoadScene(m_4PMap3);
            }
        }

    }
}
