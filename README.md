# How Many Triangles?
Solves the **"how many triangles in this shape?"** types of riddles

### Example

![riddle2.bmp](img/riddle2.bmp)


### Usages

The  application takes an input of lines made up of indices of nodes (lines intersections) in the shape.

Mark each node with a unique index and create a `Line` from the indices of each actual (full) line in the shape:

![riddle2_with_indices.bmp](img/riddle2_with_indices.bmp)

```csharp
Line[] example =
{
    //Horizontal lines (-):
    new Line(){ 2, 3 }),
    new Line(){ 4, 5, 6 }),
    new Line(){ 7, 8, 9, 10 }),
    new Line(){ 11, 12, 13, 14, 15 }),
    //Diagonal lines (/)
    new Line(){ 1, 2 , 4 , 7 , 11  }),
    new Line(){ 3, 5 , 8 , 12 }),
    new Line(){ 6, 9 , 13 }),
    new Line(){ 10, 14 }),
    //Diagonal lines (\)
    new Line(){ 1, 3 , 6 , 10 , 15  }),
    new Line(){ 2, 5 , 9 , 14 }),
    new Line(){ 4, 8 , 13 }),
    new Line(){ 7, 12 }),
};


```

### Output

Running the above example gives the following result:


![example_result.PNG](img/example_result.PNG)