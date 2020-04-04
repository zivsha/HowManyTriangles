using System.Collections.Generic;
using HowManyTriangles;

namespace HowManyTrianglesApp
{
    static class Riddles
    {
        public static IEnumerable<Line> Riddle1
        {
            get
            {
                return new Line[] {
                    new Line(new List<int>(){ 1, 4, 5}),
                    new Line(new List<int>(){ 1, 9, 11, 6}),
                    new Line(new List<int>(){ 1, 8, 10, 7}),
                    new Line(new List<int>(){ 1, 2, 3}),
                    new Line(new List<int>(){ 2, 8, 9, 4}),
                    new Line(new List<int>(){ 2, 10, 11, 5}),
                    new Line(new List<int>(){ 5, 6, 7, 3})
                };
            }
        }
        public static IEnumerable<Line> Riddle2
        {
            get
            {
                return new Line[]
                {
                    new Line(new List<int>(){ 1,2 ,3 ,4 ,5}),
                    new Line(new List<int>(){ 1,9 ,8 ,7 ,6}),
                    new Line(new List<int>(){ 1,10,11,12,13}),
                    new Line(new List<int>(){ 1,17,16,15,14}),
                    new Line(new List<int>(){ 2,9,10,17}),
                    new Line(new List<int>(){ 3,8,11,16}),
                    new Line(new List<int>(){ 4,7,12,15}),
                    new Line(new List<int>(){ 5,6,13,14})
                };
            }
        }

        public static IEnumerable<Line> Riddle3
        {
            get
            {
                return new Line[] 
                {
                    //Horizontal lines (-):
                    new Line(new List<int>(){ 2, 3 }),
                    new Line(new List<int>(){ 4, 5, 6 }),
                    new Line(new List<int>(){ 7, 8, 9, 10 }),
                    new Line(new List<int>(){ 11, 12, 13, 14, 15 }),
                    //Diagonal lines (/)
                    new Line(new List<int>(){ 1, 2 , 4 , 7 , 11  }),
                    new Line(new List<int>(){ 3, 5 , 8 , 12 }),
                    new Line(new List<int>(){ 6, 9 , 13 }),
                    new Line(new List<int>(){ 10, 14 }),
                    //Diagonal lines (\)
                    new Line(new List<int>(){ 1, 3 , 6 , 10 , 15  }),
                    new Line(new List<int>(){ 2, 5 , 9 , 14 }),
                    new Line(new List<int>(){ 4, 8 , 13 }),
                    new Line(new List<int>(){ 7, 12 }),
                };
            }
        }
    }
}
