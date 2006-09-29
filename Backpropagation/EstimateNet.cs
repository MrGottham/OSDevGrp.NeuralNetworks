using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.NeuralNetworks
{
    public class EstimateNet : ByteBackpropagation
    {
        private double _Error = 0;
        private int _Epochs = 0;
        private System.Xml.XmlDocument _XmlSetupDocument = null;
        private System.Collections.Generic.List<EstimateNetInputCategory> _InputCategories = null;
        private EstimateNetOutput _Output = null;

        private class Definition : System.Collections.Generic.List<uint>
        {
            public Definition() : base()
            {
                try
                {
                    Add(9);
                    Add(18);
                    Add(72);
                    Add(108);
                    Add(135);
                    Add(27);
                    Add(9);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        public EstimateNet() : base(new Definition())
        {
            try
            {
                Initialize("EstimateNet.xml");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EstimateNet(string setupfilename) : base(new Definition())
        {
            try
            {
                Initialize(setupfilename);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~EstimateNet()
        {
            try
            {
                if (InputCategories != null)
                {
                    while (InputCategories.Count > 0)
                        InputCategories.Clear();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public double Error
        {
            get
            {
                return System.Math.Round(_Error, 5);
            }
            private set
            {
                _Error = value;
            }
        }

        public int Epochs
        {
            get
            {
                return _Epochs;
            }
            private set
            {
                _Epochs = value;
            }
        }

        private System.Xml.XmlDocument XmlSetupDocument
        {
            get
            {
                return _XmlSetupDocument;
            }
            set
            {
                _XmlSetupDocument = value;
            }
        }

        public System.Collections.Generic.List<EstimateNetInputCategory> InputCategories
        {
            get
            {
                return _InputCategories;
            }
            private set
            {
                _InputCategories = value;
            }
        }

        public EstimateNetOutput Output
        {
            get
            {
                return _Output;
            }
            private set
            {
                _Output = value;
            }
        }

        private void Initialize(string setupfilename)
        {
            try
            {
                base.Sigmoid.LowerBound = -1;
                base.Sigmoid.UpperBound = 1;
                base.Sigmoid.Mirror = -1;
                base.Sigmoid.Slope = 1;
                base.UseBias = true;
                if (InputCategories == null)
                    InputCategories = new System.Collections.Generic.List<EstimateNetInputCategory>((int) base.Neurons[0]);
                while (InputCategories.Count > 0)
                    InputCategories.Clear();
                InputCategories.Capacity = (int) base.Neurons[0];
                _XmlSetupDocument = new System.Xml.XmlDocument();
                _XmlSetupDocument.Load(setupfilename);
                System.Xml.XmlNode xmlnode = _XmlSetupDocument.SelectSingleNode("/" + _XmlSetupDocument.DocumentElement.Name + "/InputCategories");
                if (xmlnode != null)
                {
                    foreach (System.Xml.XmlNode xmlchildnode in xmlnode.ChildNodes)
                    {
                        switch (xmlchildnode.Name.ToUpper())
                        {
                            case "INPUTCATEGORY":
                                if (InputCategories.Count < InputCategories.Capacity)
                                    InputCategories.Add(new EstimateNetInputCategory(xmlchildnode, setupfilename));
                                break;
                        }
                    }
                    if (InputCategories.Count == 0)
                        throw new System.Exception("Can't find any nodes named 'InputCategory' under the node named 'InputCategories' in the file named '" + setupfilename + "'.");
                }
                else
                    throw new System.Exception("Can't find the node named '/" + _XmlSetupDocument.DocumentElement.Name + "/InputCategories' in the file named '" + setupfilename + "'.");
                xmlnode = _XmlSetupDocument.SelectSingleNode("/" + _XmlSetupDocument.DocumentElement.Name + "/Output");
                if (xmlnode != null)
                    Output = new EstimateNetOutput(xmlnode, base.Neurons[(int)base.Layers - 1], setupfilename);
                else
                    throw new System.Exception("Can't find the node named '/" + _XmlSetupDocument.DocumentElement.Name + "/Output' in the file named '" + setupfilename + "'.");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public float ReTrain()
        {
            try
            {
                Epochs = 0;
                return 0;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

    public class EstimateNetInputCategory : System.Object
    {
        private System.Xml.XmlNode _Name = null;
        private System.Xml.XmlNode _Description = null;
        private System.Collections.Generic.List<EstimateNetInputValue> _InputValues = null;
        private EstimateNetInputValue _SelectedInputValue = null;
        
        public EstimateNetInputCategory(System.Xml.XmlNode xmlnode, string setupfilename) : base()
        {
            try
            {
                byte b = 0;
                _InputValues = new System.Collections.Generic.List<EstimateNetInputValue>(8);
                foreach (System.Xml.XmlNode xmlchildnode in xmlnode.ChildNodes)
                {
                    switch (xmlchildnode.Name.ToUpper())
                    {
                        case "NAME":
                            _Name = xmlchildnode;
                            break;
                        case "DESCRIPTION":
                            _Description = xmlchildnode;
                            break;
                        case "INPUTVALUE":
                            if (_InputValues.Count < _InputValues.Capacity)
                            {
                                switch (_InputValues.Count)
                                {
                                    case 0:
                                        b = 1;
                                        break;
                                    case 1:
                                        b = 2;
                                        break;
                                    default:
                                        b += b;
                                        break;
                                }
                                _InputValues.Add(new EstimateNetInputValue(xmlchildnode, b));
                            }
                            break;
                    }
                }
                if (_InputValues.Count > 0)
                {
                    int i = System.Convert.ToInt32(_InputValues.Count / 2);
                    _SelectedInputValue = InputValues[i];
                }
                else
                    throw new Exception("Can't find any nodes named 'InputValue' under the 'InputCategory' named '" + Name + "' in the file named '" + setupfilename + "'.");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~EstimateNetInputCategory()
        {
            try
            {
                if (InputValues != null)
                {
                    while (InputValues.Count > 0)
                        InputValues.Clear();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EstimateNetInputCategory This
        {
            get
            {
                return this;
            }
        }

        public string Name
        {
            get
            {
                if (_Name != null)
                    return _Name.InnerText;
                return String.Empty;
            }
            set
            {
                if (_Name != null)
                    _Name.InnerText = value;
            }
        }

        public string Description
        {
            get
            {
                if (_Description != null)
                    return _Description.InnerText;
                return String.Empty;
            }
            set
            {
                if (_Description != null)
                    _Description.InnerText = value;
            }
        }

        public System.Collections.Generic.List<EstimateNetInputValue> InputValues
        {
            get
            {
                return _InputValues;
            }
        }

        public EstimateNetInputValue SelectedInputValue
        {
            get
            {
                return _SelectedInputValue;
            }
            set
            {
                _SelectedInputValue = value;
            }
        }
    }

    public class EstimateNetInputValue : System.Object
    {
        private System.Xml.XmlNode _Name = null;
        private System.Xml.XmlNode _Description = null;
        private byte _Value = 0;

        public EstimateNetInputValue(System.Xml.XmlNode xmlnode, byte b) : base()
        {
            try
            {
                foreach (System.Xml.XmlNode xmlchildnode in xmlnode.ChildNodes)
                {
                    switch (xmlchildnode.Name.ToUpper())
                    {
                        case "NAME":
                            _Name = xmlchildnode;
                            break;
                        case "DESCRIPTION":
                            _Description = xmlchildnode;
                            break;
                    }
                }
                _Value = b;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EstimateNetInputValue This
        {
            get
            {
                return this;
            }
        }

        public string Name
        {
            get
            {
                if (_Name != null)
                    return _Name.InnerText;
                return String.Empty;
            }
            set
            {
                if (_Name != null)
                    _Name.InnerText = value;
            }
        }

        public string Description
        {
            get
            {
                if (_Description != null)
                    return _Description.InnerText;
                return String.Empty;
            }
            set
            {
                if (_Description != null)
                    _Description.InnerText = value;
            }
        }

        public byte Value
        {
            get
            {
                return _Value;
            }
        }
    }

    public class EstimateNetOutput : System.Object
    {
        private System.Xml.XmlNode _Name = null;
        private System.Xml.XmlNode _Description = null;

        public EstimateNetOutput(System.Xml.XmlNode xmlnode, uint neurons, string setupfilename) : base()
        {
            try
            {
                foreach (System.Xml.XmlNode xmlchildnode in xmlnode.ChildNodes)
                {
                    switch (xmlchildnode.Name.ToUpper())
                    {
                        case "NAME":
                            _Name = xmlchildnode;
                            break;
                        case "DESCRIPTION":
                            _Description = xmlchildnode;
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~EstimateNetOutput()
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string Name
        {
            get
            {
                if (_Name != null)
                    return _Name.InnerText;
                return string.Empty;
            }
            set
            {
                if (_Name != null)
                    _Name.InnerText = value;
            }
        }

        public string Description
        {
            get
            {
                if (_Description != null)
                    return _Description.Name;
                return string.Empty;
            }
            set
            {
                if (_Description != null)
                    _Description.InnerText = value;
            }
        }
    }
}
