using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.NeuralNetworks
{
    public class Sigmoid : System.Object
    {
        private int _LowerBound = 0;
        private int _UpperBound = 1;
        private int _Mirror = 0;
        private int _Slope = 1;

        public Sigmoid(int lowerbound, int upperbound, int mirror, int slope)
        {
            try
            {
                LowerBound = lowerbound;
                UpperBound = upperbound;
                Mirror = mirror;
                Slope = slope;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public int LowerBound
        {
            get
            {
                return _LowerBound;
            }
            set
            {
                _LowerBound = value;
            }
        }

        public int UpperBound
        {
            get
            {
                return _UpperBound;
            }
            set
            {
                _UpperBound = value;
            }
        }

        public int Mirror
        {
            get
            {
                return _Mirror;
            }
            set
            {
                _Mirror = value;
            }
        }

        public int Slope
        {
            get
            {
                return _Slope;
            }
            set
            {
                _Slope = value;
            }
        }
    }

    public class Backpropagation : System.Object 
    {
        private System.Collections.Generic.List<uint> _Neurons = null;
        private System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<float>>> _Weigths = null;
        private System.Collections.Generic.List<System.Collections.Generic.List<float>> _Bias = null;
        private Sigmoid _Sigmoid = null;

        public Backpropagation(System.Collections.Generic.List<uint> definition)
        {
            try
            {
                // Create and initialize the neural network.
                Create(definition, 0, 1, 0, 1);
                Initialize();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~Backpropagation()
        {
            try
            {
                // Destroy the neural network.
                Destroy();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected System.Collections.Generic.List<uint> Neurons
        {
            get
            {
                return _Neurons;
            }
            set
            {
                _Neurons = value;
            }
        }

        public uint Layers
        {
            get
            {
                if (Neurons != null)
                    return (uint) Neurons.Count;
                return 0;
            }
        }

        protected System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<float>>> Weights
        {
            get
            {
                return _Weigths;
            }
            set
            {
                _Weigths = value;
            }
        }

        protected System.Collections.Generic.List<System.Collections.Generic.List<float>> Bias
        {
            get
            {
                return _Bias;
            }
            set
            {
                _Bias = value;
            }
        }

        public Sigmoid Sigmoid
        {
            get
            {
                return _Sigmoid;
            }
            private set
            {
                _Sigmoid = value;
            }
        }

        protected void Create(System.Collections.Generic.List<uint> definition, int lowerbound, int upperbound, int mirror, int slope)
        {
            try
            {
                // Destroy an existing neural network.
                Destroy();
                // Create the vector for the neurons pr. layer.
                if (Neurons == null)
                    Neurons = new System.Collections.Generic.List<uint>(definition.Count);
                Neurons.Capacity = definition.Count;
                for (int layer = 0; layer < definition.Count; layer++)
                    Neurons[layer] = definition[layer];
                // Create the matrix for the weights.
                if (Weights == null)
                    Weights = new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<float>>>((int) Layers - 1);
                Weights.Capacity = (int) Layers - 1;
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    Weights[layer] = new System.Collections.Generic.List<System.Collections.Generic.List<float>>((int) Neurons[layer]);
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                        Weights[layer][neuron] = new System.Collections.Generic.List<float>((int) Neurons[layer + 1]);
                }
                // Create the vectors for the bias.
                if (Bias == null)
                    Bias = new System.Collections.Generic.List<System.Collections.Generic.List<float>>((int) Layers - 1);
                Bias.Capacity = (int) Layers - 1;
                for (int layer = 0; layer < Layers - 1; layer++)
                    Bias[layer] = new System.Collections.Generic.List<float>((int) Neurons[layer + 1]);
                // Create the sigmoid function.
                if (Sigmoid == null)
                    Sigmoid = new Sigmoid(lowerbound, upperbound, mirror, slope);
                Sigmoid.LowerBound = lowerbound;
                Sigmoid.UpperBound = upperbound;
                Sigmoid.Mirror = mirror;
                Sigmoid.Slope = slope;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected void Destroy()
        {
            try
            {
                // Destroy the vectors for the bias.
                if (Bias != null)
                {
                    while (Bias.Count > 0)
                    {
                        Bias[0].Clear();
                        Bias.RemoveAt(0);
                    }
                    Bias.Clear();
                }
                // Destroy the matrix for the weights.
                if (Weights != null)
                {
                    while (Weights.Count > 0)
                    {
                        while (Weights[0].Count > 0)
                        {
                            Weights[0][0].Clear();
                            Weights[0].RemoveAt(0);
                        }
                        Weights[0].Clear();
                        Weights.RemoveAt(0);
                    }
                    Weights.Clear();
                }
                // Destroy the vector for the neurons pr. layer.
                if (Neurons != null)
                    Neurons.Clear();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected void Initialize()
        {
            try
            {
                System.Random r = new System.Random();
                // Initialize the weights.
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                    {
                        for (int weight = 0; weight < Neurons[layer + 1]; weight++)
                            Weights[layer][neuron][weight] = (float) r.Next(1001) / 1000 - (float) 0.5;
                    }
                }
                // Initialize the bias.
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    for (int bias = 0; bias < Neurons[layer + 1]; bias++)
                        Bias[layer][bias] = (float) r.Next(1001) / 1000 - (float) 0.5;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
