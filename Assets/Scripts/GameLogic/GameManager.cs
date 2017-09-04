using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameManager:MonoBehaviour
{
	private static volatile GameManager instance;
	private static object syncRoot = new Object();
	private float secondsCount = 0;
	private int minCount = 0;
	private float startTime = 0;
	[SerializeField] private Text livesText;
	[SerializeField] private Text timeText;
	[SerializeField] private Text WinTimeText;
	private int lives = 3;

	public static GameManager Instance {
		get {
			if (instance == null) {
				GameObject obj = new GameObject ("GameManager");
				obj.AddComponent<GameManager> ();
			}

			return instance;
		}
	}

	public void SetActiveGameCanvas(bool val) {
		
		livesText.transform.parent.gameObject.SetActive (val);
	}

	void Start(){
		startTime = Time.time;
		ShowLives();
	}

	private void ShowLives(){
		livesText.text = "Lives: " + lives;
	}

	private void ShowTime(){
		timeText.text = string.Format ("{0} : {1}", minCount, secondsCount);
	}


	void Update (){
		UpdateTimer ();
	}

	///sub one live and return true if lives == 0
	public bool SubLive(){
		lives--;
		ShowLives ();
		return lives == 0? true : false;

	}

	public void Reset(){
		lives = 3;
		secondsCount = 0;
		minCount = 0;
		startTime = Time.time;
	}

	public void UpdateTimer(){
		float time = Time.time - startTime;
		secondsCount = (int)(time % 60);
		minCount = (int)(time / 60);
		ShowTime ();
	}

	public void ShowWinnerScore(){
		WinTimeText.text = string.Format ("Your Time Score is: {0}:{1}", minCount, secondsCount);
		//show the winner canvas
		WinTimeText.transform.parent.gameObject.SetActive(true);
	}

	void Awake(){
		instance = this;
		InitializeScore ();
	}

	//TODO
	public void finishLevel(){
		SaveScore ((minCount * 60 )+ secondsCount);
		//need to show winner text and score
	}

	/// <summary>
	/// Saving score if needed
	/// </summary>
	public void SaveScore(float score){
		List<float> scores = new List<float>();
		int worstIndex = 0;
		float worst = 0;
		for (int i = 1; i < 11; i++) {
			scores.Add(PlayerPrefs.GetFloat("Score"+i));
		}
		for(int i = 1; i < 11; i++){
			if (scores [i - 1] > worst) {
				worst = scores [i - 1];
				worstIndex = i;
			}
		}
		//the new score is better then the worst
		if(score < worst){
			PlayerPrefs.SetFloat("Score"+worstIndex,score);
		}
	}

	private void InitializeScore(){
		int defScore = 9999999;
		//first time you play
		if (PlayerPrefs.HasKey ("Score1") == null) {
			for (int i = 1; i < 11; i++) {
				PlayerPrefs.SetInt ("Score" + i.ToString (), defScore);
			}
		}
	}
}
