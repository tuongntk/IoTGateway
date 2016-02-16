﻿using System;
using System.Collections.Generic;
using System.Text;
using Waher.Script.Abstraction.Elements;
using Waher.Script.Model;

namespace Waher.Script.Operators.Conditional
{
	/// <summary>
	/// IF operator.
	/// </summary>
	public class If : TernaryOperator
	{
		/// <summary>
		/// IF operator.
		/// </summary>
		/// <param name="Condition">Required condition.</param>
		/// <param name="IfTrue">Required statement, if true.</param>
		/// <param name="IfFalse">Optional statement, if false.</param>
		/// <param name="Start">Start position in script expression.</param>
		/// <param name="Length">Length of expression covered by node.</param>
		public If(ScriptNode Condition, ScriptNode IfTrue, ScriptNode IfFalse, int Start, int Length)
			: base(Condition, IfTrue, IfFalse, Start, Length)
		{
		}

		/// <summary>
		/// Evaluates the node, using the variables provided in the <paramref name="Variables"/> collection.
		/// </summary>
		/// <param name="Variables">Variables collection.</param>
		/// <returns>Result.</returns>
		public override Element Evaluate(Variables Variables)
		{
			throw new NotImplementedException();	// TODO: Implement
		}
	}
}
