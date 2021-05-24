using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoesProject.Forms
{
    public partial class ShoesInfo : System.Web.UI.Page
    {
        DB myDb;
        string id;

        /*
         *  When the page is loaded, the page connects to the DB class. The method checks for the current Shoe given in the query string. The Shoe id is passed to the myDb.getData method to get the name, description and image of the current shoe. This information is then displayed onto the page.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            myDb = new DB();
            id = Request.QueryString.Get("ShoeInfo");
            Dictionary<string, string> info = myDb.getData(id);
            ShoeName.Text = info["name"];
            ShoeDesc.Text = info["description"];
            ShoeImage.ImageUrl = "../images/Products/" + info["image"];
        }

        /*
         * This method runs whenever a user decides to add the current shoe to their shopping cart. It calls the addToCart method for myDb. If it is successful it displays a message saying that it was added successfully.
         * 
         */
        protected void AddCart_Click(object sender, EventArgs e)
        {
            if (myDb.addToCart(id))
                CartMsg.Text = "Added to Cart successfully";
        }
    }
}