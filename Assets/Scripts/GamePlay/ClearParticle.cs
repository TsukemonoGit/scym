using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearParticle : MonoBehaviour
{
  
    void OnParticleSystemStopped()
    {
        // SceneManager.LoadScene(0);
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
}
