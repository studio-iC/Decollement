using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{

    public GameObject levelButtonPrefab;
    public int btnSpace = 10;
    private void Start()
    {
        int cnt = SceneManager.sceneCount - 2;
        for (int i = 1; i <= cnt; i++)
        {
            GameObject tmp = Instantiate(levelButtonPrefab);
            tmp.transform.SetParent(this.transform);
            
        }
    }

}
