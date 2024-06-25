   #region Tests


        private void button3_Click(object sender, EventArgs e)
        {
            //this.timer1.Enabled = true;
            Button Order_Button = new Button()
            {
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightSteelBlue,
                Size = new Size(New_Orders.Width - 10, 68),
                Text = "T18X00009JOK" //Text = "B18U002438",
            };
            //Order_Button.Click += Get_Order_Details;

            StringReader reader = new StringReader(File.ReadAllText(Application.StartupPath + "\\bug_order.txt"));
            JToken x;
            using (JsonTextReader rd = new JsonTextReader(reader))
            {
                JsonSerializer sz = new JsonSerializer();
                x = (JToken)sz.Deserialize(rd, typeof(JToken));
            }

            //Order_Button.Click += (ss, ee) => { Get_Order_Details(ss, ee, x["data"].First(), Order_Status.Receipt); };
            this.New_Orders.Controls.Add(Order_Button);





            //Order_Button.PerformClick();
        }



    

        private void button8_Click_1(object sender, EventArgs e)
        {

            //MessageBox.Show(Helper_Class.Rand_X_Api_Secret());

            //Close_Order_Notification("B1JS02AVWC");
            //this.timer1.Enabled = false;
            //this.New_Orders.Controls.Clear();
            //In_Progress_Orders.Controls.Clear();

            //DateTime To_12Time2 = DateTime.ParseExact("24" + ":" + "00", "HH:mm", Beamin_Control.WebSite.Web_Helper.Culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            //string tt = String.Format("{0} ~ ", To_12Time2.ToString("hh:mm tt", Beamin_Control.WebSite.Web_Helper.Culture));


            //DateTime To_12Time3 = DateTime.ParseExact("12" + ":" + "00", "hh:mm", Beamin_Control.WebSite.Web_Helper.Culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


            //MessageBox.Show(To_12Time3.ToString ("HH:mm"));



            //MessageBox.Show(Special_Headers[2].ToString());


#if Design_Test
            this.New_Orders.Controls.Clear();

     
#else
            Orders_Control.Check_New_Orders();
#endif
            //foreach (Tuple<string, string> x in Special_Headers)
            //{
            //    //P_request.AddHeader(x.Item1, x.Item2);
            //    MessageBox.Show(x.Item2, x.Item1);

            //}
            //this.timer1.Enabled = true;
            //Load_Completed_Orders();
        }


        private void button7_Click(object sender, EventArgs e)
        {

            //Order_Details o = (Order_Details)this.Completed_Orders_Details.Controls[0]; 
            //Order_Details o = this.Completed_Orders_Details.Controls.OfType <Order_Details>().Where(Order => Order._orderNo == "B1JS02AVWC").FirstOrDefault();
            //var o = this.Order_Details.Controls.Find<Order_Details>(o=>o ).Where(Order => Order.GetType ()== typeof (Order_Details) &&((Order_Details)Order)._orderNo == "B1JS02AVWC");
            //var o = (Control)this.Order_Details.Controls.Cast<Control>().Where(Order => Order.GetType ()== typeof (Order_Details) &&((Order_Details)Order)._orderNo == "B1JS02AVWC");

            //var o = (Order_Details)this.Order_Details.Controls.Cast<Order_Details>().Where(Order => Order._orderNo == "B1JS02AVWC");

            //if (o != null)
            //{

            //    MessageBox.Show(o.orderNo.Text);
            //}


            //Close_Order_Notification("B1JP026EPK");

        }

 





        #endregion


