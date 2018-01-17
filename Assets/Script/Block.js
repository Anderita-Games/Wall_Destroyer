#pragma strict
var maxFallDistance = -5;
var Left = 12;

function Start () {
	var times = 20;
	while (times > -1 && PlayerPrefs.GetInt("GameOver") == 1) {
		yield WaitForSeconds (1);
		times--;
		if (times == 0) {
			Destroy (gameObject);
		}
	}
}

function Update () {
	if (Input.GetMouseButtonDown(0)) {
		var hit: RaycastHit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, hit)){
        	if (hit.transform.name == this.name && PlayerPrefs.GetInt("GameOver") != 1) {
        		PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
        		PlayerPrefs.SetInt("Block Total", PlayerPrefs.GetInt("Block Total") - 1);
        		PlayerPrefs.SetInt(this.name, 0);
        		Destroy (gameObject); //Nothing after
            }
        	
        }
	}
	
	if (transform.position.y <= maxFallDistance && Application.loadedLevelName == "MainMenu") {
		Destroy (gameObject);
	}
}

function OnCollisionEnter(col : Collision) {
     if (col.collider.name == "Limit" && PlayerPrefs.GetInt("GameOver") != 1) {
        PlayerPrefs.SetInt("GameOver", 1);
		Debug.Log("END");
     }
 }