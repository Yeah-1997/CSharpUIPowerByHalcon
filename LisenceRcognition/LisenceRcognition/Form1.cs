using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.Threading;

namespace LisenceRcognition
{
    public partial class Form1 : Form
    {
        /*===================声明变量=========================*/
        // Stack for temporary objects 
        HObject[] OTemp = new HObject[20];
        HObject ho_Image = null, ho_psf = null, ho_noisefiltered = null;
        HObject ho_RestoredImage = null, ho_RestoredImage1 = null, ho_R = null;
        HObject ho_G = null, ho_B = null, ho_GrayImage1 = null, ho_H = null;
        HObject ho_S = null, ho_V = null, ho_MultiChannelImage = null;
        HObject ho_Regions = null, ho_ConnectedRegions = null, ho_SelectedRegions = null;
        HObject ho_RegionFillUp = null, ho_RegionTrans = null, ho_ImageReduced = null;
        HObject ho_ImagePart = null, ho_GrayImage = null, ho_Regions2 = null;
        HObject ho_RegionDilation = null, ho_ConnectedRegions2 = null;

        HObject ho_RegionIntersection = null, ho_SelectedRegions1 = null, ho_showroi = null;

       

        HObject ho_SortedRegions = null;


        // Local control variables 

        HTuple hv_OCRHandle = null, hv_fileadd = null;
        HTuple hv_WindowHandle = null, hv_WindowHandle1 = null, hv_WindowHandle2 = null;
        HTuple hv_ImageFiles = null, hv_imgIndex = null, hv_Width1 = new HTuple();
        HTuple hv_Height1 = new HTuple(), hv_Class = new HTuple();
        HTuple hv_Confidence = new HTuple(), hv_i = new HTuple();

        /*===================声明处理多张图片的线程=========================*/
        Thread procethread;

        bool picload_flag = false;

        bool mulpicProOn_flag = false;//处理多张图片的标志，此时不能打开选择图片按钮

        string result="";

        //Thread ProMulPicThread = new Thread(ProMulPic);

