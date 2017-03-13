using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharpNeat.Phenomes;

public class StickController : UnitController {

	private Rigidbody2D handle;
	private bool IsRunning;
	private IBlackBox box;

	void Awake() {
		handle = transform.Find ("Handle").GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {

		if (IsRunning) {

			ISignalArray inputArr = box.InputSignalArray;
			/*inputArr[0] = frontSensor;
			inputArr[1] = leftFrontSensor;
			inputArr[2] = leftSensor;
			inputArr[3] = rightFrontSensor;
			inputArr[4] = rightSensor;
			*/
			box.Activate();

			ISignalArray outputArr = box.OutputSignalArray;

			float vx = (float)(outputArr[0] * 2 - 1) * 1000.0f;
			float vy = (float)(outputArr[1] * 2 - 1) * 1000.0f;

			handle.velocity = new Vector2(vx, vy);
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
		return 0;
	}
}
