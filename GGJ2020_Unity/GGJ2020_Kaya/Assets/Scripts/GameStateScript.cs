using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Game { begin, game, matched, win, lose, notMatched }
public class GameStateScript : MonoBehaviour
{
	public GameObject Listener;
	public GameObject Speaker;
	LevelDataScript LevelData;
	WaveControllerScript waveController;
	public static Game State = Game.begin;
	ProgressBar progressBar;
	float threshold;
	public int gameCounter = 0;
	int won = 0;
	bool leftPersonTalk = true;

	public Head_AniScript leftPerson;
	public Head_AniScript rightPerson;

	Ingame_BGM bgm;

	public Image timerBar;

	float maxTimer = 6;
	float timer = 0;

	// Start is called before the first frame update
	void Start()
	{
		LevelData = GetComponent<LevelDataScript>();
		waveController = GetComponent<WaveControllerScript>();
		progressBar = FindObjectOfType<ProgressBar>();

		bgm = FindObjectOfType<Ingame_BGM>();

		threshold = progressBar.checkPoint2;
		timer = maxTimer;
	}

	// Update is called once per frame
	void Update()
	{
		switch (State)
		{
			case Game.begin:
				{
					Debug.Log(LevelData.Waves.Length);
					WaveType type = LevelData.Waves[gameCounter].type;
					float amplitude = LevelData.Waves[gameCounter].amplitude;
					float frequency = LevelData.Waves[gameCounter].frequency;
					Speaker.GetComponent<LineController>().switchWave(type, amplitude, frequency);

					leftPerson.SetIsTalking(true);

					Debug.Log("Begin State");
					break;
				}
			case Game.game:
				{

					timer -= Time.deltaTime;

					if (waveController.closeness > waveController.winMargin)
					{
						//Debug.Log(closeness + " " + winMargin);
						State = Game.matched;
						timer = maxTimer;
					}

					bgm.UpdateMatchRate(waveController.closeness);

					if (timer < 0)
					{
						State = Game.notMatched;
						timer = maxTimer;
					}

					timerBar.fillAmount = timer / maxTimer;

					//Debug.Log("Game State");
					break;
				}
			case Game.matched:
				{
					AudioStatics.PlayOneShotAtLocation("event:/sfx_good", Vector3.zero);
					gameCounter++;
					won++;
					Debug.Log("Matched State");
					Debug.Log(LevelData.Waves.Length);

					bgm.UpdateBGM(gameCounter / 4);

					progressBar.progress = (float)won / LevelData.Waves.Length;

					if (gameCounter >= LevelData.Waves.Length)
					{
						EndGame();
					}
					else
					{

						State = Game.game;
						WaveType type = LevelData.Waves[gameCounter].type;
						float amplitude = LevelData.Waves[gameCounter].amplitude;
						float frequency = LevelData.Waves[gameCounter].frequency;
						Speaker.GetComponent<LineController>().switchWave(type, amplitude, frequency);
						if (!leftPersonTalk)
						{
							leftPerson.SetIsTalking(true);
							rightPerson.GoodJob();
							timerBar.fillOrigin = 0;
						}
						else
						{
							rightPerson.SetIsTalking(true);
							leftPerson.GoodJob();
							timerBar.fillOrigin = 1;
						}

						leftPersonTalk = !leftPersonTalk;


					}
					break;
				}
			case Game.notMatched:
				gameCounter++;
				Debug.Log("Not Matched State");
				Debug.Log(LevelData.Waves.Length);
				bgm.UpdateBGM(gameCounter / 4);
				if (gameCounter >= LevelData.Waves.Length)
				{
					EndGame();
				}
				else
				{

					State = Game.game;
					WaveType type = LevelData.Waves[gameCounter].type;
					float amplitude = LevelData.Waves[gameCounter].amplitude;
					float frequency = LevelData.Waves[gameCounter].frequency;
					Speaker.GetComponent<LineController>().switchWave(type, amplitude, frequency);
					if (!leftPersonTalk)
					{
						leftPerson.SetIsTalking(true);
						timerBar.fillOrigin = 0;
					}
					else
					{
						rightPerson.SetIsTalking(true);
						timerBar.fillOrigin = 1;
					}

					leftPersonTalk = !leftPersonTalk;
				}
				break;
			case Game.win:
				{
					//Debug.Log("You Win");

					break;
				}
			case Game.lose:
				{
					//Debug.Log("You Lose");
					break;
				}
		}
	}

	void EndGame()
	{

		rightPerson.SetIsTalking(false);
		leftPerson.SetIsTalking(false);

		if (progressBar.progress > threshold)
		{
			State = Game.win;

			leftPerson.hS = Head_AniScript.HeadState.kissMove;

			rightPerson.hS = Head_AniScript.HeadState.kissMove;
			Debug.Log("You Win");
		}
		else
		{
			State = Game.lose;


			leftPerson.hS = Head_AniScript.HeadState.headButt;

			rightPerson.hS = Head_AniScript.HeadState.headButt;
			Debug.Log("You Lose");
		}
	}
}
