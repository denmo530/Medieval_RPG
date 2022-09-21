using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }
    //Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSrites;
    public List<int> weaponPrices;
    public List<int> xpTable;


    //References
    public Player player;
    //Public weapon weapon..

    //Logic
    public int pesos;
    public int experience;

    //Save state
    /*  
    INT preferredSkin
    INT pesos
    INT experience
    INT weaponLevel1
    */
    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change the weapon level
        Debug.Log("LoadState");
    }
}
