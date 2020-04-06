using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static int scorevalue = 0;
    public Text textscore;
    // Start is called before the first frame update
    void Start()
    {
        scorevalue= 0;
    }

    // Update is called once per frame
    void Update()
    {
        textscore.text = "score: " + scorevalue;
    }
}
