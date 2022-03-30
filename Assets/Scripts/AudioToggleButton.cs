using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggleButton : MonoBehaviour
{
    public enum ButtonType
    {
        BackgroundMusic,
        SoundFX
    };

    [SerializeField] private ButtonType buttonType;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;



    private Image image;

    private void Start(){
        image = GetComponent<Image>();
        image.sprite = onSprite;


        ToggleButton();
    }

    public void ToggleButton()
    {
        var muted = false;

        if (buttonType == ButtonType.BackgroundMusic)
            muted = AudioManager.Instance.IsBackgroundMusicMuted();
        else
        {
            muted = AudioManager.Instance.IsSoundFxMuted();
        }

        image.sprite = muted ? offSprite : onSprite;
    }
}//Class



















