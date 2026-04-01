using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using XoshBank.Entities;
using XoshBankCore.Entities.Repositories;

public class MsSqlCardRepository : ICardRepository
{
    private readonly string _connectionString;

    public MsSqlCardRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Card> GetAll()
    {
        return new List<Card>();
    }

    public Card GetById(int id)
    {
        return null;
    }

    public void Insert(Card entity)
    {
    }

    public void Update(Card entity)
    {
    }

    public void Delete(int id)
    {
    }

    public List<Card> GetCardsByAccountId(int accountId)
    {
        return new List<Card>();
    }
}


