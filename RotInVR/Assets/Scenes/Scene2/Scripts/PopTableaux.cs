using System.Collections;
using UnityEngine;

public class PopTableaux : MonoBehaviour {

// Init others functions

public static GameObject oeuvre1;
public static GameObject oeuvre2;
public static GameObject oeuvre3;
public static GameObject oeuvre4;

public static GameObject[] mesOeuvres = { oeuvre1, oeuvre2, oeuvre3, oeuvre4 };



    public void initMur1(){
    for (int i=21; i<87; i+2){
           int o = Random.Range(0, mesOeuvres.Length-1);
           GameObject monOeuvre = (GameObject)Instantiate(mesOeuvres[o], new Vector3(-2.8f, i, 5.4f), Quaternion.Euler(0, 180, 0));// To do
        }
    }

public void initMur2(){
        for (int i = 21; i < 87; i + 2){
            int o = Random.Range(0, mesOeuvres.Length-1);
            GameObject monOeuvre = (GameObject)Instantiate(mesOeuvres[o], new Vector3(-1.44f, i, 6.8f), Quaternion.Euler(0, -90, 0)); // To do
        }
    }

public void initMur3(){
        for (int i = 21; i < 87; i + 2)
        {
            int o = Random.Range(0, mesOeuvres.Length-1);
            GameObject monOeuvre = (GameObject)Instantiate(mesOeuvres[o], new Vector3(0f, i, 5.4f), Quaternion.Euler(0, 0, 0));// To do
        }
    }

public void initMur4(){
        for (int i = 21; i < 87; i + 2)
        {
            int o = Random.Range(0, mesOeuvres.Length-1);
            GameObject monOeuvre = (GameObject)Instantiate(mesOeuvres[o], new Vector3(-1.44f,i, 4f), Quaternion.Euler(0, 90, 0));// To do
        }
    }

public void Shuffle()
    {

    }

void Start(){

mesOeuvres = GameObject.FindGameObjectsWithTag("Tableau");


initMur1();
initMur2();
initMur3();
initMur4();

}

void Update() {

}


}