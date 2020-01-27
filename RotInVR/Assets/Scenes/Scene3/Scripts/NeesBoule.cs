using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random=UnityEngine.Random;

public class NeesBoule : MonoBehaviour
{
    private Vector3 centrePosition;
    private float rayon;
    private Vector3 precedent;
    private float normeRayon;
    private Vector3 newPosition;
    private float newNorme;
    private Vector3 milieu;

    private float scale;
    private Vector3 translate;
    private Vector3 rotate;

    public GameObject line;
    public float respawnTime = 0.5f;


    Vector3 getPosNormalise(Vector3 centrePosition, float normeRayon)
    {
        newPosition.x = Random.Range(centrePosition.x - rayon, centrePosition.x + rayon);
        newPosition.y = Random.Range(centrePosition.y - rayon, centrePosition.y + rayon);
        newPosition.z = Random.Range(centrePosition.z - rayon, centrePosition.z + rayon);

        newNorme = (float) Math.Sqrt(Math.Pow(centrePosition.x, 2) + Math.Pow(centrePosition.y, 2) + Math.Pow(centrePosition.z, 2));

        if (newNorme != normeRayon)
        {
            newPosition = newPosition / newNorme * normeRayon;
        }

        return newPosition;
    }

    IEnumerator<WaitForSeconds> lineWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            for (int i = 0; i < 10; i++)
            {
                spawn();
            }
        }
    }



    void generate()
    {
   
        rayon = Random.Range(0.1f, 0.5f);
        centrePosition.x = Random.Range(0, rayon);
        centrePosition.y = Random.Range(0, rayon);
        centrePosition.z = Random.Range(0, rayon);

        normeRayon = (float) Math.Sqrt(Math.Pow(centrePosition.x, 2) + Math.Pow(centrePosition.y, 2) + Math.Pow(centrePosition.z, 2));

        precedent = getPosNormalise(centrePosition, normeRayon);

        StartCoroutine(lineWave());
    }

    private void spawn()
    {
        newPosition = getPosNormalise(centrePosition, normeRayon);
        milieu = (newPosition - precedent) / 2;

        scale = (float) Math.Sqrt(Math.Pow(precedent.x - newPosition.x, 2) + Math.Pow(precedent.y - newPosition.y, 2) + Math.Pow(precedent.z - newPosition.z, 2));
        translate = centrePosition + (precedent - newPosition) / 2;
        rotate.z = (float) Math.Atan((newPosition.y - milieu.y) / (newPosition.y - milieu.y));
        rotate.y = (float) Math.Atan((newPosition.x - milieu.x) / (newPosition.z - milieu.z));
        rotate.x = (float) Math.Atan((newPosition.x - milieu.x) / (newPosition.y - milieu.y));

        GameObject newLine = Instantiate(line, translate, Quaternion.identity);
//        newLine.transform.rotation.x = rotate.x;
  //      newLine.transform.scale = new Vector3(scale, scale, scale);

        precedent = newPosition;
    }
}