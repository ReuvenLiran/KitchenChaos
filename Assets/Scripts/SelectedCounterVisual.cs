using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] BaseCounter baseCounter;
    [SerializeField] GameObject[] visualGameObjectArray;
    [SerializeField] private Player player;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChange += Player_OnSelectedCounterChange;
    }

    private void Player_OnSelectedCounterChange(object sender, Player.OnSelectedCounterChangeEventArgs e)
    {
        if (baseCounter == e.selectedCounter)
        {
            Debug.Log("SHOW");
            this.Show();
        }
        else
        {
            Debug.Log("HIDE");
            this.Hide();
        }
    }

    private void ToggleShowHide(bool isShow)
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(isShow);
        }
    }

    private void Show()
    {
        this.ToggleShowHide(true);
    }

    private void Hide()
    {
        this.ToggleShowHide(false);
    }
}
