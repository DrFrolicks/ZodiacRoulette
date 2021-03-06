﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Calls GameManager.activateSign(sign) when a ball is in the trigger for the specified time. 
/// lasted edited: ec
/// </summary>
public class ZodiacBallTrigger : MonoBehaviour
{
    public Sign sign;

    float ballStayDuration = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && GameManager.Instance.currentState == GameState.Throwing)
        {
            GetComponentInParent<Spin>().stopSpinning();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ball") && GameManager.Instance.currentState == GameState.Throwing)
        {
            ballStayDuration += Time.deltaTime;  
            if(ballStayDuration >= GameManager.Instance.signActivationSeconds)
            {
                GameManager.Instance.activateSign(sign);
                ballStayDuration = 0; 
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ball") && GameManager.Instance.currentState == GameState.Throwing)
        {
            ballStayDuration = 0; 
        }
    }
}
