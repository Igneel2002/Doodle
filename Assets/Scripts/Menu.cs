using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Death death;
    public Win winner;
    public Character play;
    [SerializeField]
    private GameObject score;
    [SerializeField]
    private GameObject highscore;
    [SerializeField]
    private GameObject start;
    [SerializeField]
    private GameObject pause;
    [SerializeField]
    private GameObject DEAD;
    [SerializeField]
    private GameObject WIN;
    [SerializeField]
    private GameObject Tip;
    [SerializeField]
    private bool paus;
    public float Highscore = 99f;
    public float Score = 0f;
    [SerializeField]
    public Text Highscoretext;
    [SerializeField]
    public Text Scoretext;
    [SerializeField]
    private bool st;
    public AudioMixer masterAudio;

    // When the game boots
    void Start()
    {
        // Stop game from playing
        Time.timeScale = 0;
        // Make start menu visible
        start.SetActive(true);
        // Make pause menu invisible
        pause.SetActive(false);
        // Make p = pause not work
        paus = false;
        // Dismiss tip
        Tip.SetActive(false);
        // Dismiss score count
        score.SetActive(false);
        // Dismiss highscore count
        highscore.SetActive(false);
        // Dismiss death screen
        DEAD.SetActive(false);
        // Dismiss win screen
        WIN.SetActive(false);
    }


    public void START()
    {
        // Dismiss start menu
        start.SetActive(false);
        // Reveal tip
        Tip.SetActive(true);
        // Reveal score
        score.SetActive(true);
        // Reveal highscore
        highscore.SetActive(true);
        // Restart time so that the game can work
        Time.timeScale = 1;
        // Make p = pause work
        paus = true;
        // Make st true
        st = true;

        play.player.transform.position = play.Spawn.transform.position;
    }

    public void Return()
    {
        DEAD.SetActive(false);
        WIN.SetActive(false);
        start.SetActive(true);
    }

    public void Resume()
    {
        // Dismiss pause menu
        pause.SetActive(false);
        // Restart time so that the game can work
        Time.timeScale = 1;
        // Reveal tip
        Tip.SetActive(true);
        // Reveal score
        score.SetActive(true);
        // Reveal highscore
        highscore.SetActive(true);
        // Make p = pause work
        paus = true;
    }

    public void SAVE()
    {
        // Save highscore as float
        PlayerPrefs.SetFloat("Highscore", Highscore);
    }

    public void LOAD()
    {
        // Load highscore previous float, if a set float doesn't exist load default of 0
        float num =  PlayerPrefs.GetFloat("Highscore", 99);
        Highscore = num;
    }

    public void TRY()
    {
        WIN.SetActive(false);
        // Dismiss tip
        Tip.SetActive(true);
        // Set Score/time to 0
        Score = 0;
        // Spawn the player in
        play.player.transform.position = play.Spawn.transform.position;
        // Start time to play the game
        Time.timeScale = 1;
    }

    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat("volume", volume);
    }

    void Update()
    {
        if (st == true)
        {
            // Make a timer of real seconds
            Score += 1 * Time.deltaTime;
        }
        else if (st != true)
        {
            Score = 0;
        }
        // If p key is pressed
        if (Input.GetKeyDown("p"))
        {
            // If paus is true
            if (paus == true)
            {
                // Reveal pause menu
                pause.SetActive(true);
                // Reveal tip
                Tip.SetActive(false);
                // Dismiss score
                score.SetActive(false);
                // Dismiss highscore
                highscore.SetActive(false);
                // Pause game
                Time.timeScale = 0;
                // Play coroutine
                StartCoroutine(Delay(0.1f));
            }

            // If paus is false
            if (paus == false)
            {
                // Dismiss pause menu
                pause.SetActive(false);
                // Reveal tip
                Tip.SetActive(true);
                // Reveal score
                score.SetActive(true);
                // Reveal highscore
                highscore.SetActive(true);
                // Restart time so game can be played
                Time.timeScale = 1;
                // Play Coroutine
                StartCoroutine(Delay2(0.1f));
            }

        }
        // If bool dead is true
        if (death.dead == true)
        {
            // Play Coroutine
            StartCoroutine(Delay3(0.1f));
        }
        
        // If bool win is true
        if ( winner.win == true)
        {
            // If Highscore is greater than Score
            if (Highscore > Score)
            {
                Highscore = Score;
            }
            // Play Coroutine
            StartCoroutine(Delay4(0.1f));
        }
        // Highscoretext will display (Time and number of seconds that has passed)
        Highscoretext.text = "Best Time " + (int)Highscore;
        // Scoretext will display (Time and number of seconds that has passed)
        Scoretext.text = "Time " + (int)Score;
    }

    public IEnumerator Delay(float _Delay)
    {
        // Return value and wait for real seconds
        yield return new WaitForSecondsRealtime(_Delay);
        // Make paus false
        paus = false;
    }

    public IEnumerator Delay2(float _Delay)
    {
        // Return value and wait for real seconds
        yield return new WaitForSecondsRealtime(_Delay);
        // Make paus false
        paus = true;
    }
    
    public IEnumerator Delay3(float _Delay)
    {
        // Return value and wait for real seconds
        yield return new WaitForSecondsRealtime(_Delay);
        // Make st false
        st = false;
        // display death screen
        DEAD.SetActive(true);
        // Dismiss tip
        Tip.SetActive(false);
        // Dismiss score
        score.SetActive(false);
        // Dismiss highscore
        highscore.SetActive(false);
        // Make dead false
        death.dead = false;
    }
    
    public IEnumerator Delay4(float _Delay)
    {
        // Return value and wait for real seconds
        yield return new WaitForSecondsRealtime(_Delay);
        // display death screen
        WIN.SetActive(true);
        // Dismiss tip
        Tip.SetActive(false);
        // Dismiss score
        score.SetActive(true);
        // Dismiss highscore
        highscore.SetActive(true);
        // Make dead false
        winner.win = false;
    }

    public void EXIT()
    {
        // If this is in unity editor
#if     UNITY_EDITOR
        // Close unity editor otherwise close application
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
