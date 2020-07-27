using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
   public void atras()
    {
        SceneManager.LoadScene("menu");
    }

    public void fractal()
    {
        SceneManager.LoadScene("Fractal");
    }
    public void recontruccion()
    {
        SceneManager.LoadScene("recre");
    }
    public void fun1()
    {
        SceneManager.LoadScene("f1");
    }


    public void sig1()
    {
        SceneManager.LoadScene("f2");
    }
    public void sig2()
    {
        SceneManager.LoadScene("f3");
    }
    public void sig3()
    {
        SceneManager.LoadScene("f4");
    }

}
