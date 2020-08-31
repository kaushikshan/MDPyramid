using MDPyramid.CoreInterfaces;
using MDPyramid.HelperInterfaces;
using MDPyramid.Models;
using System;
using System.Collections.Generic;

namespace MDPyramid.HelperModels
{
    /// <summary>
    /// This is the Pyramid Context
    /// Contains Strategy and Builder
    /// </summary>
	public class PyramidContext
    {

        public IPyramidStrategy strategy { get; private set; }
        private Pyramid pyramid;

        /// <summary>
        /// Initialize with Default Strategy
        /// </summary>
        public PyramidContext()
        {
            this.strategy = new DefaultPyramidStrategy();
            this.pyramid = new Pyramid();
        }

        /// <summary>
        /// Use DI to inject Strategy
        /// </summary>
        /// <param name="strategy"></param>
        public PyramidContext(IPyramidStrategy strategy)
        {
            this.strategy = strategy;
            this.pyramid = new Pyramid();
        }

        /// <summary>
        /// Allow to replace Strategy at Runtime
        /// </summary>
        /// <param name="strategy"></param>
        public void SetStrategy(IPyramidStrategy strategy)
        {
            this.strategy = strategy;
        }

        /// <summary>
        /// Builder uses DI to read the Data
        /// </summary>
        /// <param name="pyramidData"></param>
        public bool BuildPyramid(IDataProvider pyramidData)
        {
            int index = -1;
            int level = -1;
            bool isBuilt;
            try
            {
                //Read Data line by line to build the Pyramid
                foreach (IEnumerable<int> line in pyramidData.ReadByLines())
                {
                    ++level;
                    foreach (int item in line)
                    {
                        ++index;
                        //Do not set any child nodes at this point
                        pyramid.AddNode(new PyramidNode(item, index, level));

                    }
                }

                //Check if it qualifies to be a pyramid
                if ((((level + 1) * (level + 2)) / 2) == pyramid.nodes.Count)
                {
                    //Pyramid Level starts at 0
                    pyramid.SetLevel(level);

                    // Assign right and left nodes
                    foreach (PyramidNode node in pyramid.nodes)
                    {
                        //Except Leaf Nodes
                        if (node.level != level)
                        {
                            //Core Logic for getting/setting Left and right nodes
                            int leftIndex = node.index + node.level + 1;
                            int rightIndex = node.index + node.level + 2;
                            node.SetLeftRight(pyramid.nodes[leftIndex], pyramid.nodes[rightIndex]);
                        }
                    }

                    //Building is Complete
                    isBuilt = true;
                }
                else
                {
                    //Did not build the Pyramid
                    isBuilt = false;
                    pyramid = null;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return isBuilt;
        }

        /// <summary>
        /// Use the DI strategy method to Execute Core Algorithm
        /// </summary>
        /// <returns></returns>
        public ResultModel WalkAndCalculate()
        {
            //Check if the Pyramid is built
            if (null != pyramid)
            {
                return strategy.WalkAndCalculate(pyramid);
            }
            else
            {
                throw new Exception("Invalid Pyramid");
            }
        }
    }
}
