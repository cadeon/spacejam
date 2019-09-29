using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameNotifier : MonoBehaviour
{
    public EndGameScript[] viewers;

    private void OnDestroy()
    {
        foreach(EndGameScript viewer in viewers)
        {
            viewer.GameOver();
        }
    }
}
