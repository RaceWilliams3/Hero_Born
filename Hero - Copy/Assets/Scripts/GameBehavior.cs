using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public bool showPauseScreen = false;
    private int _itemsCollected = 0;
    public PlayerBehaviour _PB;
    public BeserkPickup _BSK;
    public bool isBeserk;
    private float targetTime = 8.0f;
    public bool needToFreeze = false;
    public int Items
    {    
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);
            if (_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                needToFreeze = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
                
            }
        }
    }
    private int _playerHP = 10;
    public int HP
    {
        get { return _playerHP;  }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
            if(_playerHP <=0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                needToFreeze = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's gotta hurt.";
            }
        }
    }
    void Start()
    {
        Cursor.visible = false;
        GameObject Player = GameObject.Find("Player");
        _PB = Player.GetComponent<PlayerBehaviour>();
        GameObject Beserk = GameObject.Find("B_Collide");
        _BSK = Beserk.GetComponent<BeserkPickup>();
    }
    void timerEnded()
    {
        Debug.Log("Beserk Mode ended");
        targetTime = 8.0f;
        _BSK.isBeserk = false;
        Debug.Log(isBeserk);
    }
    void Update()
    {
        isBeserk = _BSK.isBeserk;
        if (isBeserk == true)
        {
            _PB.moveSpeed = 20;
            _PB.jumpVelocity = 20;
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                _PB.moveSpeed = 10;
                _PB.jumpVelocity = 10;
                timerEnded();
                targetTime = 8.0f;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (showPauseScreen == false)
            {
                needToFreeze = true;
                Time.timeScale = 0;
                showPauseScreen = true;
                Cursor.visible = false;
            }
            else
            {
                needToFreeze = false;
                Time.timeScale = 1;
                showPauseScreen = false;
                Cursor.visible = false;
            }

        }
    }
    
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected:" + _itemsCollected);
        GUI.Box(new Rect(20, 80, 150, 25), "Ammo:" + _PB.ammo);
        if (isBeserk)
        {
            GUI.Box(new Rect(Screen.width / 2 - 125, Screen.height / 2, 225, 25), "BESERK MODE ACTIVATED!!");
        }
        if (showPauseScreen)
        {
            Cursor.visible = true;
            
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Paused, Press ESC");
        }
        if (showWinScreen)
        {
            Cursor.visible = true;
            if (GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 - 50, 200, 100),"YOU WON!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
        if (showLossScreen)
        {
            SceneManager.LoadScene(2);
            /*Cursor.visible = true;
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You Lose..."))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }*/
        }
    }
}
