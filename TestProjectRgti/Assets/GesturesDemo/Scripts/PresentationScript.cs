using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresentationScript : MonoBehaviour 
{
	public bool slideChangeWithGestures = true;
	public bool slideChangeWithKeys = true;
	public float spinSpeed = 5;
	
	public bool autoChangeAlfterDelay = false;
	public float slideChangeAfterDelay = 10;
	
	public List<GameObject> horizontalSides;
	
	// if the presentation cube is behind the user (true) or in front of the user (false)
	public bool isBehindUser = false;
	
	private int maxSides = 0;
	private int side = 0;
	private int tex = 0;
	private bool isSpinning = false;
	private float slideWaitUntil;
	//private Quaternion targetRotationHor;
	//private Quaternion targetRotationVer;
	private Quaternion targetRotation;
	
	private GestureListenerLevel1 gestureListener;
	

	
	void Start() 
	{
		// hide mouse cursor
		Screen.showCursor = false;
		
		// calculate max slides and textures
		maxSides = horizontalSides.Count;

		// delay the first slide
		slideWaitUntil = Time.realtimeSinceStartup + slideChangeAfterDelay;

		//targetRotation = transform.rotation;
		//targetRotation = transform.rotation;
		targetRotation = transform.rotation;
		isSpinning = false;
		
		// get the gestures listener
		gestureListener = Camera.main.GetComponent<GestureListenerLevel1>();
	}
	
	void Update() 
	{
		// dont run Update() if there is no user
		KinectManager kinectManager = KinectManager.Instance;
		if(autoChangeAlfterDelay && (!kinectManager || !kinectManager.IsInitialized() || !kinectManager.IsUserDetected()))
			return;
		
		if(!isSpinning)
		{
			if(slideChangeWithKeys)
			{
				if(Input.GetKeyDown(KeyCode.PageDown))
					RotateToNext();
				else if(Input.GetKeyDown(KeyCode.PageUp))
					RotateToPrevious();
			}
			
			if(slideChangeWithGestures && gestureListener)
			{
				if(gestureListener.IsSwipeLeft())
					RotateToNext();
				else if(gestureListener.IsSwipeRight())
					RotateToPrevious();
				else if(gestureListener.IsSwipeUp())
					RotateUp();
				else if(gestureListener.IsSwipeDown())
					RotateDown();
			}
			
			// check for automatic slide-change after a given delay time
			if(autoChangeAlfterDelay && Time.realtimeSinceStartup >= slideWaitUntil)
			{
				RotateToNext();
			}
		}
		else
		{
			// spin the presentation
			//targetRotation = targetRotationVer * targetRotationHor;
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, spinSpeed * Time.deltaTime);
			
			// check if transform reaches the target rotation. If yes - stop spinning
			float deltaTargetX = Mathf.Abs(targetRotation.eulerAngles.x - transform.rotation.eulerAngles.x);
			float deltaTargetY = Mathf.Abs(targetRotation.eulerAngles.y - transform.rotation.eulerAngles.y);
			
			if(deltaTargetX < 1f && deltaTargetY < 1f)
			{
				// delay the slide
				slideWaitUntil = Time.realtimeSinceStartup + slideChangeAfterDelay;
				isSpinning = false;
			}
		}
	}

	private void RotateUp()
	{
		// rotate the presentation
		Vector3 rotateDegrees = new Vector3(90f, 0f, 0f);
		targetRotation *= Quaternion.Euler(rotateDegrees);
		isSpinning = true;
	}

	private void RotateDown()
	{		
		// rotate the presentation
		Vector3 rotateDegrees = new Vector3(-90f, 0f, 0f);
		targetRotation *= Quaternion.Euler(rotateDegrees);
		isSpinning = true;
	}
	
	private void RotateToNext()
	{
		// set the next texture slide

		if(!isBehindUser)
		{
			side = (side + 1) % maxSides;
		}
		else
		{
			if(side <= 0)
				side = maxSides - 1;
			else
				side -= 1;
		}
		
		// rotate the presentation
		float yawRotation = !isBehindUser ? 360f / maxSides : -360f / maxSides;
		Vector3 rotateDegrees = new Vector3(0f, yawRotation, 0f);
		targetRotation *= Quaternion.Euler(rotateDegrees);
		isSpinning = true;
	}
	
	
	private void RotateToPrevious()
	{
		if(!isBehindUser)
		{
			if(side <= 0)
				side = maxSides - 1;
			else
				side -= 1;
		}
		else
		{
			side = (side + 1) % maxSides;
		}
		
		// rotate the presentation
		float yawRotation = !isBehindUser ? -360f / maxSides : 360f / maxSides;
		Vector3 rotateDegrees = new Vector3(0f, yawRotation, 0f);
		targetRotation *= Quaternion.Euler(rotateDegrees);
		isSpinning = true;
	}
	
	
}
