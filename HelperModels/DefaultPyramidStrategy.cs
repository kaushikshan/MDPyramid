using MDPyramid.CoreInterfaces;
using MDPyramid.Models;
using System;
using System.Linq;

namespace MDPyramid.HelperModels
{
    /// <summary>
    /// This is the Default Strategy
    /// </summary>
	public class DefaultPyramidStrategy : IPyramidStrategy
    {
        /// <summary>
        /// Walk the Path and Calculate Sum
        /// </summary>
        /// <param name="pyramid"></param>
        /// <returns></returns>
		public ResultModel WalkAndCalculate(Pyramid pyramid)
        {
            ResultModel resultModel = new ResultModel();

            if (pyramid == null)
            {
                throw new ArgumentNullException("Root Doesn't Exist");
            }

            //First node is the Parent
            PyramidNode parent = pyramid.nodes.FirstOrDefault();

            //Include the Parent in the Sum
            int sum = parent.number;

            //Set level to next
            int level = 0;
            ++level;

            //Add root to the Path
            resultModel.path.Add(parent.number);

            //Traverse Pyramid Levels
            while (level <= pyramid.level)
            {
                //Get the next node
                PyramidNode pathNode = pyramid.nodes.Where(n => n.level == level)
                                                            .Where(n => n.IsOdd() != parent.IsOdd())
                                                                .Where(n => parent.left.index == n.index || parent.right.index == n.index)
                                                                    .OrderByDescending(n => n.number)
                                                                        .FirstOrDefault();

                //If there is no node Return
                if (null == pathNode)
                {
                    resultModel.path.Clear();
                    return resultModel;
                }
                else
                {
                    //Update the Sum
                    sum += pathNode.number;
                    //Node is the new Parent
                    parent = pathNode;
                    //Include the node in the Path
                    resultModel.path.Add(pathNode.number);
                    //Ready for next level
                    level++;
                }
            }

            //Include calculated Sum and Return
            resultModel.maxSum = sum;
            return resultModel;
        }
    }
}
