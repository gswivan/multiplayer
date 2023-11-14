
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class PlayerController : MonoBehaviour
{

    public GameObject camera;
    public Transform spawn_point;
    public float movement_speed = 5.0f;
    public float rotation_speed = 40.0f;

    private Vector2 movement;
    private float rotation;
    private PhotonView view;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    private void OnEnable()
    {
        camera.SetActive(view.IsMine);
    }

    private void OnDisable()
    {
        camera.SetActive(false);
    }

    public void OnMovement(InputValue value_)
    {
        if (!view.IsMine) return;
        movement = value_.Get<Vector2>() * movement_speed;
    }

    public void OnRotate(InputValue value_)
    {
        if (!view.IsMine) return;
        rotation = value_.Get<float>() * rotation_speed;
    }

    private void Update()
    {
        if (!view.IsMine) return;
        transform.Rotate(Vector3.up, rotation * Time.deltaTime);
        transform.position += ((movement.y * transform.forward) + (movement.x * transform.right)) * Time.deltaTime;
    }

    public void OnTrigger()
    {
        if (!view.IsMine) return;
        PhotonNetwork.Instantiate("Prop", spawn_point.position, spawn_point.rotation);
    }

}
