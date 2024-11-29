using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelController : MonoBehaviour
{
    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel Uno");
    }

    public void Nivel2()
    {
        SceneManager.LoadScene("Nivel dos");
    }

    public void Nivel3()
    {
        SceneManager.LoadScene("Nivel tres");
    }

    public void Nivel4()
    {
        SceneManager.LoadScene("Nivel Cuatro");
    }
}
