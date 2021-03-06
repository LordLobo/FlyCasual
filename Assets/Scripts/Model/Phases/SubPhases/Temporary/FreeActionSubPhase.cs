﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubPhases
{

    public class FreeActionSubPhase : GenericSubPhase
    {

        public override void Start()
        {
            Game = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
            Name = "Free Action SubPhase";
            IsTemporary = true;
            UpdateHelpInfo();

            Initialize();
        }

        public override void Initialize()
        {
            Roster.GetPlayer(Phases.CurrentSubPhase.RequiredPlayer).PerformFreeAction();
        }

        public override void Next()
        {
            Phases.CurrentSubPhase = PreviousSubPhase;
            UpdateHelpInfo();
        }

        public override bool ThisShipCanBeSelected(Ship.GenericShip ship)
        {
            bool result = false;
            Messages.ShowErrorToHuman("Ship cannot be selected: Perform action first");
            return result;
        }

        public override bool AnotherShipCanBeSelected(Ship.GenericShip anotherShip)
        {
            bool result = false;
            Messages.ShowErrorToHuman("Ship cannot be selected: Perform action first");
            return result;
        }

    }

}
