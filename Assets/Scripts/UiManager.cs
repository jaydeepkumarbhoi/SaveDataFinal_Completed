using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public List<BaseClass> screenList;

    BaseClass CanvasScreen;

    public static UiManager instance;

    private void Awake()
    {
        instance = this;
        CanvasScreen = screenList[0];
    }
    public void showNext(CanvasScreen initialScreen)
    {
        CanvasScreen.hideScreen();
        screenList[(int)initialScreen].showScreen();
        CanvasScreen = screenList[(int)initialScreen];
       
    }
}
