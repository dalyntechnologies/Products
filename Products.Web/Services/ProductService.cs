using Microsoft.Extensions.Configuration;
using Products.Web.Responses;
using Products.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Products.Web.Models;
using System;

namespace Products.Web.Services
{
    public class ProductService :IProductService
    {

        private IHelperService _helperService;
        public ProductService(IHelperService helperService)
        {
            _helperService= helperService;
        }

        public async Task<(bool,string)> AddProductAsync(ProductViewModel product)
        {
            try
            {
                using(var client=new HttpClient())
                {

                   
                    
                    var json = JsonConvert.SerializeObject(product);
                    HttpContent content = new StringContent(json);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await client.PostAsync($"{_helperService.GetBaseUrl()}/v1/api/products/product", content);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    var view = data;
                    return (true,"success");

                }
            }
            catch(Exception ex)
            {
                return (false, "fail");
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    {

                        var response = await client.DeleteAsync($"{_helperService.GetBaseUrl()}/v1/api/products/product/{id}");
                        response.EnsureSuccessStatusCode();
                        var result = await response.Content.ReadAsStringAsync();                      
                        return true;
                    }

                }

            }
            catch
            {
                return false;
            }
        }

        public async Task<ProductResponse> GetProductAsync(int id)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    {

                        var response = await client.GetAsync($"{_helperService.GetBaseUrl()}/v1/api/products/product/{id}");
                        response.EnsureSuccessStatusCode();
                        var result = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<ProductResponse>(result);
                        return product;
                    }

                }

            }
            catch
            {
                return null;
            }
        }

        public async Task<List<ProductResponse>> GetProductsAsync()
        {
            try
            {
               
               using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    {

                        var response = await client.GetAsync($"{_helperService.GetBaseUrl()}/v1/api/products/product");
                        response.EnsureSuccessStatusCode();
                        var result=await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<List<ProductResponse>>(result);
                        return products;
                    }

                }

            }
            catch
            {
                return null;
            }
        }

        public async Task<(bool, string)> UpdateProductAsync(ProductViewModel product)
        {
            try
            {
                using (var client = new HttpClient())
                {



                    var json = JsonConvert.SerializeObject(product);
                    HttpContent content = new StringContent(json);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await client.PutAsync($"{_helperService.GetBaseUrl()}/v1/api/products/product/{product.Id}", content);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    var view = data;
                    return (true, "success");

                }
            }
            catch (Exception ex)
            {
                return (false, "fail");
            }
        }
    }
}
