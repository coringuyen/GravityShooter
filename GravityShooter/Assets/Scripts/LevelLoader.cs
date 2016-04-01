﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    /// <summary>
    /// Task: Set up a system to handle scene transitions 
    /// as the the user progresses through the game.
    /// 
    /// Pass in a string to call whatever scene you please.
    /// </summary>

    public void LoadLevel(string scene, LoadSceneMode mode)
    {
        SceneManager.LoadScene(scene, mode);
    }
}
