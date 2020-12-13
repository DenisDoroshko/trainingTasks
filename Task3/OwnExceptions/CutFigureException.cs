﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnExceptions
{
    /// <summary>
    /// Represents a cut figure error
    /// </summary>

    public class CutFigureException:Exception
    {
        /// <summary>
        /// Creates a cut figure error
        /// </summary>

        public CutFigureException() : base("The figure being cut is larger then original figure.")
        {
        }

        /// <summary>
        /// Creates a cut figure error
        /// </summary>

        public CutFigureException(string message) : base(message)
        {
        }
    }
}
