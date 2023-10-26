using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private int progress = 0;
    public Slider slider;

    public void UpdateProgress()
    {
        progress += 1;
        slider.value = progress;
    }
}
