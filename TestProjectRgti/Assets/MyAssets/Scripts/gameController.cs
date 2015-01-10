using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

	public ballSpawner ballSpawn;
	public GameObject spawner1;
	public GameObject spawner2;
	public GameObject spawner3;
	public GameObject spawner4;
	public GameObject spawner5;
	public GameObject spawner6;
	public GameObject spawner7;
	public GameObject winSound;
	public GameObject failSound;
	public GameObject spawnSound;
	public GameObject introSound;
	public float fireRate=2;
	public float startDelay=5;
	public float ballForce=12;
	public int rotationRange=300;
	
	public Text scoreText;
	public Text gameOverText;

	private bool gameOver;
	private float nextFire;
	private ArrayList spawnerji;
	private ArrayList enacbe;
	private int[] rezultati;
	private GameObject currSpawner;
	private int index;
	private int indexEnacbe;
	private float kotStrela;
	private int ballsHit=0;
	private float izstrelkov;
	private int rez;
	private float diff;
		// Use this for initialization
	void Start () {
		introSound.audio.Play ();
		spawnerji=new ArrayList();
		spawnerji.Add (spawner1);
		spawnerji.Add (spawner2);
		spawnerji.Add (spawner3);
		spawnerji.Add (spawner4);
		spawnerji.Add (spawner5);
		spawnerji.Add (spawner6);
		spawnerji.Add (spawner7);

		enacbe = new ArrayList ();
		enacbe.Add ("3 + 2 = ");
		enacbe.Add ("5 + 1 = ");
		enacbe.Add ("2 + 7 = ");
		enacbe.Add ("5 + 5 = ");
		enacbe.Add ("6 + 7 = ");

		enacbe.Add("10 - 7 = ");
		enacbe.Add("15 - 8 = ");
		enacbe.Add("8 - 0 = ");
		enacbe.Add("20 - 11 = ");
		enacbe.Add("39 - 28 = ");

		enacbe.Add("2 X 3 = ");
		enacbe.Add("1 X 7 = ");
		enacbe.Add("4 X 2 = ");
		enacbe.Add("3 X 4 = ");
		enacbe.Add("5 X 3 = ");

		enacbe.Add ("8 / 2 = ");
		enacbe.Add ("15 / 5 = ");
		enacbe.Add ("66 / 22 = ");
		enacbe.Add ("110 / 11 = ");
		enacbe.Add ("250 / 50 = ");

		rezultati = new int[20];
		rezultati[0]=5;
		rezultati[1]=6;
		rezultati[2]=9;
		rezultati[3]=10;
		rezultati[4]=13;

		rezultati[5]=3;
		rezultati[6]=7;
		rezultati[7]=8;
		rezultati[8]=9;
		rezultati[9]=11;

		rezultati[10]=6;
		rezultati[11]=7;
		rezultati[12]=8;
		rezultati[13]=12;
		rezultati[14]=15;

		rezultati[15]=4;
		rezultati[16]=3;
		rezultati[17]=3;
		rezultati[18]=10;
		rezultati[19]=5;

		indexEnacbe = Random.Range (0, enacbe.Count);

		scoreText.text = enacbe [indexEnacbe] as string;
		rez = rezultati [indexEnacbe];
		diff = Mathf.Ceil (rez / 2);
		izstrelkov = rez + diff;
//		scoreText= GameObject.FindWithTag ("scoreText") as GUIText;
	}
	public void AddScore (int newScoreValue)
	{
		ballsHit += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore ()
	{
		scoreText.text = enacbe[indexEnacbe] as string + ballsHit;
	//	Debug.Log ("Balls hit: " + ballsHit);
	}
	public IEnumerator pocakaj(float sekund){
		Debug.Log ("in pocakaj ");
		yield return new WaitForSeconds (sekund);
		Debug.Log ("after yield ");
		if (ballsHit == rez) {
			gameOverText.color = Color.green;
			gameOverText.text = "Bravo! Enačba je bila rešena pravilno";
			winSound.audio.Play();
			yield return new WaitForSeconds (3);
			Application.LoadLevel("LevelSelectScreen");
		} 
		else {
			gameOverText.color = Color.red;
			gameOverText.text = "Narobe! Pravilen rezultat je "+ rez;
			failSound.audio.Play();
			yield return new WaitForSeconds (3);
			Application.LoadLevel("LevelSelectScreen");
		}
		gameOver = true;
	}
	public void GameOver ()
	{
		StartCoroutine (pocakaj(3.0f));
	}
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire && izstrelkov>0 && Time.time > startDelay) {
			spawnSound.audio.Play();
			nextFire = Time.time + fireRate;
			index = Random.Range (0, spawnerji.Count);
			kotStrela = Random.Range (-100, 100);
			kotStrela = kotStrela / rotationRange;
			if (index < spawnerji.Count / 2) {
					kotStrela = Mathf.Abs (kotStrela);
			} else if (index >= spawnerji.Count / 2) {
					kotStrela = -Mathf.Abs (kotStrela);
			}
			currSpawner = spawnerji [index] as GameObject;
		//	Debug.Log ("current spawner" + currSpawner.name);
		//	Debug.Log ("kot strela " + kotStrela);
			ballSpawn.SpawnBall (currSpawner, kotStrela, ballForce);
				
				
				izstrelkov--;
				Debug.Log(izstrelkov);
		}
		if (izstrelkov == 0) {
			GameOver();		
			Debug.Log ("game over called");
			izstrelkov--;
		}

	}
}
