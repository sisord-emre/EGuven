using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class ResultJson
    {
        public string status { get; set; }
        public string message { get; set; }
        public string data { get; set; }
        public string serialize()
        {
            return JsonConvert.SerializeObject(new Dictionary<string, object>(){
                {"status", status},
                {"message", message},
                {"data", data},
            });
        }
        public Dictionary<string, object> deserialize()
        {
            return new Dictionary<string, object>(){
                {"status", status},
                {"message", message},
                {"data", data},
            };
        }
        /* Kullanım Örneği;
        ResultJson result = JsonConvert.DeserializeObject<ResultJson>("{'status':'success','message':'tmassge','data':'tdata'}");
        Debug.WriteLine(result.message);

        ResultJson resultJson = new ResultJson();
        resultJson.status = "success";
        resultJson.message = "Fatura Listesi";
        resultJson.data = "Fatura Listesi";
        Debug.WriteLine(resultJson.getArray()["message"]); 
        
        JArray array= JsonConvert.DeserializeObject<JArray>(result.data);
        foreach (var item in array)
        {
            Debug.WriteLine(item["installSourceNo"]);
            InstallSourceInvoiceDetail(item["installSourceNo"].ToString());
        }
        */
    }
}
