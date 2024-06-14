using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWinner : MonoBehaviour
{
    public Text winnerText;
    // Start is called before the first frame update
    void Start()
    {
        winnerText.text = "Winner: " + GameData.winnerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
