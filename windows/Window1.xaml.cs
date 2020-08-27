using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Colors;

using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ViewModel.HWTuner;
using Autodesk.AutoCAD.MacroRecorder;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;

namespace AutoCAD_1.windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
    public partial class Window1 : Window
    {
        int[] o1;
        int[] o2;
        int[] o3;
        int[] o4;
        int[] o5;


        Random rnd = new Random();
        List<int[]> rec1_list = new List<int[]>();
        List<int[]> rec2_list = new List<int[]>();
        List<int[]> rec3_list = new List<int[]>();
        List<int[]> rec4_list = new List<int[]>();
        List<int[]> rec5_list = new List<int[]>();

        int[] radius_list = { 15, 18, 25, 32, 35, 42, 49 };

        List<int[]> rec1_pointlist = new List<int[]>();
        List<int[]> rec2_pointlist = new List<int[]>();
        List<int[]> rec3_pointlist = new List<int[]>();
        List<int[]> rec4_pointlist = new List<int[]>();
        List<int[]> rec5_pointlist = new List<int[]>();

        int[] pointRec1_init = new int[3]; //first point for rec1
        int[] pointRec2_init = new int[3]; //first point for rec2
        int[] pointRec3_init = new int[3]; //first point for rec3
        int[] pointRec4_init = new int[3]; //first point for rec4
        int[] pointRec5_init = new int[3]; //first point for rec5

        static Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
        Database acCurDb = acDoc.Database;
        
        util Util = new util();

        public Window1()
        {
            InitializeComponent();
            //rec1_state = true;
            groupbox_rec2.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec3.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec4.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec5.Visibility = System.Windows.Visibility.Hidden;
            
        }

        private void show_window()
        {
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            // Draws a circle and zooms to the extents or
            // limits of the drawing
            acDoc.SendStringToExecute("._showWindowForm ", true, false, false);
            
        }

        

        public double cal_distance(int p1x,int p1y,int p2x,int p2y)
        {
            double d = Math.Sqrt((p1x - p2x) * (p1x - p2x) + (p1y - p2y) * (p1y - p2y));
            return d;
        }

        public bool point_validate(List<int[]> list, int[] point,int original_x,int width,int height)
        {
            int count = 0;
            bool state = false;
            double distance;
            int px = point[0];
            int py = point[1];
            //Debug.WriteLine(list.Count);
            for (int i = 0; i < list.Count; i++) 
            {
                int[]  p2 = (int[])list[i];
                distance = cal_distance(px, py, p2[0], p2[1]);
                if (distance < (point[2]+Convert.ToDouble(p2[2])))
                    count++;                
                if ((px - point[2] - original_x) <0)              
                    count++;             
                if (py - point[2] < 0)               
                    count++;              
                if ((px + point[2] - width) > 0)
                    count++;
                if ((py + point[2] - height) > 0)
                    count++;
            }
            if (count == 0)
            {
                state = true;
            }
            return state;
        }

        public void pointRec1_list()
        {
            
            if (rec1_circle1.IsChecked == true)
            {
                int[] circle1_type1 = new int[2];
                circle1_type1[0] = 0;
                int n = int.Parse(textbox_rec1_circle1.Text);
                circle1_type1[1] = n;
                rec1_list.Add(circle1_type1);
            }
            
            if (rec1_circle2.IsChecked == true)
            {
                int[] circle2_type1 = new int[2];
                circle2_type1[0] = 1;
                int n = int.Parse(textbox_rec1_circle2.Text);
                circle2_type1[1] = n;
                rec1_list.Add(circle2_type1);
            }
            if (rec1_circle3.IsChecked == true)
            {
                int[] circle3_type1 = new int[2];
                circle3_type1[0] = 2;
                int n = int.Parse(textbox_rec1_circle3.Text);
                circle3_type1[1] = n;
                rec1_list.Add(circle3_type1);
            }
            if (rec1_circle4.IsChecked == true)
            {
                int[] circle4_type1 = new int[2];
                circle4_type1[0] = 3;
                int n = int.Parse(textbox_rec1_circle4.Text);
                circle4_type1[1] = n;
                rec1_list.Add(circle4_type1);
            }
            if (rec1_circle5.IsChecked == true)
            {
                int[] circle5_type1 = new int[2];
                circle5_type1[0] = 4;
                int n = int.Parse(textbox_rec1_circle5.Text);
                circle5_type1[1] = n;
                rec1_list.Add(circle5_type1);
            }
            if (rec1_circle6.IsChecked == true)
            {
                int[] circle6_type1 = new int[2];
                circle6_type1[0] = 5;
                int n = int.Parse(textbox_rec1_circle6.Text);
                circle6_type1[1] = n;
                rec1_list.Add(circle6_type1);
            }
            if (rec1_circle7.IsChecked == true)
            {
                int[] circle7_type1 = new int[2];
                circle7_type1[0] = 6;
                int n = int.Parse(textbox_rec1_circle7.Text);
                circle7_type1[1] = n;
                rec1_list.Add(circle7_type1);
            }
        }
        public void pointRec2_list()
        {

          
            if (rec2_circle1.IsChecked == true)
            {
                int[] circle1_type2 = new int[2];
                circle1_type2[0] = 0;
                int n = int.Parse(textbox_rec2_circle1.Text);
                circle1_type2[1] = n;
                rec2_list.Add(circle1_type2);
            }
            if (rec2_circle2.IsChecked == true)
            {
                int[] circle2_type2 = new int[2];
                circle2_type2[0] = 1;
                int n = int.Parse(textbox_rec2_circle2.Text);
                circle2_type2[1] = n;
                rec2_list.Add(circle2_type2);
            }
            if (rec2_circle3.IsChecked == true)
            {
                int[] circle3_type2 = new int[2];
                circle3_type2[0] = 2;
                int n = int.Parse(textbox_rec2_circle3.Text);
                circle3_type2[1] = n;
                rec2_list.Add(circle3_type2);
            }
            if (rec2_circle4.IsChecked == true)
            {
                int[] circle4_type2 = new int[2];
                circle4_type2[0] = 3;
                int n = int.Parse(textbox_rec2_circle4.Text);
                circle4_type2[1] = n;
                rec2_list.Add(circle4_type2);
            }
            if (rec2_circle5.IsChecked == true)
            {
                int[] circle5_type2 = new int[2];
                circle5_type2[0] = 4;
                int n = int.Parse(textbox_rec2_circle5.Text);
                circle5_type2[1] = n;
                rec2_list.Add(circle5_type2);
            }
            if (rec2_circle6.IsChecked == true)
            {
                int[] circle6_type2 = new int[2];
                circle6_type2[0] = 5;
                int n = int.Parse(textbox_rec2_circle6.Text);
                circle6_type2[1] = n;
                rec2_list.Add(circle6_type2);
            }
            if (rec2_circle7.IsChecked == true)
            {
                int[] circle7_type2 = new int[2];
                circle7_type2[0] = 6;
                int n = int.Parse(textbox_rec2_circle7.Text);
                circle7_type2[1] = n;
                rec2_list.Add(circle7_type2);
            }
        }
        public void pointRec3_list()
        {
            

            if (rec3_circle1.IsChecked == true)
            {
                int[] circle1_type3 = new int[2];
                circle1_type3[0] = 0;
                int n = int.Parse(textbox_rec3_circle1.Text);
                circle1_type3[1] = n;
                rec3_list.Add(circle1_type3);
            }
            if (rec3_circle2.IsChecked == true)
            {
                int[] circle2_type3 = new int[2];
                circle2_type3[0] = 1;
                int n = int.Parse(textbox_rec3_circle2.Text);
                circle2_type3[1] = n;
                rec3_list.Add(circle2_type3);
            }
            if (rec3_circle3.IsChecked == true)
            {
                int[] circle3_type3 = new int[2];
                circle3_type3[0] = 2;
                int n = int.Parse(textbox_rec3_circle3.Text);
                circle3_type3[1] = n;
                rec3_list.Add(circle3_type3);
            }
            if (rec3_circle4.IsChecked == true)
            {
                int[] circle4_type3 = new int[2];
                circle4_type3[0] = 3;
                int n = int.Parse(textbox_rec3_circle4.Text);
                circle4_type3[1] = n;
                rec2_list.Add(circle4_type3);
            }
            if (rec3_circle5.IsChecked == true)
            {
                int[] circle5_type3 = new int[2];
                circle5_type3[0] = 4;
                int n = int.Parse(textbox_rec3_circle5.Text);
                circle5_type3[1] = n;
                rec3_list.Add(circle5_type3);
            }
            if (rec3_circle6.IsChecked == true)
            {
                int[] circle6_type3 = new int[2];
                circle6_type3[0] = 5;
                int n = int.Parse(textbox_rec3_circle6.Text);
                circle6_type3[1] = n;
                rec3_list.Add(circle6_type3);
            }
            if (rec3_circle7.IsChecked == true)
            {
                int[] circle7_type3 = new int[2];
                circle7_type3[0] = 6;
                int n = int.Parse(textbox_rec3_circle7.Text);
                circle7_type3[1] = n;
                rec3_list.Add(circle7_type3);
            }
        }
        public void pointRec4_list()
        {
            //int[] circle_type4 = new int[2];

            if (rec4_circle1.IsChecked == true)
            {
                int[] circle1_type4 = new int[2];
                circle1_type4[0] = 0;
                int n = int.Parse(textbox_rec4_circle1.Text);
                circle1_type4[1] = n;
                rec4_list.Add(circle1_type4);
                Debug.WriteLine("checkbox1 true");
            }
            if (rec4_circle2.IsChecked == true)
            {
                int[] circle2_type4 = new int[2];
                circle2_type4[0] = 1;
                int n = int.Parse(textbox_rec4_circle2.Text);
                circle2_type4[1] = n;
                rec4_list.Add(circle2_type4);
                Debug.WriteLine("checkbox2 true");
            }
            if (rec4_circle3.IsChecked == true)
            {
                int[] circle3_type4 = new int[2];
                circle3_type4[0] = 2;
                int n = int.Parse(textbox_rec4_circle3.Text);
                circle3_type4[1] = n;
                rec4_list.Add(circle3_type4);
                Debug.WriteLine("checkbox3 true");
            }
            if (rec4_circle4.IsChecked == true)
            {
                int[] circle4_type4 = new int[2];
                circle4_type4[0] = 3;
                int n = int.Parse(textbox_rec4_circle4.Text);
                circle4_type4[1] = n;
                rec4_list.Add(circle4_type4);
                Debug.WriteLine("checkbox4 true");
            }
            if (rec4_circle5.IsChecked == true)
            {
                int[] circle5_type4 = new int[2];
                circle5_type4[0] = 4;
                int n = int.Parse(textbox_rec4_circle5.Text);
                circle5_type4[1] = n;
                rec4_list.Add(circle5_type4);
                Debug.WriteLine("checkbox5 true");
            }
            if (rec4_circle6.IsChecked == true)
            {
                int[] circle6_type4 = new int[2];
                circle6_type4[0] = 5;
                int n = int.Parse(textbox_rec4_circle6.Text);
                circle6_type4[1] = n;
                rec4_list.Add(circle6_type4);
                Debug.WriteLine("checkbox6 true");
            }
            if (rec4_circle7.IsChecked == true)
            {
                int[] circle7_type4 = new int[2];
                circle7_type4[0] = 6;
                int n = int.Parse(textbox_rec4_circle7.Text);
                circle7_type4[1] = n;
                rec4_list.Add(circle7_type4);
                Debug.WriteLine("checkbox7 true");
            }
            for (int i=0;i<rec4_list.Count;i++)
            {
                Debug.WriteLine(rec4_list[i][0]);
            }
        }
        public void pointRec5_list()
        {
            

            if (rec5_circle1.IsChecked == true)
            {
                int[] circle1_type5 = new int[2];
                circle1_type5[0] = 0;
                int n = int.Parse(textbox_rec5_circle1.Text);
                circle1_type5[1] = n;
                rec5_list.Add(circle1_type5);
            }
            if (rec5_circle2.IsChecked == true)
            {
                int[] circle2_type5 = new int[2];
                circle2_type5[0] = 1;
                int n = int.Parse(textbox_rec5_circle2.Text);
                circle2_type5[1] = n;
                rec5_list.Add(circle2_type5);
            }
            if (rec5_circle3.IsChecked == true)
            {
                int[] circle3_type5 = new int[2];
                circle3_type5[0] = 2;
                int n = int.Parse(textbox_rec5_circle3.Text);
                circle3_type5[1] = n;
                rec5_list.Add(circle3_type5);
            }
            if (rec5_circle4.IsChecked == true)
            {
                int[] circle4_type5 = new int[2];
                circle4_type5[0] = 3;
                int n = int.Parse(textbox_rec5_circle4.Text);
                circle4_type5[1] = n;
                rec5_list.Add(circle4_type5);
            }
            if (rec5_circle5.IsChecked == true)
            {
                int[] circle5_type5 = new int[2];
                circle5_type5[0] = 4;
                int n = int.Parse(textbox_rec5_circle5.Text);
                circle5_type5[1] = n;
                rec5_list.Add(circle5_type5);
            }
            if (rec5_circle6.IsChecked == true)
            {
                int[] circle6_type5 = new int[2];
                circle6_type5[0] = 5;
                int n = int.Parse(textbox_rec5_circle6.Text);
                circle6_type5[1] = n;
                rec5_list.Add(circle6_type5);
            }
            if (rec5_circle7.IsChecked == true)
            {
                int[] circle7_type5 = new int[2];
                circle7_type5[0] = 6;
                int n = int.Parse(textbox_rec5_circle7.Text);
                circle7_type5[1] = n;
                rec5_list.Add(circle7_type5);
            }
        }

        public void draw_circle(int x,int y,int radius,int type)
        {
            

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Block table for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                             OpenMode.ForRead) as BlockTable;

                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                OpenMode.ForWrite) as BlockTableRecord;

                //Autodesk.AutoCAD.Colors.Color acColor = new Autodesk.AutoCAD.Colors.Color();
                //acColor = Autodesk.AutoCAD.Colors.Color.FromColorIndex(ColorMethod.ByAci, Convert.ToInt16(type));

                Circle acCirc = new Circle();
                acCirc.SetDatabaseDefaults();
                acCirc.Center = new Point3d(x, y, 0);
                acCirc.Radius = radius;
                acCirc.ColorIndex = type;

                // Add the new object to the block table record and the transaction
                acBlkTblRec.AppendEntity(acCirc);
                acTrans.AddNewlyCreatedDBObject(acCirc, true);

                // Save the new object to the database
                acTrans.Commit();
            }


        }
        

        public void clear_layer()
        {
            

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Layer table for read
                LayerTable acLyrTbl;
                acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId,
                                             OpenMode.ForRead) as LayerTable;

                string sLayerName = "0";

                if (acLyrTbl.Has(sLayerName) == true)
                {
                    // Check to see if it is safe to erase layer
                    ObjectIdCollection acObjIdColl = new ObjectIdCollection();
                    acObjIdColl.Add(acLyrTbl[sLayerName]);
                    acCurDb.Purge(acObjIdColl);

                    if (acObjIdColl.Count > 0)
                    {
                        LayerTableRecord acLyrTblRec;
                        acLyrTblRec = acTrans.GetObject(acObjIdColl[0],
                                                        OpenMode.ForWrite) as LayerTableRecord;

                        
                            // Erase the unreferenced layer
                            acLyrTblRec.Erase(true);

                            // Save the changes and dispose of the transaction
                            acTrans.Commit();
                        
                       
                    }
                }
            }
        }

        public void draw_rec()
        {
           
            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
               
                // Open the Block table for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                OpenMode.ForRead) as BlockTable;
                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                OpenMode.ForWrite) as BlockTableRecord;
             
                // Create a polyline with two segments (3 points)
                Autodesk.AutoCAD.DatabaseServices.Polyline acPoly1 = new Autodesk.AutoCAD.DatabaseServices.Polyline();
                Autodesk.AutoCAD.DatabaseServices.Polyline acPoly2 = new Autodesk.AutoCAD.DatabaseServices.Polyline();
                Autodesk.AutoCAD.DatabaseServices.Polyline acPoly3 = new Autodesk.AutoCAD.DatabaseServices.Polyline();
                Autodesk.AutoCAD.DatabaseServices.Polyline acPoly4 = new Autodesk.AutoCAD.DatabaseServices.Polyline();
                Autodesk.AutoCAD.DatabaseServices.Polyline acPoly5 = new Autodesk.AutoCAD.DatabaseServices.Polyline();

                // rec1
                acPoly1.SetDatabaseDefaults();
                acPoly1.AddVertexAt(0, new Point2d(0, 0), 0, 0, 0);
                acPoly1.AddVertexAt(1, new Point2d(100, 0), 0, 0, 0);
                acPoly1.AddVertexAt(2, new Point2d(100, 200), 0, 0, 0);
                acPoly1.AddVertexAt(3, new Point2d(0, 200), 0, 0, 0);
                acPoly1.AddVertexAt(4, new Point2d(0, 0), 0, 0, 0);

                // rec2
                acPoly2.SetDatabaseDefaults();
                acPoly2.AddVertexAt(0, new Point2d(200, 0), 0, 0, 0);
                acPoly2.AddVertexAt(1, new Point2d(450, 0), 0, 0, 0);
                acPoly2.AddVertexAt(2, new Point2d(450, 500), 0, 0, 0);
                acPoly2.AddVertexAt(3, new Point2d(200,500 ), 0, 0, 0);
                acPoly2.AddVertexAt(4, new Point2d(200, 0), 0, 0, 0);

                // rec3
                acPoly3.SetDatabaseDefaults();
                acPoly3.AddVertexAt(0, new Point2d(550, 0), 0, 0, 0);
                acPoly3.AddVertexAt(1, new Point2d(700, 0), 0, 0, 0);
                acPoly3.AddVertexAt(2, new Point2d(700, 250), 0, 0, 0);
                acPoly3.AddVertexAt(3, new Point2d(550, 250), 0, 0, 0);
                acPoly3.AddVertexAt(4, new Point2d(550, 0), 0, 0, 0);

                // rec4
                acPoly4.SetDatabaseDefaults();
                acPoly4.AddVertexAt(0, new Point2d(800, 0), 0, 0, 0);
                acPoly4.AddVertexAt(1, new Point2d(1150, 0), 0, 0, 0);
                acPoly4.AddVertexAt(2, new Point2d(1150, 550), 0, 0, 0);
                acPoly4.AddVertexAt(3, new Point2d(800, 550), 0, 0, 0);
                acPoly4.AddVertexAt(4, new Point2d(800, 0), 0, 0, 0);

                // rec5
                acPoly5.SetDatabaseDefaults();
                acPoly5.AddVertexAt(0, new Point2d(1250, 0), 0, 0, 0);
                acPoly5.AddVertexAt(1, new Point2d(1500, 0), 0, 0, 0);
                acPoly5.AddVertexAt(2, new Point2d(1500, 550), 0, 0, 0);
                acPoly5.AddVertexAt(3, new Point2d(1250, 550), 0, 0, 0);
                acPoly5.AddVertexAt(4, new Point2d(1250, 0), 0, 0, 0);


                // Add the new object to the block table record and the transaction
                acBlkTblRec.AppendEntity(acPoly1);
                acBlkTblRec.AppendEntity(acPoly2);
                acBlkTblRec.AppendEntity(acPoly3);
                acBlkTblRec.AppendEntity(acPoly4);
                acBlkTblRec.AppendEntity(acPoly5);
                acTrans.AddNewlyCreatedDBObject(acPoly1, true);
                acTrans.AddNewlyCreatedDBObject(acPoly2, true);
                acTrans.AddNewlyCreatedDBObject(acPoly3, true);
                acTrans.AddNewlyCreatedDBObject(acPoly4, true);
                acTrans.AddNewlyCreatedDBObject(acPoly5, true);
                // Save the new object to the database
                acTrans.Commit();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            

            this.statusText.Text = "Circles are Generating ...";
            draw_rec();
            pointRec1_list();
            pointRec2_list();
            pointRec3_list();
            pointRec4_list();
            pointRec5_list();

            pointRec1_init[0] = 50;
            pointRec1_init[1] = 50;   
            pointRec2_init[0] = 250;
            pointRec2_init[1] = 50;
            pointRec3_init[0] = 600;
            pointRec3_init[1] = 50;
            pointRec4_init[0] = 850;
            pointRec4_init[1] = 50;
            pointRec5_init[0] = 1300;
            pointRec5_init[1] = 50;

            if (rec1_list.Any())
            {
                o1 = (int[])rec1_list[0];
                pointRec1_init[2] = radius_list[o1[0]];
            }
            
            if (rec2_list.Any())
            {
                o2 = (int[])rec2_list[0];
                pointRec2_init[2] = radius_list[o2[0]];
            }
            
            if (rec3_list.Any())
            {
                o3 = (int[])rec3_list[0];
                pointRec3_init[2] = radius_list[o3[0]];
            }
            
            if (rec4_list.Any())
            {
                o4 = (int[])rec4_list[0];
                pointRec4_init[2] = radius_list[o4[0]];
            }
            
            if (rec5_list.Any())
            {
                o5 = (int[])rec5_list[0];
                pointRec5_init[2] = radius_list[o5[0]];
            }
            

            rec1_pointlist.Add(pointRec1_init);
            rec2_pointlist.Add(pointRec2_init);
            rec3_pointlist.Add(pointRec3_init);
            rec4_pointlist.Add(pointRec4_init);
            rec5_pointlist.Add(pointRec5_init);
            
            if (rec1_list.Any())
                draw_circle(pointRec1_init[0], pointRec1_init[1], pointRec1_init[2], o1[0]);
            if (rec2_list.Any())
                draw_circle(pointRec2_init[0], pointRec2_init[1], pointRec2_init[2], o2[0]);
            if (rec3_list.Any())
                draw_circle(pointRec3_init[0], pointRec3_init[1], pointRec3_init[2], o3[0]);
            if (rec4_list.Any())
                draw_circle(pointRec4_init[0], pointRec4_init[1], pointRec4_init[2], o4[0]);
            if (rec5_list.Any())
                draw_circle(pointRec5_init[0], pointRec5_init[1], pointRec5_init[2], o5[0]);
       

                // draw rec1
                for (int j = 0; j < rec1_list.Count; j++)
            {
                //Debug.WriteLine(rec4_list[j][0]);
                //Debug.WriteLine(rec4_list[j][1]);
                for (int k = 0; k < rec1_list[j][1]; k++)
                {
                    int c = 0;
                    bool s = false;
                    int[] point = new int[3];
                    while (!s)
                    {
                        point[0] = rnd.Next(15, 85);
                        point[1] = rnd.Next(15, 185);
                        point[2] = radius_list[rec1_list[j][0]];
                        Debug.WriteLine(point[2]);
                        if (point_validate(rec1_pointlist, point, 0,100,200) == true)
                        {
                            rec1_pointlist.Add(point);
                            //Debug.WriteLine(point[2]);
                            draw_circle(point[0], point[1], point[2], rec1_list[j][0]);
                            s = true;
                            break;
                        }
                        c++;
                        if (c > 1000)
                        {
                            Debug.WriteLine("fail to find proper circle");
                            break;
                        }


                    }
                    Debug.WriteLine("done");
                }

            }

            // draw rec2
            for (int j = 0; j < rec2_list.Count; j++)
            {
                //Debug.WriteLine(rec4_list[j][0]);
                //Debug.WriteLine(rec4_list[j][1]);
                for (int k = 0; k < rec2_list[j][1]; k++)
                {
                    int c = 0;
                    bool s = false;
                    int[] point = new int[3];
                    while (!s)
                    {
                        point[0] = rnd.Next(215, 435);
                        point[1] = rnd.Next(15, 285);
                        point[2] = radius_list[rec2_list[j][0]];
                        Debug.WriteLine(point[2]);
                        if (point_validate(rec2_pointlist, point, 200,450,300) == true)
                        {
                            rec2_pointlist.Add(point);
                            //Debug.WriteLine(point[2]);
                            draw_circle(point[0], point[1], point[2], rec2_list[j][0]);
                            s = true;
                            break;
                        }
                        c++;
                        if (c > 1000)
                        {
                            Debug.WriteLine("fail to find proper circle");
                            break;
                        }


                    }
                    Debug.WriteLine("done");
                }

            }

            // draw rec3
            for (int j = 0; j < rec3_list.Count; j++)
            {
                //Debug.WriteLine(rec4_list[j][0]);
                //Debug.WriteLine(rec4_list[j][1]);
                for (int k = 0; k < rec3_list[j][1]; k++)
                {
                    int c = 0;
                    bool s = false;
                    int[] point = new int[3];
                    while (!s)
                    {
                        point[0] = rnd.Next(565, 685);
                        point[1] = rnd.Next(15, 235);
                        point[2] = radius_list[rec3_list[j][0]];
                        Debug.WriteLine(point[2]);
                        if (point_validate(rec3_pointlist, point, 550,700,250) == true)
                        {
                            rec3_pointlist.Add(point);
                            //Debug.WriteLine(point[2]);
                            draw_circle(point[0], point[1], point[2], rec3_list[j][0]);
                            s = true;
                            break;
                        }
                        c++;
                        if (c > 1000)
                        {
                            Debug.WriteLine("fail to find proper circle");
                            break;
                        }


                    }
                    Debug.WriteLine("done");
                }

            }
            // draw rec4
            for (int j=0;j<rec4_list.Count;j++)
            {
                //Debug.WriteLine(rec4_list[j][0]);
                //Debug.WriteLine(rec4_list[j][1]);
                for (int k=0;k<rec4_list[j][1];k++)
                {
                    int c = 0;
                    bool s = false;
                    int[] point = new int[3];
                    while (!s)
                    {
                        point[0] = rnd.Next(815, 1135);
                        point[1] = rnd.Next(15, 535);
                        point[2] = radius_list[rec4_list[j][0]];
                        Debug.WriteLine(point[2]);
                        if (point_validate(rec4_pointlist, point,800,1150,550) == true)
                        {
                            rec4_pointlist.Add(point);
                            //Debug.WriteLine(point[2]);
                            draw_circle(point[0], point[1], point[2], rec4_list[j][0]);
                            s = true;
                            break;
                        }
                        c++;
                        if (c > 1000)
                        {
                            Debug.WriteLine("fail to find proper circle");
                            break;
                        }
                            
                        
                    }
                    Debug.WriteLine("done");
                }
                
            }
            // draw rec5
            for (int j = 0; j < rec5_list.Count; j++)
            {
                //Debug.WriteLine(rec4_list[j][0]);
                //Debug.WriteLine(rec4_list[j][1]);
                for (int k = 0; k < rec5_list[j][1]; k++)
                {
                    int c = 0;
                    bool s = false;
                    int[] point = new int[3];
                    while (!s)
                    {
                        point[0] = rnd.Next(1265, 1485);
                        point[1] = rnd.Next(15, 535);
                        point[2] = radius_list[rec5_list[j][0]];
                        Debug.WriteLine(point[2]);
                        if (point_validate(rec5_pointlist, point, 1250,1500,550) == true)
                        {
                            rec5_pointlist.Add(point);
                            //Debug.WriteLine(point[2]);
                            draw_circle(point[0], point[1], point[2], rec5_list[j][0]);
                            s = true;
                            break;
                        }
                        c++;
                        if (c > 1000)
                        {
                            Debug.WriteLine("fail to find proper circle");
                            break;
                        }


                    }
                    Debug.WriteLine("done");
                }

            }

            DialogResult = true;
            //show_window();

        }

        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.statusText.MaxLines = 3;
            //draw_rec();
            string text1 = Util.openExcel(1,0); //read row 1 col 0
            text1 = text1 + "\r\n";
            this.statusText.AppendText(text1);

            string text2 = Util.openExcel(1, 1); //read row 1 col 1
            text2 = "WIDTH: " + text2 + "\r\n";
            this.statusText.AppendText(text2);

            string text3 = Util.openExcel(1, 2); //read row 1 col 2
            text3 = "HEIGHT: " + text3 + "\r\n";
            this.statusText.AppendText(text3);
            //DialogResult = true;
            //show_window();
        }

        private void circle1_Checked(object sender, RoutedEventArgs e)
        {
            bool state = true;
        }

        private void circle2_Checked(object sender, RoutedEventArgs e)
        {
            bool state = true;
        }

        private void circle3_Checked(object sender, RoutedEventArgs e)
        {
            bool state = true;
        }

        private void circle4_Checked(object sender, RoutedEventArgs e)
        {
            bool state = true;
        }

        private void circle5_Checked(object sender, RoutedEventArgs e)
        {
            bool state = true;
        }

        private void circle6_Checked(object sender, RoutedEventArgs e)
        {
            bool state = true;
        }

        private void circle7_Checked(object sender, RoutedEventArgs e)
        {
            bool state = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rec1_Click(object sender, RoutedEventArgs e)
        {
            //rec1_state = true;
            groupbox_rec2.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec3.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec4.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec5.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec1.Visibility = System.Windows.Visibility.Visible;
        }

        private void rec2_Click(object sender, RoutedEventArgs e)
        {
            //rec2_state = true;
            groupbox_rec1.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec3.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec4.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec5.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec2.Visibility = System.Windows.Visibility.Visible;
        }

        private void rec3_Click(object sender, RoutedEventArgs e)
        {
            //rec3_state = true;
            groupbox_rec1.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec2.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec4.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec5.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec3.Visibility = System.Windows.Visibility.Visible;
        }

        private void rec4_Click(object sender, RoutedEventArgs e)
        {
            //rec4_state = true;
            groupbox_rec1.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec2.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec3.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec5.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec4.Visibility = System.Windows.Visibility.Visible;
        }

        private void rec5_Click(object sender, RoutedEventArgs e)
        {
            //rec5_state = true;
            groupbox_rec1.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec2.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec3.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec4.Visibility = System.Windows.Visibility.Hidden;
            groupbox_rec5.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            clear_layer();
        }
    }
}
