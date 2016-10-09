using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

    private static FadeController instance;

	private Image FadePanel;
    private bool fadeActive;
	private bool fadeAudio;

    public static FadeController Instance{
        get{
            if (instance == null)
                instance = GameObject.FindObjectOfType(typeof(FadeController)) as FadeController;
            return instance;
        }
    }

    void Awake(){
		Object.DontDestroyOnLoad(gameObject);
		FadePanel = GetComponentInChildren<Image>();
        FadePanel.canvasRenderer.SetAlpha(0);
	}

	public void FadeIN (float dur) {
            FadePanel.CrossFadeAlpha(1, dur, false);
			fadeAudio = true;
	}

	public void FadeOUT (float dur) {
		FadePanel.CrossFadeAlpha (0, dur, false); 
		fadeAudio = false;
	}

	void Update(){
		if (!fadeAudio) {
			AudioListener.volume = Mathf.Lerp (AudioListener.volume, 1, 0.06f);
		} 
		else if (fadeAudio) {
			AudioListener.volume = Mathf.Lerp (AudioListener.volume, 0, 0.06f);
		}
	}
}
