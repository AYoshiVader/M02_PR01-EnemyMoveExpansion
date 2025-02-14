using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public string labelText = "Collect all 4 Energy and win your freedom!";
    public int maxEnergy = 4;
    public bool showWinScreen = false;

    private int _energyGathered = 0;
    public int Energy
    {
        get { return _energyGathered; }

        set
        {
            _energyGathered = value;
            if (_energyGathered >= maxEnergy)
            {
                labelText = "You've found all the Energy!";
                doWin();
            }
            else
            {
                labelText = "Item found, only " + (maxEnergy - _energyGathered) + " more to go!";
            }
            UnityEngine.Debug.LogFormat("Energy: {0}", _energyGathered);
        }
    }

    private int _playerMaxHP = 10;
    public int MaxHP
    {
        get { return _playerMaxHP; }
        set
        {
            _playerMaxHP = value;
            UnityEngine.Debug.LogFormat("MaxLives: {0}", _playerMaxHP);
        }
    }

    private int _playerHP = 10;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            UnityEngine.Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    private int _playerShield = 0;
    public int Shields
    {
        get { return _playerShield; }
        set
        {
            _playerShield = value;
            UnityEngine.Debug.LogFormat("Shields: {0}", _playerShield);
        }
    }

    void doWin()
    {
        showWinScreen = true;
        Time.timeScale = 0f;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP + "/" + _playerMaxHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Shield Charges:" + _playerShield);
        GUI.Box(new Rect(20, 80, 150, 25), "Energy Collected: " + _energyGathered);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
    }

}
