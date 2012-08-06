using System;

namespace Sandworks.Google
{
    public class GoogleParameter
    {
        /// <summary>
        /// Name of the parameter, ex: output
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the parameter, ex: xml
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Initialize the parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public GoogleParameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
