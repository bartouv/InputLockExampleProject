using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Button))]
public class RandomColorButton : MonoBehaviour
{
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChangeButtonColor);
    }

    private void ChangeButtonColor()
    {
        var r = Random.Range(0.0f, 1);
        var g = Random.Range(0.0f, 1);
        var b = Random.Range(0.0f, 1);
        _button.image.color = new Color(r, g, b);
    }
}
