using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private BoxCollider2D boxCollider;

    private float halfColliderWidth;
    private float halfColliderHeight;

    float originalX;

    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        halfColliderWidth = boxCollider.size.x / 2;
        halfColliderHeight = boxCollider.size.y / 2;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");


        if (horizontal != 0)
        {
            Vector2 position = rb2d.position;
            position.x += horizontal * ConfigurationUtils.PaddleMoveUnitsPerSecond *
                Time.deltaTime;
            position.x = CalculateClampedX(position.x);
            rb2d.MovePosition(position);
        }
    }

    private float CalculateClampedX(float x)
    {

        // clamp left and right edges
        if (x - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else if (x + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - halfColliderWidth;
        }
        return x;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            if (IsItTopCollision(coll))
            {
                // calculate new ball direction
                float ballOffsetFromPaddleCenter = transform.position.x -
                    coll.transform.position.x;
                float normalizedBallOffset = ballOffsetFromPaddleCenter /
                    halfColliderWidth;
                float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
                float angle = Mathf.PI / 2 + angleOffset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                // tell ball to set direction to new direction
                Ball ballScript = coll.gameObject.GetComponent<Ball>();
                ballScript.SetDirection(direction);
            }
        }
    }

    private bool IsItTopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = coll.contacts;
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }
}
