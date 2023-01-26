using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNumberText : MonoBehaviour
{
    public Text Text;
    public Game Game;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Text.text = scene.name;
    }
}
