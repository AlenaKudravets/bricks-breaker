using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;
    private Timer timer;
    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    void Start()
    {
        timer = GetComponent<Timer>();
        LaunchTimer();

        GameObject tempBall = Instantiate<GameObject>(ballPrefab);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);

        SpawnNewBall();
    }

    void Update()
    {
        if (timer.Finished)
        {
            SpawnNewBall();
            LaunchTimer();
        }
        if (retrySpawn)
        {
            SpawnNewBall();
            LaunchTimer();
        }
    }

    public void SpawnNewBall()
    {
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            Instantiate(ballPrefab);
        }
        else
        {
            retrySpawn = true;
        }
    }

    private void LaunchTimer()
    {
        timer.Duration = Random.Range(ConfigurationUtils.NewBallMinTimeSpawn, ConfigurationUtils.NewBallMaxTimeSpawn);
        timer.Run();
    }
}
