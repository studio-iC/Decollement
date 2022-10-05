using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{
    public int levelNumber = 1;
    public bool isDisable = false;
    public GameObject mask;
    public TextMeshPro text;

    private void Start() 
    {
        text.text = "" + levelNumber;
        mask.SetActive(isDisable);
    }

    public void UnlockLevel()
    {
        mask.SetActive(false);
        isDisable = false;
    }

    private void OnMouseDown() {
        mask.SetActive(true);
    }

    public void OnMouseUp()
    {
        if (isDisable) return;
        mask.SetActive(false);
        SceneManager.LoadScene("Level_" + levelNumber);
    }
}
