using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceAutomation.Model
{
    public class RestResponse
    {
        private int _statusCode;
        private string _responseData;
        public RestResponse(int _statusCode, string _responseData)
        {
            this._statusCode = _statusCode;
            this._responseData = _responseData;

        }
        public int StatusCode
        {
            get
            {
                return _statusCode;
            }
            
        }
        public string ResponseData
        {
            get
            {
                return _responseData;
            }

        }
        public override string ToString()
        {
            return String.Format("StatusCode : {0} ResponseData :{1}", _statusCode, _responseData);

        }
    }
}
