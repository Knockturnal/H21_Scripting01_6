using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	public Rigidbody2D rb2d;
	public float speed;
	private Vector2 myVel = Vector2.left;
	private void FixedUpdate()
	{
		rb2d.velocity = myVel * speed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		myVel *= -1f;
	}
}
