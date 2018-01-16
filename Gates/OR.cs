﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC_523_Game.Gates
{
    class OR : Gate
    {

        public OR(Wire [] inputs) : base(inputs)
        {
            output = gateOperation();
        }

        public override Wire getOutputWire()
        {
            return new Wire(output);
        }

        protected override bool gateOperation()
        {
            bool assignedValue = false;
            bool result = false;

            foreach(Wire w in inputs)
            {
                if (!assignedValue)
                {
                    result = w.getValue();
                    assignedValue = true;
                }

                else result = result || w.getValue();
            }

            return result;
        }
    }

}
