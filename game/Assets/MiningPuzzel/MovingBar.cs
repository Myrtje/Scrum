using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using game.Manager;
using game.PlayerControl;

public class MovingBar : MonoBehaviour
{
    public RectTransform bar;
    public RectTransform greenZone;
    public InputManager input;
    public GameObject movingBarHUD;
    public PlayerController playerController;
    private Ore currentOre;




    public float speed = 400f;
    public float distance = 600f;
    public float moveTime;


    Vector2 startPos;
    public bool startminigame = false;
    bool checkedThisPress;

    void Start()
    {
        startPos = bar.anchoredPosition;
    }

    void Update()
    {
        if (startminigame == true)
        {
            moveTime += Time.deltaTime;

            float offset = Mathf.PingPong(moveTime * speed, distance);
            bar.anchoredPosition = startPos + Vector2.right * offset;
        }

        CheckSuccess();
    }

    public void StartMiniGame(Ore ore)
    {
        currentOre = ore;
        startminigame = true;
        moveTime = 0f;
        movingBarHUD.SetActive(true);
        playerController.canMove = false;
    }

    void EndMiniGame()
    {
        startminigame = false;
        movingBarHUD.SetActive(false);
        playerController.canMove = true;
        currentOre = null;
    }


void CheckSuccess()
{
    if (input.InteractSpaceMiningPuzzle && !checkedThisPress && startminigame)
    {
        checkedThisPress = true;

        if (IsOverlapping())
        {
            Debug.Log("YOU DID IT");
            Debug.Log("you get 1 stone");
        }
        else
        {
            if (currentOre != null)
            {
                currentOre.Hit();
            }

            EndMiniGame();
        }
    }

    if (!input.InteractPressed)
    {
        checkedThisPress = false;
    }
}

    bool IsOverlapping()
    {
        Rect barRect = GetWorldRect(bar);
        Rect greenRect = GetWorldRect(greenZone);

        return barRect.Overlaps(greenRect);
    }

    Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);

        return new Rect(
            corners[0],
            corners[2] - corners[0]
        );
    }
}
