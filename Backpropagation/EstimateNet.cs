using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.NeuralNetworks
{
    public class EstimateNet : ByteBackpropagation
    {
        private const string SETUP_FILENAME = "EstimateNet.xml";
        
        private double _Error = 0;
        private int _Epochs = 0;
        private System.Xml.XmlDocument _XmlSetupDocument = null;
        private System.Collections.Generic.List<EstimateNetInputCategory> _InputCategories = null;
        private EstimateNetOutput _Output = null;
        private EstimateNetTrainPairs _TrainPairs = null;

        private class Definition : System.Collections.Generic.List<uint>
        {
            static private System.Xml.XmlDocument _XmlSetupDocument = null;

            public Definition(string setupfilename) : base()
            {
                try
                {
                    XmlSetupDocument = new System.Xml.XmlDocument();
                    XmlSetupDocument.Load(setupfilename);
                    System.Xml.XmlNode xmlnode = XmlSetupDocument.SelectSingleNode("/" + XmlSetupDocument.DocumentElement.Name + "/Definition");
                    if (xmlnode != null)
                    {
                        foreach (System.Xml.XmlNode xmlchildnode in xmlnode.ChildNodes)
                        {
                            switch (xmlchildnode.Name.ToUpper())
                            {
                                case "NEURONS":
                                    Add(uint.Parse(xmlchildnode.InnerText));
                                    break;
                            }
                        }
                        if (Count == 0)
                            throw new System.Exception("Can't find any nodes named 'Neurons' under the node named 'Definition' in the file named '" + setupfilename + "'.");
                    }
                    else
                        throw new System.Exception("Can't find the node named '/" + XmlSetupDocument.DocumentElement.Name + "/Definition' in the file named '" + setupfilename + "'.");
                    }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }

            static public System.Xml.XmlDocument XmlSetupDocument
            {
                get
                {
                    return _XmlSetupDocument;
                }
                private set
                {
                    _XmlSetupDocument = value;
                }
            }
        }

        public EstimateNet() : base(new Definition(SETUP_FILENAME))
        {
            try
            {
                XmlSetupDocument = Definition.XmlSetupDocument;
                Initialize(SETUP_FILENAME);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EstimateNet(string setupfilename) : base(new Definition(setupfilename))
        {
            try
            {
                XmlSetupDocument = Definition.XmlSetupDocument;
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

        public EstimateNetTrainPairs TrainPairs
        {
            get
            {
                return _TrainPairs;
            }
            private set
            {
                _TrainPairs = value;
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
                System.Xml.XmlNode xmlnode = XmlSetupDocument.SelectSingleNode("/" + XmlSetupDocument.DocumentElement.Name + "/InputCategories");
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
                    throw new System.Exception("Can't find the node named '/" + XmlSetupDocument.DocumentElement.Name + "/InputCategories' in the file named '" + setupfilename + "'.");
                xmlnode = XmlSetupDocument.SelectSingleNode("/" + XmlSetupDocument.DocumentElement.Name + "/Output");
                if (xmlnode != null)
                    Output = new EstimateNetOutput(xmlnode, base.Neurons[(int)base.Layers - 1], setupfilename);
                else
                    throw new System.Exception("Can't find the node named '/" + XmlSetupDocument.DocumentElement.Name + "/Output' in the file named '" + setupfilename + "'.");
                xmlnode = XmlSetupDocument.SelectSingleNode("/" + XmlSetupDocument.DocumentElement.Name + "/TrainPairs");
                if (xmlnode != null)
                    TrainPairs = new EstimateNetTrainPairs(xmlnode, setupfilename, this, base.Neurons[0], base.Neurons[(int) base.Layers - 1]);
                else
                    throw new System.Exception("Can't find the node named '/" + XmlSetupDocument.DocumentElement.Name + "/TrainPairs' in the file named '" + setupfilename + "'.");
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

        public EstimateNetOutput Run(System.Collections.Generic.List<EstimateNetInputCategory> inputcategories)
        {
            try
            {
                System.Collections.Generic.List<byte> input = new System.Collections.Generic.List<byte>((int) base.Neurons[0]);
                foreach (EstimateNetInputCategory category in inputcategories)
                {
                    if (input.Count < base.Neurons[0])
                    {
                        if (category.SelectedInputValue != null)
                            input.Add(category.SelectedInputValue.Value);
                        else
                            input.Add((byte) base.Sigmoid.LowerBound);
                    }
                }
                while (input.Count < base.Neurons[0])
                    input.Add((byte) base.Sigmoid.LowerBound);
                foreach (EstimateNetOutputValue outputvalue in Output.OutputValues)
                {
                    outputvalue.Value = base.Sigmoid.LowerBound;
                }
                System.Collections.Generic.List<float> output = base.Run(input);
                for (int i = 0; i < output.Count; i++)
                {
                    if (i < Output.OutputValues.Count)
                        Output.OutputValues[i].Value = output[i];
                }
                return Output;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EstimateNetOutput Run()
        {
            try
            {
                return Run(InputCategories);
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
                    throw new System.Exception("Can't find any nodes named 'InputValue' under the 'InputCategory' named '" + Name + "' in the file named '" + setupfilename + "'.");
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
        private System.Collections.Generic.List<EstimateNetOutputValue> _OutputValues = null;

        public EstimateNetOutput(System.Xml.XmlNode xmlnode, uint neurons, string setupfilename) : base()
        {
            try
            {
                _OutputValues = new System.Collections.Generic.List<EstimateNetOutputValue>((int) neurons);
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
                        case "OUTPUTVALUE":
                            if (_OutputValues.Count < _OutputValues.Capacity)
                                _OutputValues.Add(new EstimateNetOutputValue(xmlchildnode));
                            break;
                    }
                }
                if (_OutputValues.Count == 0)
                    throw new System.Exception("Can't find any nodes named 'OutputValue' under the node named 'Output' in the file named '" + setupfilename + "'.");
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
                if (OutputValues != null)
                {
                    while (OutputValues.Count > 0)
                        OutputValues.Clear();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EstimateNetOutput This
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

        public System.Collections.Generic.List<EstimateNetOutputValue> OutputValues
        {
            get
            {
                return _OutputValues;
            }
        }
    }

    public class EstimateNetOutputValue : System.Object
    {
        private System.Xml.XmlNode _Name = null;
        private System.Xml.XmlNode _Description = null;
        private float _Value = 0;

        public EstimateNetOutputValue(System.Xml.XmlNode xmlnode) : base()
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

        public EstimateNetOutputValue This
        {
            get
            {
                return This;
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
                    return _Description.InnerText;
                return string.Empty;
            }
            set
            {
                if (_Description != null)
                    _Description.InnerText = value;
            }
        }

        public float Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        public bool Checked
        {
            get
            {
                return Value > 0.75;
            }
        }
    }

    public class EstimateNetTrainPairs : System.Object
    {
        private System.Collections.Generic.List<EstimateNetTrainSource> _Sources = null;
        private System.Collections.Generic.List<EstimateNetTrainTarget> _Targets = null;

        public EstimateNetTrainPairs(System.Xml.XmlNode xmlnode, string setupfilename, EstimateNet net, uint inputneurons, uint outputneurons)
        {
            try
            {
                _Sources = new System.Collections.Generic.List<EstimateNetTrainSource>();
                _Targets = new System.Collections.Generic.List<EstimateNetTrainTarget>();
                foreach (System.Xml.XmlNode xmlchildnode in xmlnode.ChildNodes)
                {
                    switch (xmlchildnode.Name.ToUpper())
                    {
                        case "TRAINPAIR":
                            System.Xml.XmlNode xmlsourcenode = null;
                            System.Xml.XmlNode xmltargetnode = null;
                            foreach (System.Xml.XmlNode xmlsubnode in xmlchildnode.ChildNodes)
                            {
                                switch (xmlsubnode.Name.ToUpper())
                                {
                                    case "SOURCE":
                                        if (xmlsourcenode == null)
                                            xmlsourcenode = xmlsubnode;
                                        break;
                                    case "TARGET":
                                        if (xmltargetnode == null)
                                            xmltargetnode = xmlsubnode;
                                        break;
                                }
                            }
                            if (xmlsourcenode == null)
                                throw new System.Exception("Can't find a nodes named 'Source' under a node named '" + xmlnode.Name + "' in the file named '" + setupfilename + "'.");
                            else if (xmltargetnode == null)
                                throw new System.Exception("Can't find a nodes named 'Target' under a node named '" + xmlnode.Name + "' in the file named '" + setupfilename + "'.");
                            _Sources.Add(new EstimateNetTrainSource(xmlsourcenode, setupfilename, net, inputneurons));
                            _Targets.Add(new EstimateNetTrainTarget(xmltargetnode, setupfilename, net, outputneurons));
                            break;
                    }
                }
                if (_Sources.Count == 0 || _Targets.Count == 0 || _Sources.Count != _Targets.Count)
                    throw new System.Exception("Can't find any nodes named 'TrainPair' under the node named '" + xmlnode.Name + "' in the file named '" + setupfilename + "'.");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~EstimateNetTrainPairs()
        {
            try
            {
                if (Sources != null)
                {
                    while (Sources.Count > 0)
                        Sources.RemoveAt(0);
                    Sources.Clear();
                }
                if (Targets != null)
                {
                    while (Targets.Count > 0)
                        Targets.RemoveAt(0);
                    Targets.Clear();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Collections.Generic.List<EstimateNetTrainSource> Sources
        {
            get
            {
                return _Sources;
            }
        }

        public System.Collections.Generic.List<EstimateNetTrainTarget> Targets
        {
            get
            {
                return _Targets;
            }
        }
    }

    public class EstimateNetTrainSource : System.Collections.Generic.List<byte>
    {
        private System.Xml.XmlNode _Source = null;

        public EstimateNetTrainSource(System.Xml.XmlNode xmlnode, string setupfilename, EstimateNet net, uint neurons) : base((int) neurons)
        {
            try
            {
                _Source = xmlnode;
                string[] s = _Source.InnerText.Split(';');
                if (s.Length != Capacity)
                    throw new System.Exception("The node named '" + _Source.Name + "' under a node named '" + _Source.ParentNode.Name + "' does not have " + Capacity.ToString() + " elements in it value (" + _Source.InnerText + ").");
                int i = 0;
                while (i < Capacity)
                {
                    if (i < net.InputCategories.Count)
                    {
                        int j = 0; bool b = false;
                        while (j < net.InputCategories[i].InputValues.Count && !b)
                        {
                            b = (byte.Parse(s[i]) == net.InputCategories[i].InputValues[j].Value);
                            j++;
                        }
                        if (!b)
                            throw new System.Exception("The node named '" + _Source.Name + "' under a node named '" + _Source.ParentNode.Name + "' continue an unknown source element (" + (i + 1).ToString() + ") with the value '" + s[i] + "'.");
                    }
                    else
                        Add((byte) net.Sigmoid.LowerBound);
                    i++;
                }
                while (Count < Capacity)
                    Add((byte) net.Sigmoid.LowerBound);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~EstimateNetTrainSource()
        {
            try
            {
                while (Count > 0)
                    Clear();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Xml.XmlNode Source
        {
            get
            {
                return _Source;
            }
        }
    }

    public class EstimateNetTrainTarget : System.Collections.Generic.List<byte>
    {
        private System.Xml.XmlNode _Target = null;

        public EstimateNetTrainTarget(System.Xml.XmlNode xmlnode, string filename, EstimateNet net, uint neurons) : base((int) neurons)
        {
            try
            {
                _Target = xmlnode;
                string[] s = _Target.InnerText.Split(';');
                if (s.Length != Capacity)
                    throw new System.Exception("The node named '" + _Target.Name + "' under a node named '" + _Target.ParentNode.Name + "' does not have " + Capacity.ToString() + " elements in it value (" + _Target.InnerText + ").");
                for (int i = 0; i < Capacity; i++)
                {
                    if (i < net.Output.OutputValues.Count)
                        Add(byte.Parse(s[i]));
                    else
                        Add((byte) net.Sigmoid.LowerBound);
                }
                while (Count < Capacity)
                    Add((byte) net.Sigmoid.LowerBound);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~EstimateNetTrainTarget()
        {
            try
            {
                while (Count > 0)
                    Clear();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Xml.XmlNode Target
        {
            get
            {
                return _Target;
            }
        }
    }
}
