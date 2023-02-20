using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIcontroller : MonoBehaviour
{
    [SerializeField] private GameObject OpenButton, Menu, CloseButton;
    [SerializeField] private Text AmperText;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private Color[] Colors;
    private float AmperTextInt;
    public void OpenMenu()
    {
        OpenButton.SetActive(false);
        Menu.transform.localScale.Set(1, 1, 1);
    }
    public void CloseMenu()
    {
        OpenButton.SetActive(true);
        Menu.transform.localScale.Set(0, 1, 1);
    }
    private void Update()
    {
        AmperTextInt = scrollbar.value * 10;
        AmperTextInt = (int)AmperTextInt;
        AmperText.text = AmperTextInt.ToString();
    }
    public void quest( GameObject button)
    {
        if (button.gameObject.name == "0.4") button.GetComponent<Image>().color = Colors[0];
        else button.GetComponent<Image>().color = Colors[1];
    }
}
