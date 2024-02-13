using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct GameCounters
{
    public int RaidCount;
    public int WheatCount;
    public int CountrymanCount;
    public int CountrymanDeadCount;
    public int WarriorCount;
    public int WarriorDeadCount;
}

public class GameManager : MonoBehaviour
{
    private GameCounters Counters = new GameCounters();

    private AudioSource audio;

    public SoundManager soundManager;

    public Timers ImgHarvest;
    public Timers ImgFood;

    public Text TextCountrymanCount;
    public Text TextWarriorCount;
    public Text TextWheatCount;
    public Text TextEnemiCount;
    public Text RaidCountText;
    public Text TextResultGameLoss;
    public Text TextResultGameWin;
    public Text VictoryConditionText;

    public Button HiringCountrymanButton;
    public Button HiringWarriorButton;
    public Button ButtonPausePlay;
    public Button ButtonSoundOffOn;

    public Image HiringCountrymanTimer;
    public Image HiringWarriorTimer;
    public Image imgRaidTimer;
    private Image imgBattleTimer;

    public Sprite imgPlay;
    public Sprite imgPause;
    public Sprite imgSoundOn;
    public Sprite imgSoundOff;

    public GameObject GameWinPage;
    public GameObject GameOverPage;
    public GameObject GameOnPause;
    public GameObject imgBattlePage;

    public int CountrymanCount;
    public int WarriorCount;
    public int WheatCount;

    public int WheatPerCountryman;
    public int WheatToWarrior;

    public int CountrymanCost;
    public int WarriorCost;

    private float CountrymanTimer = -2;
    private float WarriorTimer = -2;
    private float RaidTimer;
    private float BattleTimer = -2;

    public float RaidMaxTime;
    public int RaidIncrease;
    public int NextRaid;
    public int ScoutingRaids; // Количество набегов без войнов (разведка)

    public float CountrymanCreateTime;
    public float WarriorCreateTime;

    private bool PauseOn = false;
    private bool BattleOn = false;
    private bool SoundOn = true;

    /// <summary>
    /// VictoryCondition... 
    /// Если в одну из этих переменных установлен 0 (ноль), то это не будет считаться целью для победы
    /// </summary>
    public int VictoryConditionRaidCount;
    public int VictoryConditionCountrymanCount;
    public int VictoryConditionWarriorCount;
    public int VictoryConditionWheatCount;

    void Start()
    {
        HiringCountrymanTimer.fillAmount = 0;
        HiringWarriorTimer.fillAmount = 0;

        RaidTimer = RaidMaxTime;

        imgBattleTimer = imgBattlePage.GetComponent<Image>();
        audio = GetComponent<AudioSource>();
        audio.Play();

        UpdateText();
        UpdateVictoryConditionText();
    }

    void Update()
    {
        RaidTimer -= Time.deltaTime;
        imgRaidTimer.fillAmount = RaidTimer / RaidMaxTime;

        if (RaidTimer <= 0)
        {
            RaidTimer = RaidMaxTime;
            if (ScoutingRaids == 0)
            {
                Counters.WarriorDeadCount += Math.Min(NextRaid, WarriorCount);
                WarriorCount -= NextRaid;
                if (WarriorCount < 0) //Если врагов больше то они убивают ещё и крестьян
                {
                    Counters.CountrymanDeadCount += Math.Min(WarriorCount * -2, CountrymanCount);
                    CountrymanCount -= WarriorCount * -2;
                    WarriorCount = 0;
                    if (CountrymanCount < 0) CountrymanCount = 0;
                }
                Battle(NextRaid);
                NextRaid += RaidIncrease;
            }
            else
            {
                ScoutingRaids--;
            }
            TextEnemiCount.text = NextRaid.ToString();
            Counters.RaidCount++;
        }

        if (ImgHarvest.Step)
        {
            WheatCount += CountrymanCount * WheatPerCountryman;
            Counters.WheatCount += CountrymanCount * WheatPerCountryman;
            soundManager.Harvest();
        }

        if (ImgFood.Step)
        {
            WheatCount -= Math.Min(WarriorCount * WheatToWarrior, WheatCount);
            soundManager.Eat();
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
            Counters.CountrymanCount++;
            soundManager.Countryman();
        }

        if (HiringCountrymanTimer.fillAmount == 0)
        {
            if (WheatCount < CountrymanCost) HiringCountrymanButton.interactable = false;
            else HiringCountrymanButton.interactable = true;
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
            Counters.WarriorCount++;
            soundManager.Warrior();
        }

        if (BattleTimer > 0)
        {
            BattleTimer -= Time.deltaTime;
            imgBattleTimer.fillAmount = BattleTimer / NextRaid;
        }
        else if (BattleTimer > -1)
        {
            BattleTimer = -2;
            imgBattleTimer.fillAmount = 1;
            imgBattlePage.SetActive(false);
            BattleOn = false;
        }


        if (HiringWarriorTimer.fillAmount == 0)
        {
            if (WheatCount < WarriorCost) HiringWarriorButton.interactable = false;
            else HiringWarriorButton.interactable = true;
        }

        if (WarriorCount == 0 && CountrymanCount == 0 && !BattleOn) GameOver();

        UpdateText();
        UpdateVictoryConditionText();
    }

