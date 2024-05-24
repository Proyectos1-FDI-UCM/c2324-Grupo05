using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementNotifier : MonoBehaviour
{
    [SerializeField] private RectTransform _notifyPanel; 
    public float animationDuration = 0.5f; 
    public float displayTime = 2.0f; 

    private Vector2 _offScreenPosition; 
    private Vector2 _onScreenPosition; 

    void Start()
    {
        _offScreenPosition = new Vector2(0, _notifyPanel.rect.height);
        _onScreenPosition = new Vector2(0, -_notifyPanel.rect.height / 2);

       
        _notifyPanel.anchoredPosition = _offScreenPosition;
    }

    public void ShowNotify()
    {
        StartCoroutine(AnimateNotification());
    }

    private IEnumerator AnimateNotification()
    {
        yield return StartCoroutine(AnimatePanel(_onScreenPosition, animationDuration));

        yield return new WaitForSeconds(displayTime);

        yield return StartCoroutine(AnimatePanel(_offScreenPosition, animationDuration));
    }

    private IEnumerator AnimatePanel(Vector2 targetPosition, float duration)
    {
        Vector2 initialPosition = _notifyPanel.anchoredPosition;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            _notifyPanel.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _notifyPanel.anchoredPosition = targetPosition;
    }
}
