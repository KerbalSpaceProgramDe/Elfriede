using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Elfriede
{
    /// <summary>
    /// PartModule that applies a random upward force to the part, if the player is within a certain range
    /// </summary>
    public class Elfriede : PartModule
    {
        [KSPField(isPersistant = false)] public Single range;
        [KSPField(isPersistant = false)] public Int32 minForce;
        [KSPField(isPersistant = false)] public Int32 maxForce;
        [KSPField(isPersistant = false)] public Int32 count;
        [KSPField(isPersistant = true)] public Boolean jumped;

        void FixedUpdate()
        {
            // Distance is smaller
            Single dist = Vector3.Distance(FlightGlobals.ActiveVessel.transform.position, transform.position);
            if (dist < range && !jumped)
            {
                System.Random r = new System.Random();
                for (Int32 i = 0; i < count; i++)
                    part.rb.AddExplosionForce(r.Next(minForce, maxForce), transform.position, 5, 0);
                jumped = true;
            }
            else if (dist >= range && jumped)
            {
                jumped = false;
            }
        }
    }
}
