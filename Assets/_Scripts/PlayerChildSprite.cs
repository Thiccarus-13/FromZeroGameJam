using UnityEngine;

public class PlayerChildSprite : MonoBehaviour
{
    [SerializeField] public SpriteRenderer sr;
    private Vector3 fullScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fullScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDisplayMode(string mode){
        if(mode.Equals("Single")){
            // Modify the x-axis scale to be the normal value
            transform.localScale = new Vector3(fullScale.x, fullScale.y, fullScale.z);
        }else if(mode.Equals("Double")){
            transform.localScale = new Vector3(fullScale.x * 0.5f, fullScale.y, fullScale.z);
        }else if(mode.Equals("None")){
            transform.localScale = new Vector3(0f, fullScale.y, fullScale.z);
        }
    }
    
}
