using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = new Mat(@"C:\Users\myng1\OneDrive\바탕 화면\캡스톤디자아인\원단.jpg");
            Mat yellow = new Mat();
            Mat dst = src.Clone();
            Cv2.Resize(src, dst, new Size(500, 500));
            Point[][] contours;
            HierarchyIndex[] hierarchy;
            //160, 80, 90
            Cv2.InRange(dst, new Scalar(100, 100, 100), new Scalar(255, 255, 255), yellow);
            Cv2.FindContours(yellow, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            List<Point[]> new_contours = new List<Point[]>();
            foreach (Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                if (length > 100)
                {
                    new_contours.Add(p);
                }
            }

            Cv2.DrawContours(dst, new_contours, -1, new Scalar(180, 255, 255), 2, LineTypes.AntiAlias, null, 1);
            
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
        }
    }
}