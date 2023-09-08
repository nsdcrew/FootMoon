using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using Web;
using Web.Pages;

[IgnoreAntiforgeryToken]
public class WebhookModel : PageModel
{

    private readonly ILogger<IndexModel> _logger;
    public AppDbContext _dbContext { get; set; }

    public WebhookModel(ILogger<IndexModel> logger, AppDbContext dbCOntext)
    {
        _logger = logger;
        _dbContext = dbCOntext;
    }

    public void OnGet()
    {

    }


    public async void OnPost()
    {
        using (StreamReader reader = new StreamReader(Request.Body))
        {
            string requestBody = await reader.ReadToEndAsync();
            var webhookData = JsonConvert.DeserializeObject<WebhookData>(requestBody);

            // Handle the purchase event
            //if (webhookData?.type == "purchase.created")
            //{
            //    // Map DTO to entity classes (you may use AutoMapper for this)
            //    var entityData = MapToEntity(webhookData);

            //    // Save the webhook data to the database

            //    //_dbContext.VimeoWebhookDatas.Add(entityData);

            //    // You can also handle related entities here if needed
            //    // For example: _dbContext.VimeoWebhookVideo.Add(entityData.Video);
            //    //             _dbContext.VimeoWebhookUser.Add(entityData.User);

            //    // Save changes to the database
            //    _dbContext.SaveChanges();
            //}


        }

         // Respond with an empty result to acknowledge receipt of the webhook
    }

    // Helper method to map DTO to entity classes
  
}

// Define the same classes for webhook data as in the previous examples


public class Customer
{
    public Links links { get; set; }
    public Embedded embedded { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string thumbnail { get; set; }
    public Location location { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string plan { get; set; }
    public string platform { get; set; }
}

public class Links
{
    public string events { get; set; }
    public string self { get; set; }
    public string watching { get; set; }
    public string watchlist { get; set; }
}

public class Embedded
{
    public List<Product> products { get; set; }
}

public class Product
{
    public Links links { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public Price price { get; set; }
    public bool is_active { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public List<string> types { get; set; }
}

public class Price
{
    public int cents { get; set; }
    public string currency { get; set; }
    public string formatted { get; set; }
}

public class Location
{
    public string city { get; set; }
    public string region { get; set; }
    public string country { get; set; }
}

public class WebhookData
{
    public string topic { get; set; }
    public DateTime created_at { get; set; }
    public Embedded embedded { get; set; }
}