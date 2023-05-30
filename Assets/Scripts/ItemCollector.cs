using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int strawberries = 0;

    [SerializeField] private Text strawberriesText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void Start()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            Destroy(collision.gameObject);
            strawberries++;
            Debug.Log("Strawberries: " + strawberries);
            strawberriesText.text = "Strawberries: " + strawberries;
            collectSoundEffect.Play();
            CheckHighScore();
        }
    }

    private void CheckHighScore()
    {
        if(strawberries > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", strawberries);
            UpdateHighScoreText();
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0);
    }
    

}
