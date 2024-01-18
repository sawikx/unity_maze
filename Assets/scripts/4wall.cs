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
