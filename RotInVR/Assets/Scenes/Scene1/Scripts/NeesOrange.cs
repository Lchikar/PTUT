using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeesOrange : MonoBehaviour
{
    public int width;
    public int height;
    public int depth;

    private const int SIZE = 4;

    public GameObject[] cubesSrc = new GameObject[SIZE];
    private GameObject cubes;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    private void Generate()
    {
        cubes = new GameObject();
        cubes.name = "Cubes";

        Debug.Log("nb cubes src : " + cubesSrc.Length);
        for(int i = 0; i < cubesSrc.Length; i++)
        {
            Debug.Log(cubesSrc[i].name);
        }

        Vector3 initPos = new Vector3(-width / 2.0f, 0, -height/2.0f);
        Vector3 currPos = initPos;
        GameObject currCube = new GameObject();
        int countCubes = -1;

        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                for(int k = 0; k < depth; k++)
                {
                    
                    currPos = new Vector3(initPos.x + i , initPos.y + j , initPos.z + k );
                    currCube = Instantiate(
                        cubesSrc[Random.Range(0,cubesSrc.Length-1)], 
                        currPos, 
                        Quaternion.identity) as GameObject;
                    currCube.name = (++countCubes).ToString();
                    currCube.transform.parent = cubes.transform;
                }
            }
        }
        Debug.Log(countCubes + " cubes");
    }

    
}
