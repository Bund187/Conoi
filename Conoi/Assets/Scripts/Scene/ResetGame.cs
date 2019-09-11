using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.activeSelf)
            ResetQuit();
    }

    public void ResetQuit()
    {
        if (transform.parent.GetChild(0).GetComponent<Animator>().runtimeAnimatorController != null){
            SceneManager.LoadScene("Start");
            this.gameObject.SetActive(false);
            this.enabled = false;
        }
        else
        {
            print("exit game");
            Application.Quit();
        }
    }
}
