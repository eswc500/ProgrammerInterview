using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BounceButton : MonoBehaviour
{
    public Button button;
    public float bounceScale = 0.9f;
    public float bounceDuration = 0.2f;

    private Vector3 originalScale;

    private void Start()
    {
        button = this.GetComponent<Button>();
        originalScale = button.transform.localScale;
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        button.transform.DOKill();
        button.transform.DOScale(originalScale * bounceScale, bounceDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                button.transform.DOScale(originalScale, bounceDuration)
                    .SetEase(Ease.InQuad);
            });
    }
}
