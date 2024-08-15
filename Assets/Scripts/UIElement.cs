using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image[] images;
    public bool isDragging;

    private UnityEngine.UI.Outline outline;

    private void OnEnable()
    {
        outline = GetComponent<UnityEngine.UI.Outline>();
        outline.enabled = false;
    }

    public void Selected()
    {
        outline.enabled = true;
    }

    public void Deselected()
    {
        outline.enabled = false;
    }

    public void SetFont(TMP_FontAsset font)
    {
        if (text)
            text.font = font;
    }

    public void SetColor(Color color)
    {
        if (text)
            text.color = color;
        foreach (Image img in images)
            img.color = color;
    }

    public void SetScale(float scale)
    {
        transform.localScale = Vector3.one * scale;
    }

    public void OnSelect()
    {
        InteractUI.SelectNewUI(this);
    }

    public void OnPointerDown()
    {
        isDragging = true;
    }

    public void OnPointerUp()
    {
        isDragging = false;
    }
}
