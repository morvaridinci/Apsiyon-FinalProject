﻿using CreditCardService.Configuretion;
using CreditCardService.Models.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardService.Services
{
    public class CreditCardService
    {
        IMongoCollection<CreditCard> _creditCardCollection;
        MongoDbConfiguration _config;
        public CreditCardService(IOptions<MongoDbConfiguration> config)
        {
            _config = config.Value;
            MongoClient mongoClient = new MongoClient(_config.ConnectionString);
            var database = mongoClient.GetDatabase(_config.Database);
            _creditCardCollection = database.GetCollection<CreditCard>("CreditCard");

        }

        public async Task<bool> WithdrawMoney(CreditCard creditCard, int money)
        {
            try
            {

            var current = await _creditCardCollection.Find(x => x.CardNumber == creditCard.CardNumber)
                  .FirstOrDefaultAsync(); 
                if (current != null && current.Balance >= money)
            {

                current.Balance -= money;

                await _creditCardCollection.ReplaceOneAsync(x => x.Id == current.Id, current);

                return true;
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


           

            return false;
        }
    }
}