    private void UpdateVictoryConditionText()
    {
        string str = "";
        int i = 0;

        if (VictoryConditionRaidCount > 0)
        {
            str = $"Набеги: {Counters.RaidCount}/{VictoryConditionRaidCount}";
            i += Counters.RaidCount >= VictoryConditionRaidCount ? 1 : 0;
        }
        else i++;

        if (VictoryConditionCountrymanCount > 0)
        {
            str += (str.Length == 0 ? "" : "\n") + $"Нанято крестьян: {Counters.CountrymanCount}/{VictoryConditionCountrymanCount}";
            i += Counters.CountrymanCount >= VictoryConditionCountrymanCount ? 1 : 0;
        }
        else i++;

        if (VictoryConditionWarriorCount > 0)
        {
            str += (str.Length == 0 ? "" : "\n") + $"Нанято воинов: {Counters.WarriorCount}/{VictoryConditionWarriorCount}";
            i += Counters.WarriorCount >= VictoryConditionWarriorCount ? 1 : 0;
        }
        else i++;

        if (VictoryConditionWheatCount > 0)
        {
            str += (str.Length == 0 ? "" : "\n") + $"Произведено пшеницы: {Counters.WheatCount}/{VictoryConditionWheatCount}";
            i += Counters.WheatCount >= VictoryConditionWheatCount ? 1 : 0;
        }
        else i++;

        VictoryConditionText.text = str;

        if (i == 4) GameWin();
    }

    private void GameWin()
    {
        GameWinPage.SetActive(true);
        TextResultGameWin.text = GetTextResult();
        audio.clip = soundManager.GetWin();
        Time.timeScale = 0;
    }

    private void GameOver()
    {
        WarriorCount = 0;
        GameOverPage.SetActive(true);
        TextResultGameLoss.text = GetTextResult();
        audio.clip = soundManager.GetLoss();
        Time.timeScale = 0;
    }

    private void Battle(int enemis)
    {
        if (enemis > 0)
        {
            BattleOn = true;
            imgBattlePage.SetActive(true);
            BattleTimer = enemis;
            soundManager.Combat();
        }
    }

    private string GetTextResult()
    {
        return $"Набеги: {Counters.RaidCount.ToString()}\nПроизведено пшеницы: {Counters.WheatCount.ToString()}" +
                $"\nНанято крестьян: {Counters.CountrymanCount.ToString()}\n Потеряно крестьян: {Counters.CountrymanDeadCount.ToString()}" +
                $"\nНанято воинов: {Counters.WarriorCount.ToString()}\nПотеряно воинов: {Counters.WarriorDeadCount.ToString()}";
    }

    public void PausePlay()
    {
        PauseOn = !PauseOn;

        GameOnPause.SetActive(PauseOn);

        ButtonPausePlay.image.sprite = PauseOn ? imgPlay : imgPause;
        Time.timeScale = PauseOn ? 0 : 1;

        if (PauseOn && audio.isPlaying) audio.Pause();
        else if (!PauseOn && !audio.isPlaying) audio.Play();
    }

    public void SoundOffOn()
    {
        SoundOn = !SoundOn;

        ButtonSoundOffOn.image.sprite = !SoundOn ? imgSoundOff : imgSoundOn;

        if (!SoundOn && audio.isPlaying) audio.Stop();
        else if (SoundOn && !audio.isPlaying) audio.Play();
    }

    private void UpdateText()
    {
        TextCountrymanCount.text = CountrymanCount.ToString();
        TextWarriorCount.text = WarriorCount.ToString();
        TextWheatCount.text = WheatCount.ToString();

        RaidCountText.text = "Набеги: " + Counters.RaidCount.ToString()
                        + (ScoutingRaids == 0 ? "" : "\n До боевых набегов: " + ScoutingRaids.ToString());
    }

    public void CreateCountryman()
    {
        if (WheatCount >= CountrymanCost)
        {
            WheatCount -= CountrymanCost;
            CountrymanTimer = CountrymanCreateTime;
            HiringCountrymanButton.interactable = false;
            soundManager.ButtonClick();
        }
    }

    public void CreateWarrior()
    {
        if (WheatCount >= WarriorCost)
        {
            WheatCount -= WarriorCost;
            WarriorTimer = WarriorCreateTime;
            HiringWarriorButton.interactable = false;
            soundManager.ButtonClick();
        }
    }
}
