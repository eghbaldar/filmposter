using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Common.BankGetway.Sepal
{
    public abstract class Keys
    {
        public const bool switcher = true; // {true}: ON SERVER {false}: ON LOCALHOST

        // on server
        public const string server_apiUrl = "https://sepal.ir/api/request.json";
        public const string server_merchant = "041bf0bdb4a55ffc3b711fc54eb18b39"; // webservice key
        public const string server_verifyLink = "https://sepal.ir/api/verify.json"; // verficiation link

        // on localhost
        public const string localhost_apiUrl = "https://sepal.ir/api/sandbox/request.json";
        public const string localhost_merchant = "test"; // webservice key
        public const string localhost_verifyLink = "https://sepal.ir/api/sandbox/verify.json"; // verficiation link

        // NOTE: if you are goint to channge localhost to server vice versa
        // you have to change the payment link in: userTempalte/..../PrePayment.js        
        //window.location.href = `https://sepal.ir/sandbox/payment/${resultBank.paymentNumber}`;
        //window.location.href = `https://sepal.ir/payment/${resultBank.paymentNumber}`;
    }
}
