using UnityEngine;
using System.Collections;
using System;

public class GestureListenerLevel1Selector : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// Custom added
	//public ChangeCubeColor changeCubeScript;

	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;
	private int numberOfRaises;

	// private bool to track if progress message has been displayed
	private bool progressDisplayed;
	
	
	public void UserDetected(uint userId, int userIndex)
	{
		// as an example - detect these user specific gestures
		KinectManager manager = KinectManager.Instance;
		manager.DetectGesture(userId, KinectGestures.Gestures.Jump);
		manager.DetectGesture(userId, KinectGestures.Gestures.Squat);
		manager.DetectGesture(userId, KinectGestures.Gestures.Push);
		manager.DetectGesture(userId, KinectGestures.Gestures.Pull);
		manager.DetectGesture(userId, KinectGestures.Gestures.RaiseRightHand);
//		manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeUp);
//		manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeDown);
		
		if(GestureInfo != null)
		{
			GestureInfo.guiText.text = "SwipeLeft, SwipeRight, Jump, Push or Pull.";
		}
	}
	
	public void UserLost(uint userId, int userIndex)
	{
		if(GestureInfo != null)
		{
			GestureInfo.guiText.text = string.Empty;
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
		float progress, KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
	{
		//GestureInfo.guiText.text = string.Format("{0} Progress: {1:F1}%", gesture, (progress * 100));
		if(gesture == KinectGestures.Gestures.Click && progress > 0.3f)
		{
			//string sGestureText = string.Format ("{1:F2} detected, zoom={2:F2}%", screenPos.x, screenPos.y);
			if(GestureInfo != null)
				//GestureInfo.guiText.text = sGestureText;
			
			progressDisplayed = true;
		}	
	

	}

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
		KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
	{
		string sGestureText = gesture + " detected";
		if (gesture == KinectGestures.Gestures.Click) {
			Changed(screenPos.x, screenPos.y);
			sGestureText += string.Format (" at ({0:F1}, {1:F1})", screenPos.x, screenPos.y);
		}
		else if(gesture == KinectGestures.Gestures.RaiseRightHand)
		{
			Application.LoadLevel("Level1");
		}

		if(GestureInfo != null)
			GestureInfo.guiText.text = sGestureText;
		
		progressDisplayed = false;
		PlayerPrefs.SetInt ("Level 1 returns", PlayerPrefs.GetInt ("Level 1 returns") + 1);
		return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
		KinectWrapper.SkeletonJoint joint)
	{
		//changeCubeScript.Clean();
		if(progressDisplayed)
		{
			// clear the progress info
			if(GestureInfo != null)
				GestureInfo.guiText.text = String.Empty;
			
			progressDisplayed = false;
		}
		
		return true;
	}

	public void Changed(float x, float y) {
		GameObject xMark = GameObject.Find ("Xmark");
		int correct = PlayerPrefs.GetInt ("Correct cube");
		if (x < 0.25f && y < 0.6f ) {
			if (correct == 1) 
				Application.LoadLevel("LevelSelectScreen");
			else {
				xMark.SetActive(true);
				Destroy(xMark, 1f);
			}
				
		}
		else if (x < 0.5f && y < 0.6f && x > 0.25f) {
			if (correct == 2) 
				Application.LoadLevel("LevelSelectScreen");
			else {
				xMark.SetActive(true);
				Destroy(xMark, 1f);
			}
		}
		else if (x >= 0.5f && y < 0.6f && x < 0.75f) {
			if (correct == 3) 
				Application.LoadLevel("LevelSelectScreen");
			else {
				xMark.SetActive(true);
				Destroy(xMark, 1f);
			}
		}
		else if (x >= 0.75f && y < 0.6f) {
			if (correct == 4) 
				Application.LoadLevel("LevelSelectScreen");
			else {
				xMark.SetActive(true);
				Destroy(xMark, 1f);
			}
		}
	}
	
}
