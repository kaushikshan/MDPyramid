The Design Uses Strategy Pattern.
The solution uses the DefaultPyramidStrategy.
The Data Provider is Injected During the Construction Of Pyramid.
The solution supports addition of new strategies for Calculation of Path and Sum.

Read the file Lines and Transform them into List of Lines having space separated integers. Construct a Pyramid from the Data.
Start the traversal at the top, select children that are opposite to the parent in terms of being odd/even.
Select the child with the maximum value and move to the next level, repeat the above step.
Stop when you reach the node with no children.
