using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class GameManager:MonoBehaviour
{
	private static volatile GameManager instance;
	private static object syncRoot = new Object();
	private int secondsCount = 0;
	private int minCount = 0;
	private float startTime = 0;
	[SerializeField] private Text livesText;
	[SerializeField] private Text timeText;
	[SerializeField] private Text WinTimeText;
	[SerializeField] private GameObject WinnerCanvas;
	[SerializeField] private GameObject GameOverCanvas;
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
	}

	//TODO
	public void finishLevel(){
		SaveScore ((minCount * 60 )+ secondsCount);
		WinTimeText.text = string.Format ("{0}:{1}",minCount,secondsCount);
		Reset ();
		Time.timeScale = 0;
		WinnerCanvas.gameObject.SetActive(true);
		//need to show winner text and score
	}

	/// <summary>
	/// Saving score if needed
	/// </summary>
	public void SaveScore(int score){
		int temp;

		for(int i=1; i<=10; i++)
		{
			if(PlayerPrefs.GetInt("Score"+i.ToString())>score)     //if cuurent score is in top 10
			{
				temp=PlayerPrefs.GetInt("Score"+i.ToString());     //store the old highscore in temp varible to shift it down 
				PlayerPrefs.SetInt("Score"+i.ToString(),score);     //store the currentscore to highscores
				if(i<10)                                        //do this for shifting scores down
				{
					int j=i+1;
					score = PlayerPrefs.GetInt("Score"+j.ToString());
					PlayerPrefs.SetInt("Score"+j.ToString(),temp);    
				}
			}
		}
	}



	public void RestartGame(){
		Time.timeScale = 1;
		Reset ();
		SceneManager.LoadScene (0);
	}

	public void MainMenu(){
		Time.timeScale = 1;
		SceneManager.LoadScene (1);
	}

	public void GameOver(){
		Reset ();
		Time.timeScale = 0;
		GameOverCanvas.gameObject.SetActive(true);
	}
}
