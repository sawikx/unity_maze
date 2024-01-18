using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class game_start : MonoBehaviour
{
    [SerializeField] wall4 wallPrefab;        
    public GameObject drogaPrefab;
    public GameObject startPrefab;
    public GameObject postacPrefab;
    public GameObject miejsceLabirynt;
        
    //public int Seed = 0;
    // public int start_naroznik = 0;
    
    // Start is called before the first frame update

    void Start()
    {
        
    }    
    public GameObject Postac()
    {
        return postacPrefab;
    }   
    public void resetowaniePlanszy()
    {
        foreach (Transform child in miejsceLabirynt.transform)
        {
            Destroy(child.gameObject);
        }
        
    }
    public void tworzenielabiryntu(int seed =2,int rozmiar = 3)
    {
        int Rozmiarplanszy = rozmiar;
        miejsceLabirynt.SetActive(true);
        System.Random rnd = new System.Random(seed);
        System.Random rnd2 = new System.Random();
        List<wall4> pokoj = new List<wall4>();
        List<wall4> pokojbrzeg = new List<wall4>();
        int materiallos = rnd2.Next(0, wallPrefab.ileMatierialu());
        int materiallosPodloga = rnd2.Next(0, wallPrefab.ileMatierialuPodloga());
        //tworzenie pokoji
        for (int i = 0; i < Rozmiarplanszy; i++)
        {
            for(int j = 0; j < Rozmiarplanszy; j++)
            {
                Vector3 lokalizacjaPokoj = new Vector3(i *5f ,0,j * 5f);
                wall4 nowyPokoj = Instantiate(wallPrefab, lokalizacjaPokoj, Quaternion.identity,transform);
                nowyPokoj.jakiMaterial(materiallos);
                nowyPokoj.jakiMaterialPodloga(materiallosPodloga);
                if ((i==0||i==Rozmiarplanszy-1)||j==0||j==Rozmiarplanszy-1)
                {
                    pokojbrzeg.Add(nowyPokoj);
                }
                pokoj.Add(nowyPokoj);
            }
        }
        //tworzenie labiryntu

        List<wall4> aktualnypokoj = new List<wall4>();
        List<wall4> skonczonaDroga = new List<wall4>();

        aktualnypokoj.Add(pokojbrzeg[rnd.Next(0, pokojbrzeg.Count)]);
        
        postacPrefab.transform.position = new Vector3(aktualnypokoj[0].transform.position.x, 2f, aktualnypokoj[0].transform.position.z - 2.5f);

        int  najdalej = 0,liczenie=0;
        float metax = 0, metaz = 0;



        while (skonczonaDroga.Count < pokoj.Count)
        {            
            List<int> mozliwyPokoj = new List<int>();
            List<int> mozliwyKierunek = new List<int>();

            int bierzacyPokoj = pokoj.IndexOf(aktualnypokoj[aktualnypokoj.Count -1]);
                    
            if (bierzacyPokoj+Rozmiarplanszy < pokoj.Count-1)
            {
                
                if (!skonczonaDroga.Contains(pokoj[bierzacyPokoj+ Rozmiarplanszy]) && !aktualnypokoj.Contains(pokoj[bierzacyPokoj + Rozmiarplanszy]))
                {
                    mozliwyKierunek.Add(1);
                    mozliwyPokoj.Add(bierzacyPokoj+Rozmiarplanszy);                    
                }
            }
            
            if (bierzacyPokoj-Rozmiarplanszy-1 >0 )
            {
                
                if (!skonczonaDroga.Contains(pokoj[bierzacyPokoj - Rozmiarplanszy]) && !aktualnypokoj.Contains(pokoj[bierzacyPokoj - Rozmiarplanszy]))
                {
                    mozliwyKierunek.Add(2);
                    mozliwyPokoj.Add(bierzacyPokoj - Rozmiarplanszy);                    
                }
            }
            
            if ((bierzacyPokoj % Rozmiarplanszy) < Rozmiarplanszy - 1)
            {
                
                if (!skonczonaDroga.Contains(pokoj[bierzacyPokoj + 1]) && !aktualnypokoj.Contains(pokoj[bierzacyPokoj + 1]))
                {
                    mozliwyKierunek.Add(3);
                    mozliwyPokoj.Add(bierzacyPokoj + 1);
                    
                }
            }
            
            if ((bierzacyPokoj%Rozmiarplanszy) > 0)
            {
                
                if (!skonczonaDroga.Contains(pokoj[bierzacyPokoj -1]) && !aktualnypokoj.Contains(pokoj[bierzacyPokoj -1]))
                {
                    mozliwyKierunek.Add(4);
                    mozliwyPokoj.Add(bierzacyPokoj -1);
                }
            }
            
            if (mozliwyKierunek.Count > 0)
            {        
                int wybraniekierunku = rnd.Next(0, mozliwyKierunek.Count);
                wall4 wybranypoku = pokoj[mozliwyPokoj[wybraniekierunku]];

                liczenie++;

                if (liczenie > najdalej)
                {
                    najdalej = liczenie;
                    metax = wybranypoku.transform.position.x;
                    metaz = wybranypoku.transform.position.z;
                }
                switch (mozliwyKierunek[wybraniekierunku])
                {
                    case 1:                                               
                        wybranypoku.removeWall(0);
                        pokoj[pokoj.IndexOf(wybranypoku)-Rozmiarplanszy].removeWall(1);
                        break;
                    case 2:                        
                        wybranypoku.removeWall(1);
                        pokoj[pokoj.IndexOf(wybranypoku)+Rozmiarplanszy].removeWall(0);
                        break;
                    case 3:                        
                        wybranypoku.removeWall(3);
                        pokoj[pokoj.IndexOf(wybranypoku) - 1].removeWall(2);
                        break;
                    case 4:                        
                        wybranypoku.removeWall(2);
                        pokoj[pokoj.IndexOf(wybranypoku) + 1].removeWall(3);
                        break;
                }
                aktualnypokoj.Add(wybranypoku);
            }
            else
            {
                liczenie--;
                skonczonaDroga.Add(aktualnypokoj[aktualnypokoj.Count - 1]);
                aktualnypokoj.RemoveAt(aktualnypokoj.Count - 1);
            }
            
        }

        //strtprefab -> meta
        Vector3 start = new Vector3(metax, 0.078f, metaz-2.5f);
        startPrefab.transform.position = start;
        //Instantiate(startPrefab, start, Quaternion.identity, transform);

    }
    // Update is called once per frame

    void Update()
    {

    }
}
