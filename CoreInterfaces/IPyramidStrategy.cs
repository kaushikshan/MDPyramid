using MDPyramid.HelperModels;
using MDPyramid.Models;

namespace MDPyramid.CoreInterfaces
{
	/// <summary>
	/// Interface For Strategy
	/// </summary>
	public interface IPyramidStrategy
	{
		/// <summary>
		/// Walk the path and calculate the Sum
		/// </summary>
		/// <param name="pyramid"></param>
		/// <returns></returns>
		ResultModel WalkAndCalculate(Pyramid pyramid);
	}
}
