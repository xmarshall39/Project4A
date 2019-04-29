using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public int crystalCount;
    public float time;
    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene == SceneManager.GetSceneByName("GameScene"))
            time += Time.deltaTime;
    }


    //Restarts the timer when the gameScene is reloaded
    private void OnEnable()
    {
        PlayGame.OnGameStart += Restart;
        Colletable.OnCrystalCollect += CollectCrystal;

    }

    private void OnDisable()
    {
        PlayGame.OnGameStart -= Restart;
        Colletable.OnCrystalCollect -= CollectCrystal;
    }

    public void Restart()
    {
        time = 0;
        crystalCount = 0;
    }

    public void CollectCrystal()
    {
        ++crystalCount;
    }


}
