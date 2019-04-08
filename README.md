# PercentileInc
Assumptions:
I assume I am allowed to use Array.Sort function to sort array as opposed to writing out the sorting algorithm.
I assume the client consuming the WebApi is powerful enough and have enough memory to process the dataset from the WebAPI. 

Design decisions:
I have decided against using entity framework for the WebApi task. The returned dataset is one column of numerical value. Using a class to represent a numerical value will incur performance penalty due to "boxing" and "unboxing" operations.
