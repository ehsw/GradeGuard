using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradeGuard.App_Code {
    public class SPParameters {
        private ArrayList parameterName = new ArrayList();
        private ArrayList paramaterValue = new ArrayList();
        private ArrayList paramDirection = new ArrayList();
        private int arraySize = 0;

        public ArrayList ParameterName { get { return parameterName; } private set { parameterName = value; } }
        public ArrayList ParamaterValue { get { return paramaterValue; } private set { paramaterValue = value; } }
        public ArrayList ParamDirection { get { return paramDirection; } set { paramDirection = value; } }

        public int ArraySize { get { return arraySize; } set { arraySize = value; } }

        public void AddParameter(string name, string value) {
            AddParameter(name, value, false);
        }

        public void AddParameter(string name, string value, bool isOutput) {
            ParameterName.Add(name);
            ParamaterValue.Add(value);
            ParamDirection.Add(isOutput);
            arraySize++;
        }
    }
}