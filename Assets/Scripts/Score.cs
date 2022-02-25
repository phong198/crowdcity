using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public GameObject player;
    public Text scoreUI;
    public int score;

    void Update()
    {
        score = player.transform.parent.childCount;
        scoreUI.text = score.ToString();
        PlayerPrefs.SetInt("score", score);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (score == 1)
        {
            if (other.transform.tag == "Player")
            {
                Destroy(player);
                Destroy(scoreUI);
            }
        }
    }
}
