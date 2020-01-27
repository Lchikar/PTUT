using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ArtWorkGen : MonoBehaviour {
    private GameObject[] artWorks;
    public GameObject mazeGenerator;
    private GameObject paintings;

    void LoadPaintings()
    {
        paintings = new GameObject();
        paintings.name = "Paintings";
        GameObject[] prefabsGo = Resources.LoadAll("Prefabs/Tableaux", typeof(GameObject)).Cast<GameObject>().ToArray();
        List<GameObject> prefabs = new List<GameObject>();
        foreach (GameObject go in prefabsGo)
            prefabs.Add(go);

        artWorks = new GameObject[prefabs.Count];
        for (int i = 0; 0 < prefabs.Count; i++)
        {
            int selected = UnityEngine.Random.Range(0, prefabs.Count - 1);
            artWorks[i] = Instantiate(prefabs[selected], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            prefabs.RemoveAt(selected);
        }
    }

	void Start () {
        LoadPaintings();

        GameObject maze = GameObject.Find("Maze");

        Maze mazeGen = mazeGenerator.GetComponent<Maze>();

        int j = 0;
        //FACE 1
        for (int i = 0; i < 2 * mazeGen.length * mazeGen.width + 2 * mazeGen.width; i++)
        {
            if (j >= artWorks.Length)
                j = 0;
            if (maze.transform.Find(i.ToString()) != null && maze.transform.Find(i.ToString()).GetComponent<Renderer>().material.color != Color.red)
            {
                float wallThickness = 1.5f;
                float artThickness = 0.5f;

                artWorks[j].transform.position = new Vector3(
                    maze.transform.Find(i.ToString()).position.x,
                    maze.transform.Find(i.ToString()).position.y,
                    maze.transform.Find(i.ToString()).position.z);

                
                //Vertical wall
                if (Int32.Parse(maze.transform.Find(i.ToString()).name) <= ((mazeGen.length - 1) * (mazeGen.width + 1) + mazeGen.width))
                {
                    Debug.Log("\t" + artWorks[j].name + " sur mur vertical " + maze.transform.Find(i.ToString()).name);
                }

                //Horizontal wall
                else
                {
                    Debug.Log("\t" + artWorks[j].name + " sur mur horizontal " + maze.transform.Find(i.ToString()).name);
                    artWorks[j].transform.Rotate(0, 90, 0);
                }
                j++;
            }
        }

        //FACE 2
        for (int i = 0; i < 2 * mazeGen.length * mazeGen.width + 2 * mazeGen.width; i++)
        {
            if (j >= artWorks.Length)
                j = 0;
            if (maze.transform.Find(i.ToString()) != null && maze.transform.Find(i.ToString()).GetComponent<Renderer>().material.color != Color.red)
            {
                float wallThickness = 1.5f;
                float artThickness = 0.5f;

                artWorks[j].transform.position = new Vector3(
                    maze.transform.Find(i.ToString()).position.x,
                    maze.transform.Find(i.ToString()).position.y,
                    maze.transform.Find(i.ToString()).position.z);


                //Vertical wall
                if (Int32.Parse(maze.transform.Find(i.ToString()).name) <= ((mazeGen.length - 1) * (mazeGen.width + 1) + mazeGen.width))
                {
                    Debug.Log("\t" + artWorks[j].name + " sur mur vertical " + maze.transform.Find(i.ToString()).name);
                    artWorks[j].transform.Rotate(0,180,0);
                }

                //Horizontal wall
                else
                {
                    Debug.Log("\t" + artWorks[j].name + " sur mur horizontal " + maze.transform.Find(i.ToString()).name);
                    artWorks[j].transform.Rotate(0, 90, 0);
                    artWorks[j].transform.Rotate(0,180,0);
                }
                j++;
            }
        }

        //for (; j < artWorks.Length; j++)
        //    Destroy(artWorks[j]);

        for(int i = 0; i < artWorks.Length; i++)
            artWorks[i].transform.parent = paintings.transform;
    }

}
