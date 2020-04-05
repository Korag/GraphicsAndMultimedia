using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PostEffectsController : MonoBehaviour
{
    public Text dafState, bloomState, edgeDetState, sunShaftsState,
     blurState, fogState, antialiasingState;

    private DepthOfFieldDeprecated _depthOfField;
    private BloomOptimized _bloom;
    private EdgeDetection _edgeDetection;
    private SunShafts _sunShaft;
    private MotionBlur _motionBlur;
    private GlobalFog _globalFog;
    private Antialiasing _antialiasing;

    private const string POST_EFFECT_OFF = "(OFF)";
    private const string POST_EFFECT_ON = "(ON)";

    // Start is called before the first frame update
    void Start()
    {
        _depthOfField = GetComponent<DepthOfFieldDeprecated>();
        _bloom = GetComponent<BloomOptimized>();
        _edgeDetection = GetComponent<EdgeDetection>();
        _sunShaft = GetComponent<SunShafts>();
        _motionBlur = GetComponent<MotionBlur>();
        _globalFog = GetComponent<GlobalFog>();
        _antialiasing = GetComponent<Antialiasing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_depthOfField.enabled == false)
            {
                _depthOfField.enabled = true;
                SetPostEffectUITextState(dafState, POST_EFFECT_ON);
            }
            else
            {
                _depthOfField.enabled = false;
                SetPostEffectUITextState(dafState, POST_EFFECT_OFF);
            }
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            if (_bloom.enabled == false)
            {
                _bloom.enabled = true;
                SetPostEffectUITextState(bloomState, POST_EFFECT_ON);
            }
            else
            {
                _bloom.enabled = false;
                SetPostEffectUITextState(bloomState, POST_EFFECT_OFF);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            if (_edgeDetection.enabled == false)
            {
                _edgeDetection.enabled = true;
                SetPostEffectUITextState(edgeDetState, POST_EFFECT_ON);
            }
            else
            {
                _edgeDetection.enabled = false;
                SetPostEffectUITextState(edgeDetState, POST_EFFECT_OFF);
            }
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            if (_sunShaft.enabled == false)
            {
                _sunShaft.enabled = true;
                SetPostEffectUITextState(sunShaftsState, POST_EFFECT_ON);
            }
            else
            {
                _sunShaft.enabled = false;
                SetPostEffectUITextState(sunShaftsState, POST_EFFECT_OFF);
            }
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            if (_motionBlur.enabled == false)
            {
                _motionBlur.enabled = true;
                SetPostEffectUITextState(blurState, POST_EFFECT_ON);
            }
            else
            {
                _motionBlur.enabled = false;
                SetPostEffectUITextState(blurState, POST_EFFECT_OFF);
            }
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            if (_globalFog.enabled == false)
            {
                _globalFog.enabled = true;
                SetPostEffectUITextState(fogState, POST_EFFECT_ON);
            }
            else
            {
                _globalFog.enabled = false;
                SetPostEffectUITextState(fogState, POST_EFFECT_OFF);
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (_antialiasing.enabled == false)
            {
                _antialiasing.enabled = true;
                SetPostEffectUITextState(antialiasingState, POST_EFFECT_ON);
            }
            else
            {
                _antialiasing.enabled = false;
                SetPostEffectUITextState(antialiasingState, POST_EFFECT_OFF);
            }
        }
    }

    public void SetPostEffectUITextState(Text uiTextElement, string textState)
    {
        uiTextElement.text = textState;
    }
}
