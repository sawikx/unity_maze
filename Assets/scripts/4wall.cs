using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wall4 : MonoBehaviour
{
    [SerializeField] GameObject[] sciany;
    [SerializeField] Material[] material;
    [SerializeField] GameObject podloga;
    [SerializeField] Texture2D[] materialPodloga;
    //public bool brzegLabiryntu = false;

    public void removeWall(int wallRoRemove)
    {
        sciany[wallRoRemove].gameObject.SetActive(false);
    }
    public void reziseWallCrouch(int resize) //zmiana wilkoœci, gracz musi kucaæ by przeœæ dalej
    {
        sciany[resize].transform.position = new Vector3(sciany[resize].transform.position.x, 3.25f, sciany[resize].transform.position.z);
        sciany[resize].transform.localScale = new Vector3(sciany[resize].transform.localScale.x, 3.5f, sciany[resize].transform.localScale.z);
    }
    public void reziseWallJump(int resize) //zmiana wilkoœci, gracz musi skakaæ by przeœæ dalej
    {
        sciany[resize].transform.position = new Vector3(sciany[resize].transform.position.x, 0.9f, sciany[resize].transform.position.z);
        sciany[resize].transform.localScale = new Vector3(sciany[resize].transform.localScale.x, 1.75f, sciany[resize].transform.localScale.z);
    }
    public void jakiMaterial(int wybranyMaterial)
    {
        for (int i = 0; i < sciany.Length; i++)
        {
            sciany[i].GetComponent<Renderer>().material = material[wybranyMaterial];        
        }
        
    }
    public int ileMatierialu()
    {
        return material.Length;
    }

    public void jakiMaterialPodloga(int wybranyMateriall)
    {
        podloga.GetComponent<Renderer>().material.mainTexture= materialPodloga[wybranyMateriall];
    }
    public int ileMatierialuPodloga()
    {
        return materialPodloga.Length;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
