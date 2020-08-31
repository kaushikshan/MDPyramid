using System.Collections.Generic;

namespace MDPyramid.Models
{
    /// <summary>
    /// The whole Pyramid
    /// </summary>
	public class Pyramid
    {
        public Pyramid()
        {
            nodes = new List<PyramidNode>();
        }

        /// <summary>
        /// Nodes of the Pyramid
        /// </summary>
        public IList<PyramidNode> nodes { get; private set; }
        public int level { get; private set; }

        public void AddNode(PyramidNode pyramidNode)
        {
            nodes.Add(pyramidNode);
        }

        /// <summary>
        /// Usually called when the Pyramid Construction is Complete
        /// </summary>
        /// <param name="level"></param>
        public void SetLevel(int level)
        {
            this.level = level;
        }
    }
}
