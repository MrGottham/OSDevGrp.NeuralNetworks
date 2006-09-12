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

        public Sigmoid(int lowerbound, int upperbound, int mirror, int slope) : base()
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

    public abstract class Backpropagation<T> : System.Object
    {
        private const int FILE_VERSION = 1;

        private System.Collections.Generic.List<uint> _Neurons = null;
        private System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<float>>> _Weigths = null;
        private System.Collections.Generic.List<System.Collections.Generic.List<float>> _Bias = null;

        private Sigmoid _Sigmoid = null;

        private float _LearningRate = 0.5F;
        private double _Tolerance = 0.1;
        private bool _UseBias = false;

        public Backpropagation(System.Collections.Generic.List<uint> definition) : base()
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
                    return (uint)Neurons.Count;
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

        public float LearningRate
        {
            get
            {
                return _LearningRate;
            }
            set
            {
                _LearningRate = value;
            }
        }

        public double Tolerance
        {
            get
            {
                return _Tolerance;
            }
            set
            {
                _Tolerance = value;
            }
        }

        public bool UseBias
        {
            get
            {
                return _UseBias;
            }
            set
            {
                _UseBias = value;
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
                    Neurons.Add(definition[layer]);
                // Create the matrix for the weights.
                if (Weights == null)
                    Weights = new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<float>>>((int)Layers - 1);
                Weights.Capacity = (int)Layers - 1;
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    Weights.Add(new System.Collections.Generic.List<System.Collections.Generic.List<float>>((int)Neurons[layer]));
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                    {
                        Weights[layer].Add(new System.Collections.Generic.List<float>((int)Neurons[layer + 1]));
                        for (int weight = 0; weight < Neurons[layer + 1]; weight++)
                            Weights[layer][neuron].Add(0);
                    }
                }
                // Create the vectors for the bias.
                if (Bias == null)
                    Bias = new System.Collections.Generic.List<System.Collections.Generic.List<float>>((int)Layers - 1);
                Bias.Capacity = (int)Layers - 1;
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    Bias.Add(new System.Collections.Generic.List<float>((int)Neurons[layer + 1]));
                    for (int bias = 0; bias < Neurons[layer + 1]; bias++)
                        Bias[layer].Add(0);
                }
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
                            Weights[layer][neuron][weight] = (float)r.Next(1001) / 1000 - (float)0.5;
                    }
                }
                // Initialize the bias.
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    for (int bias = 0; bias < Neurons[layer + 1]; bias++)
                        Bias[layer][bias] = (float)r.Next(1001) / 1000 - (float)0.5;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected abstract float ConvertInput(T value);

        protected double f(double x, int a, int b, int c, int d)
        {
            return (b - a) / (1 + System.Math.Exp(-d * (x - c))) + a;
        }

        protected virtual double fout(double x, int a, int b, int c, int d)
        {
            return f(x, a, b, c, d);
        }

        private double df(double x, int a, int b, int c, int d)
        {
            return ((-a + f(x, a, b, c, d)) * (1 - f(x, a, b, c, d))) / (b - a);
        }

        public double Train(System.Collections.Generic.List<T> source, System.Collections.Generic.List<T> target)
        {
            try
            {
                System.Collections.Generic.List<System.Collections.Generic.List<float>> input = null;
                System.Collections.Generic.List<System.Collections.Generic.List<float>> output = null;
                System.Collections.Generic.List<System.Collections.Generic.List<float>> delta = null;
                double error = 0;
                // Create vectors for the input
                input = new System.Collections.Generic.List<System.Collections.Generic.List<float>>((int)Layers - 1);
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    input.Add(new System.Collections.Generic.List<float>((int)Neurons[layer + 1]));
                    for (int neuron = 0; neuron < Neurons[layer + 1]; neuron++)
                        input[layer].Add(0);
                }
                // Create vectors for the output.
                output = new System.Collections.Generic.List<System.Collections.Generic.List<float>>((int)Layers);
                for (int layer = 0; layer < Layers; layer++)
                {
                    output.Add(new System.Collections.Generic.List<float>((int)Neurons[layer]));
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                        output[layer].Add(0);
                }
                // Create vectors for the delta values.
                delta = new System.Collections.Generic.List<System.Collections.Generic.List<float>>((int)Layers - 1);
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    delta.Add(new System.Collections.Generic.List<float>((int)Neurons[layer + 1]));
                    for (int neuron = 0; neuron < Neurons[layer + 1]; neuron++)
                        delta[layer].Add(0);
                }
                // Feed forward.
                for (int i = 0; i < Neurons[0]; i++)
                    output[0][i] = ConvertInput(source[i]);
                for (int layer = 1; layer < Layers; layer++)
                {
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                    {
                        input[layer - 1][neuron] = 0;
                        if (UseBias)
                            input[layer - 1][neuron] = Bias[layer - 1][neuron];
                        for (int i = 0; i < Neurons[layer - 1]; i++)
                            input[layer - 1][neuron] += output[layer - 1][i] * Weights[layer - 1][i][neuron];
                        if (layer == (int)Layers - 1)
                            output[layer][neuron] = (float)fout(input[layer - 1][neuron], Sigmoid.LowerBound, Sigmoid.UpperBound, Sigmoid.Mirror, Sigmoid.Slope);
                        else
                            output[layer][neuron] = (float)f(input[layer - 1][neuron], Sigmoid.LowerBound, Sigmoid.UpperBound, Sigmoid.Mirror, Sigmoid.Slope);
                    }
                }
                // Calculate the error value.
                error = 0;
                for (int neuron = 0; neuron < Neurons[(int)Layers - 1]; neuron++)
                    error += (ConvertInput(target[neuron]) - output[(int)Layers - 1][neuron]) * (ConvertInput(target[neuron]) - output[(int)Layers - 1][neuron]);
                // Backpropagation.
                for (int neuron = 0; neuron < Neurons[(int)Layers - 1]; neuron++)
                    delta[(int)Layers - 2][neuron] = (ConvertInput(target[neuron]) - output[(int)Layers - 1][neuron]) * (float)df(input[(int)Layers - 2][neuron], Sigmoid.LowerBound, Sigmoid.UpperBound, Sigmoid.Mirror, Sigmoid.Slope);
                for (int layer = (int)Layers - 2; layer > 0; layer--)
                {
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                    {
                        double d = 0;
                        for (int i = 0; i < Neurons[layer + 1]; i++)
                            d += delta[layer][i] * Weights[layer][neuron][i];
                        delta[layer - 1][neuron] = (float)(d * df(input[layer - 1][neuron], Sigmoid.LowerBound, Sigmoid.UpperBound, Sigmoid.Mirror, Sigmoid.Slope));
                    }
                }
                // Adjust weights and bias values.
                for (int layer = 1; layer < Layers; layer++)
                {
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                    {
                        Bias[layer - 1][neuron] += LearningRate * delta[layer - 1][neuron];
                        for (int i = 0; i < Neurons[layer - 1]; i++)
                            Weights[layer - 1][i][neuron] += LearningRate * delta[layer - 1][neuron] * output[layer - 1][i];
                    }
                }
                // Destroy vectors for the input.
                while (input.Count > 0)
                {
                    input[0].Clear();
                    input.RemoveAt(0);
                }
                input.Clear();
                // Destroy vectors for the output.
                while (output.Count > 0)
                {
                    output[0].Clear();
                    output.RemoveAt(0);
                }
                output.Clear();
                // Destroy vectors for the delta values.
                while (delta.Count > 0)
                {
                    delta[0].Clear();
                    delta.RemoveAt(0);
                }
                delta.Clear();
                return error;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public double Train(System.Collections.Generic.List<System.Collections.Generic.List<T>> sources, System.Collections.Generic.List<System.Collections.Generic.List<T>> targets)
        {
            try
            {
                double error = 0;
                for (int i = 0; i < sources.Count && i < targets.Count; i++)
                    error += Train(sources[i], targets[i]);
                return error;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Collections.Generic.List<float> Run(System.Collections.Generic.List<T> input)
        {
            try
            {
                System.Collections.Generic.List<System.Collections.Generic.List<float>> output = null;
                System.Collections.Generic.List<float> result = null;
                // Create vectors for the output.
                output = new System.Collections.Generic.List<System.Collections.Generic.List<float>>((int)Layers);
                for (int layer = 0; layer < Layers; layer++)
                {
                    output.Add(new System.Collections.Generic.List<float>((int)Neurons[layer]));
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                        output[layer].Add(0);
                }
                // Activate the input neurons.
                for (int neuron = 0; neuron < Neurons[0]; neuron++)
                    output[0][neuron] = ConvertInput(input[neuron]);
                // Feed forward.
                for (int layer = 1; layer < Layers; layer++)
                {
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                    {
                        float inp = 0;
                        if (UseBias)
                            inp = Bias[layer - 1][neuron];
                        for (int i = 0; i < Neurons[layer - 1]; i++)
                            inp += output[layer - 1][i] * Weights[layer - 1][i][neuron];
                        if (layer == (int)Layers - 1)
                            output[layer][neuron] = (float)fout(inp, Sigmoid.LowerBound, Sigmoid.UpperBound, Sigmoid.Mirror, Sigmoid.Slope);
                        else
                            output[layer][neuron] = (float)f(inp, Sigmoid.LowerBound, Sigmoid.UpperBound, Sigmoid.Mirror, Sigmoid.Slope);
                    }
                }
                // Copy the result to a new list.
                result = new System.Collections.Generic.List<float>(output[(int)Layers - 1].Count);
                foreach (float f in output[(int)Layers - 1])
                    result.Add(f);
                // Destroy vectors for the output.
                while (output.Count > 0)
                {
                    output[0].Clear();
                    output.RemoveAt(0);
                }
                output.Clear();
                return result;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Save(string filename)
        {
            System.IO.FileStream fs = null;
            try
            {
                string netname = "Backpropagation net";
                byte[] bytes = null;
                // Create the data file.
                fs = new System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None);
                // Write the data file version.
                bytes = System.BitConverter.GetBytes(FILE_VERSION);
                fs.Write(bytes, 0, bytes.Length);
                // Write the length and name of the neural network.
                bytes = System.BitConverter.GetBytes(System.Text.Encoding.ASCII.GetByteCount(netname));
                fs.Write(bytes, 0, bytes.Length);
                bytes = System.Text.Encoding.ASCII.GetBytes(netname);
                fs.Write(bytes, 0, bytes.Length);
                // Write the number of layers in the neural network.
                bytes = System.BitConverter.GetBytes(Layers);
                fs.Write(bytes, 0, bytes.Length);
                // Write the values for the sigmoid function.
                bytes = System.BitConverter.GetBytes(Sigmoid.LowerBound);
                fs.Write(bytes, 0, bytes.Length);
                bytes = System.BitConverter.GetBytes(Sigmoid.UpperBound);
                fs.Write(bytes, 0, bytes.Length);
                bytes = System.BitConverter.GetBytes(Sigmoid.Mirror);
                fs.Write(bytes, 0, bytes.Length);
                bytes = System.BitConverter.GetBytes(Sigmoid.Slope);
                fs.Write(bytes, 0, bytes.Length);
                // Write values for the learning rate, tolerance and whether to 
                // use bias values.
                bytes = System.BitConverter.GetBytes(LearningRate);
                fs.Write(bytes, 0, bytes.Length);
                bytes = System.BitConverter.GetBytes(Tolerance);
                fs.Write(bytes, 0, bytes.Length);
                bytes = System.BitConverter.GetBytes(UseBias);
                fs.Write(bytes, 0, bytes.Length);
                // Write the number of neurons in each layer.
                for (int layer = 0; layer < Layers; layer++)
                {
                    bytes = System.BitConverter.GetBytes(Neurons[layer]);
                    fs.Write(bytes, 0, bytes.Length);
                }
                // Write the wieghts for the neural network.
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                    {
                        for (int i = 0; i < Neurons[layer + 1]; i++)
                        {
                            bytes = System.BitConverter.GetBytes(Weights[layer][neuron][i]);
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                }
                // Write the bias values for the neural network.
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    for (int neuron = 0; neuron < Neurons[layer + 1]; neuron++)
                    {
                        bytes = System.BitConverter.GetBytes(Bias[layer][neuron]);
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                fs.Close();
            }
            catch (System.Exception ex)
            {
                if (fs != null)
                    fs.Close();
                throw ex;
            }
        }

        public void Load(string filename)
        {
            // TODO: Remember to check for the stored version in the file.
            System.IO.FileStream fs = null;
            try
            {
                int fileversion = FILE_VERSION;
                int netnamelength = 0, lowerbound = 0, upperbound = 1, mirror = 0, slope = 1;
                byte[] bytes = null;
                System.Collections.Generic.List<uint> definition = null;
                // Open the data file.
                fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                // Read the data file version.
                bytes = System.BitConverter.GetBytes(FILE_VERSION);
                fs.Read(bytes, 0, bytes.Length);
                fileversion = System.BitConverter.ToInt32(bytes, 0);
                // Write the length and name of the neural network.
                bytes = System.BitConverter.GetBytes(netnamelength);
                fs.Read(bytes, 0, bytes.Length);
                netnamelength = System.BitConverter.ToInt32(bytes, 0);
                bytes = new byte[netnamelength];
                fs.Read(bytes, 0, bytes.Length);
                // Destroy the existing network.
                Destroy();
                // Read the number of layers in the neural network.
                bytes = System.BitConverter.GetBytes(Layers);
                fs.Read(bytes, 0, bytes.Length);
                definition = new System.Collections.Generic.List<uint>(System.BitConverter.ToInt32(bytes, 0));
                while (definition.Count < definition.Capacity)
                    definition.Add(0);
                // Read the values for the sigmoid function.
                bytes = System.BitConverter.GetBytes(lowerbound);
                fs.Read(bytes, 0, bytes.Length);
                lowerbound = System.BitConverter.ToInt32(bytes, 0);
                bytes = System.BitConverter.GetBytes(upperbound);
                fs.Read(bytes, 0, bytes.Length);
                upperbound = System.BitConverter.ToInt32(bytes, 0);
                bytes = System.BitConverter.GetBytes(mirror);
                fs.Read(bytes, 0, bytes.Length);
                mirror = System.BitConverter.ToInt32(bytes, 0);
                bytes = System.BitConverter.GetBytes(slope);
                fs.Read(bytes, 0, bytes.Length);
                slope = System.BitConverter.ToInt32(bytes, 0);
                // Read values for the learning rate, tolerance and whether to 
                // use bias values.
                bytes = System.BitConverter.GetBytes(LearningRate);
                fs.Read(bytes, 0, bytes.Length);
                LearningRate = System.BitConverter.ToInt32(bytes, 0);
                bytes = System.BitConverter.GetBytes(Tolerance);
                fs.Read(bytes, 0, bytes.Length);
                Tolerance = System.BitConverter.ToInt32(bytes, 0);
                bytes = System.BitConverter.GetBytes(UseBias);
                fs.Read(bytes, 0, bytes.Length);
                UseBias = System.BitConverter.ToBoolean(bytes, 0);
                // Write the number of neurons in each layer.
                for (int layer = 0; layer < definition.Count; layer++)
                {
                    bytes = System.BitConverter.GetBytes(definition[layer]);
                    fs.Read(bytes, 0, bytes.Length);
                    definition[layer] = System.BitConverter.ToUInt32(bytes, 0);
                }
                // Create and initialize the new neural network.
                Create(definition, lowerbound, upperbound, mirror, slope);
                Initialize();
                // Read the wieghts for the neural network.
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    for (int neuron = 0; neuron < Neurons[layer]; neuron++)
                    {
                        for (int i = 0; i < Neurons[layer + 1]; i++)
                        {
                            bytes = System.BitConverter.GetBytes(Weights[layer][neuron][i]);
                            fs.Read(bytes, 0, bytes.Length);
                            Weights[layer][neuron][i] = System.BitConverter.ToSingle(bytes, 0);
                        }
                    }
                }
                // Read the bias values for the neural network.
                for (int layer = 0; layer < Layers - 1; layer++)
                {
                    for (int neuron = 0; neuron < Neurons[layer + 1]; neuron++)
                    {
                        bytes = System.BitConverter.GetBytes(Bias[layer][neuron]);
                        fs.Read(bytes, 0, bytes.Length);
                        Bias[layer][neuron] = System.BitConverter.ToSingle(bytes, 0);
                    }
                }
                fs.Close();
            }
            catch (System.Exception ex)
            {
                if (fs != null)
                    fs.Close();
                throw ex;
            }
        }
    }

    public class ByteBackpropagation : Backpropagation<byte>
    {
        public ByteBackpropagation(System.Collections.Generic.List<uint> definition) : base(definition)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected override float ConvertInput(byte value)
        {
            return (float)value;
        }
    }

    public class CharBackpropagation : Backpropagation<char>
    {
        public CharBackpropagation(System.Collections.Generic.List<uint> definition) : base(definition)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected override float ConvertInput(char value)
        {
            return (float)value;
        }
    }

    public class IntBackpropagation : Backpropagation<int>
    {
        public IntBackpropagation(System.Collections.Generic.List<uint> definition) : base(definition)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected override float ConvertInput(int value)
        {
            return (float)value;
        }
    }

    public class LongBackpropagation : Backpropagation<long>
    {
        public LongBackpropagation(System.Collections.Generic.List<uint> definition) : base(definition)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected override float ConvertInput(long value)
        {
            return (float)value;
        }
    }

    public class DoubleBackpropagation : Backpropagation<double>
    {
        public DoubleBackpropagation(System.Collections.Generic.List<uint> definition) : base(definition)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected override float ConvertInput(double value)
        {
            return (float)value;
        }
    }

    public class FloatBackpropagation : Backpropagation<float>
    {
        public FloatBackpropagation(System.Collections.Generic.List<uint> definition) : base(definition)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected override float ConvertInput(float value)
        {
            return (float)value;
        }
    }
}
