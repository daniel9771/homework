using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoardManager : MonoBehaviour
{
    int width = 9;
    int height = 14;
    Node[,] board;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject TilePrefab;
    [SerializeField] GameObject TileParent;

    List<Node> NodesToDelete = new List<Node>();

   
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void VerifyBoard()
    {
        NodesToDelete.Clear();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Node node = board[x, y];

                if (node.value == -1)
                {
                    continue;
                }

                if (NodesToDelete.Contains(node))
                {
                    continue;
                }

                if (x + 2 < width && node.value == board[x + 1, y].value && node.value == board[x + 2, y].value)
                {
                    NodesToDelete.Add(node);
                    NodesToDelete.Add(board[x + 1, y]);
                    NodesToDelete.Add(board[x + 2, y]);

                    if (x + 3 < width && node.value == board[x + 3, y].value)
                    {
                        NodesToDelete.Add(board[x + 3, y]);

                        if (x + 4 < width && node.value == board[x + 4, y].value)
                        {
                            NodesToDelete.Add(board[x + 4, y]);
                        }
                    }
                }
                if (y + 2 < height && node.value == board[x, y + 1].value && node.value == board[x, y + 2].value)
                {
                    NodesToDelete.Add(node);
                    NodesToDelete.Add(board[x, y + 1]);
                    NodesToDelete.Add(board[x, y + 2]);
                    //if it's a column of 4
                    if (y + 3 < height && node.value == board[x, y + 3].value)
                    {
                        NodesToDelete.Add(board[x, y + 3]);
                        //if it's a row of 5
                        if (y + 4 < height && node.value == board[x, y + 4].value)
                        {
                            NodesToDelete.Add(board[x, y + 4]);
                        }
                    }
                }
            }
        }
    }

    void StartGame()
    {

        board = new Node[width, height];

        //init board
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                board[x, y] = new Node(0, new Point(x, y));
            }
        }

        //set holes
        for (int x = 3; x < 6; x++)
        {
            for (int y = 5; y < 8; y++)
            {
                board[x, y].value = -1;
            }
        }
        //randomize candies
        foreach (Node node in board)
        {
            if (node.value != -1)
            {
                node.value = Random.Range(1, 6);
            }
        }


        //Verify board
        do
        {
            foreach (Node node in NodesToDelete)
            {
                node.value = Random.Range(1, 6);
            }    
            VerifyBoard();

        } while (NodesToDelete.Count > 0);
        //instantiate sprites
        GameObject current_tile;
        foreach (Node node in board)
        {
           current_tile = Instantiate(TilePrefab, TileParent.transform);
            current_tile.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(32 + (node.index.x * 64), -32 - (node.index.y * 64));
            if (node.value > 0)
                current_tile.GetComponent<Image>().sprite = sprites[node.value - 1];
            else
                current_tile.GetComponent<Image>().color = Color.black;
               
        }
    }
}

[System.Serializable]
public class Node
{
    public int value; //0 = blank, 1 = cube, 2 = sphere, 3 = cylinder, 4 = pyramid, 5 - diamond, -1 = hole
    public Point index;

    public Node(int v, Point i)
    {
        value = v;
        index = i;
    }



}

[System.Serializable]
public class Point
{
    public int x;
    public int y;

    public Point(int nx, int ny)
    {
        x = nx;
        y = ny;
    }

    public void mult(int m)
    {
        x *= m;
        y *= m;
    }

    public void add(Point p)
    {
        x += p.x;
        y += p.y;
    }

    public Vector2 ToVector()
    {
        return new Vector2(x, y);
    }

    public bool Equals(Point p)
    {
        return (x == p.x && y == p.y);
    }

    public static Point fromVector(Vector2 v)
    {
        return new Point((int)v.x, (int)v.y);
    }

    public static Point fromVector(Vector3 v)
    {
        return new Point((int)v.x, (int)v.y);
    }

    public static Point mult(Point p, int m)
    {
        return new Point(p.x * m, p.y * m);
    }

    public static Point add(Point p, Point o)
    {
        return new Point(p.x + o.x, p.y + o.y);
    }

    public static Point clone(Point p)
    {
        return new Point(p.x, p.y);
    }

    public static Point zero
    {
        get { return new Point(0, 0); }
    }

    public static Point one
    {
        get { return new Point(1, 1); }
    }

    public static Point up
    {
        get { return new Point(0, 1); }
    }

    public static Point down
    {
        get { return new Point(0, -1); }
    }

    public static Point left
    {
        get { return new Point(-1, 0); }
    }

    public static Point right
    {
        get { return new Point(1, 0); }
    }
}

