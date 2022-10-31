using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObserverController : MonoBehaviour
{
    [SerializeField] private IntValueSO points;

    [SerializeField] private TMP_Text pointsText;

    private void OnEnable()
    {
        //Subscribing to the Scriptable Object value event
        points.OnValueChanged += UpdatePointsText;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            points.Value++;
    }

    private void UpdatePointsText(int value)
    {
        pointsText.text = value.ToString();
    }
}
