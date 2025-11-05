using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    [Header("UI")]
    public Image chargeBarFill;

    [Header("Charge Settings")]
    public float maxChargeTime = 2f;
    private float chargeTimer = 0f;
    private bool isCharging = false;

    //void Start()
    //{
    //    chargeBarFill.fillAmount = 1f; // should fully fill on play
    //    Debug.Log("auto fill"); 
    //}

    void Update()
    {
        if (isCharging)
        {
            chargeTimer += Time.deltaTime;
            chargeTimer = Mathf.Clamp(chargeTimer, 0, maxChargeTime);
            chargeBarFill.fillAmount = chargeTimer / maxChargeTime;
        }
    }

    // Called when you start pressing the charge button
    public void StartCharging()
    {
        isCharging = true;
        chargeTimer = 0f;
    }
    public void StopCharging()
    {
        isCharging = false;
        ReleaseCharge();
    }

    void ReleaseCharge()
    {
        float chargePercent = chargeTimer / maxChargeTime;
        chargeBarFill.fillAmount = 0f;
        chargeTimer = 0f;
    }
}

