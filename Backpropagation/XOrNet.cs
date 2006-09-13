using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.NeuralNetworks
{
    public class XOrNet : IntBackpropagation
    {
        private const string FILENAME = "XOrNet.dat";

        private double _Error = 0;
        private XOrNetTrainSet _TrainSet = null;

        private class Definition : System.Collections.Generic.List<uint>
        {
            public Definition() : base()
            {
                try
                {
                    Add(2);
                    Add(4);
                    Add(3);
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
                _TrainSet = new XOrNetTrainSet();
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
                return _Error;
            }
            private set
            {
                _Error = value;
            }
        }

        public XOrNetTrainSet TrainSet
        {
            get
            {
                return _TrainSet;
            }
        }

        public double Train()
        {
            try
            {
                Error = base.Train(TrainSet.Sources, TrainSet.Targets);
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

    public class XOrNetTrainSet : System.Object 
    {
        private System.Collections.Generic.List<System.Collections.Generic.List<int>> _Sources = null;
        private System.Collections.Generic.List<System.Collections.Generic.List<int>> _Targets = null;

        public XOrNetTrainSet() : base()
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

        ~XOrNetTrainSet()
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
