using UnityEngine;
using UnityEngine.EventSystems;

enum ButtonAction
{
    StartGame,
    ExitGame,
    OpenMenu
}

public class ButtonHandler : MonoBehaviour, ISelectHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ButtonAction buttonAction;
    [SerializeField] private GameObject menuTab;
    private MenuManager _menuManager;

    private void Start()
    {
        _menuManager = GetComponentInParent<MenuManager>();
    }

    private void DoAction()
    {
        switch (buttonAction)
        {
            case ButtonAction.StartGame:
                _menuManager.StartGame(); break;
            case ButtonAction.ExitGame:
                _menuManager.ExitGame(); break;
            case ButtonAction.OpenMenu:
                _menuManager.OpenMenuTab(menuTab); break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        _menuManager.audioManager.PlaySound(SoundType.click);
        DoAction();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        _menuManager.audioManager.PlaySound(SoundType.highlited);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");

    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("OnSelect");

    }
}