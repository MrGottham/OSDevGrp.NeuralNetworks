using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.NeuralNetworks
{
    public class Backpropagation : System.Object 
    {
        private System.Collections.Generic.List<uint> _Neurons = null;
        private System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<float>>> _Weigths = null;
        private System.Collections.Generic.List<System.Collections.Generic.List<float>> _Bias = null;

        public Backpropagation(System.Collections.Generic.List<uint> definition)
        {
            try
            {
                // Create the neural network.
                Create(definition);
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

        protected void Create(System.Collections.Generic.List<uint> definition)
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
    }
}
