﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASender
{
    public static class XPathStore
    {
        public static string GMap_Result = "//div[contains(@jsname,'GZq3Ke')]";
        public static string GMap_Heading = "//h2[contains(@data-attrid,'title')]";
        public static string GMap_MobileNumber = "//a[contains(@data-dtype,'d3ph')]";
        //public static string GMap_MobileNumber = "//*[@data-tooltip='Copiar número de telefone'] ";
        public static string GMap_MobileNumberSecond="//*[@id=\"QA0Szd\"]/div/div/div[1]/div[3]/div/div[1]/div/div/div[2]/div[7]/div[4]/button/div[1]/div[2]/div[1]";
        //public static string GMap_Address = "//*[@data-item-id='address' and (self::div or self::button)] | //span[@class='section-info-icon']/img[contains(@src,'/place_gm')]/ancestor::div[1] | //img[contains(@src,'/place_gm')]/ancestor::*[contains(@class,'button')][1]";
        public static string GMap_Address = "//span[@class='LrzXr']";
        //public static string GMap_WebSite = "//*[@data-item-id='authority' and (self::div or self::button or self::a)] |  //span[@class='section-info-icon']/img[contains(@src,'/public_')]/ancestor::div[1] | //img[contains(@src,'/public_')]/ancestor::*[contains(@class,'button')][0]";
        public static string GMap_WebSite = "//a[@class='CL9Uqc']";
        public static string GMap_PlusCode = "//*[@data-item-id='oloc' and (self::div or self::button)] | //span[contains(@class,'plus-code')]/../.. | //img[contains(@src,'plus_code')]/ancestor::*[contains(@class,'button')][1]";
        //public static string GMap_Rating = "//div[@jsaction='pane.rating.moreReviews']/span/span";
        public static string GMap_Rating = "//span[@class='Aq14fc']";
        //public static string GMap_ReviewCount = "//button[@jsaction='pane.reviewChart.moreReviews']";
        public static string GMap_ReviewCount = "//span[@class='z5jxId']";
        public static string GMap_Catagory = "//button[@jsaction='pane.rating.category']";
        public static string GMap_NextButton = "//a[@id='pnnext']";



    }
}
