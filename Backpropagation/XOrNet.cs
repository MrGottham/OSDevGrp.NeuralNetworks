using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.NeuralNetworks
{
    public class XOrNet : IntBackpropagation
    {
        private const string FILENAME = "XOrNet.dat";

        private double _Error = 0;
        private int _Epochs = 0;
        private XOrNetTrainPairs _TrainPairs = null;

        private class Definition : System.Collections.Generic.List<uint>
        {
            public Definition() : base()
            {
                try
                {
                    Add(2);
                    Add(4);
                    Add(1);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        public XOrNet() : base(new Definition())
        {
            try
            {
                base.Tolerance = 0.03;
                base.UseBias = true;
                _TrainPairs = new XOrNetTrainPairs();
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

        public XOrNetTrainPairs TrainPairs
        {
            get
            {
                return _TrainPairs;
            }
        }

        public double Train()
        {
            try
            {
                Epochs++;
                Error = base.Train(TrainPairs.Sources, TrainPairs.Targets);
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

    public class XOrNetTrainPairs : System.Object
    {
        private System.Collections.Generic.List<System.Collections.Generic.List<int>> _Sources = null;
        private System.Collections.Generic.List<System.Collections.Generic.List<int>> _Targets = null;

        public XOrNetTrainPairs() : base()
        {
            try
            {
                _Sources = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
                _Sources.Add(new System.Collections.Generic.List<int>());
                _Sources[_Sources.Count - 1].Add(0);
                _Sources[_Sources.Count - 1].Add(0);
                _Sources.Add(new System.Collections.Generic.List<int>());
                _Sources[_Sources.Count - 1].Add(0);
                _Sources[_Sources.Count - 1].Add(1);
                _Sources.Add(new System.Collections.Generic.List<int>());
                _Sources[_Sources.Count - 1].Add(1);
                _Sources[_Sources.Count - 1].Add(0);
                _Sources.Add(new System.Collections.Generic.List<int>());
                _Sources[_Sources.Count - 1].Add(1);
                _Sources[_Sources.Count - 1].Add(1);
                _Targets = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
                foreach (System.Collections.Generic.List<int> src in _Sources)
                {
                    _Targets.Add(new System.Collections.Generic.List<int>());
                    _Targets[_Targets.Count - 1].Add(src[0] ^ src[1]);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~XOrNetTrainPairs()
        {
            try
            {
                if (Sources != null)
                {
                    while (Sources.Count > 0)
                    {
                        Sources[0].Clear();
                        Sources.RemoveAt(0);
                    }
                    Sources.Clear();
                }
                if (Targets != null)
                {
                    while (Targets.Count > 0)
                    {
                        Targets[0].Clear();
                        Targets.RemoveAt(0);
                    }
                    Targets.Clear();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Collections.Generic.List<System.Collections.Generic.List<int>> Sources
        {
            get
            {
                return _Sources;
            }
        }

        public System.Collections.Generic.List<System.Collections.Generic.List<int>> Targets
        {
            get
            {
                return _Targets;
            }
        }
    }
}
