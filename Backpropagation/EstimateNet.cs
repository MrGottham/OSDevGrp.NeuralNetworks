using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.NeuralNetworks
{
    public class EstimateNet : ByteBackpropagation
    {
        private const string FILENAME = "EstimateNet.dat";
        private const string SETUP_FILENAME = "EstimateNet.xml";

        private string _SetupFileName = null;
        private double _Error = 0;
        private int _Epochs = 0;
        private System.Xml.XmlDocument _XmlSetupDocument = null;
        private System.Collections.Generic.List<EstimateNetInputCategory> _InputCategories = null;
        private EstimateNetOutput _Output = null;
        private EstimateNetTrainPairs _TrainPairs = null;

        private class Definition : System.Collections.Generic.List<uint>
        {
            static private System.Xml.XmlDocument _XmlSetupDocument = null;

            public Definition(string setupfilename)
                : base()
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

        public string FileName
        {
            get
            {
                return FILENAME;
            }
        }

        public string SetupFileName
        {
            get
            {
                return _SetupFileName;
            }
            private set
            {
                _SetupFileName = value;
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
                SetupFileName = setupfilename;
                if (InputCategories == null)
                    InputCategories = new System.Collections.Generic.List<EstimateNetInputCategory>((int)base.Neurons[0]);
                while (InputCategories.Count > 0)
                    InputCategories.Clear();
                InputCategories.Capacity = (int)base.Neurons[0];
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
                    TrainPairs = new EstimateNetTrainPairs(xmlnode, setupfilename, this, base.Neurons[0], base.Neurons[(int)base.Layers - 1]);
                else
                    throw new System.Exception("Can't find the node named '/" + XmlSetupDocument.DocumentElement.Name + "/TrainPairs' in the file named '" + setupfilename + "'.");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public double Train()
        {
            try
            {
                System.Collections.Generic.List<System.Collections.Generic.List<byte>> sources = new System.Collections.Generic.List<System.Collections.Generic.List<byte>>(TrainPairs.Count);
                System.Collections.Generic.List<System.Collections.Generic.List<byte>> targets = new System.Collections.Generic.List<System.Collections.Generic.List<byte>>(TrainPairs.Count);
                foreach (EstimateNetTrianPair trainpair in TrainPairs)
                {
                    sources.Add(new System.Collections.Generic.List<byte>((int) Neurons[0]));
                    foreach (EstimateNetInputValue inputvalue in trainpair.Sources)
                    {
                        if (sources[sources.Count - 1].Count < sources[sources.Count - 1].Capacity)
                            sources[sources.Count - 1].Add(inputvalue.Value);
                    }
                    while (sources[sources.Count - 1].Count < sources[sources.Count - 1].Capacity)
                        sources[sources.Count - 1].Add((byte) Sigmoid.LowerBound);
                    targets.Add(new System.Collections.Generic.List<byte>((int) Neurons[(int) Layers - 1]));
                    foreach (EstimateNetOutputValue outputvalue in trainpair.Targets)
                    {
                        if (targets[targets.Count - 1].Count < targets[targets.Count - 1].Capacity)
                        {
                            if (outputvalue.Checked)
                                targets[targets.Count - 1].Add((byte)Sigmoid.UpperBound);
                            else if (Sigmoid.LowerBound < 0)
                                targets[targets.Count - 1].Add(0);
                            else
                                targets[targets.Count - 1].Add((byte)Sigmoid.LowerBound);
                        }
                    }
                    while (targets[targets.Count - 1].Count < targets[targets.Count - 1].Capacity)
                        targets[targets.Count - 1].Add((byte) Sigmoid.LowerBound);
                }
                Epochs++;
                Error = base.Train(sources, targets);
                while (sources.Count > 0)
                {
                    while (sources[0].Count > 0)
                        sources[0].Clear();
                    sources.RemoveAt(0);
                }
                sources.Clear();
                while (targets.Count > 0)
                {
                    while (targets[0].Count > 0)
                        targets[0].Clear();
                    targets.RemoveAt(0);
                }
                targets.Clear();
                return Error;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public double ReTrain()
        {
            try
            {
                Epochs = 0;
                base.Initialize();
                return this.Train();
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
                System.Collections.Generic.List<byte> input = new System.Collections.Generic.List<byte>((int)base.Neurons[0]);
                foreach (EstimateNetInputCategory category in inputcategories)
                {
                    if (input.Count < base.Neurons[0])
                    {
                        if (category.SelectedInputValue != null)
                            input.Add(category.SelectedInputValue.Value);
                        else
                            input.Add((byte)base.Sigmoid.LowerBound);
                    }
                }
                while (input.Count < base.Neurons[0])
                    input.Add((byte)base.Sigmoid.LowerBound);
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

        public void Save()
        {
            try
            {
                base.Save(FileName);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Load()
        {
            try
            {
                base.Load(FileName);
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
                _OutputValues = new System.Collections.Generic.List<EstimateNetOutputValue>((int)neurons);
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

    public class EstimateNetOutputValue : System.Object, System.ICloneable
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

        public System.Object Clone()
        {
            try
            {
                EstimateNetOutputValue clone = new EstimateNetOutputValue(_Name.ParentNode);
                return (System.Object) clone;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

    public class EstimateNetTrainPairs : System.Collections.Generic.List<EstimateNetTrianPair>
    {
        private System.Xml.XmlNode _TrainPairsXmlNode = null;
        private EstimateNet _EstimateNet = null;
        private uint _InputNeurons = 0;
        private uint _OutputNeurons = 0;
        private bool _Modified = false;

        public EstimateNetTrainPairs(System.Xml.XmlNode xmlnode, string setupfilename, EstimateNet net, uint inputneurons, uint outputneurons) : base()
        {
            try
            {
                TrainPairsXmlNode = xmlnode;
                EstimateNet = net;
                InputNeurons = inputneurons;
                OutputNeurons = outputneurons;
                Modified = false;
                foreach (System.Xml.XmlNode xmlchildnode in TrainPairsXmlNode.ChildNodes)
                {
                    switch (xmlchildnode.Name.ToUpper())
                    {
                        case "TRAINPAIR":
                            this.Add(new EstimateNetTrianPair(xmlchildnode, setupfilename, EstimateNet, InputNeurons, OutputNeurons));
                            break;
                    }
                }
                if (Count == 0)
                    throw new System.Exception("Can't find any nodes named 'TrainPair' under the node named '" + TrainPairsXmlNode.Name + "' in the file named '" + setupfilename + "'.");
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
                while (Count > 0)
                    Clear();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private System.Xml.XmlNode TrainPairsXmlNode
        {
            get
            {
                return _TrainPairsXmlNode;
            }
            set
            {
                _TrainPairsXmlNode = value;
            }
        }

        public EstimateNet EstimateNet
        {
            get
            {
                return _EstimateNet;
            }
            private set
            {
                _EstimateNet = value;
            }
        }

        private uint InputNeurons
        {
            get
            {
                return _InputNeurons;
            }
            set
            {
                _InputNeurons = value;
            }
        }

        private uint OutputNeurons
        {
            get
            {
                return _OutputNeurons;
            }
            set
            {
                _OutputNeurons = value;
            }
        }

        public bool Modified
        {
            get
            {
                return _Modified;
            }
            private set
            {
                _Modified = value;
            }
        }

        public EstimateNetTrianPair Create()
        {
            try
            {
                System.Xml.XmlElement xmlelement = TrainPairsXmlNode.OwnerDocument.CreateElement("TrainPair");
                xmlelement.AppendChild(xmlelement.OwnerDocument.CreateElement("Source"));
                for (int i = 0; i < InputNeurons; i++)
                {
                    if (xmlelement.LastChild.InnerText.Length > 0)
                        xmlelement.LastChild.InnerText = xmlelement.LastChild.InnerText + ';';
                    if (i < EstimateNet.InputCategories.Count)
                    {
                        if (EstimateNet.InputCategories[0].InputValues.Count > 0)
                            xmlelement.LastChild.InnerText = xmlelement.LastChild.InnerText + EstimateNet.InputCategories[0].InputValues[0].Value.ToString();
                        else if (EstimateNet.Sigmoid.LowerBound < 0)
                            xmlelement.LastChild.InnerText = xmlelement.LastChild.InnerText + '0';
                        else
                            xmlelement.LastChild.InnerText = xmlelement.LastChild.InnerText + EstimateNet.Sigmoid.LowerBound.ToString();
                    }
                    else if (EstimateNet.Sigmoid.LowerBound < 0)
                        xmlelement.LastChild.InnerText = xmlelement.LastChild.InnerText + '0';
                    else
                        xmlelement.LastChild.InnerText = xmlelement.LastChild.InnerText + EstimateNet.Sigmoid.LowerBound.ToString();
                }
                xmlelement.AppendChild(xmlelement.OwnerDocument.CreateElement("Target"));
                for (int i = 0; i < OutputNeurons; i++)
                {
                    if (xmlelement.LastChild.InnerText.Length > 0)
                        xmlelement.LastChild.InnerText = xmlelement.LastChild.InnerText + ';';
                    if (EstimateNet.Sigmoid.LowerBound < 0)
                        xmlelement.LastChild.InnerText = xmlelement.LastChild.InnerText + '0';
                    else
                        xmlelement.LastChild.InnerText = xmlelement.LastChild.InnerText + EstimateNet.Sigmoid.LowerBound.ToString();
                }
                return new EstimateNetTrianPair(xmlelement, string.Empty, EstimateNet, InputNeurons, OutputNeurons);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

    public class EstimateNetTrianPair : System.Object
    {
        private System.Xml.XmlNode _XmlNode = null;
        private EstimateNet _EstimateNet = null;
        private uint _InputNeurons = 0;
        private uint _OutputNeurons = 0;
        private System.Xml.XmlNode _SourceXmlNode = null;
        private System.Xml.XmlNode _TargetXmlNode = null;
        private System.Collections.Generic.List<EstimateNetInputValue> _Sources = null;
        private System.Collections.Generic.List<EstimateNetOutputValue> _Targets = null;

        public EstimateNetTrianPair(System.Xml.XmlNode xmlnode, string setupfilename, EstimateNet net, uint inputneurons, uint outputneurons) : base()
        {
            try
            {
                XmlNode = xmlnode;
                EstimateNet = net;
                InputNeurons = inputneurons;
                OutputNeurons = outputneurons;
                foreach (System.Xml.XmlNode xmlchildnode in XmlNode.ChildNodes)
                {
                    switch (xmlchildnode.Name.ToUpper())
                    {
                        case "SOURCE":
                            SourceXmlNode = xmlchildnode;
                            break;
                        case "TARGET":
                            TargetXmlNode = xmlchildnode;
                            break;
                    }
                }
                if (SourceXmlNode == null)
                    throw new System.Exception("Can't find a nodes named 'Source' under a node named '" + XmlNode.Name + "' in the file named '" + setupfilename + "'.");
                else if (TargetXmlNode == null)
                    throw new System.Exception("Can't find a nodes named 'Target' under a node named '" + XmlNode.Name + "' in the file named '" + setupfilename + "'.");
                Sources = new System.Collections.Generic.List<EstimateNetInputValue>((int) InputNeurons);
                string[] s = SourceXmlNode.InnerText.Split(';');
                if (s.Length != Sources.Capacity)
                    throw new System.Exception("The node named '" + SourceXmlNode.Name + "' under a node named '" + SourceXmlNode.ParentNode.Name + "' does not have " + Sources.Capacity.ToString() + " elements in it value (" + SourceXmlNode.InnerText + ").");
                int i = 0;
                while (i < Sources.Capacity)
                {
                    if (i < EstimateNet.InputCategories.Count)
                    {
                        int j = 0; bool b = false;
                        while (j < EstimateNet.InputCategories[i].InputValues.Count && !b)
                        {
                            b = (byte.Parse(s[i]) == EstimateNet.InputCategories[i].InputValues[j].Value);
                            if (b)
                                Sources.Add(EstimateNet.InputCategories[i].InputValues[j]);
                            else
                                j++;
                        }
                        if (!b)
                            throw new System.Exception("The node named '" + SourceXmlNode.Name + "' under a node named '" + SourceXmlNode.ParentNode.Name + "' continue an unknown source element (" + (i + 1).ToString() + ") with the value '" + s[i] + "'.");
                    }
                    i++;
                }
                Targets = new System.Collections.Generic.List<EstimateNetOutputValue>((int) OutputNeurons);
                s = TargetXmlNode.InnerText.Split(';');
                if (s.Length != Targets.Capacity)
                    throw new System.Exception("The node named '" + TargetXmlNode.Name + "' under a node named '" + TargetXmlNode.ParentNode.Name + "' does not have " + Targets.Capacity.ToString() + " elements in it value (" + TargetXmlNode.InnerText + ").");
                for (i = 0; i < Targets.Capacity; i++)
                {
                    if (i < EstimateNet.Output.OutputValues.Count)
                    {
                        EstimateNetOutputValue outputvalue = (EstimateNetOutputValue) EstimateNet.Output.OutputValues[i].Clone();
                        outputvalue.Value = float.Parse(s[i]);
                        Targets.Add(outputvalue);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~EstimateNetTrianPair()
        {
            try
            {
                if (Sources != null)
                {
                    while (Sources.Count > 0)
                        Sources.Clear();
                }
                if (Targets != null)
                {
                    while (Targets.Count > 0)
                        Targets.Clear();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private System.Xml.XmlNode XmlNode
        {
            get
            {
                return _XmlNode;
            }
            set
            {
                _XmlNode = value;
            }
        }

        public EstimateNet EstimateNet
        {
            get
            {
                return _EstimateNet;
            }
            private set
            {
                _EstimateNet = value;
            }
        }

        private uint InputNeurons
        {
            get
            {
                return _InputNeurons;
            }
            set
            {
                _InputNeurons = value;
            }
        }

        private uint OutputNeurons
        {
            get
            {
                return _OutputNeurons;
            }
            set
            {
                _OutputNeurons = value;
            }
        }

        public System.Xml.XmlNode SourceXmlNode
        {
            get
            {
                return _SourceXmlNode;
            }
            private set
            {
                _SourceXmlNode = value;
            }
        }

        public System.Xml.XmlNode TargetXmlNode
        {
            get
            {
                return _TargetXmlNode;
            }
            private set
            {
                _TargetXmlNode = value;
            }
        }

        public System.Collections.Generic.List<EstimateNetInputValue> Sources
        {
            get
            {
                return _Sources;
            }
            private set
            {
                _Sources = value;
            }
        }

        public System.Collections.Generic.List<EstimateNetOutputValue> Targets
        {
            get
            {
                return _Targets;
            }
            private set
            {
                _Targets = value;
            }
        }
    }
}
