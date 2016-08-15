using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HZ
{ 
    class API
    {
       public static string URL = "http://59.127.14.4:8080";


        public class employee
        {
            public int employee_Id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public int pay { get; set; }
            public int overtimePay { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
        }

        public class pay
        {
            public int pay_Id { get; set; }
            public int employee_Id { get; set; }
            public string date { get; set; }
            public int money { get; set; }
        }
        public class detailPay
        {
            public int detailPay_Id { get; set; }
            public int pay_Id { get; set; }
            public int timeSegment { get; set; }
            public int time { get; set; }
            public int bid_Id { get; set; }
            public int money { get; set; }
        }

       

        public class bid
        {
            public int bid_Id { get; set; }
            public string bidName { get; set; }
            public string bidAbbreviation { get; set; }
            public int bidMoney { get; set; }
            public int bidBond { get; set; }
            public string  bidStartDate{ get; set; }
            public string bidEndDate { get; set; }
            public bool bidType { get; set; }
        }


        public static bid getBid(int bid_Id)
        {
            string api = getApi((int)ENUM.API_t.API_GET_BID_ONE)+ bid_Id.ToString();

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(api);
            bid bid = null;
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Timeout = 10000;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                bid = (bid)JsonConvert.DeserializeObject(result, typeof(bid));
            }

            return bid;

        }

        public static pay getPayData(int pay_Id)
        {

            string api = getApi((int)ENUM.API_t.API_GET_PAY_DATA) + pay_Id;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(api);
            pay tempPay = null;
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Timeout = 10000;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                tempPay = (pay)JsonConvert.DeserializeObject(result, typeof(pay));
            }
            return tempPay;
        }

        public static List<bid> getBidAll(int type)
        {
            string api = getApi((int)ENUM.API_t.API_GET_BID) + type.ToString();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(api);
            List<bid> bidList = null;
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Timeout = 10000;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                bidList = (List<bid>)JsonConvert.DeserializeObject(result, typeof(List<bid>));
            }

            return bidList;
        }

        public static List<detailPay> getDetailPay(int pay_Id)
        {
            string api = getApi((int)ENUM.API_t.API_GET_DETAILPAY) + pay_Id.ToString();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(api);
            List<detailPay> detailPayList = null;
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";

            httpWebRequest.Timeout = 10000;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                var result = streamReader.ReadToEnd();

                detailPayList = (List<detailPay>)JsonConvert.DeserializeObject(result, typeof(List<detailPay>));
            }

            httpResponse.Close();

            return detailPayList;
        }


        public static List<pay> getPay(int employee_Id)
        {
            string api = getApi((int)ENUM.API_t.API_GET_PAY) + employee_Id.ToString();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(api);
            List<pay> payList = null;
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";

            httpWebRequest.Timeout = 10000;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                var result = streamReader.ReadToEnd();

                payList = (List<pay>)JsonConvert.DeserializeObject(result, typeof(List<pay>));
            }

            httpResponse.Close();

            return payList;
        }


        public static List<employee> getEmployee()
        {

            string api = getApi((int)ENUM.API_t.API_GET_EMPLOYEE);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(api);
            List<employee> employeeList = null;
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";

            httpWebRequest.Timeout = 10000;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                var result = streamReader.ReadToEnd();

                employeeList = (List<employee>)JsonConvert.DeserializeObject(result, typeof(List<employee>));
            }

            httpResponse.Close();

            return employeeList;
        }
        public static employee getEmployee(int employee_Id)
        {
            string api = getApi((int)ENUM.API_t.API_GET_EMPLOYEE) + employee_Id.ToString();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(api);
            employee employee = null;
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";

            httpWebRequest.Timeout = 10000;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                var result = streamReader.ReadToEnd();

                employee = (employee)JsonConvert.DeserializeObject(result, typeof(employee));
            }

            httpResponse.Close();

            return employee;
        }
        
        public static int checkLink()
        {
            try
            {
                string linkApi = getApi((int)ENUM.API_t.API_CHECK_LINK);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(linkApi);
                string result = null;
                httpWebRequest.Method = "GET";
                httpWebRequest.Accept = "application/json";

                httpWebRequest.Timeout = 10000;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                httpResponse.Close();
                if (result == "success")
                {
                    return 1;
                }
              
            }
            catch
            {

                    return -1;

            }
            return 1;

        }

        


        public static string  getApi(int api)
        {
            string getUrl = null ;

            switch (api)
            {
                case (int)ENUM.API_t.API_CHECK_LINK:
                    getUrl = URL + "/api/checkLink";
                    break;

                case (int)ENUM.API_t.API_NEW_EMPLOYEE:

                    getUrl = URL + "/api/employee/new";
                    break;

                case (int)ENUM.API_t.API_GET_EMPLOYEE:
                    getUrl = URL + "/api/employee/";
                    break;

                case (int)ENUM.API_t.API_UPDATE_EMPLOYEE:
                    getUrl = URL + "/api/employee/update";
                    break;

                case (int)ENUM.API_t.API_DElETE_EMPLOYEE:
                    getUrl = URL + "/api/employee/delete";
                    break;

                case (int)ENUM.API_t.API_NEW_BID:
                    getUrl = URL + "/api/bid/new";
                    break;
                case (int)ENUM.API_t.API_GET_BID_ONE:
                    getUrl = URL + "/api/bid/one/";
                    break;

                case (int)ENUM.API_t.API_GET_BID:
                    getUrl = URL + "/api/bid/name/";
                    break;               
                case (int)ENUM.API_t.API_NEW_PAY:
                    getUrl = URL + "/api/pay/insert";
                    break;
                case (int)ENUM.API_t.API_GET_PAY:
                    getUrl = URL + "/api/pay/";
                    break;
                case (int)ENUM.API_t.API_GET_DETAILPAY:
                    getUrl = URL + "/api/pay/detail/";
                    break;
                case (int)ENUM.API_t.API_POST_BILLING:
                    getUrl = URL + "/api/pay/billing";
                    break;
                case (int)ENUM.API_t.API_BID_EDIT:
                    getUrl = URL + "/api/bid/edit";
                    break;
                case (int)ENUM.API_t.API_BID_DELETE:
                    getUrl = URL + "/api/bid/delete";
                    break;
                case (int)ENUM.API_t.API_GET_PAY_DATA:
                    getUrl = URL + "/api/pay/getPayData/";
                    break;
                case (int)ENUM.API_t.API_PAY_UPDATE:
                    getUrl = URL + "/api/pay/updatePay";
                    break;
                case (int)ENUM.API_t.API_PAY_DELETE:
                    getUrl = URL + "/api/pay/deletePay";
                    break;

            }
            return getUrl;

        }
    }

}
