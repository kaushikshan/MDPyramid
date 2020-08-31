using System;
using System.Collections.Generic;

namespace MDPyramid.HelperModels
{
	/// <summary>
	/// Useful for Holding and Displaying the Result
	/// </summary>
	public class ResultModel
	{
		public List<int> path { get; set; }
		public int maxSum { get; set; }

		public ResultModel()
		{
			path = new List<int>();
		}

		/// <summary>
		/// Display the Result
		/// </summary>
		public void Display()
		{
			//Diplay only if path has Nodes
			if (this.path.Count > 0)
			{
				Console.WriteLine("Max Sum is: " + this.maxSum);
				Console.WriteLine("Path: " + String.Join(", ", this.path));
			}
			else
			{
				Console.WriteLine("No Valid Path to the Leaf");
			}
		}
	}
}
