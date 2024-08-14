using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    public static UIElement selectedUI;
    public Slider scaleSlider;

    public UIElement[] elements;

    public TMP_FontAsset[] fonts;
    public Color[] color;

    private static float sliderValue;

    private void Start()
    {
        SpawnElement(6);
        SelectFont(1);
        //SelectScale(scaleSlider);
        SelectColor(3);
    }

    private void Update()
    {
        //scaleSlider.value = sliderValue;
    }

    public void SpawnElement(int index)
    {
        UIElement el = Instantiate(elements[index].gameObject, transform.position, transform.rotation, transform).GetComponent<UIElement>();
        SelectNewUI(el);
    }

    public void SelectFont(int fontIndex)
    {
        if (!selectedUI)
            return;

        selectedUI.SetFont(fonts[fontIndex]);
    }

    public void SelectScale(Slider scale)
    {
        if (!selectedUI)
            return;

        selectedUI.SetScale(scale.value);
    }

    public void SelectColor(int colorIndex)
    {
        if (!selectedUI)
            return;

        selectedUI.SetColor(color[colorIndex]);
    }

    public static void SelectNewUI(UIElement element)
    {
        if (selectedUI != null)
            selectedUI.Deselected();

        selectedUI = element;
        selectedUI.Selected();
        sliderValue = selectedUI.transform.localScale.x;
    }
}
