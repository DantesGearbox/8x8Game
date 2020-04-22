using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;

	public FloatWrapper movespeed;
	public BoolWrapper takesInput;

	public Sequence dodgeRoll;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
	}
	
    void Update()
    {
		if (!takesInput.boolValue)
		{
			return;
		}

		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		Vector2 inputDirection = new Vector2(horizontal, vertical);
		inputDirection = ClampMagnitudeVector2(inputDirection, 0, 1);

		rb.velocity = inputDirection * movespeed.floatValue;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			dodgeRoll.StopTimer(); //To reset it
			dodgeRoll.StartTimer(); //To start it up
		}
	}

	Vector2 SetMagnitudeVector2(Vector2 vec, float newMagnitude)
	{
		float reciprocal = 1 / vec.magnitude;

		float xCoord = vec.x * reciprocal;
		float yCoord = vec.y * reciprocal;
		
		return vec.normalized * newMagnitude;
	}

	Vector2 ClampMagnitudeVector2(Vector2 vec, float minMagnitude, float maxMagnitude)
	{
		if(vec.magnitude > maxMagnitude)
		{
			return SetMagnitudeVector2(vec, maxMagnitude);
		}
		else if(vec.magnitude < minMagnitude)
		{
			return SetMagnitudeVector2(vec, minMagnitude);
		}
		else
		{
			return vec;
		}
	}
}