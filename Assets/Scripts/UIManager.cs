using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pulsePanel;
    public GameObject cadrePanel;
    public Sprite transparentSquare;
    public Sprite inputUp;
    public Sprite inputBottom;
    public Sprite inputLeft;
    public Sprite inputRight;
    
    [SerializeField] private Slider healthSlider, specialHitSlider, feverSlider;

    [SerializeField] private GameObject pauseMenu, optionsMenu, loseMenu;

    private PlayerManager _player;
    private Color _tmpColor;
    private int _delayTimer;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerManager>();

        SetMaxSliderValue(healthSlider, _player.Health);
        SetMaxSliderValue(specialHitSlider, Variables.MaxSpecial);
        SetMaxSliderValue(feverSlider, 3);
    }

    private void Start()
    {
        _tmpColor = pulsePanel.transform.GetChild(0).GetComponent<RawImage>().color;

        for (int i = 0; i < cadrePanel.transform.childCount; i++) 
        {
            cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentSquare;
        }
    }

    private void Update()
    {
        SetCurrentSliderValue(healthSlider, _player.Health);
        SetCurrentSliderValue(specialHitSlider, BeatManager.feverStacks);
        SetCurrentSliderValue(feverSlider, BeatManager.Stacks);

        if (InputManager.pauseInput)
        {
            if(pauseMenu.activeSelf) Resume();
            else if(!optionsMenu.activeSelf) Pause();
            else if(optionsMenu.activeSelf) Return();
        }
        
        if(_player.PlayerDead) Lose();

        _tmpColor.a = BeatManager.pulseAperture ? 1f : 0f;

        for (int i = 0; i < pulsePanel.transform.childCount; i++)
        {
           pulsePanel.transform.GetChild(i).GetComponent<RawImage>().color = _tmpColor;
        }

        
        
        if (BeatManager.beatTimer >= BeatManager.beatInterval)
        {
            if (PlayerManager.delayAfterCombo)
            {
                _delayTimer++;
            }
        }

        if (_delayTimer == 4)
        {
            _delayTimer = 0;
        }

        for (int i = 0; i < PlayerManager.combo.Length; i++) 
        {
            if (PlayerManager.combo[i] == 'H')
            {
                cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = inputUp;
            }
            else if (PlayerManager.combo[i] == 'B')
            {
                cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = inputBottom;
            }
            else if (PlayerManager.combo[i] == 'G')
            {
                cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = inputLeft;
            }
            else if (PlayerManager.combo[i] == 'D')
            {
                cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = inputRight;
            }
        }
        switch (PlayerManager.combo.Length)
        {
            case 0 :
                if (PlayerManager.delayAfterCombo && _delayTimer <= 2f) return;

                for (int i = 0; i < cadrePanel.transform.childCount; i++) 
                {
                    cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentSquare;
                }
                
                break;
            case 1 :
                for (int i = 1; i < cadrePanel.transform.childCount; i++) 
                {
                    cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentSquare;
                }
                break;
            case 2 :
                for (int i = 2; i < cadrePanel.transform.childCount; i++) 
                {
                    cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentSquare;
                }
                break;
            case 3 :
                for (int i = 3; i < cadrePanel.transform.childCount; i++) 
                {
                    cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentSquare;
                }
                break;
        }
    }

    private void Pause()
    {
        BeatManager.AudioSource.Pause();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        BeatManager.AudioSource.UnPause();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    [UsedImplicitly] public static void ReturnMain() => SceneManager.LoadScene(6);
    
    public void Return()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    
    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        loseMenu.SetActive(true);
    }

    public void ReloadLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    private static void SetMaxSliderValue(Slider currentSlider, int maxValue) => currentSlider.maxValue = maxValue;

    private static void SetCurrentSliderValue(Slider currentSlider, int currentValue) => currentSlider.value = currentValue;
}