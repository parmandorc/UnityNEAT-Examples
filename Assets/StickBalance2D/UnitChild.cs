using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitChild : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Wall")) 
		{
			transform.parent.GetComponent<StickController> ().OnWallHit ();
		}
	}
}