#region  Order_Set_Action_Click
                    //Ordders_Details_Response rs = JsonConvert.DeserializeObject<Ordders_Details_Response>(tx.Result.Content, Serializer_Settings);


            Thread th = new Thread(new ParameterizedThreadStart((object f) =>
            {



                JObject Request_Payload_Cancel_By_Menu = null;

                //if (canceledByMenuDetail != null && canceledByMenuDetail.HasValues)
                //{
                Request_Payload_Cancel_By_Menu = new JObject();
                //Request_Payload_Cancel_By_Menu.Add("_t", "TMerchantMenublockReq");

                //JObject r_pa = new JObject();
                //r_pa.Add("storeId", shopNo);
                //r_pa.Add("orderNo", Order_No);
                //r_pa.Add("menus", canceledByMenuDetail);

                //Request_Payload_Cancel_By_Menu.Add("payload", r_pa);
                Request_Payload_Cancel_By_Menu.Add("storeId", shopNo);
                Request_Payload_Cancel_By_Menu.Add("orderNo", Order_No);
                //Request_Payload_Cancel_By_Menu.Add("menus", canceledByMenuDetail);

                //MessageBox.Show(Request_Payload_Cancel_By_Menu.ToString(), "Cancel By Menu");
                //Task<IRestResponse> tx2 = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v4/merchant/{Properties.Settings.Default.Owner_No}/menu/block", Method.POST, null, Request_Payload.ToString(), Main_Frm.Special_Headers));
                //tx2.Wait();
                //}

                JObject x = new JObject();
                //x.Add("_t", "TOrderActionReq");
                x.Add("_t", "TOrderCancelReq");
                x.Add("pcName", Properties.Settings.Default._deviceName);
                x.Add("cancelReasonCode", detailInfo); //test
                x.Add("canceledByMenuDetail", Request_Payload_Cancel_By_Menu);
                x.Add("ReqContentType", 5);


                //x.Add("orderNumber", Order_No);
                //x.Add("shopNo", shopNo);
                //x.Add("orderProgressCode", orderProgressCode);
                //x.Add("detailInfo", detailInfo);
                //x.Add("userId", Properties.Settings.Default.User_Name); //x.Add("userId", "jbk9191");


                //MessageBox.Show(x.ToString());
                //Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v5/order/action", Method.POST, null, x.ToString(), Special_Headers));
                Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v7/orders/{Order_No}/cancel", Method.POST, null, x.ToString(), Main_Frm.Special_Headers));
                tx.Wait();

                if (!string.IsNullOrEmpty(tx.Result.Content))
                {
                    JToken response = Helper_Class.Json_Response(tx.Result.Content.ToString());
                    //Ordders_Details_Response rs = JsonConvert.DeserializeObject<Ordders_Details_Response>(tx.Result.Content, Serializer_Settings);

                    if (response["rspCode"].ToString() == "200")
                    {

                        Main_Frm.Invoke(new Action(() =>
                        {
                            ((Form)sender).DialogResult = DialogResult.OK;
                            //    this.timer1.Enabled = false;


                            //    foreach (Button b in In_Progress_Orders.Controls)
                            //    {
                            //        if (b.Text == Order_No)
                            //        {
                            //            MessageBox.Show("will remove");
                            //            //b.BackColor = Color.Green;
                            //            In_Progress_Orders.Controls.Remove(b);
                            //            //break;

                            //        }
                            //    }

                        }));
                        Check_New_Orders();
                        Close_Order_Notification(Order_No);



                    }
                }

                if (Request_Payload_Cancel_By_Menu != null)
                {

                    JObject menu_canceled = new JObject();

                    menu_canceled.Add("_t", "TMerchantMenublockReq");



                    string ignored = JsonConvert.SerializeObject(canceledByMenuDetail, Formatting.Indented,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

#if !Release

                    MessageBox.Show(ignored, "test");
#endif


                    //var filteredData = canceledByMenuDetail.Where(q => q.Value() != (JValue)"name");

                    //MessageBox.Show(filteredData.First().ToString (),"test");

                    //canceledByMenuDetail.All(())

                    JObject r_pa = new JObject();
                    r_pa.Add("storeId", shopNo);
                    r_pa.Add("orderNo", Order_No);
                    //r_pa.Add("menus", canceledByMenuDetail2);

                    r_pa.Add("ReqContentType", 5); //x.Add("ReqContentType", 5);


                    menu_canceled.Add("payload", r_pa);

#if !Release
                    MessageBox.Show(menu_canceled.ToString());
                    MessageBox.Show(Request_Payload_Cancel_By_Menu.ToString(), "will send");
#endif



                    Task<IRestResponse> tx2 = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v4/merchant/{Properties.Settings.Default.Owner_No}/menu/block", Method.POST, null, Request_Payload_Cancel_By_Menu.ToString(), Main_Frm.Special_Headers));
                    tx2.Wait();

                    //Close_Order_Notification(Order_No);
                }

                //MessageBox.Show(tx.Result.Content);
                //if ( !string.IsNullOrEmpty(tx.Result.Content) )
                //{
                //    JToken o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                //    this.Invoke(new Action(() =>
                //    {

                //        if ( o.SelectToken("rspCode").ToString() == "200" ) // SUCCESS
                //        {
                //            this.Order_Details.Controls.Clear();
                //            Check_New_Orders();
                //            foreach ( Form fr in Application.OpenForms )
                //            {
                //                if ( fr.GetType() == typeof(Order_Notification) )
                //                {
                //                    Order_Notification fr1 = (Order_Notification)fr;
                //                    //MessageBox.Show(fr1.orderNo + "-" + o["data"].ToString());
                //                    if ( fr1.orderNo == o["data"].ToString() )
                //                    {
                //                        fr1.Dispose();
                //                    }
                //                    return;
                //                }
                //            }
                //        }
                //        //    foreach (JToken or in o["data"])
                //        //    {
                //        //    }
                //        //}
                //        //else if (o.SelectToken("rspMsg").ToString() != "NO.ORDER")
                //        //{
                //        //    this.timer1.Enabled = false;
                //        //    //MessageBox.Show(this, o.SelectToken("rspMsg").ToString(), o.SelectToken("code").ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        //}
                //    }));
                //}




            }));
            //th.Start();


            //Button se = (Button)sender;
            //MessageBox.Show(se.Parent.Parent.GetType().ToString());
            //if (se.Parent.Parent.GetType() == typeof(Order_Notification))
            //{
            //    ((Order_Notification)se.Parent.Parent).Dispose();
            //}
            //else if (se.Parent.Parent.GetType() == typeof(REJECT_REASON_frm))
            //{
            //    ((REJECT_REASON_frm)se.Parent.Parent).DialogResult = DialogResult.OK;
            //    if (((REJECT_REASON_frm)se.Parent.Parent).Owner.GetType() == typeof(Order_Notification))
            //    {
            //        //MessageBox.Show(((REJECT_REASON_frm)se.Parent.Parent).Owner.GetType().ToString());
            //        ((Order_Notification)((REJECT_REASON_frm)se.Parent.Parent).Owner).Dispose();
            //    }
            //}
            //MessageBox.Show(Order_No, ((Button)sender).Text + "-" + detailInfo + "-" + orderProgressCode);
            //MessageBox.Show("ready");
            //Check_New_Orders();


               //Main_Frm.Invoke(new Action(() =>
                        //{
                        //    ((Form)sender).DialogResult = DialogResult.OK;
                        //    //    this.timer1.Enabled = false;


                        //    //    foreach (Button b in In_Progress_Orders.Controls)
                        //    //    {
                        //    //        if (b.Text == Order_No)
                        //    //        {
                        //    //            MessageBox.Show("will remove");
                        //    //            //b.BackColor = Color.Green;
                        //    //            In_Progress_Orders.Controls.Remove(b);
                        //    //            //break;

                        //    //        }
                        //    //    }

                        //}));



                                  //Order_Details x2 = (Order_Details)Cancel_By_Menu.Tag;
                //JArray j_Order = new JArray();
                //JArray j_Menu = new JArray();
                //foreach (Order_Details.order_item cn in x2.Foods_Menu)
                //{
                //    if (cn.Checked == true)
                //    {
                //        JObject zz = new JObject();
                //        zz.Add("id", cn.ID);
                //        zz.Add("name", cn.name);


                //        JObject zz2 = new JObject();
                //        zz2.Add("id", cn.ID);

                //        if (cn.Options.Count > 0)
                //        {
                //            JArray opp = new JArray();
                //            JArray opp2 = new JArray();
                //            foreach (Order_Details.order_item ch2 in cn.Options)
                //            {
                //                if (ch2.Checked == true)
                //                {
                //                    JObject c = new JObject();
                //                    c.Add("id", ch2.ID);
                //                    c.Add("name", ch2.name);

                //                    c.Add("resetDate", DateTime.Now.ToString("yyyy-MM-dd"));
                //                    opp.Add(c);

                //                    JObject c2 = new JObject();
                //                    c2.Add("id", ch2.ID);

                //                    c2.Add("resetDate", DateTime.Now.ToString("yyyy-MM-dd"));
                //                    opp2.Add(c2);
                //                }
                //            }
                //            zz.Add("options", opp);
                //            zz2.Add("options", opp2);
                //        }
                //        j_Order.Add(zz);
                //        j_Menu.Add(zz2);
                //    }
                //}

#endregion


#region  other
      if (Helper_Class.Is_IP_OK() == false)
            {
                return;
            }

            //timer1.Interval = 10000;

            //Properties.Settings.Default.deviceToken = "BM_PC94890784-6A09-48A7-8FEE-FF4FCEB4CBD0";
            //Properties.Settings.Default.Member_No = "dxvd";
            //Properties.Settings.Default.Owner_No = "dsvd";
            //Properties.Settings.Default.X_Auth = "eyJlbmMiOiJBMTI4Q0JDLUhTMjU2IiwiYWxnIjoiUlNBLU9BRVAtMjU2In0.Fznf2xJCYQIyUUxv9KZmAimISES5fHdzedJXfwbnYPbMoDg-mgNBmLKTtIElKoeDEQZl_jrhrXKdU8e4sjgcu43xw1YGGmr2qIbu0Kcq3Nm7teG2GzTz9EqF1YtpZuYzhS9iAq9O0UGqrdpnPuTcfgdDefa7PC-COYcAVTx55XWWZPC4ebIalEk3HZBXDmaNw_Pkt2AU6WdBnWQBKGmjjIDq872NCf83fMopKvypTZuNDIrpC00GIlIfYC3F_qgKyLeygsE_fpj5uNtNyg4081KwArWoglMxyvpYr1PIlKTRnfC-ectlnAxCSwwEuR6iI69LwYHPyYZgyuN4O3qOEw.ReMvlmQLeMqzXabTnXfFVw.nGDv0_iBxp6gZux4efkWYoB-STHhIEOLsdQuPv9IzG1t7CX3COlvmby2dVtw98Y2hKVi_lX8hAmN4_Bwrpg6KyeMkkINeh4P1idqEwl38RgsMPgDIfYBOYlw_jMIt05p51RYcQQ_38AL4cN1721iBMD75Jc8Qi5UNO1UbaVdvfRwh9Pcf_ZFIdnP6nbT4XLBGXFvliSKDbLdlvfugSfs7Q.Q4PKN1WChQ4Ls-UAIqdWNg";
            //Properties.Settings.Default.X_Refresh = "dcx-799f-4998-9997-b303b6fc3f5e";
            //Properties.Settings.Default.ETag = "W/\"50e-39gjxv+DMQ5+n6UXIxUp037mDbA\"";
            //MessageBox.Show(Properties.Settings.Default.ETag);
            //Properties.Settings.Default.User_Name = "dscds";
            //Properties.Settings.Default.Save();




            //Properties.Settings.Default.deviceToken = "BM_PC94890784-6A09-48A7-8FEE-FF4FCEB4CBD0";
            //Properties.Settings.Default.Member_No = "dsc";
            //Properties.Settings.Default.Owner_No = "dscds";
            //Properties.Settings.Default.X_Auth = ".jAXNKH3kn9p7vA_gdUmFtMjPJ4p-gPFDbUnCr1e1esZK4l_MhE0r_ddO6YY1o4M9RCtYfvXjUp-crzXLogrIj3TJhEMOO_9TK6iVvSG3QZAyfcCMcc5Pm-X-h2e7nDgKnyVTDgZCB41mMywsJc2j8M_0X_hWOvt4dh8z10My79PSVjNCSouuaWNNk1h5SjWsjLCvdtJZ7Ieb1ROhRxbOqc6qeLWiX3jUaQMTXPTT74kh45EtB-TnwqG9dpLnwGfcmL_Ayz5jfzx87Ze2mTEb62ltl7dBMMT5rr7HrOlmxjcf9cU1EefaoGw1tlTxQnpy9fsKS2zJI54yydzfqx8ieg.k8DKFO54nDWNcUU5CnITIA.2OKaIRW0WFX32MI0VtJriog8b2g_iXYJye8VShlZ2CJINVWvHtWv2VhY8fl3e9pS-l0VyT69lbiwV-bo346SD3o3StAJrklr7QZZ8AXbs7dBmbJ8oawmeOSj11eDZLgv1nXCpoXAyTKMI55zKwsSeNybo17aazpsBDqEcnF_DbBgHvGGrs2EAM-DSIHBYRL_0_-XVGRlaWU_YXWmeG_9Ng.XIMFrRjDY1l8qDw36rGVjA";
            //Properties.Settings.Default.X_Refresh = "7c872171-799f-4998-9997-b303b6fc3f5e";
            ////Properties.Settings.Default.ETag = "W/\"50e-39gjxv+DMQ5+n6UXIxUp037mDbA\"";
            //Properties.Settings.Default.ETag = "W/\"50e-NmoQ+lRzfFAOCHmxxaqT6FjQiHA\"";

            //MessageBox.Show(Properties.Settings.Default.ETag);
            //Properties.Settings.Default.User_Name = "dsfc";




            //Properties.Settings.Default.deviceToken = "BM_PC1688304371008";
            //Properties.Settings.Default.Member_No = "dscvd";
            //Properties.Settings.Default.Owner_No = "dscd";
            //Properties.Settings.Default.User_Name = "dsfcd";


            //Properties.Settings.Default.X_Auth = "dsd.a7kwMgD5L4HeafKkZ8sDB0C5tVc75FMYFiByGg5egyZCD-l3f3m2IXY9nInntYGsCQ0k1eujl320k80Fh1BKYIH_wExq3QCZuSZZ3Gn4mERqXBpB21RyHHnKnPhAREY8TMR-FWvJho3M-EO_bmqVZtAt7RLL2Vt6g1E2oVUNK7gqtGD2D54tkY6qIao_O7lJAxnaS0yhOLqtipe6_W7YSYXS8iMRjfWpnx1HM6lMen7K28tlQy4UxXOODOpsM_LP-Kg1jc814CfTttDqV5fUj-qtBDQ1E05Bip5_SWtQuFuL5eZy8Jh_PHtXMkdDitrOHFY2PeOYNd373BkpNq62TA.WANBEBI6OAbFaaTI2SKcLg.bgQKzimYX-J6yQlYCbZ19u1nWZOGj2mMm2_ve_yuuEzERSbdy_uAwbWKt5LtREd6E2XDy4Q2kNnaVjLRBQUWC7fultGoWVDlU4YKL-uhtv7bdqZ0l2pz62EWqBEtm7Dukn18YEFVgh3mVlqMqAyWIzkoJwELudSrlHv86AFTNCprwuwWNCD3vZCSps6dTcqh9DQjulPmOL5f4GQ9mjkIPA.c2Wvtxe3aZ669imejHkDBA";
            //Properties.Settings.Default.X_Refresh = "6fc57446-cb5b-4d9c-8436-51f65a5e7b7a";
            //Properties.Settings.Default.ETag = "W/\"4b-N5eh32jaaoTqhlWos/MSAbkxmh8\"";

            //Properties.Settings.Default.Save();


            //Properties.Settings.Default.deviceToken = "";
            //Properties.Settings.Default.Member_No = "";
            //Properties.Settings.Default.Owner_No = "";
            //Properties.Settings.Default.X_Auth = "";
            //Properties.Settings.Default.X_Refresh = "";
            //Properties.Settings.Default.ETag = "";
            //Properties.Settings.Default.User_Name = "";

            //Properties.Settings.Default.Save();
#endregion