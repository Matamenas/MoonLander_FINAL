using UnityEngine;
using System.Collections;

/// <summary>
/// Spin the object at a specified speed
/// </summary>
public class SpinEarth : MonoBehaviour {

	public float speed = 10f;

	public float direction = 1f;


	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime);
	}
}