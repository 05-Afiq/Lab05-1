using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public Text Coin;
    public int CoinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            CoinCount += 10;
            Coin.text = "Coin: $" + CoinCount;

        }
        if (other.gameObject.tag == "Enviroment")
        {
            SceneManager.LoadScene("GameLOseScene");
        }
    }
}
