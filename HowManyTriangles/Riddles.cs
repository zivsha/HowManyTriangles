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
                    new Line(){ 1, 4, 5 },
                    new Line(){ 1, 9, 11, 6 },
                    new Line(){ 1, 8, 10, 7 },
                    new Line(){ 1, 2, 3 },
                    new Line(){ 2, 8, 9, 4 },
                    new Line(){ 2, 10, 11, 5 },
                    new Line(){ 5, 6, 7, 3 }
                };
            }
        }
        public static IEnumerable<Line> Riddle2
        {
            get
            {
                return new Line[]
                {
                    new Line(){ 1, 2 ,3 ,4 ,5 },
                    new Line(){ 1, 9 ,8 ,7 ,6 },
                    new Line(){ 1, 10, 11, 12, 13 },
                    new Line(){ 1, 17, 16, 15, 14 },
                    new Line(){ 2, 9, 10, 17 },
                    new Line(){ 3, 8, 11, 16 },
                    new Line(){ 4, 7, 12, 15 },
                    new Line(){ 5, 6, 13, 14 }
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
                    new Line(){ 2, 3 },
                    new Line(){ 4, 5, 6 },
                    new Line(){ 7, 8, 9, 10 },
                    new Line(){ 11, 12, 13, 14, 15 },
                    //Diagonal lines (/)
                    new Line(){ 1, 2, 4, 7, 11 },
                    new Line(){ 3, 5, 8, 12 },
                    new Line(){ 6, 9, 13 },
                    new Line(){ 10, 14 },
                    //Diagonal lines (\)
                    new Line(){ 1, 3, 6, 10, 15 },
                    new Line(){ 2, 5, 9, 14 },
                    new Line(){ 4, 8, 13 },
                    new Line(){ 7, 12 },
                };
            }
        }
    }
}