        /*=======================定义变量=================================*/
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            procethread = new Thread(new ThreadStart(ProMulPic));
            procethread.Name = "picProThread";
            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_showroi);
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_psf);
            HOperatorSet.GenEmptyObj(out ho_noisefiltered);
            HOperatorSet.GenEmptyObj(out ho_RestoredImage);
            HOperatorSet.GenEmptyObj(out ho_RestoredImage1);
            HOperatorSet.GenEmptyObj(out ho_R);
            HOperatorSet.GenEmptyObj(out ho_G);
            HOperatorSet.GenEmptyObj(out ho_B);
            HOperatorSet.GenEmptyObj(out ho_GrayImage1);
            HOperatorSet.GenEmptyObj(out ho_H);
            HOperatorSet.GenEmptyObj(out ho_S);
            HOperatorSet.GenEmptyObj(out ho_V);
            HOperatorSet.GenEmptyObj(out ho_MultiChannelImage);
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_RegionFillUp);
            HOperatorSet.GenEmptyObj(out ho_RegionTrans);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_ImagePart);
            HOperatorSet.GenEmptyObj(out ho_GrayImage);
            HOperatorSet.GenEmptyObj(out ho_Regions2);
            HOperatorSet.GenEmptyObj(out ho_RegionDilation);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions2);
            HOperatorSet.GenEmptyObj(out ho_RegionIntersection);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions1);
            HOperatorSet.GenEmptyObj(out ho_SortedRegions);
            dev_update_off();
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.CloseWindow(HDevWindowStack.Pop());
                HOperatorSet.CloseWindow(HDevWindowStack.Pop());

            }
            //使用变形后的数据训练的网络
            //read_ocr_class_mlp ('ocrmlp_change.omc', OCRHandle)
            //使用没变形的数据训练的网络
            hv_fileadd = "F:/毕设用/AA毕设/halcon模糊矿车图片/";
            /****************************最右边窗口**************************/
            HOperatorSet.SetWindowAttr("background_color", "black");
            HOperatorSet.OpenWindow(0, 0, hWindowControl1.Width, hWindowControl1.Height, hWindowControl1.HalconWindow, "", "", out hv_WindowHandle);
            HDevWindowStack.Push(hv_WindowHandle);
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "margin");
            }
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
            }
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(),2);
            }
            set_display_font(hv_WindowHandle, 15, "mono", "true", "false");


            /****************************最左边窗口**************************/
            HOperatorSet.SetWindowAttr("background_color", "black");

            HOperatorSet.OpenWindow(0, 0, hWindowControl2.Width, hWindowControl2.Height, hWindowControl2.HalconWindow, "", "", out hv_WindowHandle1);
            HDevWindowStack.Push(hv_WindowHandle1);
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "margin");
            }

            /***************************中间窗口**************************/
            HOperatorSet.SetWindowAttr("background_color", "black");
            HOperatorSet.OpenWindow(0, 0, hWindowControl3.Width, hWindowControl3.Height, hWindowControl3.HalconWindow, "", "", out hv_WindowHandle2);
            HDevWindowStack.Push(hv_WindowHandle2);
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "margin");
            }
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
            }
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 2);
            }

            HOperatorSet.ReadOcrClassMlp("ocrmlp.omc", out hv_OCRHandle);
        }
        public Form1()
        {
            InitializeComponent();
        }

        /*===================打开图片按钮的操作=========================*/
        private void openPic_button_Click(object sender, EventArgs e)
        {
            if(mulpicProOn_flag == false)
            {
                string image_path;
                UInt16 i;
                single.Checked = true;
                ho_Image.Dispose();
                openFileDialog1.Filter = "BMP文件|*.bmp*|JPEG文件|*.jpg*";
                openFileDialog1.RestoreDirectory = true;
                //打开图片
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    image_path = openFileDialog1.FileName;
                    HOperatorSet.ReadImage(out ho_Image, image_path);
                    HDevWindowStack.SetActive(hv_WindowHandle1);
                    for (i = 0; i < 2; i++)
                    {
                        if (HDevWindowStack.IsOpen())
                        {
                            HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());

                        }
                        if (HDevWindowStack.IsOpen())
                        {
                            HOperatorSet.SetPart(HDevWindowStack.GetActive(), 0, 0, 527, 1071);
                        }
                    }
                    picload_flag = true;

                }
            }


        }

        /*===================处理多图片的线程绑定的函数=========================*/
        private void ProMulPic()
        {
            UInt16 count = 0;
            HOperatorSet.ListFiles("F:/毕设用/AA毕设/halcon模糊矿车图片", (new HTuple("files")).TupleConcat(
            "follow_links"), out hv_ImageFiles);
            HOperatorSet.TupleRegexpSelect(hv_ImageFiles, (new HTuple("\\.(tif|tiff|gif|bmp|jpg|jpeg|jp2|png|pcx|pgm|ppm|pbm|xwd|ima)$")).TupleConcat(
                "ignore_case"), out hv_ImageFiles);

            for (hv_imgIndex = 0; (int)hv_imgIndex <= (int)((new HTuple(hv_ImageFiles.TupleLength()
                )) - 1); hv_imgIndex = (int)hv_imgIndex + 1)
            {
                ho_Image.Dispose();
                HOperatorSet.ReadImage(out ho_Image, hv_ImageFiles.TupleSelect(hv_imgIndex));

                //识别处理车牌
                ImagePro(ho_Image, count);
                count++;
            }
            mulpicProOn_flag = false;
        }

        /*===================识别按钮的执行段=========================*/
        private void recognize_button_Click(object sender, EventArgs e)
        {

            try
            {
                if (multiples.Checked == true)
                {
                    if (procethread.ThreadState == ThreadState.Unstarted )
                    {
                        /*Thread procethread = new Thread(new ThreadStart(ProMulPic));
                        procethread.Name = "picProThread"*/
                        procethread.Start();
                        mulpicProOn_flag = true;
                    }
                    else if(procethread.ThreadState == ThreadState.Running)
                    {
                        MessageBox.Show("请等待当前处理完毕", "提示", MessageBoxButtons.OK);
                    }
                    else if(procethread.ThreadState == ThreadState.Stopped)
                    {
                        Thread procethread = new Thread(new ThreadStart(ProMulPic));
                        procethread.Name = "picProThread";
                        procethread.Start();
                        mulpicProOn_flag = true;
                    }

                }

                else if (single.Checked == true)
                {
                    if (picload_flag)
                    {
                        ImagePro(ho_Image, 0);
                        picload_flag = false;
                    }
                    else
                    {
                        MessageBox.Show("请先选择图片","提示",MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("请先选择模式", "提示", MessageBoxButtons.OK);
                }

                
                //HOperatorSet.ClearOcrClassMlp(hv_OCRHandle);

            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Image.Dispose();
                ho_psf.Dispose();
                ho_noisefiltered.Dispose();
                ho_RestoredImage.Dispose();
                ho_RestoredImage1.Dispose();
                ho_R.Dispose();
                ho_G.Dispose();
                ho_B.Dispose();
                ho_GrayImage1.Dispose();
                ho_H.Dispose();
                ho_S.Dispose();
                ho_V.Dispose();
                ho_MultiChannelImage.Dispose();
                ho_Regions.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions.Dispose();
                ho_RegionFillUp.Dispose();
                ho_RegionTrans.Dispose();
                ho_ImageReduced.Dispose();
                ho_ImagePart.Dispose();
                ho_GrayImage.Dispose();
                ho_Regions2.Dispose();
                ho_RegionDilation.Dispose();
                ho_ConnectedRegions2.Dispose();
                ho_RegionIntersection.Dispose();
                ho_SelectedRegions1.Dispose();
                ho_SortedRegions.Dispose();

                throw HDevExpDefaultException;
            }
            ho_Image.Dispose();
            ho_psf.Dispose();
            ho_noisefiltered.Dispose();
            ho_RestoredImage.Dispose();
            ho_RestoredImage1.Dispose();
            ho_R.Dispose();
            ho_G.Dispose();
            ho_B.Dispose();
            ho_GrayImage1.Dispose();
            ho_H.Dispose();
            ho_S.Dispose();
            ho_V.Dispose();
            ho_MultiChannelImage.Dispose();
            ho_Regions.Dispose();
            ho_ConnectedRegions.Dispose();
            ho_SelectedRegions.Dispose();
            ho_RegionFillUp.Dispose();
            ho_RegionTrans.Dispose();
            ho_ImageReduced.Dispose();
            ho_ImagePart.Dispose();
            ho_GrayImage.Dispose();
            ho_Regions2.Dispose();
            ho_RegionDilation.Dispose();
            ho_ConnectedRegions2.Dispose();
            ho_RegionIntersection.Dispose();
            ho_SelectedRegions1.Dispose();
            ho_SortedRegions.Dispose();
        }


        /*===================图片处理的主程序段=========================*/
        private void ImagePro(HObject Image,UInt16 count)
        {
            
            UInt16 i;
            UInt16 cishu;

            if (count == 0)
            {
                cishu = 2;
            }
            else
            {
                cishu = 1;
            }


            while (!this.state.IsHandleCreated)
            {
                //解决窗体关闭时出现“访问已释放句柄“的异常
                if (this.state.Disposing || this.state.IsDisposed)
                    return;
            }
            this.Invoke(new Action(() =>
            { 
                state.Text = "识别中...";
            }));

            HOperatorSet.GetImageSize(Image, out hv_Width1, out hv_Height1);
            ho_psf.Dispose();
            HOperatorSet.GenPsfMotion(out ho_psf, hv_Width1, hv_Height1, 40, 0, 3);
            ho_noisefiltered.Dispose();
            HOperatorSet.MedianImage(ho_Image, out ho_noisefiltered, "circle", 1, 0);
            ho_RestoredImage.Dispose();
            HOperatorSet.WienerFilter(ho_Image, ho_psf, ho_noisefiltered, out ho_RestoredImage
                );
            ho_RestoredImage1.Dispose();
            HOperatorSet.MedianImage(ho_RestoredImage, out ho_RestoredImage1, "circle",
                1, 0);

            //RGB转换HSV
            ho_R.Dispose(); ho_G.Dispose(); ho_B.Dispose();
            HOperatorSet.Decompose3(ho_RestoredImage1, out ho_R, out ho_G, out ho_B);
            ho_GrayImage1.Dispose();
            HOperatorSet.Rgb1ToGray(ho_RestoredImage1, out ho_GrayImage1);
            ho_H.Dispose(); ho_S.Dispose(); ho_V.Dispose();
            HOperatorSet.TransFromRgb(ho_R, ho_G, ho_B, out ho_H, out ho_S, out ho_V,
                "hsv");
            ho_MultiChannelImage.Dispose();
            HOperatorSet.Compose3(ho_H, ho_S, ho_V, out ho_MultiChannelImage);
            //获取车牌区域
            ho_Regions.Dispose();
            HOperatorSet.Threshold(ho_V, out ho_Regions, 109, 295);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_Regions, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, (new HTuple("area")).TupleConcat(
                "rectangularity"), "and", (new HTuple(0)).TupleConcat(0.88165), (new HTuple(75688.1)).TupleConcat(
                1));
            ho_RegionFillUp.Dispose();
            HOperatorSet.FillUp(ho_SelectedRegions, out ho_RegionFillUp);
            ho_RegionTrans.Dispose();
            HOperatorSet.ShapeTrans(ho_RegionFillUp, out ho_RegionTrans, "rectangle2");
            ho_ImageReduced.Dispose();
            HOperatorSet.ReduceDomain(ho_RestoredImage, ho_RegionTrans, out ho_ImageReduced
                );
            ho_ImagePart.Dispose();
            HOperatorSet.CropDomain(ho_ImageReduced, out ho_ImagePart);

            //分割车牌字体
            ho_GrayImage.Dispose();
            HOperatorSet.Rgb1ToGray(ho_ImagePart, out ho_GrayImage);
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.ConvertImageType(ho_GrayImage, out ExpTmpOutVar_0, "byte");
                ho_GrayImage.Dispose();
                ho_GrayImage = ExpTmpOutVar_0;
            }
            //138,255
            ho_Regions2.Dispose();
            HOperatorSet.Threshold(ho_GrayImage, out ho_Regions2, 138, 255);
            //count_seconds (t1)
            //mlp识别
            ho_RegionDilation.Dispose();
            HOperatorSet.DilationRectangle1(ho_Regions2, out ho_RegionDilation, 4, 10);
            ho_ConnectedRegions2.Dispose();
            HOperatorSet.Connection(ho_RegionDilation, out ho_ConnectedRegions2);
            ho_RegionIntersection.Dispose();
            HOperatorSet.Intersection(ho_ConnectedRegions2, ho_Regions2, out ho_RegionIntersection
                );
            ho_SelectedRegions1.Dispose();
            HOperatorSet.SelectShape(ho_RegionIntersection, out ho_SelectedRegions1,
                "area", "and", 92.66, 1000);



            ho_SortedRegions.Dispose();
            HOperatorSet.SortRegion(ho_SelectedRegions1, out ho_SortedRegions, "first_point",
                "true", "column");

            ho_showroi.Dispose();
            HOperatorSet.ShapeTrans(ho_SortedRegions, out ho_showroi, "rectangle1");

            HOperatorSet.DoOcrMultiClassMlp(ho_SortedRegions, ho_GrayImage, hv_OCRHandle,
                out hv_Class, out hv_Confidence);
            //count_seconds (t2)

            /*===========================清理窗口==========================*/
            HDevWindowStack.SetActive(hv_WindowHandle1);
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.ClearWindow(HDevWindowStack.GetActive());
            }
            HDevWindowStack.SetActive(hv_WindowHandle);
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.ClearWindow(HDevWindowStack.GetActive());
            }
            HDevWindowStack.SetActive(hv_WindowHandle2);
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.ClearWindow(HDevWindowStack.GetActive());
            }

            /*===========================右窗口显示==========================*/
            HDevWindowStack.SetActive(hv_WindowHandle);
            HOperatorSet.GetImageSize(ho_GrayImage, out hv_Width1, out hv_Height1);

            for (i = 0; i < cishu; i++)
            {
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_RestoredImage, HDevWindowStack.GetActive());
                }
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_RegionTrans, HDevWindowStack.GetActive());
                }
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.SetPart(HDevWindowStack.GetActive(), 0, 0, 527, 1071);
                }
                /*if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_RegionTrans, HDevWindowStack.GetActive());
                }*/
            }
            /*===========================中间窗口显示==========================*/
            HDevWindowStack.SetActive(hv_WindowHandle2);
            HOperatorSet.GetImageSize(ho_GrayImage, out hv_Width1, out hv_Height1);

            for (i = 0; i < cishu; i++)
            {
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_ImagePart, HDevWindowStack.GetActive());
                }
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_showroi, HDevWindowStack.GetActive());
                }
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.SetPart(HDevWindowStack.GetActive(), 0, 0, hv_Height1, hv_Width1);
                }
                /*if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_RegionTrans, HDevWindowStack.GetActive());
                }*/
            }






            /*===========================左窗口显示==========================*/
            HDevWindowStack.SetActive(hv_WindowHandle1);//左边窗口

            for (i = 0; i < cishu; i++)
            {
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
                }
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.SetPart(HDevWindowStack.GetActive(), 0, 0, 527, 1071);
                }
            }

            /*===========================右窗口显示信息==========================*/
            disp_message(hv_WindowHandle, "车牌号：", "window", 20, 20, "red", "false");
            for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Class.TupleLength())) - 1); hv_i = (int)hv_i + 1)
            {
                disp_message(hv_WindowHandle, hv_Class.TupleSelect(hv_i), "window", 20,
                    120 + (15 * hv_i), "red", "false");
            }
            result = "";
            for (i = 2; i < 23; i += 5)
            {
                result += hv_Class.ToString().ToCharArray()[i].ToString();
            }
            //result = hv_Class.ToString();
            while (!this.state.IsHandleCreated)
            {
                //解决窗体关闭时出现“访问已释放句柄“的异常
                if (this.state.Disposing || this.state.IsDisposed)
                    return;
            }

            this.Invoke(new Action(() =>
            {
                //var list = (result.ToList<char>())[0];
                state.Text = result; 
            }));


            if (multiples.Checked == true)
            {
                if (Thread.CurrentThread.Name== "picProThread")
                 Thread.Sleep(1000);
            }
            

            //disp_message (WindowHandle, t2-t1, 'window', 20, 260+40*5, 'red', 'false')
            //stop ()
        }
        
        
        
        /***********************退出按钮*******************************/
        private void exit_button_Click(object sender, EventArgs e)
        {
            bool close = false;
            if (MessageBox.Show("您确定要关闭软件吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                close = true;
            }
            if (close)
            {
                this.Dispose();
                System.Environment.Exit(0);
            }
            

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("您确定要关闭软件吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                //e.Cancel = false
                this.Dispose();
                System.Environment.Exit(0);
                
               
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time_label.Text = DateTime.Now.ToShortDateString().ToString()+"\n\n"+ DateTime.Now.ToLongTimeString().ToString();   // 20:16:16;
        }
    }
}
