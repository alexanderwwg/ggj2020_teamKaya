using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Game {begin, game, matched, win, lose}
public class GameStateScript : MonoBehaviour
{
    public GameObject Listener;
    public GameObject Speaker;
    public LevelDataScript LevelData;
    public WaveControllerScript WaveController;
    public static Game State = Game.begin;
    public GameObject progressBar;
    public float threshold = 50;
    public int gameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        LevelData = GetComponent<LevelDataScript>();
        WaveController = GetComponent<WaveControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(State)
        {
            case Game.begin:
            {   
                Debug.Log(LevelData.Waves.Length);
                WaveType type = LevelData.Waves[gameCounter].type;
                float amplitude = LevelData.Waves[gameCounter].amplitude;
                float frequency = LevelData.Waves[gameCounter].frequency;
                Speaker.GetComponent<LineController>().switchWave(type, amplitude, frequency);
                
                Debug.Log("Begin State");
                break;
            }
            case Game.game:
            {
                Debug.Log("Game State");
                break;
            }
            case Game.matched:
            {
                Debug.Log("Matched State");
                Debug.Log(LevelData.Waves.Length);
                if(gameCounter > LevelData.Waves.Length)
                {
                    if (progressBar.GetComponent<ProgressBar>().progress > threshold)
                    {
                        State=Game.win;
                    }
                    else
                    {
                        State=Game.lose;
                    }
                }
                else
                {
                    gameCounter++;
                    State=Game.game;
                    WaveType type = LevelData.Waves[gameCounter].type;
                    float amplitude = LevelData.Waves[gameCounter].amplitude;
                    float frequency = LevelData.Waves[gameCounter].frequency;
                    Speaker.GetComponent<LineController>().switchWave(type, amplitude, frequency);

                }
                break;
            }
            case Game.win:
            {
                Debug.Log("You Win");

                break;
            }
            case Game.lose:
            {
                Debug.Log("You Lose");
                break;
            }
        }
    }
}
