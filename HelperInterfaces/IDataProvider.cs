using System.Collections.Generic;

namespace MDPyramid.HelperInterfaces
{
	/// <summary>
	/// Data Access Method
	/// </summary>
	public interface IDataProvider
	{
		/// <summary>
		/// Returns and Enumerable of Enumerable
		/// </summary>
		/// <returns></returns>
		IEnumerable<IEnumerable<int>> ReadByLines();
	}
}
