using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    //public SceneFader fader;

    public int LEVEL;
    public int LevelIndex;

    // Start is called before the first frame update
    void Start()
    {
        //levelText.text = level.ToString();
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level" + LEVEL.ToString());

        SceneManager.LoadScene(LevelIndex);

        //fader.FadeTo(LevelName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
