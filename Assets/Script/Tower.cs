using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Tower : MonoBehaviour
{
    public GameObject original;
    //var MiniMenu : GameObject;
    public int MaxBlocks;
    public int BB88;
    public GameObject Blockorz;
    public GameObject EndMenu;
    public System.Collections.Generic.List<int> imports;
    public UnityEngine.UI.Text Score;
    public UnityEngine.UI.Text HighScore;
    public int Level;
    public virtual IEnumerator Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Block Total", 0);
        PlayerPrefs.SetInt("GameOver", 0);
        this.MaxBlocks = 4;
        while (1 > 0)
        {
            this.Level = Random.Range(1, 8);
            while (this.Level > 0) //CREATING THE BLOCKS
            {
                int Rando = Random.Range(-3, 4);
                while (this.imports.Contains(Rando))
                {
                    Rando = Random.Range(-3, 4);
                }
                this.Blockorz = UnityEngine.Object.Instantiate(this.original, new Vector3(Rando, 12, 0), Quaternion.identity);
                PlayerPrefs.SetInt("Block Total", PlayerPrefs.GetInt("Block Total") + 1);
                this.BB88++;
                this.Blockorz.name = "Block #" + this.BB88;
                this.imports.Add(Rando);
                this.Level--;
            }
            this.imports.Clear();
            yield return new WaitForSeconds(1);
        }
    }

    public virtual void Update()
    {
        this.Score.text = "Score: " + PlayerPrefs.GetInt("Score");
        this.HighScore.text = "HighScore: " + PlayerPrefs.GetInt("Best");
        if (PlayerPrefs.GetInt("Best") <= PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Best", PlayerPrefs.GetInt("Score"));
        }
        if (PlayerPrefs.GetInt("GameOver") == 1) //ENDING IT ALL
        {
            this.EndMenu.SetActive(true);
        }
    }

    public virtual void Restart()
    {
        Application.LoadLevel("Game");
    }

    public virtual void Escape()
    {
        Application.LoadLevel("MainMenu");
    }

    public virtual void Suicide()
    {
        Application.Quit();
    }

    public Tower()
    {
        this.imports = new List<int>();
    }

}