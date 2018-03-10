using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManager
{
    public class ConsoleManagerStub : ConsoleManagerBase
    {
        #region Fields
        private int currentOutputEntryNumber = 0;
        private Queue<object> userInputs = new Queue<object>();
        private List<string> outputs = new List<string>();
        #endregion

        #region Properties
        public Queue<object> UserInputs
        {
            get
            {
                return userInputs;
            }
        }
        public List<string> Outputs
        {
            get
            {
                return outputs;
            }
        }
        #endregion

        #region Events
        public event Action<int> OutputsUpdated;
        public event Action OutputsCleared;
        #endregion

        #region ConsoleManagerBase Implementations
        public override void Clear()
        {
            currentOutputEntryNumber++;
            outputs.Clear();
            OnOutputsCleared();
            OnOutputsUpdated(currentOutputEntryNumber);
        }
        public override ConsoleKeyInfo ReadKey()
        {
            ConsoleKeyInfo result = new ConsoleKeyInfo();
            object input = null;

            if (userInputs.Count > 0)
            {
                input = userInputs.Dequeue();
            }
            else
            {
                throw new Exception("No input was presented when an inpput was expected");
            }

            if (input is ConsoleKeyInfo)
            {
                result = (ConsoleKeyInfo)input;
            }
            else
            {
                throw new Exception("Invalid input was presented when ConsoleKeyInfo was expected");
            }

            return result;
        }
        public override string ReadLine()
        {
            string result = null;
            object input = null;

            if (userInputs.Count > 0)
            {
                input = userInputs.Dequeue();
            }
            else
            {
                throw new Exception("No input was presented when an inpput was expected");
            }

            if (input is string)
            {
                result = (string)input;
                WriteLine(result);
            }
            else
            {
                throw new Exception("Invalid input was presented when String was expected");
            }

            return result;
        }
        public override void Write(string value)
        {
            outputs.Add(value);
            currentOutputEntryNumber++;
            OnOutputsUpdated(currentOutputEntryNumber);
        }
        public override void WriteLine(string value)
        {
            outputs.Add(value + "\r\n");
            currentOutputEntryNumber++;
            OnOutputsUpdated(currentOutputEntryNumber);
        }
        #endregion

        #region Events Handlers
        protected void OnOutputsUpdated(int outputEntryNumber)
        {
            if (OutputsUpdated != null)
            {
                OutputsUpdated(outputEntryNumber);
            }
        }
        protected void OnOutputsCleared()
        {
            if (OutputsCleared != null)
            {
                OutputsCleared();
            }
        }
        #endregion

        #region Object Overrides
        public override string ToString()
        {
            string result = string.Empty;

            if (outputs != null && outputs.Count > 0)
            {
                StringBuilder builder = new StringBuilder();

                foreach (string output in outputs)
                {
                    /*if (output.Contains("\n"))
                    {
                        string[] parts = output.Split('\n');

                        foreach (string part in parts)
                        {
                            if (!string.IsNullOrEmpty(part))
                            {
                                builder.AppendLine(part);
                            }
                        }
                    }
                    else
                    {
                        builder.Append(output);
                    }*/

                    builder.Append(output);
                }

                result = builder.ToString();
            }

            return result;
        }
        #endregion
    }
}
