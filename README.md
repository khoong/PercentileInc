# PercentileInc
Assumptions:
Array.Sort function is good enough for this task and no custom sorting algorithm is required.
Machine running the client is powerful enough and have enough memory to process the dataset from the WebAPI. 

Design decisions:
Entity framework was not used for the WebApi task. The returned dataset is one column of numerical value. Using a class to represent a numerical value will incur performance penalty due to "boxing" and "unboxing" operations.
