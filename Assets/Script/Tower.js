#pragma strict
import System.Collections.Generic;

var original : GameObject;
//var MiniMenu : GameObject;
var MaxBlocks : int;
var BB88 : int;
var Blockorz : GameObject;
var EndMenu : GameObject;
var imports = new List.<int>();
var Score : UnityEngine.UI.Text;
var HighScore : UnityEngine.UI.Text;
var Level : int;

function Start () {
	PlayerPrefs.SetInt("Score", 0);
	PlayerPrefs.SetInt("Block Total", 0);
	PlayerPrefs.SetInt("GameOver", 0);
	MaxBlocks = 4;
	while (1 > 0) {
		Level = Random.Range(1,8);
		while (Level > 0) { //CREATING THE BLOCKS
			var Rando = Random.Range(-3,4);
			while(imports.Contains(Rando)) {
				Rando = Random.Range(-3,4);
			}
    		Blockorz = Instantiate(original, new Vector3 (Rando, 12, 0),  Quaternion.identity);
    		PlayerPrefs.SetInt("Block Total", PlayerPrefs.GetInt("Block Total") + 1);
    		BB88++;
    		Blockorz.name = "Block #" + BB88;
    		imports.Add (Rando);
    		Level--;
   		}
		imports.Clear();
		yield WaitForSeconds (1);
	}
}

function Update () {
	Score.text = "Score: " + PlayerPrefs.GetInt("Score");
	HighScore.text = "HighScore: "  + PlayerPrefs.GetInt("Best");
	
	if (PlayerPrefs.GetInt("Best") <= PlayerPrefs.GetInt("Score")) {
       	PlayerPrefs.SetInt("Best", PlayerPrefs.GetInt("Score"));
    }
    
    if (PlayerPrefs.GetInt("GameOver") == 1) { //ENDING IT ALL
		EndMenu.SetActive(true);
	}
}

function Restart () {
	Application.LoadLevel ("Game");
}

function Escape () {
	Application.LoadLevel ("MainMenu");
}

function Suicide () {
	Application.Quit();
}