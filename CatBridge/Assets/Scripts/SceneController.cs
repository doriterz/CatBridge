using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField] private int currentScene;
    public Text answerText;

    public void Start() 
    {
        currentScene = 0;        
        answerText.text = "Answer";
    }


    public void Update() {

        if(currentScene == 0)
        {   
            answerText.text = "Answer";
        }
        if(currentScene == 2)
        {
            answerText.text = "Answer";
        }
        if(currentScene == 1)
        {
            answerText.text = "Play";
        }
        if(currentScene == 3)
        {
            answerText.text = "Play";
        }    


    }


    public void LevelToAnswer()
    {

        if(currentScene == 0)
        {   
            currentScene = 1;
        }
        if(currentScene == 2)
        {
            currentScene = 3;
        }
        if(currentScene == 1)
        {
            currentScene = 0;
        }
        if(currentScene == 3)
        {
            currentScene = 2;
        }    
    }


    public void LevelToNext()
    {
        if(currentScene == 1)
        {
            SceneManager.LoadScene(currentScene+2);
        }
        if(currentScene == 3)
        {
            currentScene = 0;
        }

        if (currentScene == 2 || currentScene == 0)
        {
            currentScene++;
        }

    }


}
