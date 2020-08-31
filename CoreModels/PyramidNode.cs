namespace MDPyramid.Models
{
    /// <summary>
    /// Single Node of the Pyramid
    /// </summary>
	public class PyramidNode
    {

        public int number { get; private set; }
        public int index { get; private set; }
        public int level { get; private set; }

        public PyramidNode left { get; private set; }

        public PyramidNode right { get; private set; }

        public PyramidNode(int number, int index, int level)
        {
            this.number = number;
            this.index = index;
            this.level = level;
            this.left = null;
            this.right = null;
        }

        /// <summary>
        /// Checks if the Node value has Odd Number
        /// </summary>
        /// <returns></returns>
        public bool IsOdd()
        {
            return number % 2 != 0;
        }

        /// <summary>
        /// Set left and right Nodes for a Parent
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void SetLeftRight(PyramidNode left, PyramidNode right)
        {
            this.left = left;
            this.right = right;
        }
    }
}
