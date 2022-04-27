using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Block : MonoBehaviour
{
    public int maxFallDistance;
    public int Left;
    public virtual IEnumerator Start()
    {
        int times = 20;
        while ((times > -1) && (PlayerPrefs.GetInt("GameOver") == 1))
        {
            yield return new WaitForSeconds(1);
            times--;
            if (times == 0)
            {
                UnityEngine.Object.Destroy(this.gameObject);
            }
        }
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.transform.name == this.name) && (PlayerPrefs.GetInt("GameOver") != 1))
                {
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
                    PlayerPrefs.SetInt("Block Total", PlayerPrefs.GetInt("Block Total") - 1);
                    PlayerPrefs.SetInt(this.name, 0);
                    UnityEngine.Object.Destroy(this.gameObject); //Nothing after
                }
            }
        }
        if ((this.transform.position.y <= this.maxFallDistance) && (Application.loadedLevelName == "MainMenu"))
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public virtual void OnCollisionEnter(Collision col)
    {
        if ((col.collider.name == "Limit") && (PlayerPrefs.GetInt("GameOver") != 1))
        {
            PlayerPrefs.SetInt("GameOver", 1);
            Debug.Log("END");
        }
    }

    public Block()
    {
        this.maxFallDistance = -5;
        this.Left = 12;
    }

}