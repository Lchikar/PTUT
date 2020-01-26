using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class starGenerator : MonoBehaviour {

    public GameObject star;
    public float respawnTime = 0.2f;
    private Vector3 position; 
    /*private meshRenderer starRenderer;*/

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(starWave());   
    }

    float getRandom(float min, float max) {

        float rand = Random.Range(-max, max);
        if(-min < rand && rand < min) {
            if(rand > 0) {
                rand = Random.Range(min, max);
            }
            else {
                rand = Random.Range(-max, -min);
            }
        }
        return rand;
    }

    private void spawnStars() {

        position = new Vector3(getRandom(30.0f, 200.0f), getRandom(30.0f, 200.0f), getRandom(30.0f, 200.0f));
        //position = new Vector3(posX, posY, posZ);
        GameObject newStar = Instantiate(star, position, Quaternion.identity);
        /*starRenderer = GetComponent<meshRenderer>();
        starRenderer.material.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 1.0f);*/
    }

    IEnumerator<WaitForSeconds> starWave() {
        while(true) {
            yield return new WaitForSeconds(respawnTime);
            for(int i=0; i<10; i++) {
                spawnStars();
            }
        }
    }
}
