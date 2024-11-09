using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UiEffectType uiEffectType;
    public float finalScale = 1.2f;
    public float scaleDuration = .1f;

    // evita bug - quando colocam scale diferente de '1'
    private Vector3 _defaultScale;
    // evita bug - quando sai de um p/ outro antes de terminar a animação 
    private Tween _currentTween;

    private void Awake()
    {
        _defaultScale = transform.localScale;
    }

    public void MakeEffect()
    {
        UiManager.Instance.DoEffect(uiEffectType, transform);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _currentTween = transform.DOScale(_defaultScale * finalScale, scaleDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        _currentTween.Kill();
        transform.localScale = _defaultScale;
    }
}
