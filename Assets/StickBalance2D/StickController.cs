using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharpNeat.Phenomes;

public class StickController : UnitController {

	[SerializeField]
	private float InitialAngle;

	[SerializeField]
	private float MaxVelocity;

	private Rigidbody2D handle;
	private Rigidbody2D ball;
	private bool IsRunning;
	private IBlackBox box;
	private float fitness;

	void Awake() {
		handle = transform.Find ("Handle").GetComponent<Rigidbody2D> ();
		ball = transform.Find ("Ball").GetComponent<Rigidbody2D> ();
		transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(-InitialAngle, InitialAngle)));
	}

	void FixedUpdate () {

		if (IsRunning) {

			// Get inputs

			Vector2 ballPosition = (ball.transform.position - handle.transform.position).normalized;
			float ballAngle = ballPosition.x; // This is actually the cosine of the angle, but no need for the actual value

			ISignalArray inputArr = box.InputSignalArray;
			inputArr [0] = ballAngle;
			inputArr [1] = ball.velocity.x;
			inputArr [2] = ball.velocity.y;


			// Run neural network

			box.Activate();


			// Process outputs

			ISignalArray outputArr = box.OutputSignalArray;

			float vx = (float)outputArr[0] * 2 - 1;
			float vy = (float)outputArr[1] * 2 - 1;

			handle.velocity = Vector2.ClampMagnitude(new Vector2(vx, vy), 1.0f) * MaxVelocity;


			// Update fitness

			fitness += ballPosition.y * Time.deltaTime;
		}
	}

	public override void Stop()
	{
		this.IsRunning = false;
	}

	public override void Activate(IBlackBox box)
	{
		this.box = box;
		this.IsRunning = true;
	}

	public override float GetFitness()
	{
		return Mathf.Max(fitness, 0.0f);
	}
}
