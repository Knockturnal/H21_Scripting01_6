using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
	public Rigidbody2D myRigidBody;
	public float speed, jumpForce;
	public LayerMask walkableLayers;
	private bool jumpRequested, isOnGround;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))	//	We have to get the button press in Update() so we don't miss an input accidentally
			jumpRequested = true;

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, walkableLayers);	//	Cast a ray down from the player's center with a length of 1.2m (because that's a little more than the distance to the ground)

		if (hit)
			isOnGround = true;
		else
			isOnGround = false;

		//	The following is a shortcut. We can cast the result of the raycast directly to a bool if we don't need any more of the hitinfo we would otherwise return
		//isOnGround = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, walkableLayers);
	}

	private void FixedUpdate()
	{
		float xMovement = Input.GetAxis("Horizontal") * speed;
		myRigidBody.velocity = new Vector2(xMovement, myRigidBody.velocity.y);

		if (jumpRequested && isOnGround)
			myRigidBody.AddForce(Vector2.up * jumpForce);

		jumpRequested = false;
	}
}
