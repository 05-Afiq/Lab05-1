using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public Text Coin;
    public int CoinCount = 0;
    public float totalcoins;
    public float timeLeft;
    public int timeRemaining;
    public Text TimerText;
    private float TimerValue = 0;
    [SerializeField] ParticleSystem collectParticle = null;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {

        timeLeft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeLeft % 60);
        TimerText.text = "Timer : " + timeRemaining.ToString();
        if(CoinCount==totalcoins)
        {
            if(timeLeft<=TimerValue)
            {
                SceneManager.LoadScene("GameWinScene");
            }
        }
        else if(timeLeft<=0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            CoinCount += 10;
            Coin.text = "Coin: $" + CoinCount;
            collectParticle.Play();
            StartCoroutine(stopSparkles());

        }
        if (other.gameObject.tag == "Enviroment")
        {
            SceneManager.LoadScene("GameLOseScene");
        }
    }
    IEnumerator stopSparkles()
    {
        yield return new WaitForSeconds(5f);
        collectParticle.Stop();
    }
}
