using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFigures : MonoBehaviour
{
    [SerializeField] private Text playerFigures;

    [SerializeField] private Player_Ctrl player_Ctrl;

    private void FixedUpdate()
    {
        playerFigures.text =    "Health Point : " + player_Ctrl.hp + "\n" +
                                "Attack Delay : " + player_Ctrl.delay_Time;
    }
}
