using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    [RequireComponent(typeof(Interactable))]
    public class TileInteraction : MonoBehaviour
    {
        public Tile tile;
        private Interactable interactable;

        private void Start()
        {
            interactable = this.GetComponent<Interactable>();
        }

        private void OnTriggerEnter(Collider other)
        {
            print("handy");
            if (other.gameObject.CompareTag("righthand"))
            {
                tile.OnClick();
            }
            else if (other.gameObject.CompareTag("lefthand"))
            {
                
            }
        }
    }
}
