using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightChange : MonoBehaviour
{
       [SerializeField] private Light2D backgroundLight;
       [SerializeField] private float bgl_intensity;
       [SerializeField] private Color bgl_color;
       
       [SerializeField] private Light2D backdecorativeLight;
       [SerializeField] private float bdl_intensity;
       [SerializeField] private Color bdl_color;
       
       [SerializeField] private Light2D defaultLight;
       [SerializeField] private float def_intensity;
       [SerializeField] private Color def_color;
       
       [SerializeField] private Light2D foredecorativeLight;
       [SerializeField] private float fgd_intensity;
       [SerializeField] private Color fgd_color;
       
       [SerializeField] private Light2D foregroundLight;
       [SerializeField] private float fgl_intensity;
       [SerializeField] private Color fgl_color;


       private void OnTriggerEnter2D(Collider2D other)
       {
              if (other.tag == "Player")
              {
                     backgroundLight.color = bgl_color;
                     backgroundLight.intensity = bgl_intensity;
                     
                     backdecorativeLight.color = bdl_color;
                     backdecorativeLight.intensity = bdl_intensity;
                     
                     defaultLight.color = def_color;
                     defaultLight.intensity = def_intensity;
                     
                     foredecorativeLight.color = fgd_color;
                     foredecorativeLight.intensity = fgd_intensity;
                     
                     foregroundLight.color = fgl_color;
                     foregroundLight.intensity = fgl_intensity;
              }
       }
}
