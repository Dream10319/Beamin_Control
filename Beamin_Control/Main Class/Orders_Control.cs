using Beamin_Control.Controls;
using Beamin_Control.JSON_Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.Main_Class
{
    public static class Orders_Control
    {
        public const int Checker_New_Order_Timer = 60;
        public static Form1 Main_Frm;
        private static Thread Check_New_Orders_TH;

        #region Orders Load

        public static void Check_New_Orders()
        {
            Check_New_Orders_TH = new Thread(new ThreadStart(() =>
            {
#if Test_With_Proxy 

                if (Helper_Class.Is_IP_OK(false) == false)
                {
                    Main_Frm.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Not Same IP");

                        Main_Frm.timer1.Enabled = false;
                    }));
                    //th.Abort();
                    Check_New_Orders_TH.Abort();
                    return;
                }

#endif



                Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v3/ord/alerts/{Properties.Settings.Default.Owner_No}/{Properties.Settings.Default.deviceToken}", Method.GET, null, null, Main_Frm.Special_Headers));
                tx.Wait();

                if (!string.IsNullOrEmpty(tx.Result.Content))
                {

                    Order_Check rs = JsonConvert.DeserializeObject<Order_Check>(tx.Result.Content, Main_Frm.Serializer_Settings);

                    if (Main_Frm.IsDisposed == true)
                    {
                        return;
                    }

                    if (rs.rspCode == "200" || rs.rspCode == "300")
                    {
                        Main_Frm.Checker_New_Order_Timer_current = Checker_New_Order_Timer;

                        Main_Frm.Invoke(new Action(() =>
                        {
                            Main_Frm.timer1.Enabled = true;

                        }));
                    }

                    switch (rs.rspCode)
                    {
                        case "200":
                            if (rs.data != null && rs.data.Count > 0)
                            {
                                List<string> Orders_To_load = new List<string>();
                                foreach (Order_Check_Datum o in rs.data)
                                {
                                    if (!Orders_To_load.Contains(o.orderNo)) // update 2024
                                    {
                                        Orders_To_load.Add(o.orderNo);

                                    }

                                }


                                Load_Orders_Details(Orders_To_load, rs.data);
                                //foreach (Order_Check_Datum o in rs.data)
                                //{
                                //   var ff = Main_Frm.New_Orders.Controls.Cast<Button>().Where(ss => ss.Name == o.orderNo).FirstOrDefault ();
                                //   var ff2 = Main_Frm.In_Progress_Orders.Controls.Cast<Button>().Where(ss => ss.Name == o.orderNo).FirstOrDefault ();

                                //    if (ff !=null)
                                //    {
                                //        ff.Tag = new Order_Status()
                                //        {
                                //            orderProgress = o.orderProgress,
                                //            orderStatus = o.orderStatus,
                                //            riderStatus = o.riderStatus,
                                //            date = o.date
                                //        };
                                //    }

                                //    if (ff2 != null)
                                //    {
                                //        ff2.Tag = new Order_Status()
                                //        {
                                //            orderProgress = o.orderProgress,
                                //            orderStatus = o.orderStatus,
                                //            riderStatus = o.riderStatus,
                                //            date = o.date
                                //        };
                                //    }
                                //}

                                //if (Order_Check != null)
                                //{
                                //    Order_Check_Datum cf = Order_Check.Where(ss => ss.orderNo == Od.orderNo).FirstOrDefault();
                                //    if (cf != null)
                                //    {
                                //        Order_Button.Tag = new Order_Status()
                                //        {
                                //            orderProgress = cf.orderProgress,
                                //            orderStatus = cf.orderStatus,
                                //            riderStatus = cf.riderStatus,
                                //            date = cf.date
                                //        };
                                //    }
                                //}

                            }
                            break;

                        case "403":
                            Main_Frm.Invoke(new Action(() =>
                            {
                                Main_Frm.timer1.Enabled = false;
                                MessageBox.Show(Main_Frm, rs.rspMsg, Program.Language.De[1000], MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }));


                            break;

                    }


                }
            }));

            Check_New_Orders_TH.Start();

        }


        public static void Load_Orders_Details(List<string> Orders_To_Load = null, List<Order_Check_Datum> Order_Check = null)
        {
            Task<IRestResponse> tx;
            if (Orders_To_Load != null)
            {// If Orders_To_Load Not Null Load Selected Order
                string Orders_URL = "";

                foreach (string r in Orders_To_Load)
                {
                    if (Orders_URL == "")
                    {
                        Orders_URL = $"orderNos={r}";
                    }
                    else
                    {
                        Orders_URL += $"&orderNos={r}";

                    }
                }


                tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v7/orders?{Orders_URL}", Method.GET, null, null, Main_Frm.Special_Headers));
            }
            else
            {// If Orders_To_Load  Null Load  All Orders
                tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v8/orders/merchant/{Properties.Settings.Default.Owner_No}", Method.GET, null, null, Main_Frm.Special_Headers));

            }

            tx.Wait();




            if (!string.IsNullOrEmpty(tx.Result.Content))
            {
                Ordders_Details_Response rs = JsonConvert.DeserializeObject<Ordders_Details_Response>(tx.Result.Content, Main_Frm.Serializer_Settings);

                Main_Frm.Invoke(new Action(() =>
                {
                    if (rs.rspCode == "200")
                    {


                        foreach (Ordders_Details_Datum Od in rs.data)
                        {
                            Order_Check_Datum Order_Last_Check = null;

                            if (Order_Check != null)
                            {
                                Order_Last_Check = Order_Check.Where(r => r.orderNo == Od.orderNo).FirstOrDefault();
                            }

                            Order_Button Order_Button = new Order_Button()
                            {
                                FlatStyle = FlatStyle.Flat,
                                BackColor = Color.LightSteelBlue,
                                Text = Od.orderNo,
                                Name = Od.orderNo,
                                Cursor = Cursors.Hand
                            };

                            Order_Button.Order_Details = Od;
                            Order_Button.Last_Check_Data = Order_Last_Check;




                            if (Od.adInventoryKey == "BAEMIN_1")
                            {
                                Order_Button.Text = string.Format("{0} [{1}]", Od.orderNo, Program.Language.De[1119]);
                            }

                            //Order_Button.Click += (ss, ee) => { Load_Order_Details_Response(Od, (Order_Status )Order_Button.Tag); };
                            Order_Button.Click += (ss, ee) => { Load_Order_Details_Response(Order_Button.Order_Details, Order_Button.Last_Check_Data); };

                            //Order_Button.Click += (ss, ee) => { Load_Order_Details_Response(Od, Order_Check.Where(sss => sss.orderNo == Od.orderNo).FirstOrDefault()); };


                            switch (Od.orderStatus)
                            {

                                case "NEW":
                                    if (!Main_Frm.New_Orders.Controls.ContainsKey(Order_Button.Name))
                                    {

                                        Order_Button.Size = new Size(Main_Frm.New_Orders.Width - 25, 68);
                                        Main_Frm.New_Orders.Controls.Add(Order_Button);


                                    }
                                    if (Orders_To_Load != null)
                                    {


                                        //Show_New_Order_Notification(Od.orderNo, Od.deliveryType, Od.payInfo.salePrice, Od.foods, Od.serviceType, Od.shopInfo.shopNo);
                                        Show_New_Order_Notification(Od);

                                    }

                                    break;

                                case "RECEIPT":
                                    if (!Main_Frm.In_Progress_Orders.Controls.ContainsKey(Order_Button.Name))
                                    {
                                        Order_Button.Size = new Size(Main_Frm.In_Progress_Orders.Width - 25, 68);
                                        //Order_Button.Click += (ss, ee) => { Get_Order_Details(ss, ee, null, Order_Status.Receipt); };
                                        Main_Frm.In_Progress_Orders.Controls.Add(Order_Button);
                                    }
                                    else
                                    {
                                        Control cn = Main_Frm.In_Progress_Orders.Controls.Find(Order_Button.Name, true).FirstOrDefault();
                                        if (cn != null && cn.GetType() == typeof(Order_Button))
                                        {
                                            Order_Button ord = (Order_Button)cn;
                                            ord.Order_Details = Od;
                                            ord.Last_Check_Data = Order_Last_Check;

                                        }

                                    }


                                    if (Orders_To_Load != null)
                                    {
                                        Close_Order_Notification(Od.orderNo);

                                        Order_Details oo = Main_Frm.Order_Details.Controls.OfType<Order_Details>().Where(Order => Order._orderNo == Od.orderNo).FirstOrDefault();
                                        if (oo != null)
                                        {
                                            Main_Frm.Order_Details.Controls.Remove(oo);
                                        }
                                    }

                                    Order_Button test = Main_Frm.New_Orders.Controls.OfType<Order_Button>().Where(Order_btn => Order_btn.Name == Od.orderNo).FirstOrDefault();
                                    if (test != null)
                                    {
                                        Main_Frm.New_Orders.Controls.Remove(test);
                                    }

                                    //foreach (Button b in Main_Frm.New_Orders.Controls)
                                    //{
                                    //    if (b.Text == Od.orderNo)
                                    //    {
                                    //        //b.BackColor = Color.Red;

                                    //        //if (Order_Details.Controls.ContainsKey(or["orderNo"].ToString()))
                                    //        //{
                                    //        //    MessageBox.Show("ddd");
                                    //        //    Order_Details.Controls.RemoveByKey(or["orderNo"].ToString());

                                    //        //}
                                    //        //Order_Details.Controls.Clear();
                                    //        Main_Frm.New_Orders.Controls.Remove(b);

                                    //        //break;
                                    //    }
                                    //}




                                    break;

                                case "COMPLETED":
                                case "CANCEL":
                                    //this.Order_Details.Controls.Clear();

                                    if (Orders_To_Load != null)
                                    {
                                        Close_Order_Notification(Od.orderNo);

                                        Order_Details oo = Main_Frm.Order_Details.Controls.OfType<Order_Details>().Where(Order => Order._orderNo == Od.orderNo).FirstOrDefault();
                                        if (oo != null)
                                        {
                                            Main_Frm.Order_Details.Controls.Remove(oo);
                                        }

                                    }

                                    Order_Button.Size = new Size(Main_Frm.Completed_Orders.Width - 25, 68);
                                    //Order_Button.Click += (ss, ee) => { Get_Order_Details(ss, ee, null, Order_Status.Completed); };

                                    if (!Main_Frm.Completed_Orders.Controls.ContainsKey(Order_Button.Name))
                                    {
                                        Main_Frm.Completed_Orders.Controls.Add(Order_Button);

                                    }
                                    else
                                    {
                                        Control cn = Main_Frm.Completed_Orders.Controls.Find(Order_Button.Name, true).FirstOrDefault();
                                        if (cn != null && cn.GetType() == typeof(Order_Button))
                                        {
                                            Order_Button ord = (Order_Button)cn;
                                            ord.Order_Details = Od;
                                            ord.Last_Check_Data = Order_Last_Check;

                                        }

                                    }


                                    foreach (Button b in Main_Frm.In_Progress_Orders.Controls)
                                    {
                                        if (b.Name == Od.orderNo)
                                        {
                                            Main_Frm.In_Progress_Orders.Controls.Remove(b);
                                        }
                                    }

                                    foreach (Button b in Main_Frm.New_Orders.Controls)
                                    {
                                        if (b.Name == Od.orderNo)
                                        {
                                            Main_Frm.New_Orders.Controls.Remove(b);
                                        }
                                    }






                                    break;
                            }




                        }
                    }
                    else
                    {
                        Main_Frm.ShowMessages(rs.rspMsg, Program.Language.De[1001], MessageBoxIcon.Error);
                    }
                }));

            }

        }

        private static JArray Load_Order_Accept_Times(string siteCode, string serviceType, string deliveryType, string deliveryCarryType)
        {

            //JToken final = Main_Frm.selectedTimes.Where(x => x["siteCode"].ToString() == siteCode && x["serviceType"].ToString() == serviceType
            //&& x["deliveryType"].ToString() == deliveryType && x["deliveryCarryType"].ToString() == deliveryCarryType).FirstOrDefault();

            //return ((JArray)final["times"]).Count > 0 ? (JArray)final["times"] : (JArray)final["ranges"];

            foreach (JToken r in Main_Frm.selectedTimes)
            {
                if (r["siteCode"].ToString() == siteCode && r["serviceType"].ToString() == serviceType && r["deliveryCarryType"].ToString() == deliveryCarryType)
                {
                    return ((JArray)r["times"]).Count > 0 ? (JArray)r["times"] : (JArray)r["ranges"];

                }
            }
            return null;




            //foreach (JToken r in Main_Frm.selectedTimes)
            //{
            //    if (r["serviceType"].ToString() == serviceType && r["deliveryType"].ToString() == deliveryType)
            //    {
            //        return ((JArray)r["times"]).Count > 0 ? (JArray)r["times"] : (JArray)r["ranges"];

            //    }
            //}
            //return null;
        }

        //Ordders_Details_Datum
        //private static void Show_New_Order_Notification(string orderNo, string deliveryType, string Sale_price, List<Food> Menus, string serviceType, string shopNo)
        private static void Show_New_Order_Notification(Ordders_Details_Datum Current_Order)
        {
            //Od.orderNo, Od.deliveryType, Od.payInfo.salePrice, Od.foods, Od.serviceType, Od.shopInfo.shopNo

            var oop = Application.OpenForms.Cast<Form>().Where(
                Order => Order.GetType() == typeof(Order_Notification) && Order.Name == Current_Order.orderNo);

            if (oop.Count() > 0)
            {
                return;
            }
            //MessageBox.Show(oop.Count().ToString());

            int Notifications_frm_count = 1;
            for (int i = 0; i <= Application.OpenForms.Count - 1; i++)
            {
                if (Application.OpenForms[i].GetType() == typeof(Order_Notification))
                {
                    Notifications_frm_count += 1;
                }
            }


            Order_Notification n = new Order_Notification();


            n.Name = Current_Order.orderNo;

            //MessageBox.Show(Notifications_frm_count.ToString());


            n.AutoSizeMode = AutoSizeMode.GrowOnly;
            n.Name = Current_Order.orderNo;


            //string Order_details = ;

            n.Order_No.Text = $"{Current_Order.deliveryType} #{Current_Order.orderNo}";
            n.Order_Details.Text = $"{Current_Order.foods.Count} Menus - Total {Current_Order.payInfo.salePrice}";



            //foreach (Food Food in Menus)
            //{
            //    Label L = new Label()
            //    {
            //        Text = $"{Food.quantity} {Food.foodName}" + (string.IsNullOrEmpty(Food.foodContents) != false ? $" ({Food.foodContents})" : null),
            //        AutoSize = true

            //    };
            //    n.Menus.Controls.Add(L);
            //}


            foreach (Food foods in Current_Order.foods)
            {

                Label L = new Label()
                {
                    Text = $"{foods.quantity} {foods.foodName}" + (string.IsNullOrEmpty(foods.foodContents) == false ? $" ({foods.foodContents})" : null),
                    AutoSize = true

                };

                //Order_Details.order_item New_Food_Item = new Order_Details.order_item() ;


                //New_Food_Item.ID = foods.foodSeq;
                //New_Food_Item.name = foods.foodName;

                FlowLayoutPanel pn = new FlowLayoutPanel() { Tag = foods.foodSeq, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
                pn.Controls.Add(new Label() { Name = "foodName", Text = $"{foods.quantity} {foods.foodName}" });
                //pn.Controls.Add(new Label() { Text = foods.quantity, Size = new Size(50, 18) });
                //pn.Controls.Add(new Label() { Text = foods.price.ToString(), Size = new Size(50, 18) });


                string options = null;
                foreach (PriceGroup priceGroup in foods.priceGroup)
                {
                    foreach (FoodPrice p3 in priceGroup.foodPrice)
                    {
                        if (!string.IsNullOrEmpty(p3.priceName))
                        {
                            if (string.IsNullOrEmpty(options) == true)
                            {
                                options = p3.priceName;
                            }
                            else
                            {
                                options = options + "," + p3.priceName;
                            }
                            FlowLayoutPanel pn1 = new FlowLayoutPanel() { Name = "options", Tag = p3.shopFoodPriceSeq.ToString() };
                            //New_Food_Item.Options.Add(new Beamin_Control.Controls.Order_Details.order_item()
                            //{
                            //    ID = p3.shopFoodPriceSeq,
                            //    name = p3.priceName,
                            //});
                            pn1.Controls.Add(new Label() { Name = "priceName", Text = $"{p3.priceName}" });

                            //pn1.Controls.Add(new Label() { Name = "priceName", Text = p3.priceName, Margin = new Padding(20, 0, 385, 0), Size = new Size(180, 18) });
                            //pn1.Controls.Add(new Label() { Text = p3.price.ToString(), Size = new Size(100, 18) });
                            pn1.AutoSize = true;
                            //pn.Controls.Add(pn1);
                        }
                    }
                    //new_order.Foods.Controls.Add(pn1);
                }

                // n.Menus.Controls.Add(pn);

                if (string.IsNullOrEmpty(options) == false)
                {
                    L.Text = L.Text + " {" + options + "}";
                }

                n.Menus.Controls.Add(L);


                //new_order.Foods_Menu.Add(New_Food_Item);
                ////o_item.Options = foods_options;
                //pn.AutoSize = true;
                //new_order.Foods.Controls.Add(pn);
            }


            //#if !Design_Test
            //n.Selected_Time = Load_Order_Accept_Times(serviceType, deliveryType);
            n.Selected_Time = Load_Order_Accept_Times(Current_Order.siteCode, Current_Order.serviceType, Current_Order.deliveryType, Current_Order.deliveryCarryType);
            n.Current_selected_timee = n.Selected_Time.First();

            n.Cancel_Order.Click += (ss, ee) =>
            { Show_REJECT_Resons(ss, ee, Current_Order.orderNo, Current_Order.shopInfo.shopNo, Current_Order.siteCode, Current_Order.serviceType, Current_Order.deliveryType, "REJECT", Current_Order.foods); };

            n.Accept_Order.Click += (ss, ee) =>
            //{ Order_Accept(ss, ee, orderNo, n.Time.Text); };
            { Order_Accept(ss, ee, Current_Order, n.Current_selected_timee); };

            //#endif

            int Y_Location = Screen.PrimaryScreen.WorkingArea.Height - ((n.Height) * Notifications_frm_count);

            n.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - n.Width, Y_Location);

            n.Show();



            //Order_Notification x = (Order_Notification)Application.OpenForms["Order_Notification"];
            //if (x == null)
            //{
            //    n.Name = Order_No;
            //    n.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - n.Width, Screen.PrimaryScreen.WorkingArea.Height - n.Height);

            //    n.Show();
            //}
            //else
            //{



            //    Order_Notification n = new Order_Notification();

            //    n.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - n.Width, Screen.PrimaryScreen.WorkingArea.Height - (n.Height + 10 + x.Height));


            //}
        }

        private static void Close_Order_Notification(string orderNo)
        {
            //Application.OpenForms.AsQueryable().OfType
            //Application.OpenForms.GetEnumerator().
            //foreach (Form f in Application.OpenForms)
            //MessageBox.Show(orderNo);
            var q = Application.OpenForms.Cast<Form>().Where(form => form.GetType() == typeof(Order_Notification) && form.Name == orderNo).ToList();

            //System.InvalidOperationException: 'Collection was modified;  bug
            if (q.Count > 0)
            {
                Main_Frm.Invoke(new Action(() =>
                {
                    //q.ToList<Form>()[0].Dispose();
                    q.FirstOrDefault().Dispose();
                }));
            }

            //List<Form> all = q.ToList<Form>();

            //for (int i = 0; i < all.Count; i++)
            //{
            //    Form form = all[i];
            //    form.Dispose();
            //}

            //for (int i = 0; i < Application.OpenForms.Count ; i++)
            //{

            //    Form f = Application.OpenForms[i];
            //    if (f.GetType() == typeof(Order_Notification) && f.Name == orderNo)
            //    {
            //        f.Dispose();
            //    }
            //}



        }


        private static string Parse_Date(string _date)
        {
            DateTime DT;

            return DateTime.TryParse(_date, out DT) == true ? DT.ToString("MM.dd (ddd) hh:mm") : _date;




        }


        private static void Load_Order_Details_Response(Ordders_Details_Datum o, Order_Check_Datum Order_S)
        {
            Order_Details new_order = new Order_Details();

            //new_order.Requests_Lb.Text = Program.Language.De[1104];
            //new_order.Foods_Lb.Text = Program.Language.De[1105];
            //new_order.Order_Information_Lb.Text = Program.Language.De[1106];

            new_order._orderNo = o.orderNo;
            new_order.Selected_Time = Load_Order_Accept_Times(o.siteCode, o.serviceType, o.deliveryType, o.deliveryCarryType);

            if (Order_S != null)
            {
                new_order.orderProgress.Text = String.Format(Program.Language.De[1120] + ": {0} - " + Program.Language.De[1121] + " : {1} - " + Program.Language.De[1122] + " : {2}", Order_S.orderProgress, Order_S.orderStatus, Order_S.riderStatus);
                new_order.date.Text = Program.Language.De[1123] + " : " + Order_S.date;
            }


            int width = 0;

            switch (o.orderStatus)
            {
                case "NEW":
                    width = Main_Frm.Order_Details.Width - 35;


                    new_order.Order_Controls.Visible = true;
                    new_order.pn.Visible = true;
                    new_order.Cancel_Order.Text = Program.Language.De[1100];
                    new_order.Cancel_Order.Click += (ss, ee) =>
                    //{ Show_REJECT_Resons(ss, ee, o.orderNo, o.shopInfo.shopNo, o.serviceType, o.deliveryType, "REJECT", new_order.Foods_Menu); };
                    { Show_REJECT_Resons(ss, ee, o.orderNo, o.shopInfo.shopNo, o.siteCode, o.serviceType, o.deliveryType, "REJECT", o.foods); };

                    new_order.Accept_Order.Text = Program.Language.De[1103]; //Accept
                    new_order.Accept_Order.Click += (ss, ee) =>
                    {
                        Order_Accept(ss, ee, o, new_order.Current_selected_timee);
                    };
                    break;


                case "RECEIPT":
                    width = Main_Frm.Order_Details.Width - 35;
                    new_order.Order_Controls.Visible = true;


                    //if (Main_Frm.Cancel_Codes.Where(ss =>
                    //    ss["siteCode"].ToString() == o.siteCode && ss["serviceType"].ToString() == o.serviceType && ss["deliveryType"].ToString() == o.deliveryType && ss["cancelType"].ToString() == "CANCEL"
                    // ).Count() != 0)

                    new_order.Cancel_Order.Text = Program.Language.De[1101];

                    if (o.siteCode == "BAERA" && o.serviceType == "BAERA" && o.deliveryType == "DELIVERY")
                    {
                        Rider_Control Rider_Status = new Rider_Control()
                        {
                            Width = width,
                        };


                        Rider_Status.OrderNo.Text = o.orderNo.ToString();
                        if (o.riderInfo != null)
                        {

                            if (!string.IsNullOrEmpty(o.riderInfo.riderAssignTime))
                            {

                                Rider_Status.rider_ProgressBar2.Rider_Assignment_Time = DateTime.ParseExact(o.riderInfo.riderAssignTime, "yyyy-MM-ddTHH:mmZ",
                                    System.Globalization.CultureInfo.CurrentCulture).ToString("HH:mm");
                            }


                            if (!string.IsNullOrEmpty(o.riderInfo.estimatedPickupExecuteTime))
                            {
                                Rider_Status.rider_ProgressBar2.Pickup_Complete_Time = DateTime.ParseExact(o.riderInfo.estimatedPickupExecuteTime, "yyyy-MM-dd HH:mm:ss",
                                    System.Globalization.CultureInfo.CurrentCulture).ToString("HH:mm");

                            }
                        }

                        if (o.riderStatus == "RIDER_ASSIGNED")
                        {
                            Rider_Status.rider_ProgressBar2.Value = 10;

                        }


                        if (o.riderStatus == "PICKUP_COMPLETED")
                        {
                            Rider_Status.rider_ProgressBar2.Value = 55;

                        }

                        if (o.riderStatus == "ARRIVED_SHOP")
                        {
                            Rider_Status.rider_ProgressBar2.Value = 100;

                        }

                        new_order.Details_Items.Controls.Add(Rider_Status);



                        if(Order_S != null)
                        {
                            if (Order_S.riderStatus == null)
                            {
                                new_order.Cancel_Order.Click += (ss, ee) =>
                                {
                                    Show_REJECT_Resons(ss, ee, o.orderNo, o.shopInfo.shopNo, o.siteCode, o.serviceType, o.deliveryType, "WAIT_ALLOCATE", o.foods);
                                };
                                new_order.Accept_Order.Visible = false;
                            }
                            else if (Order_S.riderStatus == "RIDER_ASSIGNED")
                            {
                                new_order.Cancel_Order.Click += (ss, ee) =>
                                {
                                    Show_REJECT_Resons(ss, ee, o.orderNo, o.shopInfo.shopNo, o.siteCode, o.serviceType, o.deliveryType, "RIDER_ASSIGNED", o.foods);
                                };
                                new_order.Accept_Order.Visible = false;

                            }
                            else if (Order_S.riderStatus == "ARRIVED_SHOP")

                            {
                                new_order.Cancel_Order.Visible = false;
                                new_order.Accept_Order.Visible = false;
                            }

                            else
                            {
                                new_order.Cancel_Order.Visible = false;
                                new_order.Accept_Order.Text = Program.Language.De[1124];//"Cookie Complete";
                                new_order.Accept_Order.Click += (ss, ee) =>
                                {
                                    if (MessageBox.Show(Program.Language.De[1003], Program.Language.De[1124]
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //Order_Set_Action_Click(ss, ee, o.orderNo, " ", "2", o.shopInfo.shopNo.ToString());
                                        //Order_Complete_btn(ss, ee, o.orderNo);

                                        Thread th = new Thread(new ThreadStart(() =>
                                        {


                                            Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v7/orders/{o.orderNo}/cook-complete", Method.POST, null, null, Main_Frm.Special_Headers));
                                            tx.Wait();

                                            if (!string.IsNullOrEmpty(tx.Result.Content))
                                            {
                                                JToken response = Helper_Class.Json_Response(tx.Result.Content.ToString());

                                                if (response["rspCode"].ToString() == "200")
                                                {
                                                    Main_Frm.Invoke(new Action(() =>
                                                    {
                                                        MessageBox.Show("Cookie Complete");
                                                    }));

                                                }
                                            }
                                        }));

                                        th.Start();
                                    }
                                };
                            }
                        }
                        


                    }
                    else
                    {
                        new_order.Accept_Order.Text = Program.Language.De[1102]; //Order Complete;
                        new_order.Accept_Order.Click += (ss, ee) =>
                        {
                            Order_Complete_btn(o.orderNo);
                        };


                        new_order.Cancel_Order.Click += (ss, ee) =>
                        {
                            Show_REJECT_Resons(ss, ee, o.orderNo, o.shopInfo.shopNo, o.siteCode, o.serviceType, o.deliveryType, "CANCEL", o.foods);
                        };
                    }




                    //if (Main_Frm.Cancel_Codes.Where(ss => ss["siteCode"].ToString() == o.siteCode && ss["serviceType"].ToString() == o.serviceType && ss["deliveryType"].ToString() == o.deliveryType && ss["cancelType"].ToString() == "CANCEL").FirstOrDefault() == null)
                    //{
                    //    new_order.Cancel_Order.Visible = false;
                    //}
                    //else
                    //{

                    //}


                    //}









                    break;

                case "CANCEL":
                case "COMPLETED":

                    width = Main_Frm.Completed_Orders_Details.Width - 35;

                    break;

            }



            switch (o.deliveryType)
            {
                case "TAKEOUT":
                    new_order.Order_Header.BackColor = Color.MediumSpringGreen;
                    break;
                case "DELIVERY":
                    new_order.Order_Header.BackColor = Color.Turquoise;
                    break;

            }

            new_order.MinimumSize = new Size(width, 100);
            new_order.orderNo.Text = o.orderNo;

            new_order.amountToReceive.Text = o.amountToReceive.ToString();

            //if(o.deliveryAgencyType == "RIDERS" && (o.orderStatus != "CANCEL" && o.orderStatus !="COMPLETED"))
            //{

            //}
            #region Requests

            Order_Details_Panel Requests = new Order_Details_Panel(Program.Language.De[1104]) { Width = width, };
            //Requests.Top = new_order.Order_Header.Bottom + 5;


            foreach (Memo memos in o.deliveryInfo.memos)
            {
                FlowLayoutPanel r2 = new FlowLayoutPanel()
                {
                    FlowDirection = FlowDirection.LeftToRight
                };
                r2.Controls.Add(new Label() { Text = memos.memoType, AutoSize = true });
                r2.Controls.Add(new Label() { Text = memos.title, AutoSize = true });
                r2.Controls.Add(new Label() { Text = memos.memo, AutoSize = true });
                r2.AutoSize = true;
                //new_order.Requests.Controls.Add(r2);
                Requests.Items_Container.Controls.Add(r2);

            }

            new_order.Details_Items.Controls.Add(Requests);

            #endregion


            Order_Details_Panel Foods = new Order_Details_Panel(Program.Language.De[1105]) { Width = width, };

            Foods.Top = Requests.Bottom + 5;

            foreach (Food foods in o.foods)
            {
                Order_Details.order_item New_Food_Item = new Order_Details.order_item();
                New_Food_Item.ID = foods.foodSeq;
                New_Food_Item.name = foods.foodName;

                FlowLayoutPanel pn = new FlowLayoutPanel() { Tag = foods.foodSeq };
                pn.Controls.Add(new Label() { Name = "foodName", Text = foods.foodName, Margin = new Padding(0, 0, 300, 0), Size = new Size(180, 18) });
                pn.Controls.Add(new Label() { Text = foods.quantity, Size = new Size(100, 18) });
                pn.Controls.Add(new Label() { Text = foods.price.ToString(), Size = new Size(100, 18) });




                foreach (PriceGroup priceGroup in foods.priceGroup)
                {
                    foreach (FoodPrice p3 in priceGroup.foodPrice)
                    {
                        if (!string.IsNullOrEmpty(p3.priceName))
                        {
                            FlowLayoutPanel pn1 = new FlowLayoutPanel() { Name = "options", Tag = p3.shopFoodPriceSeq.ToString() };
                            New_Food_Item.Options.Add(new Beamin_Control.Controls.Order_Details.order_item()
                            {
                                ID = p3.shopFoodPriceSeq,
                                name = p3.priceName,
                            });
                            pn1.Controls.Add(new Label() { Name = "priceName", Text = p3.priceName, Margin = new Padding(20, 0, 385, 0), Size = new Size(180, 18) });
                            pn1.Controls.Add(new Label() { Text = p3.price.ToString(), Size = new Size(100, 18) });
                            pn1.AutoSize = true;
                            pn.Controls.Add(pn1);
                        }
                    }
                    //new_order.Foods.Controls.Add(pn1);
                }

                //foreach (PriceGroup priceGroup in foods.priceGroup)
                //{
                //    foreach (FoodPrice p3 in priceGroup.foodPrice)
                //    {
                //        if (!string.IsNullOrEmpty(p3.priceName))
                //        {
                //            FlowLayoutPanel pn1 = new FlowLayoutPanel() { Name = "options", Tag = p3.shopFoodPriceSeq.ToString() };
                //            New_Food_Item.Options.Add(new Beamin_Control.Controls.Order_Details.order_item()
                //            {
                //                ID = p3.shopFoodPriceSeq,
                //                name = p3.priceName,
                //            });
                //            pn1.Controls.Add(new Label() { Name = "priceName", Text = p3.priceName, Margin = new Padding(20, 0, 385, 0), Size = new Size(180, 18) });
                //            pn1.Controls.Add(new Label() { Text = p3.price.ToString(), Size = new Size(100, 18) });
                //            pn1.AutoSize = true;
                //            pn.Controls.Add(pn1);
                //        }
                //    }
                //    //new_order.Foods.Controls.Add(pn1);
                //}
                new_order.Foods_Menu.Add(New_Food_Item);
                //o_item.Options = foods_options;
                pn.AutoSize = true;
                Foods.Items_Container.Controls.Add(pn);
            }

            new_order.Details_Items.Controls.Add(Foods);



            Panel total_panel = new Panel()
            {
                AutoSize = true,
                MinimumSize = new Size(width, 30),
                BackColor = Color.White,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            //new_order.total_panel.AutoSize = true;
            new_order.Details_Items.Controls.Add(total_panel);

            //new_order.total_panel.Top = Foods.Bottom + 5;
            FlowLayoutPanel pn2 = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.LeftToRight,
                Size = total_panel.Size
            };

            pn2.Controls.Add(new Label() { Text = Program.Language.De[1107], AutoSize = true, Margin = new Padding(5, 5, 435, 0) }); // Amount To Receive
            pn2.Controls.Add(new Label() { Text = o.amountToReceive.ToString(), AutoSize = true, Margin = new Padding(8, 5, 0, 0) });
            total_panel.Controls.Add(pn2);


            Order_Details_Panel Order_Information = new Order_Details_Panel(Program.Language.De[1106]) { Width = width, };
            new_order.Details_Items.Controls.Add(Order_Information);

            //new_order.Order_Info_Panel.Top = new_order.total_panel.Bottom + 15;
            FlowLayoutPanel pn3 = new FlowLayoutPanel();
            pn3.Controls.Add(new Label() { Text = Program.Language.De[1108], Size = new Size(200, 18) }); //"Delivery address"
            FlowLayoutPanel pn4 = new FlowLayoutPanel() { FlowDirection = FlowDirection.TopDown };
            pn4.Controls.Add(new Label() { Text = o.deliveryInfo.address, Size = new Size(400, 18) });
            pn4.Controls.Add(new Label() { Text = o.deliveryInfo.addressJibun, Size = new Size(400, 18) });
            pn4.Controls.Add(new Label() { Text = o.deliveryInfo.addressRoad, Size = new Size(400, 18) });
            pn4.Controls.Add(new Label() { Text = o.deliveryInfo.addressDetail, Size = new Size(400, 18) });
            pn4.AutoSize = true;
            pn3.Controls.Add(pn4);
            pn3.AutoSize = true;
            Order_Information.Items_Container.Controls.Add(pn3);
            FlowLayoutPanel pn5 = new FlowLayoutPanel();
            pn5.Controls.Add(new Label() { Text = Program.Language.De[1109], Size = new Size(200, 18) }); //"Phone No"
            pn5.Controls.Add(new Label() { Text = o.deliveryInfo.phoneNo, Size = new Size(400, 18) });
            pn5.AutoSize = true;
            Order_Information.Items_Container.Controls.Add(pn5);
            FlowLayoutPanel pn8 = new FlowLayoutPanel();
            pn8.Controls.Add(new Label() { Text = Program.Language.De[1110], Size = new Size(200, 18) }); //"Order number"
            pn8.Controls.Add(new Label() { Text = o.orderNo, Size = new Size(400, 18) });
            pn8.AutoSize = true;
            Order_Information.Items_Container.Controls.Add(pn8);
            FlowLayoutPanel pn6 = new FlowLayoutPanel();
            pn6.Controls.Add(new Label() { Text = Program.Language.De[1111], Size = new Size(200, 18) }); //"Order Time"
            pn6.Controls.Add(new Label() { Text = Parse_Date(o.orderDateTime), Size = new Size(400, 18) });
            //pn6.Controls.Add(new Label() { Text = DateTime.Parse(o.orderDateTime).ToString("yyy.MM.dd (ddd) hh:mm"), Size = new Size(400, 18) });
            pn6.AutoSize = true;
            Order_Information.Items_Container.Controls.Add(pn6);
            //
            FlowLayoutPanel pn7 = new FlowLayoutPanel();
            Order_Information.Items_Container.Controls.Add(pn7);

            switch (o.orderStatus)
            {
                case "COMPLETED":
                    pn7.Controls.Add(new Label() { Text = Program.Language.De[1113], Size = new Size(200, 18) }); //Completion Time
                    //pn7.Controls.Add(new Label() { Text = DateTime.Parse(o.orderCompleteDateTime).ToString("yyy.MM.dd (ddd) hh:mm"), Size = new Size(400, 18) });
                    pn7.Controls.Add(new Label() { Text = Parse_Date(o.orderCompleteDateTime), Size = new Size(400, 18) });

                    break;
                case "RECEIPT":
                    pn7.Controls.Add(new Label() { Text = Program.Language.De[1114], Size = new Size(200, 18) }); //"Receipt Time"

                    //pn7.Controls.Add(new Label() { Text = DateTime.Parse(o.orderReceiptDateTime).ToString("yyy.MM.dd (ddd) hh:mm"), Size = new Size(400, 18) });

                    pn7.Controls.Add(new Label() { Text = Parse_Date(o.orderReceiptDateTime), Size = new Size(400, 18) });

                    FlowLayoutPanel pn11 = new FlowLayoutPanel();
                    pn11.Controls.Add(new Label() { Text = Program.Language.De[1115], Size = new Size(200, 18) }); //"Delivery Minutes"
                    pn11.Controls.Add(new Label() { Text = o.deliveryMinutes, Size = new Size(400, 18) });
                    pn11.AutoSize = true;
                    Order_Information.Items_Container.Controls.Add(pn11);
                    if (o.deliveryType == "TAKEOUT")
                    {
                        new_order.Send_Notifcation.Visible = true;
                        new_order.Send_Notifcation.Click += (ss, ee) => { New_order_Send_Notification(o.orderNo); };
                    }


                    break;
                case "CANCEL":
                    pn7.Controls.Add(new Label() { Text = Program.Language.De[1116], Size = new Size(200, 18) }); //"Cancellation Time"

                    //2023/06/26 22:59:08.022
                    //pn7.Controls.Add(new Label() { Text = DateTime.Parse(o.cancelInfo.cancelDate).ToString("yyy.MM.dd (ddd) hh:mm"), Size = new Size(400, 18) });
                    pn7.Controls.Add(new Label() { Text = Parse_Date(o.cancelInfo.cancelDate), Size = new Size(400, 18) });

                    FlowLayoutPanel pn9 = new FlowLayoutPanel();
                    pn9.Controls.Add(new Label() { Text = Program.Language.De[1117], Size = new Size(200, 18) }); //"Reasons For Cancellation"
                    pn9.Controls.Add(new Label() { Text = o.cancelInfo.cancelReason, Size = new Size(400, 18) });
                    pn9.AutoSize = true;
                    Order_Information.Items_Container.Controls.Add(pn9);
                    break;
            }

            pn7.AutoSize = true;


            FlowLayoutPanel pn10 = new FlowLayoutPanel();
            pn10.Controls.Add(new Label() { Text = Program.Language.De[1112], Size = new Size(200, 18) }); //"Store Information"
            pn10.Controls.Add(new Label() { Text = o.shopInfo.shopName, Size = new Size(400, 18) });
            pn10.AutoSize = true;
            Order_Information.Items_Container.Controls.Add(pn10);


            //new_order.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
            new_order.AutoSize = true;
            //new_order.Margin = new Padding(0);

            new_order.Margin = new Padding(5, 10, 0, 20);

            switch (o.orderStatus)
            {
                case "RECEIPT":
                case "NEW":
                    Main_Frm.Order_Details.Controls.Clear();
                    //new_order.AutoSize = false;
                    Main_Frm.Order_Details.Controls.Add(new_order);
                    break;


                case "CANCEL":
                case "COMPLETED":
                    Main_Frm.Completed_Orders_Details.Controls.Clear();
                    Main_Frm.Completed_Orders_Details.Controls.Add(new_order);
                    break;

            }





        }





        #endregion



        #region Orders Buttons
        private static void New_order_Send_Notification(string Order_No)
        {
            Thread th = new Thread(new ParameterizedThreadStart((object f) =>
            {

                JObject x = new JObject();
                x.Add("_t", "TOrderAlimTalkReq");
                x.Add("alimTalkType", "PACKAGING_COMPLETE");
                x.Add("ReqContentType", 5);

                Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v7/orders/{Order_No}/alimtalk", Method.POST, null, x.ToString(), Main_Frm.Special_Headers));
                tx.Wait();
                if (!string.IsNullOrEmpty(tx.Result.Content))
                {
                    JToken o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                    Main_Frm.Invoke(new Action(() =>
                    {
                        if (o.SelectToken("rspCode").ToString() == "200")
                        {

                            Main_Frm.ShowMessages(Program.Language.De[1118], "", MessageBoxIcon.Information); //Order Complete Notification Sent

                        }
                        else
                        {
                            Main_Frm.ShowMessages(o.SelectToken("rspMsg").ToString(), "", MessageBoxIcon.Error);

                        }
                    }));
                }
            }));
            th.Start();
        }


        //private static void Order_Accept(object sender, EventArgs e, string Order_No, string Order_Time) //old
        //private static void Order_Accept(object sender, EventArgs e, string Order_No, JToken Order_Time) //  new
        private static void Order_Accept(object sender, EventArgs e, Ordders_Details_Datum Order, JToken Order_Time)

        {
#if Test_With_Proxy 

            if (Helper_Class.Is_IP_OK() == false)
            {
                MessageBox.Show("Not Same IP");
                Main_Frm.timer1.Enabled = false;
                return;
            }

#endif


            Thread th = new Thread(new ThreadStart(() =>
            {



                JObject x = new JObject();
                x.Add("_t", "TOrderReceiptReq");
                x.Add("pcName", Properties.Settings.Default._deviceName);

                //if( Order_Time.SelectToken("max") != null )
                //{
                //    x.Add("deliveryTimeMinutes", "");
                //    x.Add("cookTimeMinutes", Order_Time.SelectToken("max").ToString ());
                //}
                //else
                //{
                //    x.Add("deliveryTimeMinutes", Order_Time.ToString());
                //    x.Add("cookTimeMinutes", "");
                //}

                //if (Order.cookTimeMinutesRange != null && Order_Time.SelectToken("max") != null)

                if (Order.adInventoryKey == "BAEMIN_1")
                {
                    x.Add("deliveryTimeMinutes", "");
                    x.Add("cookTimeMinutes", Order_Time.SelectToken("max") != null ? Order_Time.SelectToken("max").ToString() : Order_Time.ToString());
                }
                else
                {
                    x.Add("deliveryTimeMinutes", Order_Time.SelectToken("max") != null ? Order_Time.SelectToken("max").ToString() : Order_Time.ToString());
                    x.Add("cookTimeMinutes", "");
                }


                x.Add("ReqContentType", 5);



                Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v7/orders/{Order.orderNo}/receipt", Method.POST, null, x.ToString(), Main_Frm.Special_Headers));
                tx.Wait();

                if (!string.IsNullOrEmpty(tx.Result.Content))
                {
                    JToken response = Helper_Class.Json_Response(tx.Result.Content.ToString());

                    if (response["rspCode"].ToString() == "200")
                    {

                        Close_Order_Notification(Order.orderNo);
                        Check_New_Orders();

                    }
                }


            }));
            th.Start();

        }


        //private static void Show_REJECT_Resons(object sender, EventArgs e, string Order_No, string shopNo, string serviceType, string deliveryType, string cancelType, List<Food> Foods)
        private static void Show_REJECT_Resons(object sender, EventArgs e, string Order_No, string shopNo, string siteCode, string serviceType, string deliveryType, string cancelType, List<Food> Foods)
        {

            //MessageBox.Show(String.Format("siteCode= {0}, serviceType= {1}, deliveryType= {2}, cancelType={3}", siteCode, serviceType, deliveryType, cancelType));
            //MessageBox.Show (
            //    Main_Frm.Cancel_Codes.Where(ss => 
            //ss["siteCode"].ToString() == siteCode && ss["serviceType"].ToString() == serviceType && ss["deliveryType"].ToString() == deliveryType && ss["cancelType"].ToString()== cancelType
            //).Count().ToString ()
            //);


            REJECT_REASON_frm frm = new REJECT_REASON_frm();
            foreach (JToken r in Main_Frm.Cancel_Codes)
            {

                //if (r["serviceType"].ToString() == serviceType && r["deliveryType"].ToString() == deliveryType && r["cancelType"].ToString() == cancelType)
                //if (r["siteCode"].ToString() == serviceType && r["deliveryType"].ToString() == deliveryType && r["cancelType"].ToString() == cancelType)
                if (r["siteCode"].ToString() == siteCode && r["serviceType"].ToString() == serviceType && r["deliveryType"].ToString() == deliveryType && r["cancelType"].ToString() == cancelType)
                {
                    foreach (JToken Codes in r["codes"])
                    {
                        Button reson = new Button()
                        {
                            Text = Codes["codeName"].ToString(),
                            Tag = Codes["code"].ToString(),
                            Size = new Size(250, 30),
                            Cursor = Cursors.Hand
                        };

                        if (reson.Tag.ToString() == "26" || reson.Tag.ToString() == "20") // If Order Canceled By Menu 
                        {
                            reson.Click += (ss, ee) =>
                            {
                                //Unable to cast object of type 'Beamin_Control.Order_Notification' to type 

                                REJECT_REASON_frm Cancel_By_Menu = new REJECT_REASON_frm();
                                //Order_Details x = (Order_Details)((Button)sender).Parent.Parent.Parent; // bug here 


                                foreach (Food vv in Foods)
                                {

                                    FlowLayoutPanel FoodMenu = new FlowLayoutPanel()
                                    {
                                        FlowDirection = FlowDirection.TopDown,
                                        AutoSize = true,
                                        WrapContents = false,
                                    };


                                    Cancel_By_Menu_CheckBox o_item = new Cancel_By_Menu_CheckBox(vv.foodSeq, vv.foodName, "Menu")
                                    {
                                        Margin = new Padding(0, 5, 0, 0),
                                        Size = new Size(frm.flowLayoutPanel1.Width - 10, 30),
                                        Cursor = Cursors.Hand
                                    };


                                    o_item.CheckStateChanged += (Sender_ch, ce) =>
                                    {

                                        if (o_item.Checked == true)
                                        {

                                            foreach (CheckBox ch in FoodMenu.Controls)
                                            {
                                                if (ch != Sender_ch)
                                                {
                                                    ch.Checked = false;
                                                }
                                            }
                                        }

                                    };

                                    FoodMenu.Controls.Add(o_item);





                                    foreach (PriceGroup priceGroup in vv.priceGroup)
                                    {
                                        foreach (FoodPrice p3 in priceGroup.foodPrice)
                                        {
                                            if (!string.IsNullOrEmpty(p3.priceName))
                                            {
                                                //FlowLayoutPanel pn1 = new FlowLayoutPanel() { Name = "options", Tag = p3.shopFoodPriceSeq.ToString() };
                                                //New_Food_Item.Options.Add(new Beamin_Control.Controls.Order_Details.order_item()
                                                //{
                                                //    ID = p3.shopFoodPriceSeq,
                                                //    name = p3.priceName,
                                                //});
                                                //pn1.Controls.Add(new Label() { Name = "priceName", Text = p3.priceName, Margin = new Padding(20, 0, 385, 0), Size = new Size(180, 18) });
                                                //pn1.Controls.Add(new Label() { Text = p3.price.ToString(), Size = new Size(100, 18) });
                                                //pn1.AutoSize = true;
                                                //pn.Controls.Add(pn1);

                                                Cancel_By_Menu_CheckBox o_item2 = new Cancel_By_Menu_CheckBox(p3.shopFoodPriceSeq, p3.priceName, "Option")
                                                {
                                                    //Tag = o2,
                                                    //Text = o2.ToString(),

                                                    //Tag = p3.shopFoodPriceSeq,
                                                    //Text = p3.priceName,




                                                    Margin = new Padding(20, 0, 0, 5),
                                                    Size = new Size(frm.flowLayoutPanel1.Width - 10, 30),
                                                    Cursor = Cursors.Hand

                                                };
                                                //o_item2.CheckStateChanged += (ch, ce) => { o_item.Checked = o_item2.Checked; o2.Checked = o_item2.Checked; };
                                                o_item2.CheckStateChanged += (ch, ce) =>
                                                {

                                                    if (o_item2.Checked == true)
                                                    {
                                                        o_item.Checked = false;
                                                    }
                                                };
                                                //Cancel_By_Menu.flowLayoutPanel1.Controls.Add(o_item2);
                                                FoodMenu.Controls.Add(o_item2);


                                            }
                                        }
                                        //new_order.Foods.Controls.Add(pn1);
                                    }


                                    Cancel_By_Menu.flowLayoutPanel1.Controls.Add(FoodMenu);




                                };


                                Button cancel = new Button() { Text = "Cancel By Menu", AutoSize = true };
                                cancel.Click += (se, ev) =>
                                {
                                    Cancel_By_Menu.DialogResult = DialogResult.OK;
                                };


                                Cancel_By_Menu.flowLayoutPanel1.Controls.Add(cancel);
                                if (Cancel_By_Menu.ShowDialog(frm) == DialogResult.OK)
                                {

                                    Order_Set_Action_Click(frm, ee, Order_No, reson.Tag.ToString(), "5", shopNo, Cancel_By_Menu.flowLayoutPanel1);

                                    //frm.DialogResult = DialogResult.OK;

                                };
                            };
                        }
                        else
                        {
                            reson.Click += (ss, ee) =>
                            {
                                Order_Set_Action_Click(frm, ee, Order_No, reson.Tag.ToString(), "5", shopNo);

                            };
                        }
                        frm.flowLayoutPanel1.Controls.Add(reson);
                    }
                    break;
                }
            }
            frm.Text = "CHOOSE REASON";
            frm.ShowDialog(((Button)sender).Parent.Parent);
        }
        private static void Order_Set_Action_Click(Form sender_frm, EventArgs e, string Order_No, string detailInfo, string orderProgressCode,
            string shopNo, FlowLayoutPanel canceledByMenuDetail = null)
        {

#if Test_With_Proxy

            if (Helper_Class.Is_IP_OK() == false)
            {
                MessageBox.Show("Not Same IP");
                Main_Frm.timer1.Enabled = false;
                return;
            }

#endif

            #region Load Selected Menus and Options Out of stock

            JArray Request_Payload_Cancel_By_Menu = null;
            JArray Block_Menu = null;



            if (canceledByMenuDetail != null)
            {
                IEnumerable<Control> all = canceledByMenuDetail.Controls.Cast<Control>().Where(ccc => ccc.GetType() == typeof(FlowLayoutPanel));

                foreach (FlowLayoutPanel L in all)
                {


                    Cancel_By_Menu_CheckBox Mmenu = L.Controls.Cast<Cancel_By_Menu_CheckBox>().Where(ch1 => ch1.Check_Type == "Menu").FirstOrDefault();
                    if (Mmenu != null)
                    {
                        JObject zz = new JObject();
                        zz.Add("id", Mmenu.foodSeq);
                        zz.Add("name", Mmenu.foodName); // removed from block


                        JObject BLock_o = new JObject();
                        BLock_o.Add("id", Mmenu.foodSeq);


                        JArray j_Options = new JArray();

                        JArray BLock_Options = new JArray();


                        IEnumerable<Cancel_By_Menu_CheckBox> M = L.Controls.Cast<Cancel_By_Menu_CheckBox>().Where(ch1 => ch1.Checked == true && ch1.Check_Type == "Option")
                        .ToList().OrderByDescending(qw => qw.foodSeq);




                        foreach (Cancel_By_Menu_CheckBox L1 in M)
                        {

                            JObject zz1 = new JObject();


                            zz1.Add("id", L1.foodSeq);
                            zz1.Add("name", L1.foodName);
                            zz1.Add("resetDate", DateTime.Now.ToString("yyyy-MM-dd"));


                            JObject zz2 = new JObject();
                            zz2.Add("id", L1.foodSeq);
                            zz2.Add("resetDate", DateTime.Now.ToString("yyyy-MM-dd"));


                            j_Options.Add(zz1);
                            BLock_Options.Add(zz2);

                        }


                        zz.Add("options", j_Options);

                        BLock_o.Add("options", BLock_Options);




                        if (Mmenu.Checked == true || M.Count() > 0)
                        {

                            if (Request_Payload_Cancel_By_Menu == null)
                            {
                                Request_Payload_Cancel_By_Menu = new JArray();

                            }
                            Request_Payload_Cancel_By_Menu.Add(zz);


                            if (Block_Menu == null)
                            {
                                Block_Menu = new JArray();

                            }
                            Block_Menu.Add(BLock_o);

                        }
                    }











                }
            }



            #endregion


            //Main_Frm.Invoke(new Action(() =>
            //                        }));
            //                    {

            Thread th1 = new Thread(new ThreadStart(() =>
            {




                JObject Request_Payload_Cancel_By_Menu_req = new JObject();

                Request_Payload_Cancel_By_Menu_req.Add("storeId", shopNo);
                Request_Payload_Cancel_By_Menu_req.Add("orderNo", Order_No);
                Request_Payload_Cancel_By_Menu_req.Add("menus", Request_Payload_Cancel_By_Menu);


                JObject x = new JObject();
                x.Add("_t", "TOrderCancelReq");
                x.Add("pcName", Properties.Settings.Default._deviceName);
                x.Add("cancelReasonCode", detailInfo);
                x.Add("canceledByMenuDetail", Request_Payload_Cancel_By_Menu_req);
                x.Add("ReqContentType", 5);

                Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v7/orders/{Order_No}/cancel", Method.POST, null, x.ToString(), Main_Frm.Special_Headers));
                tx.Wait();

                if (!string.IsNullOrEmpty(tx.Result.Content))
                {
                    JToken response = Helper_Class.Json_Response(tx.Result.Content.ToString());

                    if (response["rspCode"].ToString() == "200")
                    {
                        //sender_frm.DialogResult = DialogResult.OK;



                        if (Request_Payload_Cancel_By_Menu != null && Block_Menu != null)
                        {
                            Set_Menu_Out_of_Stock(shopNo, Order_No, Block_Menu);
                        }


                        Check_New_Orders();
                        Close_Order_Notification(Order_No);

                        sender_frm.DialogResult = DialogResult.OK;

                    }
                }



            }));
            th1.Start();



        }



        public static void Set_Menu_Out_of_Stock(string shopNo, string Order_No, JArray Block_Menu)
        {

            JObject menu_canceled = new JObject();

            menu_canceled.Add("_t", "TMerchantMenublockReq");

            JObject r_pa = new JObject();
            r_pa.Add("storeId", shopNo);
            r_pa.Add("orderNo", Order_No);
            r_pa.Add("menus", Block_Menu);

            menu_canceled.Add("payload", r_pa);

            menu_canceled.Add("ReqContentType", 5);



            Task<IRestResponse> tx2 = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v4/merchant/{Properties.Settings.Default.Owner_No}/menu/block", Method.POST, null, menu_canceled.ToString(), Main_Frm.Special_Headers));
            //tx2.Wait();




        }

        private static void Order_Complete_btn(string Order_No)
        {
#if Test_With_Proxy 

            if (Helper_Class.Is_IP_OK() == false)
            {
                MessageBox.Show("Not Same IP");
                Main_Frm.timer1.Enabled = false;
                return;
            }

#endif


            Thread th = new Thread(new ThreadStart(() =>
            {



                JObject x = new JObject();
                x.Add("_t", "TOrderActionReq");
                x.Add("pcName", Properties.Settings.Default._deviceName);
                x.Add("ReqContentType", 5); //x.Add("ReqContentType", 5);



                Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v7/orders/{Order_No}/complete", Method.POST, null, x.ToString(), Main_Frm.Special_Headers));
                tx.Wait();

                if (!string.IsNullOrEmpty(tx.Result.Content))
                {
                    JToken response = Helper_Class.Json_Response(tx.Result.Content.ToString());

                    if (response["rspCode"].ToString() == "200")
                    {
                        Check_New_Orders();
                    }
                }






            }));
            th.Start();

        }

        #endregion 
    }
    class Order_Status
    {
        public string orderProgress, orderStatus, riderStatus, date;
    }
}
