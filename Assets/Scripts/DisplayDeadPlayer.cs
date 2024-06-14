using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDeadPlayer : MonoBehaviour
{
    public Text deadPlayerText;
    // Start is called before the first frame update
    void Start()
    {
        deadPlayerText.text = LoseGameData.deadPlayerName + "has lost";
    }

   
}
