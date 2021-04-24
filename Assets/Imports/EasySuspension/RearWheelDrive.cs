using UnityEngine;
using DMG.Cars.Wheels;

public class RearWheelDrive : MonoBehaviour {

	private WheelCollider[] _wheels;

	public float maxAngle = 30;
	public float maxTorque = 300;
	public GameObject wheelShape;

	public void Start()
	{
		_wheels = GetComponentsInChildren<WheelCollider>();

		foreach (var wheel in _wheels)
		{
			var spawner = wheel.GetComponent<WheelHandler>();
			spawner.SpawnWheel();
		}
	}

	public void Update()
	{
		var angle = maxAngle * Input.GetAxis("Horizontal");
		var torque = maxTorque * Input.GetAxis("Vertical");

		foreach (var wheel in _wheels)
		{
			if (wheel.transform.localPosition.z > 0)
				wheel.steerAngle = angle;

			if (wheel.transform.localPosition.z < 0)
				wheel.motorTorque = torque;
		}
	}
}
