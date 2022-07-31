using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public int extraLives; 
    private int score;
    private float timePassed;


    public SpriteRenderer shell;
    public PlayerController playerController;
    public PlayAudioClip FXSource;

    public TMP_Text timerTextField;
    public TMP_Text scoreTextField;
    public TMP_Text appendedScoreTextField;
    public TMP_Text extraLivesField;

    private Color defaultColor;
    void Start()
    {
        score = 0;
        timePassed = 0;
        extraLivesField.text = extraLives.ToString();
        defaultColor = shell.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTimerUI();
        if (extraLives < 0)
        {
            if (Input.anyKeyDown) { RestartScene(); }
        }
    }

    void UpdateTimerUI() {
        timePassed += Time.deltaTime;
        timerTextField.text = timePassed.ToString("0:00");
    }

    void UpdateLivesLeftUI()
    {
        extraLivesField.text = extraLives.ToString();
    }

    public void ConfirmEnemyDestroyed(int addedScore)
    {
        PlayDeflectAudio();
        score += addedScore;
        if(addedScore >0)
        appendedScoreTextField.text = "+" + addedScore.ToString();
        else appendedScoreTextField.text = addedScore.ToString();
        scoreTextField.text = score.ToString();
    }


    public void AddLife()
    {
        extraLives++;
        UpdateLivesLeftUI();
        PlayLifeGainAudio();
    }

    public void PlayerGotHit()
    {
        if (extraLives == 0)
        {
            //Save Score
            PlayDeathAudio();
            DisableControls();
            DeathAnimation();
            StartCoroutine(PlayerDiedReset());
        }
        else
        {
            PlayHitAudio();
            StartCoroutine(HitAnimation());
            extraLives--;
            UpdateLivesLeftUI();
        }
    }

    public IEnumerator PlayerDiedReset()
    {

        Time.timeScale = 0.01f;
        Time.fixedDeltaTime = 0.001F * Time.timeScale;
        
        yield return new WaitForSecondsRealtime(2); ;
        /*
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        RestartScene();
        */
    }

    void DisableControls()
    {
        playerController.enabled = false;
    }
    public void DeathAnimation()
    {
        shell.color = Color.red; 
    }

    IEnumerator HitAnimation()
    {
        shell.color = Color.gray;
        yield return new WaitForSeconds(1);
        shell.color = defaultColor;
    }

    void PlayDeflectAudio()
    {
        FXSource.PlayAudio(0);
    }

    void PlayHitAudio()
    {
        FXSource.PlayAudio(1);
    }

    void PlayDeathAudio()
    {
        FXSource.PlayAudio(2);
    }

    void PlayLifeGainAudio()
    {
        FXSource.PlayAudio(3);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
