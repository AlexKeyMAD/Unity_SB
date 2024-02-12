using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Timers ImgHarvest;
    public Timers ImgFood;

    public Text TextCountrymanCount;
    public Text TextWarriorCount;
    public Text TextWheatCount;
    public Text TextEnemiCount;

    public Button HiringCountrymanButton;
    public Button HiringWarriorButton;
    public Button ButtonPausePlay;

    public Image HiringCountrymanTimer;
    public Image HiringWarriorTimer;
    public Image imgRaidTimer;

    public Sprite imgPlay;
    public Sprite imgPause;

    public GameObject GameOver;
    public GameObject GameOnPause;

    public int CountrymanCount;
    public int WarriorCount;
    public int WheatCount;

    public int WheatPerCountryman;
    public int WheatToWarrior;

    public int CountrymanCost;
    public int WarriorCost;

    public float CountrymanTimer = -2;
    public float WarriorTimer = -2;
    public float RaidTimer;

    public float RaidMaxTime;
    public int RaidIncrease;
    public int NextRaid;

    public float CountrymanCreateTime;
    public float WarriorCreateTime;

    private bool PauseOn = false;

    void Start()
    {
        HiringCountrymanTimer.fillAmount = 0;
        HiringWarriorTimer.fillAmount = 0;

        RaidTimer = RaidMaxTime;

        UpdateText();
    }

    void Update()
    {
        RaidTimer -= Time.deltaTime;
        imgRaidTimer.fillAmount = RaidTimer / RaidMaxTime;

        if (RaidTimer <= 0)
        {
            RaidTimer = RaidMaxTime;
            WarriorCount -= NextRaid;
            NextRaid += RaidIncrease;
            TextEnemiCount.text = NextRaid.ToString();
        }

        if (ImgHarvest.Step)
        {
            WheatCount += CountrymanCount * WheatPerCountryman;
        }

        if (ImgFood.Step)
        {
            WheatCount -= WarriorCount * WheatToWarrior;
        }

        if (CountrymanTimer > 0)
        {
            CountrymanTimer -= Time.deltaTime;
            HiringCountrymanTimer.fillAmount = CountrymanTimer / CountrymanCreateTime;
        }
        else if (CountrymanTimer > -1)
        {
            CountrymanTimer = -2;
            CountrymanCount++;
            HiringCountrymanButton.interactable = true;
            HiringCountrymanTimer.fillAmount = 0;
        }

        if (WarriorTimer > 0)
        {
            WarriorTimer -= Time.deltaTime;
            HiringWarriorTimer.fillAmount = WarriorTimer / WarriorCreateTime;
        }
        else if (WarriorTimer > -1)
        {
            WarriorTimer = -2;
            WarriorCount++;
            HiringWarriorButton.interactable = true;
            HiringWarriorTimer.fillAmount = 0;
        }

        if (WarriorCount < 0)
        {
            WarriorCount = 0;
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
    }  
    

    public void PausePlay()
    {
        PauseOn = !PauseOn;

        GameOnPause.SetActive(PauseOn);

        ButtonPausePlay.image.sprite = PauseOn ? imgPlay : imgPause;
        Time.timeScale = PauseOn ? 0 : 1;
    }

    private void UpdateText()
    {
        TextCountrymanCount.text = CountrymanCount.ToString();
        TextWarriorCount.text = WarriorCount.ToString();
        TextWheatCount.text = WheatCount.ToString();
    }

    public void CreateCountryman()
    {
        if (WheatCount >= CountrymanCost)
        {
            WheatCount -= CountrymanCost;
            CountrymanTimer = CountrymanCreateTime;
            HiringCountrymanButton.interactable = false;
        }
    }

    public void CreateWarrior()
    {
        if (WheatCount >= WarriorCost)
        {
            WheatCount -= WarriorCost;
            WarriorTimer = WarriorCreateTime;
            HiringWarriorButton.interactable = false;
        }
    }
}
