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

    public Transform rightHand;

    private static float sliderValue;

    private void Start()
    {

    }

    private void Update()
    {
        //scaleSlider.value = sliderValue;

        if (selectedUI != null && selectedUI.isDragging)
        {
            if (Physics.Raycast(rightHand.position, rightHand.forward, out RaycastHit hit, 100, LayerMask.GetMask("Target")))
            {
                selectedUI.transform.position = hit.point;
            }
            else
            {
                Destroy(selectedUI.gameObject);
                selectedUI = null;
            }
        }
    }

    public void SpawnElement(int index)
    {
        UIElement el = Instantiate(elements[index].gameObject, transform.position, transform.rotation, transform).GetComponent<UIElement>();
        el.GetComponent<Button>().onClick.AddListener(() => SelectNewUI(el));
        el.GetComponent<Button>().onClick.AddListener(() => { scaleSlider.value = sliderValue; });
    }

    public void SelectFont(int fontIndex)
    {
        if (!selectedUI)
            return;

        selectedUI.SetFont(fonts[fontIndex]);
    }

    public void SelectScale()
    {
        if (!selectedUI)
            return;

        selectedUI.SetScale(scaleSlider.value);
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
