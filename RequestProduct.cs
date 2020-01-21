using System;
using System.Collections.Generic;
using System.Text;
using static AutomationAssessment2.Constants;

namespace AutomationAssessment2
{
    class RequestProduct
    {

        public async void SendRequestProduct()
        {

            ProductModel productapi = new ProductModel
            {
                name = product,
                description = "Tshit ",
                regular_price = price,
                short_description = "TS",
                type = "Simple"
            };

            Response<object> response;
            APIService api = new APIService();

            response = await api.PostAsync("http://34.205.174.166/wp-json/wc/v3/products", productapi);
        }
    }
}
