﻿using Newtonsoft.Json;
using WealthApi.Core.Enums;

namespace WealthApi.Core
{
    public abstract class Transaction
    {
        [JsonProperty("value")]
        public int Value { get; set; }


        protected Transaction()
        {

        }

        protected Transaction(int value)
        {
            Value = value;
        }
    }

    public abstract class Spending : Transaction
    {
        [JsonProperty("type")]
        public abstract SpendingType Type { get; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonConstructor]
        protected Spending(int value, string description, Category category) : base(value)
        {
            Description = description;
            Category = category;
        }
    }

    public class SpendingFactory
    {
        public Spending Create(AccountSpendingDTO spendingDTO)
        {
             return spendingDTO.Type == SpendingType.SINGLE
                ? new SingleSpending(spendingDTO.Value, spendingDTO.Description, spendingDTO.Category, spendingDTO.Date)
                : new ConstantSpending(spendingDTO.Value, spendingDTO.Description, spendingDTO.Category, spendingDTO.Frequence);
        }
    }

    public class Earning : Transaction
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        public Earning()
        {

        }

        protected Earning(int value, string name) : base(value)
        {
            Name = name;
        }
    }

    public class SingleEarning : Earning
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        public SingleEarning() { }

        public SingleEarning(int value, string name, string date) : base(value, name)
        {
            Date = date;
        }
    }

    public class Goal : Transaction
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("deadline")]
        public string Deadline { get; set; }

        [JsonConstructor]
        public Goal(int value, string name, Priority priority, string deadline) : base(value)
        {
            Name = name;
            Priority = priority;
            Deadline = deadline;
        }
    }

    public class SingleSpending : Spending
    {
        public override SpendingType Type => SpendingType.SINGLE;

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonConstructor]
        public SingleSpending(int value, string description, Category category, string date) : base(value, description, category)
        {
            Date = date;
        }
    }

    public class ConstantSpending : Spending
    {
        public override SpendingType Type => SpendingType.CONSTANT;

        [JsonProperty("frequence")]
        public Frequence Frequence { get; set; }

        [JsonConstructor]
        public ConstantSpending(int value, string description, Category category, Frequence frequence) : base(value, description, category)
        {
            Frequence = frequence;
        }
    }
}
