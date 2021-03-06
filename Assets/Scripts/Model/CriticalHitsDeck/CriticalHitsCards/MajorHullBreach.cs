﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CriticalHitCard
{

    public class MajorHullBreach : GenericCriticalHit
    {
        public MajorHullBreach()
        {
            Name = "Major Hull Breach";
            Type = CriticalCardType.Ship;
            ImageUrl = "http://i.imgur.com/kUGRMK1.jpg";
        }

        public override void ApplyEffect(object sender, EventArgs e)
        {
            Messages.ShowInfo("Starting the round after you receive this card, all Damage cards dealt to you are dealt faceup");
            Game.UI.AddTestLogEntry("Starting the round after you receive this card, all Damage cards dealt to you are dealt faceup");
            Host.AssignToken(new Tokens.MajorHullBreachCritToken());

            Phases.OnPlanningPhaseStart += DealDamageCardFaceupStart;

            Host.AfterGenerateAvailableActionsList += AddCancelCritAction;

            Triggers.FinishTrigger();
        }

        public override void DiscardEffect(Ship.GenericShip host)
        {
            Messages.ShowInfo("Damage cards are dealt as usual");
            Game.UI.AddTestLogEntry("Damage cards are dealt as usual");
            host.RemoveToken(typeof(Tokens.MajorHullBreachCritToken));

            host.OnCheckFaceupCrit -= DealDamageCardFaceup;

            host.AfterGenerateAvailableActionsList -= AddCancelCritAction;
        }

        private void DealDamageCardFaceupStart()
        {
            Phases.OnPlanningPhaseStart -= DealDamageCardFaceupStart;
            Host.OnCheckFaceupCrit += DealDamageCardFaceup;
        }

        private void DealDamageCardFaceup(ref bool result)
        {
            result = true;
        }

    }

}