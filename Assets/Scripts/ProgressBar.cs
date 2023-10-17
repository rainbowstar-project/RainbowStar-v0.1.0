using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float progress = 0;
    public Slider slider;

    public void UpdateProgress() {
        progress += 0.1f;
        slider.value = progress;
    }
}
