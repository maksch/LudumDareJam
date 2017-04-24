using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSliderScript : MonoBehaviour {

    private static HealthSliderScript healthSlider;
    public Sprite sprite;
    public int healthCurrentRed, healthCurrentBlue, healthCurrentGreen;
    public int healthMax; 

    public static void Set(RangeInt redHealth, RangeInt blueHealth, RangeInt greenHealth) {
    }
    public static void AddHealth(bool blue, bool red, bool green, int value) {
        if (red) {
            healthSlider.healthCurrentRed = healthSlider.healthCurrentRed - value;
        }
        if (blue) {
            healthSlider.healthCurrentBlue = healthSlider.healthCurrentBlue - value;
        }
        if (green) {
            healthSlider.healthCurrentGreen = healthSlider.healthCurrentGreen - value;
        }
    }
    public static void SetSubtractHealth(bool blue, bool red, bool green, int value) {
        if (red) {
            healthSlider.healthCurrentRed = healthSlider.healthCurrentRed + value;
        }
        if (blue) {
            healthSlider.healthCurrentBlue = healthSlider.healthCurrentBlue + value;
        }
        if (green) {
            healthSlider.healthCurrentGreen = healthSlider.healthCurrentGreen + value;
        }
    }
}
