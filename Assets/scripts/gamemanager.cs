using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public Text textsom;   
    public Text gameOverText;
    [SerializeField] Text time;
    public Text keuze1child, keuze2child, keuze3child, keuze4child;
    
    public Button restartButton;
    public Button keuze1, keuze2, keuze3, keuze4;
    public AudioClip goed, fout;
    private AudioSource Audio;

    public bool isGameActive;

    float timeLeft = 5.0f;

   int LeftNumber, RightNumber, number, TrueAwnser, waarde, waarde1 ;

    // Start is called before the first frame update
    void Start()
    {
        
        somFn();
        restartButton.gameObject.SetActive(false);
        
        isGameActive = true;
        
        //UpdateScore(0);
        Audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("space"))
        {
            somFn();
        }

         timeLeft -= Time.deltaTime;
         time.text = "time left: " + timeLeft.ToString("0") + " seconds";
         if(timeLeft <= 0)
         {
             timeLeft=0;
             GameOver();
         }
    
    }

    public void somFn()
    {

       keuze1.onClick.RemoveListener(audiogoed);
       keuze1.onClick.RemoveListener(audiofout);
       keuze2.onClick.RemoveListener(audiogoed);
       keuze2.onClick.RemoveListener(audiofout);
       keuze3.onClick.RemoveListener(audiogoed);
       keuze3.onClick.RemoveListener(audiofout);
       keuze4.onClick.RemoveListener(audiogoed);
       keuze4.onClick.RemoveListener(audiofout);

        waarde = Random.Range(0,4);
        

         if(waarde == 0) 
         {
            LeftNumber = Random.Range(1,100);
            RightNumber = Random.Range(1,100);

            TrueAwnser = LeftNumber - RightNumber;
            Debug.Log(LeftNumber + "-" + RightNumber + "=" +  TrueAwnser);
            textsom.text = LeftNumber + " - " + RightNumber + " = ";
            antwoord();
         }

        if(waarde== 1)
        {
            LeftNumber = Random.Range(1,100);
            RightNumber = Random.Range(1,100);

            TrueAwnser = LeftNumber + RightNumber;
            Debug.Log(LeftNumber + "+" + RightNumber + "=" +  TrueAwnser);
            textsom.text = LeftNumber + " + " + RightNumber + " = ";
            antwoord();
        }

        if(waarde== 2)
        {
            LeftNumber = Random.Range(10,100);
            RightNumber = Random.Range(1,10);

            TrueAwnser = LeftNumber / RightNumber;
            Debug.Log(LeftNumber + " / " + RightNumber + " = " +  TrueAwnser);
            textsom.text = LeftNumber + " / " + RightNumber + " = ";
            antwoord();
        }

         if(waarde== 3)
        {
            LeftNumber = Random.Range(1,10);
            RightNumber = Random.Range(1,10);

            TrueAwnser = LeftNumber * RightNumber;
            Debug.Log(LeftNumber + "*" + RightNumber + "=" +  TrueAwnser);
             textsom.text = LeftNumber + " * " + RightNumber + " = ";
             antwoord();
        }

              if (LeftNumber-RightNumber  <0) {
            number = RightNumber;
            RightNumber = LeftNumber;
            LeftNumber = number;
        }
        

    }

    public void antwoord()
    {

        waarde1 = Random.Range(0,4);

        if(waarde1 == 0)
        {
            keuze1child.text = TrueAwnser.ToString();
            keuze2child.text = Random.Range(0,100).ToString();
            keuze3child.text = Random.Range(0,100).ToString();
            keuze4child.text = Random.Range(0,100).ToString();
            
            
            

            keuze1.onClick.AddListener(audiogoed);
            keuze2.onClick.AddListener(audiofout);
            keuze3.onClick.AddListener(audiofout);
            keuze4.onClick.AddListener(audiofout);

        }
        if(waarde1 == 1)
        {
            keuze1child.text = Random.Range(0,100).ToString();
            keuze2child.text = TrueAwnser.ToString();
            keuze3child.text = Random.Range(0,100).ToString();
            keuze4child.text = Random.Range(0,100).ToString();

            
            
            
            keuze1.onClick.AddListener(audiofout);
            keuze2.onClick.AddListener(audiogoed);
            keuze3.onClick.AddListener(audiofout);
            keuze4.onClick.AddListener(audiofout);
        }
         if(waarde1 == 2)
        {
            keuze1child.text = Random.Range(0,100).ToString();
            keuze2child.text = Random.Range(0,100).ToString();
            keuze3child.text = TrueAwnser.ToString();
            keuze4child.text = Random.Range(0,100).ToString();

            
           
            
            keuze1.onClick.AddListener(audiofout);
            keuze2.onClick.AddListener(audiofout);
            keuze3.onClick.AddListener(audiogoed);
            keuze4.onClick.AddListener(audiofout);
        }       
        if(waarde1 == 3)
        {
            keuze1child.text = Random.Range(0,100).ToString();
            keuze2child.text = Random.Range(0,100).ToString();
            keuze3child.text = Random.Range(0,100).ToString();
            keuze4child.text = TrueAwnser.ToString();

            
           

            keuze1.onClick.AddListener(audiofout);
            keuze2.onClick.AddListener(audiofout);
            keuze3.onClick.AddListener(audiofout);
            keuze4.onClick.AddListener(audiogoed);
        }
       
    }

    public void clear()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

 public void GameOver()
    {
      //  restart button
       // gameOverText.gameObject.SetActive(true);
       restartButton.gameObject.SetActive(true);

        textsom.text = "the game is over!";
        isGameActive = false;
        keuze1.gameObject.SetActive(false);
        keuze2.gameObject.SetActive(false);
        keuze3.gameObject.SetActive(false);
        keuze4.gameObject.SetActive(false);

        restartButton.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void audiogoed()
    {
        Audio.PlayOneShot(goed);
        score.scorevalue += 100;
        somFn(); 
        
    }
    public void audiofout()
    {
        
        Audio.PlayOneShot(fout); 
        score.scorevalue -= 75;

    }
    
}