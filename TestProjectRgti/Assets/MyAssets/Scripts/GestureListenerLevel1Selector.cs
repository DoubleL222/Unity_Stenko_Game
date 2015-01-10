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
	public GameObject Quad1, Quad2;
	public GameObject CorrectSound;
	public GameObject WrongSound;

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
//		Quad1 = GameObject.Find ("Quad1");
//		Quad2 = GameObject.Find ("Quad2");
		int correct = PlayerPrefs.GetInt ("Correct cube");
		if (x < 0.25f && y < 0.6f ) {
			if (correct == 1) {
				StartCoroutine (WaitAndCorrect(2.0f));
			}
			else {
				WrongSound.audio.Play();
				Quad1.SetActive(true);
				Quad2.SetActive(true);
				StartCoroutine(WaitAndSetInactive(1.0F));
			}
				
		}
		else if (x < 0.5f && y < 0.6f && x > 0.25f) {
			if (correct == 2) {
				StartCoroutine (WaitAndCorrect(2.0f));
			}
			else {
				WrongSound.audio.Play();
				Quad1.SetActive(true);
				Quad2.SetActive(true);
				StartCoroutine(WaitAndSetInactive(1.0F));
			}
		}
		else if (x >= 0.5f && y < 0.6f && x < 0.75f) {
			if (correct == 3) {
				StartCoroutine (WaitAndCorrect(2.0f));
			}
			else {
				WrongSound.audio.Play();
				Quad1.SetActive(true);
				Quad2.SetActive(true);
				StartCoroutine(WaitAndSetInactive(1.0F));
			}
		}
		else if (x >= 0.75f && y < 0.6f) {
			if (correct == 4) {
				StartCoroutine (WaitAndCorrect(2.0f));
			}
			else {
				WrongSound.audio.Play();
				Quad1.SetActive(true);
				Quad2.SetActive(true);
				StartCoroutine(WaitAndSetInactive(1.0F));
			}
		}
	}

	IEnumerator WaitAndSetInactive(float waitTime) {
//		Quad1 = GameObject.Find ("Quad1");
//		Quad2 = GameObject.Find ("Quad2");
		yield return new WaitForSeconds(waitTime);
		Quad1.SetActive(false);
		Quad2.SetActive(false);
	}
	IEnumerator WaitAndCorrect(float waitTime) {
		CorrectSound.audio.Play();
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel("LevelSelectScreen");
	}
	

	
}
