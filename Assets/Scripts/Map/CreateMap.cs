using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public Transform block; // cube
    public Transform circlePoint;

    private const int WIDTH = 30;
    private const int HEIGHT = 30;

    [SerializeField] private int[,] maps;
    [SerializeField] private int circlePointCnt;
    private bool flag = false;
    private bool circlePointSetting = false;

    private void Awake()
    {
        maps = new int[HEIGHT, WIDTH];

        for (int i = 0; i < HEIGHT; i++)
        {
            for (int j = 0; j < WIDTH; j++)
            {
                maps[i, j] = 1; // 모든 셀을 블록으로 채움
            }
        }
    }

    private void Start()
    {
        MapCreator();
    }

    private void MapCreator()
    {
        if (!flag)
        {
            flag = true;

            Vector2Int startPoint = new Vector2Int(0, Random.Range(0, HEIGHT));
            Vector2Int endPoint = new Vector2Int(WIDTH - 1, Random.Range(0, HEIGHT));

            for (int i = 0; i < circlePointCnt; i++)
            {
                int randX = Random.Range(-WIDTH/2, HEIGHT/2);
                int randZ = Random.Range(-WIDTH/2, HEIGHT/2);
                GameObject newPoint = Instantiate(circlePoint.gameObject, new Vector3(randX, 0, randZ), Quaternion.identity);

                int randRange = Random.Range(2, (int)WIDTH/4); 
                for (int j = 0; j < randRange+2; j++)
                {
                    int x = (int)newPoint.transform.position.x - randRange;
                    int y = (int)newPoint.transform.position.y - randRange;

                    if (0 <= x && x < WIDTH && 0 <= y && y < HEIGHT)
                        maps[j, x+j] = 0;
                }
            }   
            

            //List<Vector2Int> path = GeneratePath(startPoint, endPoint);

            // 경로 상의 블록 제거
            // foreach (Vector2Int point in path)
            // {
            //     maps[point.y, point.x] = 0;
            // }

            // 맵 생성
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (maps[i, j] == 1)
                    {
                        Vector3 blockPosition = new Vector3(j - WIDTH / 2, 0, i - HEIGHT / 2);
                        Instantiate(block, blockPosition, Quaternion.identity);
                    }
                }
            }
        }
    }

    private List<Vector2Int> GeneratePath(Vector2Int start, Vector2Int end)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Vector2Int current = start;
        path.Add(current);

        while (current != end)
        {
            if (Random.value > 0.5f)
            {
                // 가로로 이동
                if (current.x != end.x)
                {
                    current.x += (end.x > current.x) ? 1 : -1;
                }
                else if (current.y != end.y)
                {
                    current.y += (end.y > current.y) ? 1 : -1;
                }
            }
            else
            {
                // 세로로 이동
                if (current.y != end.y)
                {
                    current.y += (end.y > current.y) ? 1 : -1;
                }
                else if (current.x != end.x)
                {
                    current.x += (end.x > current.x) ? 1 : -1;
                }
            }

            path.Add(current);
        }

        return path;
    }
}