using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    public class HiiriController3 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        //class PointerController extends MonoBehaviour implements 
        //IPointerDownHandler, IPointerUpHandler


        [SerializeField] private bool pressed;
        /// <summary>
        /// Raises the pointer up event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log(eventData); //⇐ for testing!!!!
            pressed = false;
        }

        /// <summary>
        /// Raises the pointer down event.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public void OnPointerDown(PointerEventData eventData)
        {
            //Debug.Log (eventData);  ⇐ for testing!!!!
            pressed = true;
        }
        public bool Pressed
        {
            get { return this.pressed; }
        }
    }
