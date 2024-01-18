using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    [SerializeField] GameObject labiryt;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject postac;
    [SerializeField] GameObject startmenu;
    [SerializeField] GameObject wygrana;
    [SerializeField] GameObject podloga;
    private int seed =-1;
    private int wielkosc=-1;
    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = false;
    public bool cursorInputForLook = false;
    // Start is called before the first frame update
    public void StartGra()
    {
        System.Random rnd = new System.Random();
        if (seed <1)
        {
            seed= rnd.Next(1,100);
        }
        if (wielkosc < 3)
        {
            wielkosc= rnd.Next(3, 10);
        }
        game_start startgra = labiryt.GetComponent<game_start>(); 
        startgra.tworzenielabiryntu(seed, wielkosc);        
        SetCursorState(true);
        canvas.SetActive(false);
        startmenu.SetActive(false);
        //postac.SetActive(true);
    }
    public void inputWartosc(string s)
    {       
        seed = int.Parse(s);
    }
    public void inputwilekosc(string s)
    {       
        wielkosc = int.Parse(s);
    }
    public void openStartMenu()
    {
        startmenu.SetActive(true);
    }
    public void closeStartMenu()
    {
        game_start startgra = labiryt.GetComponent<game_start>();
        startgra.resetowaniePlanszy();
        startmenu.SetActive(false);
    }
    public void koniecgry()
    {        
        Application.Quit();
    }
    public void wygranafun()
    {
        wygrana.SetActive(false);
    }
    private void Start()
    {
        //postac.SetActive(false);
        SetCursorState(cursorLocked);
        startmenu.SetActive(false);
        wygrana.SetActive(false);
        postac.transform.position = new Vector3(0, 2f, 0);
        podloga.transform.position = new Vector3(0, -0.1f, 0);
    }
    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
