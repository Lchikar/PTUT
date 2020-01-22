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
        cubes.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
        cubes.transform.Translate(0,0.5f,0);
    }

    private void Generate()
    {
        cubes = new GameObject();
        cubes.name = "Cubes";
        Vector3 initPos = new Vector3(0,0.5f,0);
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
                    currCube = Instantiate(cubesSrc[Random.Range(0,cubesSrc.Length-1)],currPos,Quaternion.identity) as GameObject;
                    currCube.name = (++countCubes).ToString();
                    currCube.transform.parent = cubes.transform;
                }
            }
        }
    }

    
}
