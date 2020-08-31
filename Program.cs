using MDPyramid.HelperModels;
using System;

namespace MDPyramid
{
	class Program
	{
		/// <summary>
		/// Initialize a Context with Strategy and Calcuate
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			try
			{
				//Initialize Pyramid Context with Default Strategy
				PyramidContext p = new PyramidContext(new DefaultPyramidStrategy());

				//Use Context Object to Build the Pyramid
				if (p.BuildPyramid(new PyramidData()))
				{
					//On building the Pyramid
					//Use Context Object to call the Strategy Method to Do the Calculation
					ResultModel resultModel = p.WalkAndCalculate();

					//Display the Result
					if (null != resultModel)
					{
						resultModel.Display();
					}
				}
				else
				{
					Console.WriteLine("Building the Pyramid Failed");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception Occured: " + ex.Message.ToString());
			}
		}
	}
}
