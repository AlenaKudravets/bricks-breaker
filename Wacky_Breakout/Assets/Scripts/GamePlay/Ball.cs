using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private Vector2 force;

    private float angle;

    private float speed;

    private float previousSpeed;

    private Timer timerOfBallDeath;

    private BallSpawner ballSpawner;

    Vector2 previousVector;

    private bool invisible = false;

    void Start()
    {
        ballSpawner = Camera.main.GetComponent<BallSpawner>();

        rb2d = GetComponent<Rigidbody2D>();

        timerOfBallDeath = GetComponent<Timer>();
        timerOfBallDeath.Duration = ConfigurationUtils.BallLifeTime;
        timerOfBallDeath.Run();

        StartCoroutine("StartMovingWithDelay");
    }

    private void Update()
    {
        if (timerOfBallDeath.Finished && !invisible)
        {
            ballSpawner.SpawnNewBall();
            Destroy(gameObject);
        }
        else if (invisible)
        {
            ballSpawner.SpawnNewBall();
            timerOfBallDeath.Stop();
            invisible = false;
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        speed = rb2d.velocity.magnitude;
        rb2d.velocity = newDirection * speed;
    }

    IEnumerator StartMovingWithDelay()
    {
        yield return new WaitForSeconds(1f);
        angle = -90 * Mathf.Deg2Rad;
        force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        rb2d.AddForce(force);
    }

    private void StartBall()
    {  
        rb2d.velocity = previousVector * previousSpeed;
    }

    private void StopBall()
    {
        previousVector = rb2d.velocity;
        previousSpeed = rb2d.velocity.magnitude;
        rb2d.velocity = new Vector2(0, 0);
    }

    private bool OnBecameInvisible()
    {
        HUD.RemoveBall(1);
        invisible = true;
        return invisible;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ball")
    //    {
    //        Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
    //    }
    //}
}
