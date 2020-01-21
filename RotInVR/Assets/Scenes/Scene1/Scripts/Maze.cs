using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [System.Serializable]
    public class Cell
    {
        public List<int> neighbours;
        public List<int> links;
        public List<int> walls;
        public bool visited;
    }

    public GameObject wall;
    private GameObject walls;

    public int width;
    public int length;

    private Cell[] cells;

    private List<int> path;

    void Start()
    {
        CreateWalls();
        CreateCells();
        GeneratePath();
        BreakWalls();
        ColorInnerWalls();
        walls.transform.localScale += new Vector3(10, 10, 10);
    }

    private void CreateWalls()
    {
        float roomSize = 1;
        float wallThickness = 1;
        walls = new GameObject();
        walls.name = "Maze";
        GameObject curWall;

        Vector3 initPos = new Vector3((-width / 2.0f) + wallThickness / 2.0f, 0.0f, (-length / 2.0f) + wallThickness / 2.0f);
        Vector3 curPos = initPos;

        int countwals = -1;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j <= width; j++)
            {
                curPos = new Vector3(initPos.x + (j * roomSize) - wallThickness / 2, 0, initPos.z + (i * roomSize) - wallThickness / 2);
                curWall = Instantiate(wall, curPos, Quaternion.identity) as GameObject;
                curWall.name = (++countwals).ToString();
                curWall.transform.parent = walls.transform;
            }
        }

        for (int i = 0; i <= length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                curPos = new Vector3(initPos.x + (j * roomSize), 0, initPos.z + (i * roomSize) - wallThickness);
                curWall = Instantiate(wall, curPos, Quaternion.Euler(0.0f, 90.0f, 0.0f)) as GameObject;
                curWall.name = (++countwals).ToString();
                curWall.transform.parent = walls.transform;
            }
        }
    }

    private void CreateCells()
    {
        cells = new Cell[width*length];

        for(int i = 0; i < width*length; i++)
        {
            cells[i] = new Cell();
            cells[i].visited = false;
            cells[i].neighbours = new List<int>();
            cells[i].walls = new List<int>();

            int x = i / width;
            int z = i % width;

            cells[i].walls.Add( x * (width + 1) + z );

            cells[i].walls.Add( x * (width + 1) + z + 1 );

            cells[i].walls.Add( x * (width ) + length * (width + 1) + z );

            cells[i].walls.Add( x * (width ) + length * (width + 1) + z + width);


            if ((i%width) != 0)
            {
                cells[i].neighbours.Add(i - 1);
            }

            if (((i + 1) % width) != 0)
            {
                cells[i].neighbours.Add(i + 1);
            }
                
            if ((i - width) >= 0)
            {
                cells[i].neighbours.Add(i - width);
            }
                
            if ((i + width) < (width * length))
            {
                cells[i].neighbours.Add(i + width);
            }
        }

    }

    private static List<int> Shuffle(List<int> lst)
    {
        List<int> res = lst;
        int temp;
        int j;
        for(int i = lst.Count -1; i > 1; i--)
        {
            j = Random.Range(0, res.Count - 1);
            temp = res[j];
            res[j] = res[i];
            res[i] = temp;
        }
        return res;
    }

    private void DeepExploration(int start)
    {
        path.Add(start);
        cells[start].visited = true;
        cells[start].links = new List<int>();

        List<int> randNeigh = Shuffle(cells[start].neighbours);
        for (int n = 0; n < randNeigh.Count; n++)
        {
            if(false == cells[randNeigh[n]].visited)
            {
                cells[start].links.Add(randNeigh[n]);
                DeepExploration(randNeigh[n]);
            }
        }
    }
    
    private void GeneratePath()
    {
        path = new List<int>(width * length);
        
        int start = Random.Range(0, width * length);

        DeepExploration(start);
    }
    
    private void BreakWalls()
    {
        for(int i = 0; i < cells.Length; i++)
        {
            for (int j = 0; j < cells[i].links.Count; j++)
            {
                if ((i - cells[i].links[j]) == 1)
                {
                    Destroy(walls.transform.Find(cells[i].walls[0].ToString()).gameObject);
                }

                if ((i - cells[i].links[j]) == -1)
                {
                    Destroy(walls.transform.Find(cells[i].walls[1].ToString()).gameObject);
                }

                if ((i - cells[i].links[j]) == -width)
                {
                    Destroy(walls.transform.Find(cells[i].walls[3].ToString()).gameObject);
                }

                if ((i - cells[i].links[j]) == width)
                {
                    Destroy(walls.transform.Find(cells[i].walls[2].ToString()).gameObject);
                }
            }
        }
    }

    private void ColorInnerWalls()
    {
        for (int i = 0; i < walls.transform.childCount; i++)
        {
            for (int k = 0; k < length; k++)
                if (i == k * (width + 1) || i == k * (width + 1) + width)
                    walls.transform.Find(i.ToString()).gameObject.GetComponent<Renderer>().material.color = Color.red;
            for (int k = 0; k < width; k++)
                if (i == length * (width + 1) + k || i == length * (width + 1) + k + length * width)
                    walls.transform.Find(i.ToString()).gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

}


