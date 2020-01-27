using System.Collections;
using UnityEngine;

public class PopTableaux : MonoBehaviour {

// Init others functions

public GameObject oeuvre1;
public GameObject oeuvre2;
public GameObject oeuvre3;
public GameObject oeuvre4;

private GameObject[] mesOeuvres;



    public void initMur1(){
    for (int i=0; i<70; i++){
            if (i % 2 == 1)
            {
                int o = Random.Range(0, mesOeuvres.Length - 1);
                GameObject monOeuvre = (GameObject)Instantiate(mesOeuvres[o], new Vector3(-1.43f, i, 0), Quaternion.Euler(0, 0, 0));
            }

        }
    }

public void initMur2(){
        for (int i = 0; i < 70; i++){
            if (i % 2 == 1)
            {
                int o = Random.Range(0, mesOeuvres.Length - 1);
                GameObject monOeuvre = (GameObject)Instantiate(mesOeuvres[o], new Vector3(0, i, 1.37f), Quaternion.Euler(0, 90, 0));
            }
        }
    }

public void initMur3(){
        for (int i = 0; i < 70; i++)
        {
            if (i % 2 == 1)
            {
                int o = Random.Range(0, mesOeuvres.Length - 1);
                GameObject monOeuvre = (GameObject)Instantiate(mesOeuvres[o], new Vector3(1.43f, i, 0), Quaternion.Euler(0, 180, 0));
            }
        }
    }

public void initMur4(){
        for (int i = 0; i < 70; i++)
        {
            if (i % 2 == 1)
            {
                int o = Random.Range(0, mesOeuvres.Length - 1);
            GameObject monOeuvre = (GameObject)Instantiate(mesOeuvres[o], new Vector3(0, i, -1.37f), Quaternion.Euler(0, -90, 0));
            }
        }
    }

public void Shuffle()
    {
    //initMur1();
    //initMur2();
    //initMur3();
    //initMur4();
    }

void Start(){

       mesOeuvres = new GameObject[4] { oeuvre1, oeuvre2, oeuvre3, oeuvre4 };
initMur1();
initMur2();
initMur3();
initMur4();

}

void Update() {

}


}