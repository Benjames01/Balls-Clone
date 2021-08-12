using System;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    [SerializeField]
    Square squarePrefab;
    [SerializeField]
    int playWidth = 8;
    float distanceBetweenSquares = 0.75f;
    int rowsSpawned;

    List<Square> spawnedSquares = new List<Square>();

    void OnEnable() {

        for (int i = 0; i < 1; i++)
        {
            SpawnRow();
        }
    }

    public void SpawnRow()
    {   
        foreach (var square in spawnedSquares)
        {
            if(square != null)
            {
                square.transform.position += Vector3.down * distanceBetweenSquares;
            }
        }

        for (int i = 0; i < playWidth; i++)
        {
            if(UnityEngine.Random.Range(0, 100) <= 30)
            {
                var square = Instantiate(squarePrefab, GetPosition(i), Quaternion.identity);
                int hits = UnityEngine.Random.Range(1, 3) + rowsSpawned;

                square.SetHits(hits);

                spawnedSquares.Add(square);
            }
        }
         rowsSpawned++;
    }

    Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * distanceBetweenSquares;

        return position;  
    }
}
