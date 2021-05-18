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
        protected void Page_Load(object sender, EventArgs e)
        {
            myDb = new DB();
            id = Request.QueryString.Get("ShoeInfo");
            Dictionary<string, string> info = myDb.getData(id);
            ShoeName.Text = info["name"];
            ShoeDesc.Text = info["description"];
            ShoeImage.ImageUrl = "../images/Products/" + info["image"];
        }

        protected void AddCart_Click(object sender, EventArgs e)
        {
            if (myDb.addToCart(id))
                CartMsg.Text = "Added to Cart successfully";
        }
    }
}