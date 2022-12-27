using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimationComponnet : MonoBehaviour
{
    [SerializeField] [Range(1, 30)] private float frameRate = 10;
    [SerializeField] private UnityEvent <string>onComplite;
    [SerializeField] private AnimationClip[] _clips;

    private SpriteRenderer _renderer;

    private float secondPerFrame;
    private float nextFrameTime;
    private int currentFrame;
    private bool isPlaying = true;

    private int currentClip = 0;

    
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        secondPerFrame = 1f / frameRate;

        startAnimation();
    }
    private void OnBecameVisible()
    {
        enabled = isPlaying;
    }
    private void OnBecameInvisible()
    {
        enabled = false;
    }
    public void SetClip(string clipName)
    {
        for (var i = 0; i < _clips.Length; i++)
        {
            if(_clips[i].Name == clipName)
            {
                currentClip = i;
                startAnimation();
                return;
            }
        }
        enabled = isPlaying = false;
    }
    private void startAnimation()
    {   
        nextFrameTime = Time.time + secondPerFrame;
        isPlaying = true;
        currentFrame = 0;
    }
    private void OnEnable()
    {
        nextFrameTime = Time.time + secondPerFrame;
    }
   

    void Update()
    {
        if (nextFrameTime > Time.time) return;

        AnimationClip clip = _clips[currentClip];
        if(currentFrame >= clip.Sprite.Length)
        {
            if (clip.Loop)
            {
                currentFrame = 0;
            }
            else
            {
                clip.OnComplite?.Invoke();
                onComplite?.Invoke(clip.Name);
                enabled = isPlaying = clip.AllowNextClip;
                if (clip.AllowNextClip)
                {
                    currentFrame = 0;
                    currentClip = (int)Mathf.Repeat(currentClip + 1, _clips.Length);
                }
               
            }
            return;
        }
        _renderer.sprite = clip.Sprite[currentFrame];
        nextFrameTime += secondPerFrame;
        currentFrame++;

    }
}
[Serializable]
public class AnimationClip
{
    [SerializeField] private string name;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private bool loop;
    [SerializeField] private bool allowNextClip;
    [SerializeField] private UnityEvent onComplite;

    
    public string Name => name;
    public Sprite[] Sprite => sprite;
    public bool Loop => loop;
    public bool AllowNextClip => allowNextClip;
    public UnityEvent OnComplite => onComplite;
}