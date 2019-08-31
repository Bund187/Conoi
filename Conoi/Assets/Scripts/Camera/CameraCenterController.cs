using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenterController : MonoBehaviour {

    public GameObject player, boundary;
    public float speed;
    public Vector3 distance, velocity;
    

    private float middlePoint, originalOrthographicsSize, playerXPosition;
    private bool activateZoom, cameraChanged, followPlayer;
    private Camera camara;
    private bool talk;

    void Awake () {
        camara = GetComponent<Camera>();
        originalOrthographicsSize = camara.orthographicSize;
        cameraChanged = true;
        followPlayer = true;
    }

    private void FixedUpdate()
    {
        //if (Mathf.Approximately(camara.orthographicSize, originalOrthographicsSize))

        PlayerCentered();

        if (!activateZoom)
        {
             ZoomOut();
        }
        else
        {
            ZoomIn();
        }
    }

    //Funcion que centra la camara en el player durante todo el juego
    void PlayerCentered()
    {
        Vector3 positionDesired = player.transform.position;// + distance;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, positionDesired, speed /*Time.deltaTime*/);
        transform.position = smoothPosition;
    }

    public void ZoomIn()
    {

        Vector3 posicionDeseada;
        if(!talk)
            posicionDeseada = new Vector3(middlePoint, transform.position.y, -10);
        else
            posicionDeseada = new Vector3(transform.position.x, transform.position.y, -10);

        if (camara.orthographicSize>4.5f)
        {
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, speed);
        }
        camara.orthographicSize = Mathf.Lerp(camara.orthographicSize, 4, speed);

        cameraChanged = false;
        
    }

    public void ZoomOut()
    {
        Vector3 posicionDeseada = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        if (camara.orthographicSize <= originalOrthographicsSize)
        {
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, speed);
        }
        else
        {
            //actionTScript.IsTouching = false;
        }
        camara.orthographicSize = Mathf.Lerp(camara.orthographicSize, originalOrthographicsSize, speed);

        if (boundary != null)
            boundary.SetActive(false);
        
    }

    public float ScreenCenter(float player, float enemy)
    {
        middlePoint = (player + enemy) / 2;
        return middlePoint;
    }

    public bool ActivateZoom
    {
        get
        {
            return activateZoom;
        }

        set
        {
            activateZoom = value;
        }
    }

    public float PuntoMedio
    {
        get
        {
            return middlePoint;
        }

        set
        {
            middlePoint = value;
        }
    }

    public bool CameraChanged
    {
        get
        {
            return cameraChanged;
        }

        set
        {
            cameraChanged = value;
        }
    }

    public float PlayerXPosition
    {
        get
        {
            return playerXPosition;
        }

        set
        {
            playerXPosition = value;
        }
    }

    public bool FollowPlayer
    {
        get
        {
            return followPlayer;
        }

        set
        {
            followPlayer = value;
        }
    }

    public bool Talk
    {
        get
        {
            return talk;
        }

        set
        {
            talk = value;
        }
    }

    public float OriginalOrthographicsSize
    {
        get
        {
            return originalOrthographicsSize;
        }

        set
        {
            originalOrthographicsSize = value;
        }
    }
}
