﻿using UnityEngine;
using UnityEditor;

class BoxyCarWizard : EditorWindow {
	private int axlesCount = 2;
	private float mass = 1000;
	private float axleStep = 2;
	private float axleWidth = 2;
	private float axleShift = -0.5f;

	[MenuItem ("Vehicles/Boxy car wizard")]
	public static void  ShowWindow () {
		GetWindow(typeof(BoxyCarWizard));
	}

	void OnGUI () {
		axlesCount = EditorGUILayout.IntSlider ("Axles: ", axlesCount, 2, 10);
		mass = EditorGUILayout.FloatField ("Mass: ", mass);
		axleStep = EditorGUILayout.FloatField ("Axle step: ", axleStep);
		axleWidth = EditorGUILayout.FloatField ("Axle width: ", axleWidth);
		axleShift = EditorGUILayout.FloatField ("Axle shift: ", axleShift);

		if (GUILayout.Button("Generate")) {
			CreateCar ();
		}
	}

	void CreateCar()
	{
		var root = new GameObject ("carBase");
		var rootBody = root.AddComponent<Rigidbody> ();
		rootBody.mass = mass;

		var body = GameObject.CreatePrimitive (PrimitiveType.Cube);
		body.transform.parent = root.transform;

		float length = (axlesCount - 1) * axleStep;
		float firstOffset = length / 2;

		body.transform.localScale = new Vector3(axleWidth, 1, length);

		for (int i = 0; i < axlesCount; ++i) 
		{
			var leftWheel = new GameObject ($"Axel{i} - Left");
			var rightWheel = new GameObject ($"Axel{i} - Right");

			leftWheel.AddComponent<WheelCollider> ();
			rightWheel.AddComponent<WheelCollider> ();

			leftWheel.transform.parent = root.transform;
			rightWheel.transform.parent = root.transform;

			leftWheel.transform.localPosition = new Vector3 (-axleWidth / 2, axleShift, firstOffset - axleStep * i);
			rightWheel.transform.localPosition = new Vector3 (axleWidth / 2, axleShift, firstOffset - axleStep * i);
		}

		root.AddComponent<EasySuspension>();
		root.AddComponent<RearWheelDrive>();
	}
}