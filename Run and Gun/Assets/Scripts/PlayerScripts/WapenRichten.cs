using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

public class WapenRichten : MonoBehaviour
{
    public TextMeshProUGUI bulletText;
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject machineAmmo;
    public GameObject blasterAmmo;
    public GameObject bulletBlaster;
    public GameObject bulletMachine;
    public GameObject blaster;
    public GameObject machine;
    public Transform bulletSpawnBlaster;
    public Transform bulletSpawnMachine;
    public int machineBullets = 30;
    public bool canFireBlaster = true;
    public bool canFireMachine = false;
    public bool holdsBlaster = true;
    public bool holdsMachine = false;
    public bool isReloading = false;
    private float timer;
    public float timeBetweenFiringBlaster = 1f;
    public float timeBetweenFiringMachine = 0.3f;

    void Start()
    {
        holdsMachine = false;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        bulletText.text = machineBullets.ToString();

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rot2 = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot2);

        if (Input.GetKeyDown(KeyCode.Mouse0) && canFireBlaster == true && holdsBlaster == true)
        {
            canFireBlaster = false;
            Instantiate(bulletBlaster, bulletSpawnBlaster.position, Quaternion.identity);
        }

        if (canFireBlaster == false && holdsBlaster == true)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiringBlaster)
            {
                canFireBlaster = true;
                timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canFireMachine == true && holdsMachine == true && machineBullets > 0)
        {
            canFireMachine = false;
            Instantiate(bulletMachine, bulletSpawnMachine.position, Quaternion.identity);
            machineBullets--;
        }

        if (canFireMachine == false && holdsMachine == true)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiringMachine)
            {
                canFireMachine = true;
                timer = 0;
            }
        }

        if (holdsMachine == true)
        {
            machineAmmo.SetActive(true);
            blasterAmmo.SetActive(false);
        }
        else if (holdsBlaster == true)
        {
            machineAmmo.SetActive(false);
            blasterAmmo.SetActive(true);
        }

        if (machineBullets > 20)
        {
            machineBullets = 20;
        }

        WeaponSwitch();
    }

    public void WeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Q) && holdsBlaster == true)
        {
            blaster.SetActive(false);
            machine.SetActive(true);
            holdsBlaster = false;
            holdsMachine = true;
        }

        if (Input.GetKeyDown(KeyCode.F) && holdsMachine == true)
        {
            blaster.SetActive(true);
            machine.SetActive(false);
            holdsMachine = false;
            holdsBlaster = true;
        }
    }
}
