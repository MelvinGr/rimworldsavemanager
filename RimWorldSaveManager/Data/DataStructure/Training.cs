﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class Training
    {

        private XElement _XElement;
        private String _PawnDef;
        private List<XElement> _WantedTrainables;
        private List<XElement> _Steps;


        public bool ObedienceTraining
        {
            get
            {
                return _WantedTrainables[0].GetValue() == "True";
            }
            set
            {
                _WantedTrainables[0].SetValue(value ? "True" : "False");
            }
        }

        public bool ReleaseTraining
        {
            get
            {
                return _WantedTrainables[1].GetValue() == "True";
            }
            set
            {
                _WantedTrainables[1].SetValue(value ? "True" : "False");
            }
        }

        public bool RescueTraining
        {
            get
            {
                return _WantedTrainables[2].GetValue() == "True";
            }
            set
            {
                _WantedTrainables[2].SetValue(value ? "True" : "False");
            }
        }

        public bool HaulTraining
        {
            get
            {
                return _WantedTrainables[3].GetValue() == "True";
            }
            set
            {
                _WantedTrainables[3].SetValue(value ? "True" : "False");
            }
        }

        public bool TamenessTraining
        {
            get
            {
                return _WantedTrainables[4].GetValue() == "True";
            }
            set
            {
                _WantedTrainables[4].SetValue(value ? "True" : "False");
            }
        }

        public int ObedienceStep
        {
            get
            {
                return Convert.ToInt32(_Steps[0].GetValue());
            }
            set
            {
                _Steps[0].SetValue(value);
            }
        }

        public int ReleaseStep
        {
            get
            {
                return Convert.ToInt32(_Steps[1].GetValue());
            }
            set
            {
                _Steps[1].SetValue(value);
            }
        }

        public int RescueStep
        {
            get
            {
                return Convert.ToInt32(_Steps[2].GetValue());
            }
            set
            {
                _Steps[2].SetValue(value);
            }
        }

        public int HaulStep
        {
            get
            {
                return Convert.ToInt32(_Steps[3].GetValue());
            }
            set
            {
                _Steps[3].SetValue(value);
            }
        }

        public int TamenessStep
        {
            get
            {
                return Convert.ToInt32(_Steps[4].GetValue());
            }
            set
            {
                _Steps[4].SetValue(value);
            }
        }


        public Training(XElement xElement, String pawnDef)
        {
            _XElement = xElement;
            _PawnDef = pawnDef;

            XElement wantedTrainablesVals = _XElement.XPathSelectElement("wantedTrainables/vals");
            IEnumerable<XElement> wantedTrainables = _XElement.XPathSelectElements("wantedTrainables/vals/li");
            _WantedTrainables = (from wantedTrainable in wantedTrainables
                                 select wantedTrainable).ToList();
            if(wantedTrainablesVals != null)
            {
                 for (int i = _WantedTrainables.Count; i< 5; ++i)
                {
                    XElement li = new XElement("li", "False");
                    wantedTrainablesVals.Add(li);
                    _WantedTrainables.Add(li);
                }
            }
            

            XElement stepsVals = _XElement.XPathSelectElement("steps/vals");
            IEnumerable<XElement> steps = _XElement.XPathSelectElements("steps/vals/li");
            _Steps = (from step in steps
                      select step).ToList();
            if(stepsVals != null)
            {
                for (int i = _Steps.Count; i < 5; ++i)
                {
                    XElement li = new XElement("li", 0);
                    stepsVals.Add(li);
                    _Steps.Add(li);
                }
            }

        }



    }
}
