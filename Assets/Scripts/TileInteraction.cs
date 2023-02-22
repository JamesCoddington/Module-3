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

        private void OnAttachedToHand(Hand hand)
        {
            print("handy");
            tile.OnClick();
        }
    }
}
