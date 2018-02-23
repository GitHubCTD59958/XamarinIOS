using System;

//Libraries that we'll use 
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;
using UIKit;

namespace App
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //In this line we set our Server in which mongo is 
            var client = new MongoClient("mongodb://192.168.0.253:27017");
            //Here we're getting the database named books 
            IMongoDatabase db = client.GetDatabase("books");
            //Then we've set our collection name 
            var Coll = db.GetCollection<BsonDocument>("book");
            //Our Delegate 
            BtnInsert.TouchUpInside += delegate {
                if (txtName.Text != "" & txtLastName.Text != "" & txtseCondLastName.Text != "")
                {
                    var Documnt = new BsonDocument
            {
                        { "name",txtName.Text },
                        { "Apellido",txtLastName.Text },
                        { "ApelidoM",txtseCondLastName.Text }
            };

                    Coll.InsertOne(Documnt);
                    var okAlertController = UIAlertController.Create("DONE", "You've Inserted", UIAlertControllerStyle.Alert);

                    //Add Action
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                    // Present Alert
                    PresentViewController(okAlertController, true, null);
                    txtName.Text = 
                    txtLastName.Text = 
                    txtseCondLastName.Text = "";

                }
            };

            //TODO: We have to Make an API in which we'll do this process.
             
        }
    }
}
