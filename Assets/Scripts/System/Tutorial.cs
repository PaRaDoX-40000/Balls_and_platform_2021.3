using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Button _button;
    [SerializeField] private TutorialPanelUI _tutorialPanelUI;
    [SerializeField] private TMP_Text _buttonText;
    public UnityEvent TutorialComplete;
    private int _numberSlide=0;




    public void StartTutorial()
    {
        _tutorialPanelUI.gameObject.SetActive(true);
        _button.onClick.AddListener(ShowNextSlide);
        _buttonText.text = "Далее";
        ShowNextSlide();
    }
    void StopTutorial()
    {
        TutorialComplete?.Invoke();
        _tutorialPanelUI.gameObject.SetActive(false);
        _button.onClick.RemoveListener(ShowNextSlide);
        _numberSlide = 0;
    }

    private void ShowNextSlide()
    {
        if (_numberSlide < _sprites.Length)
        {
            _tutorialPanelUI.SetSprite(_sprites[_numberSlide]);
            _numberSlide++;
            if(_numberSlide == _sprites.Length)
            {
                _buttonText.text = "Закрыть";
            }
        }
        else
        {
            StopTutorial();
        }   
    }
}
