using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Package : MonoBehaviour
{
    public bool IsTake = false;
    public Text totaltext;
    public Text timer;
    public GameObject package;

    public GameObject PausePanel;
    public GameObject FinishPanel;
    public Button Resume;
    public Button Playa;
    public Button Quit;
    public float time;
    public bool finish=false;
    

    public int totaldelivery = 0;
    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
        FinishPanel.SetActive(false);
        totaldelivery = 0;
        Resume.onClick.AddListener(resume);
        Quit.onClick.AddListener(quit);
        Playa.onClick.AddListener(playagain);
    }

    // Update is called once per frame
    void Update()
    {
        totaltext.text = "Total Delivery "+totaldelivery.ToString();
        timer.text = time.ToString("F2");
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (totaldelivery == 8)
        {
            finish = true;
            Time.timeScale = 0;
            
            if (finish == true)
            {
                FinishPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (finish == false)
        {
            time = time + 1 * (Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Package")&&IsTake ==false)
        {
            IsTake = true;
            Destroy(other.gameObject);
            Debug.Log("paket alındı");
        }
        if(other.gameObject.CompareTag("Finish")&&IsTake == true)
        {
            IsTake = false;
            totaldelivery = totaldelivery + 1;
            Debug.Log("paket teslim edildi");

        }
    }

    public void playagain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        finish = false;
        totaldelivery = 0;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void resume()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        FinishPanel.SetActive(false);
    }
}
