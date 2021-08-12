using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    int ballsReady;
    List<Ball> balls = new List<Ball>();
    LaunchPreview launchPreview;

    Vector3 startDragPosition;
    Vector3 endDragPosition;

    [SerializeField]
    Ball ballPrefab;
    SquareSpawner squareSpawner;

    void Awake()
    {
        squareSpawner = FindObjectOfType<SquareSpawner>();
        launchPreview = GetComponent<LaunchPreview>();
        CreateBall();
    }

    public void ReturnBall()
    {
        ballsReady++;
        if(ballsReady == balls.Count)
        {
            squareSpawner.SpawnRow();
            CreateBall();
        }
    }

    void CreateBall()
    {
        var ball = Instantiate(ballPrefab);
        balls.Add(ball);
        ballsReady++;
    }
    
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPosition);
        }
        else if(Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    void EndDrag()
    {
        if(ballsReady == balls.Count)
            StartCoroutine(LaunchBalls());
    }

    IEnumerator LaunchBalls()
    {
        Vector3 direction = endDragPosition - startDragPosition;
        direction.Normalize();

        foreach (var ball in balls)
        {   
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);           
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(0.1f);
        }

        ballsReady = 0;
    }

    void ContinueDrag(Vector3 worldPosition)
    {
        endDragPosition = worldPosition;


        launchPreview.SetEndPoint(endDragPosition);
    }

    void StartDrag(Vector3 worldPosition)
    {
        startDragPosition = worldPosition;
        launchPreview.SetStartPoint(transform.position);
    }
}
