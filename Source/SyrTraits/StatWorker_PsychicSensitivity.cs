﻿using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using RimWorld;
using Verse;
using UnityEngine;

namespace SyrTraits
{
    public class StatWorker_PsychicSensitivity : StatWorker
    {
        public override float GetValueUnfinalized(StatRequest req, bool applyPostProcess = true)
        {
            CompIndividuality comp = req.Thing.TryGetComp<CompIndividuality>();
            if (comp != null)
            {
                return base.GetValueUnfinalized(req, applyPostProcess) + req.Thing.TryGetComp<CompIndividuality>().PsychicFactor;
            }
            else
            {
                return base.GetValueUnfinalized(req, applyPostProcess);
            }
        }
        public override string GetExplanationUnfinalized(StatRequest req, ToStringNumberSense numberSense)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            CompIndividuality comp = req.Thing.TryGetComp<CompIndividuality>();
            if (comp != null)
            {
                stringBuilder.AppendLine("PsychicFactor".Translate() + ": " + stat.ValueToString(comp.PsychicFactor, ToStringNumberSense.Offset));
                return base.GetExplanationUnfinalized(req, numberSense) + "\n" + stringBuilder.ToString().TrimEndNewlines();
            }
            else
            {
                return base.GetExplanationUnfinalized(req, numberSense);
            }
        }
    }
}
