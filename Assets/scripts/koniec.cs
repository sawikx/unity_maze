using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class koniec : MonoBehaviour
{

    [SerializeField] GameObject labiryt;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject postac;
    [SerializeField] GameObject wygrana;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        game_start st = labiryt.GetComponent<game_start>();
        if (other.tag == "Player")
        {
            canvas.SetActive(true);
            wygrana.SetActive(true);
            //postac.SetActive(false);
            st.resetowaniePlanszy();            
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
